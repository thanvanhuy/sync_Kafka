using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using Newtonsoft.Json;
using ProcessXML;

namespace sync_Kafka
{
    public partial class Form1 : Form
    {
        private ProcessXML.ProcessXML configXML;
        public connectSQL conn;
        tblXeVao xe;
        private string SVR;
        private string User;
        private string Pass;
        private string Catalog;

        private string Img;
        private string ImgPlate;
        private int TimeETC;
        private int TImeMTC;
        private Boolean AutoRun;


        private string Host;
        private string TopicETC;
        private string TopicMTC;
        private string Host1;
        private string TopicETC1;
        private string TopicMTC1;
        private string Host2;
        private string TopicETC2;
        private string TopicMTC2;
        string RunSVR;
        public Boolean flagConnect = false;
        public Boolean flagStop = false;
        public DateTime timeSendETC = DateTime.Now.AddSeconds(30);
        public DateTime timeSendMTC = DateTime.Now.AddSeconds(60);
        public Boolean flagETC = false;
        public Boolean flagMTC = false;

        public Boolean flagSendResual = false;
        private delegate void strsetList(string str, ListBox control);
        private delegate void strDeledate(string str, Control control);
        Thread readETC;
        Thread readMTC;
        Thread sendMessageMTC;
        Thread sendMessageETC;

        private Uri uri;
        private KafkaOptions options;
        private BrokerRouter router;
        private Producer client;
        private void SetStrvalue(string str, Control control)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new strDeledate(SetStrvalue), str, control);
                return;
            }

            control.Text = str;
        }

        private void SetStrLisbox(string str, ListBox control)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new strsetList(SetStrLisbox), str, control);
                return;
            }

            if (control.Items.Count > 50)
                control.Items.Clear();
            control.Items.Add(str);
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            configXML = new ProcessXML.ProcessXML("Config.xml");
            SVR = configXML.XmlNodeValue("Server", "SQL", "");
            Catalog = configXML.XmlNodeValue("DatabaseServer", "SQL", "");
            User = configXML.XmlNodeValue("UserServer", "SQL", "");
            Pass = configXML.XmlNodeValue("PasswordServer", "SQL", "");

            Img = configXML.XmlNodeValue("PathImg", "General", "");
            ImgPlate = configXML.XmlNodeValue("PathImgPlate", "General", "");
            TimeETC = int.Parse(configXML.XmlNodeValue("SendETC", "General", ""));
            TImeMTC = int.Parse(configXML.XmlNodeValue("SendMTC", "General", ""));
            AutoRun = configXML.XmlNodeValue("AutoRun", "General", "") == "0" ? false : true;

            Host1 = configXML.XmlNodeValue("Host1", "Kafka", "");
            TopicETC1 = configXML.XmlNodeValue("TopicEtc1", "Kafka", "");
            TopicMTC1 = configXML.XmlNodeValue("TopicMtc1", "Kafka", "");

            Host2 = configXML.XmlNodeValue("Host2", "Kafka", "");
            TopicETC2 = configXML.XmlNodeValue("TopicEtc2", "Kafka", "");
            TopicMTC2 = configXML.XmlNodeValue("TopicMtc2", "Kafka", "");
            RunSVR = configXML.XmlNodeValue("RunSVR", "Kafka", "");
            Encryption.Encryption.Decode("ITVVA", ref User, User);
            Encryption.Encryption.Decode("ITVVA", ref Pass, Pass);

            Host = RunSVR == "1" ? Host1 : Host2;
            TopicETC = RunSVR == "1" ? TopicETC1 : TopicETC2;
            TopicMTC = RunSVR == "1" ? TopicMTC1 : TopicMTC2;
            txturl.Text = Host;
            txtTopicETC.Text = TopicETC;
            txtTopicMTC.Text = TopicMTC;

            SetStrvalue(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), lblTimeStart);
            flagConnect = checkConnect();
            button3.Enabled = false;
            button2.Enabled = false;
            if (flagConnect)
            {
                if (AutoRun)
                {
                    flagStop = false;
                    btnRun_Click(null, null);
                }

            }
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            uri = new Uri(txturl.Text);
            options = new KafkaOptions(uri);
            router = new BrokerRouter(options);
            client = new Producer(router);
            xe = new tblXeVao();
            timeSendETC = DateTime.Now.AddSeconds(30);
            timeSendMTC = DateTime.Now.AddSeconds(60);
            SetStrvalue(timeSendETC.ToString("HH:mm:ss"), label3);
            SetStrvalue(timeSendMTC.ToString("HH:mm:ss"), label4);
            btnRun.Enabled = false;
            button3.Enabled = true;
            button2.Enabled = true;
            btnStop.Enabled = true;
        }
        private Boolean checkConnect()
        {
            conn = new connectSQL();
            conn.Server = SVR;
            conn.Catalog = Catalog;
            conn.Username = User;
            conn.Password = Pass;
            if (!conn.testConnect())
            {
                SetStrvalue("Connect failure", lblSQL);
                return false;
            }
            else
            {
                SetStrvalue("", lblSQL);
                return true;
            }
        }
        public void SendDataETC()
        {
            //if (flagETC)
            //    return;
            //flagETC = true;
            DataTable dt = xe.getDataETC(conn);

            List<clsSyncData> lst = new List<clsSyncData>();
            for (int a = 0; a < dt.Rows.Count; a++)
            {
                if (xe.getRow(dt.Rows[a]))
                {
                    clsSyncData D = new clsSyncData();
                    D.Transaction_Type = (xe.LoaiLan == "01" ? 1 : 2);
                    D.Transaction_ID = xe.TransId;
                    D.Transaction_Date = xe.NgayQuaTram.ToString("dd/MM/yyyy HH:mm:ss");
                    D.Ticket_ID = xe.TicketID;
                    D.EPC = xe.MaThe;
                    D.TID = "";
                    D.Station = 1730;// mã trạm Phố LU
                    D.Lane = xe.LanXe;
                    D.Plate = xe.BienSoCabin;
                    D.Work_Shift = xe.CaTruc;
                    D.Staff_name = xe.TenNV;
                    D.Vehicle_Image = clsHepls.getImage(clsHepls.pathImg, xe.TenHinhXeCaBin); // đường dẫn hình đã cấu hình sẵn trên SVR 2
                    D.Plate_Image = clsHepls.getImage(clsHepls.pathImgPlate, xe.TenHinhNDCabin);// đường dẫn hình đã cấu hình sẵn trên SVR 2
                    D.Process_Type = (int)clsHepls.getPorcessType(xe);
                    D.Ticket_Type = clsHepls.getLoaive(xe);
                    D.Plate_BE = xe.BienSoETC;
                    D.Vehicle_Type = xe.PhanLoaiXe;
                    D.Plate_Type = clsHepls.getTrangThaiNhanDang(xe.BienSoCabin, xe.BienSoETC);
                    D.Price = xe.PTTT == 1 ? xe.Phi : 0;
                    D.Enter_Transaction_ID = xe.TransId;
                    D.Enter_Station_Id = xe.MaTramVao;
                    D.Enter_Lane_Id = 0;
                    D.Enter_Transaction_Date = "";
                    D.Enter_EPC = "";
                    D.Enter_TID = "";
                    D.Enter_Vehicle_Image = "";
                    D.Enter_Plate_Image = "";
                    D.Enter_Plate = "";
                    D.Enter_Plate_BE = "";
                    D.Enter_Staff_Name = "";
                    lst.Add(D);
                }
            }

            string jsonContent = JsonConvert.SerializeObject(lst);
            if (lst.Count > 0)
            {
                flagSendResual = true;

                KafkaNet.Protocol.Message msg = new KafkaNet.Protocol.Message(jsonContent);
                SetStrLisbox(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Send ETC -> " + lst.Count(), listBox1);
                if (client.SendMessageAsync(TopicETC, new List<KafkaNet.Protocol.Message> { msg }).Wait(5000))
                {
                    SetStrLisbox(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Send OK -> " + lst.Count(), listBox1);

                    //chuyển thành công xóa dữ liệu 
                    xe.DeleteETCSync(conn, lst);
                    SetStrLisbox(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss" + " ETC -> " + lst.Count()), listBox2);
                }
                else
                {
                    SetStrLisbox(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - Send NotOK-> " + lst.Count(), listBox1);
                }

            }
        }
        public void SendDataMTC()
        {
            //if (flagMTC)
            //    return;
            //flagMTC = true;
            tblXeVao xe = new tblXeVao();
            DataTable dt = xe.getDataETC(conn);

            List<clsSyncMTC> lst = new List<clsSyncMTC>();
            for (int a = 0; a < dt.Rows.Count; a++)
            {
                if (xe.getRow(dt.Rows[a]))
                {
                    clsSyncMTC D = new clsSyncMTC();
                    D.Transaction_Type = (xe.LoaiLan == "01" ? 1 : 2);
                    D.Transaction_ID = xe.TransId;
                    D.Transaction_Date = xe.NgayQuaTram.ToString("dd/MM/yyyy HH:mm:ss");
                    D.Serial = "";
                    D.Station = 1730;// mã trạm Phố LU
                    D.Lane = xe.LanXe;
                    D.Plate = xe.BienSoCabin;
                    D.Work_Shift = xe.CaTruc;
                    D.Staff_name = xe.TenNV;
                    D.Vehicle_Image = clsHepls.getImage(clsHepls.pathImg, xe.TenHinhXeCaBin); // đường dẫn hình đã cấu hình sẵn trên SVR 2
                    D.Plate_Image = clsHepls.getImage(clsHepls.pathImgPlate, xe.TenHinhNDCabin);// đường dẫn hình đã cấu hình sẵn trên SVR 2
                    D.Process_Type = (int)clsHepls.getPorcessType(xe);
                    D.Ticket_Type = clsHepls.getLoaive(xe);
                    D.Vehicle_Type = xe.PhanLoaiXe;
                    D.Plate_Type = clsHepls.getTrangThaiNhanDang(xe.BienSoCabin, xe.BienSoETC);
                    D.Price = xe.PTTT == 1 ? xe.Phi : 0;
                    D.Enter_Transaction_ID = xe.TransId;
                    D.Enter_Station_Id = xe.MaTramVao;
                    D.Enter_Lane_Id = 0;
                    D.Enter_Transaction_Date = "";
                    D.Enter_Serial = "";
                    D.Enter_Vehicle_Image = "";
                    D.Enter_Plate_Image = "";
                    D.Enter_Plate = "";
                    D.Enter_Staff_Name = "";
                    lst.Add(D);
                }
            }


            string jsonContent = JsonConvert.SerializeObject(lst);
            if (lst.Count > 0)
            {
                flagSendResual = true;
                KafkaNet.Protocol.Message msg = new KafkaNet.Protocol.Message(jsonContent);

                SetStrLisbox(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " Send  MTC -> " + lst.Count(), listBox3);
                if (client.SendMessageAsync(TopicMTC, new List<KafkaNet.Protocol.Message> { msg }).Wait(5000))
                {
                    SetStrLisbox(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " Send OK  MTC -> " + lst.Count(), listBox3);

                    // chuyển thanh công xóa dữ liệu
                    xe.DeleteMTCSync(conn, lst);
                    SetStrLisbox(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " MTC -> " + lst.Count(), listBox4);
                }
                else
                {
                    SetStrLisbox(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " Send NOTOK  MTC -> " + lst.Count(), listBox3);
                }

            }
        }
        public void ReadMessageKafkaETC()
        {
            string topic = TopicETC;
            Uri uri = new Uri(Host);
            var options = new KafkaOptions(uri);
            var router = new BrokerRouter(options);
            var consumer = new Consumer(new ConsumerOptions(topic, router));
            int stt = 0;
            foreach (var message in consumer.Consume())
            {
                if (message.Key != null)
                {
                    if (!flagSendResual)
                        continue;
                    var strjson = Encoding.UTF8.GetString(message.Value);
                    var strkey = Encoding.UTF8.GetString(message.Key);
                    if (strkey == "ETC")
                    {
                        if (clsHepls.IsValidJson(strjson))
                        {
                            List<clsSyncData> lst = JsonConvert.DeserializeObject<List<clsSyncData>>(strjson);

                            if (lst.Count > 0)
                            {
                                xe.DeleteETCSync(conn, lst);
                                SetStrLisbox(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss" + " ETC -> " + lst.Count()), listBox2);
                            }
                            stt++;
                            SetStrvalue(stt.ToString(), this);
                        }
                    }
                    else if (strkey == "MTC")
                    {
                        if (clsHepls.IsValidJson(strjson))
                        {
                            List<clsSyncMTC> lst = JsonConvert.DeserializeObject<List<clsSyncMTC>>(strjson);
                            if (lst.Count > 0)
                            {
                                xe.DeleteMTCSync(conn, lst);
                                SetStrLisbox(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss" + " MTC -> " + lst.Count()), listBox4);
                            }
                            stt++;
                            SetStrvalue(stt.ToString(), this);
                        }
                    }

                }

            }
        }

        public void ReadMessageKafkaMTC()
        {
            string topic = TopicMTC;
            Uri uri = new Uri(Host);
            var options = new KafkaOptions(uri);
            var router = new BrokerRouter(options);
            var consumer = new Consumer(new ConsumerOptions(topic, router));
            int stt = 0;
            foreach (var message in consumer.Consume())
            {
                if (message.Key != null)
                {
                    if (!flagSendResual)
                        continue;
                    var strjson = Encoding.UTF8.GetString(message.Value);
                    var strkey = Encoding.UTF8.GetString(message.Key);
                    if (strkey == "ETC")
                    {
                        if (clsHepls.IsValidJson(strjson))
                        {
                            List<clsSyncData> lst = JsonConvert.DeserializeObject<List<clsSyncData>>(strjson);

                            if (lst.Count > 0)
                            {
                                xe.DeleteETCSync(conn, lst);
                                SetStrLisbox(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss" + " ETC -> " + lst.Count()), listBox2);
                            }
                            stt++;
                            SetStrvalue(stt.ToString(), this);
                        }
                    }
                    else if (strkey == "MTC")
                    {
                        if (clsHepls.IsValidJson(strjson))
                        {
                            List<clsSyncMTC> lst = JsonConvert.DeserializeObject<List<clsSyncMTC>>(strjson);
                            if (lst.Count > 0)
                            {
                                xe.DeleteMTCSync(conn, lst);
                                SetStrLisbox(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss" + " MTC -> " + lst.Count()), listBox4);
                            }
                            stt++;
                            SetStrvalue(stt.ToString(), this);
                        }
                    }

                }

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (sendMessageETC == null)
            {
                sendMessageETC = new Thread(SendDataETC);
            }
            sendMessageETC.Abort(100);
            sendMessageETC = new Thread(SendDataETC);
            sendMessageETC.IsBackground = true;
            sendMessageETC.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sendMessageMTC == null)
            {
                sendMessageMTC = new Thread(SendDataMTC);
            }
            sendMessageMTC.Abort(100);
            sendMessageMTC = new Thread(SendDataMTC);
            sendMessageMTC.Start();
        }

        private void btnsetting_Click(object sender, EventArgs e)
        {
            frmSetting frm = new frmSetting();
            frm.ShowDialog();
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                readETC.Abort();
                readMTC.Abort();
                if (sendMessageETC != null)
                    sendMessageETC.Abort();
                if (sendMessageMTC != null)
                    sendMessageMTC.Abort();
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetStrvalue(DateTime.Now.ToString("HH:mm:ss"), lbltime);
            if (flagStop)
                return;
            if (flagConnect)
            {
                if (timeSendETC <= DateTime.Now)
                {
                    timeSendETC = DateTime.Now.AddMinutes(TimeETC);
                    SetStrvalue(timeSendETC.ToString("HH:mm:ss"), label3);
                    if (sendMessageETC == null)
                    {
                        sendMessageETC = new Thread(SendDataETC);
                    }
                    sendMessageETC.Abort(100);
                    sendMessageETC = new Thread(SendDataETC);
                    sendMessageETC.IsBackground = true;
                    sendMessageETC.Start();
                }

                if (timeSendMTC <= DateTime.Now)
                {
                    timeSendMTC = DateTime.Now.AddMinutes(TImeMTC);
                    SetStrvalue(timeSendMTC.ToString("HH:mm:ss"), label3);
                    if (sendMessageMTC == null)
                    {
                        sendMessageMTC = new Thread(SendDataMTC);
                    }
                    sendMessageMTC.Abort(100);
                    sendMessageMTC = new Thread(SendDataMTC);
                    sendMessageMTC.Start();
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            flagStop = true;
            if (readETC != null)
                readETC.Abort();
            if (readMTC != null)
                readMTC.Abort();
            if (sendMessageETC != null)
                sendMessageETC.Abort();
            btnRun.Enabled = true;
            btnStop.Enabled = false;
        }

        private void lblSQL_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri(txturl.Text);

            string topic = txtTopicETC.Text;

            var sendMsg = new Thread(() =>

            {
                DataTable dt = xe.getDataETC(conn);
                List<clsSyncData> lst = new List<clsSyncData>();
                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    if (xe.getRow(dt.Rows[a]))
                    {
                        clsSyncData D = new clsSyncData();
                        D.Transaction_Type = (xe.LoaiLan == "01" ? 1 : 2);
                        D.Transaction_ID = xe.TransId;
                        D.Transaction_Date = xe.NgayQuaTram.ToString("dd/MM/yyyy HH:mm:ss");
                        D.Ticket_ID = xe.TicketID;
                        D.EPC = xe.MaThe;
                        D.TID = "";
                        D.Station = 1730;// mã trạm Phố LU
                        D.Lane = xe.LanXe;
                        D.Plate = xe.BienSoCabin;
                        D.Work_Shift = xe.CaTruc;
                        D.Staff_name = xe.TenNV;
                        D.Vehicle_Image = clsHepls.getImage(clsHepls.pathImg, xe.TenHinhXeCaBin); // đường dẫn hình đã cấu hình sẵn trên SVR 2
                        D.Plate_Image = clsHepls.getImage(clsHepls.pathImgPlate, xe.TenHinhNDCabin);// đường dẫn hình đã cấu hình sẵn trên SVR 2
                        D.Process_Type = (int)clsHepls.getPorcessType(xe);
                        D.Ticket_Type = clsHepls.getLoaive(xe);
                        D.Plate_BE = xe.BienSoETC;
                        D.Vehicle_Type = xe.PhanLoaiXe;
                        D.Plate_Type = clsHepls.getTrangThaiNhanDang(xe.BienSoCabin, xe.BienSoETC);
                        D.Price = xe.PTTT == 1 ? xe.Phi : 0;
                        D.Enter_Transaction_ID = xe.TransId;
                        D.Enter_Station_Id = xe.MaTramVao;
                        D.Enter_Lane_Id = 0;
                        D.Enter_Transaction_Date = "";
                        D.Enter_EPC = "";
                        D.Enter_TID = "";
                        D.Enter_Vehicle_Image = "";
                        D.Enter_Plate_Image = "";
                        D.Enter_Plate = "";
                        D.Enter_Plate_BE = "";
                        D.Enter_Staff_Name = "";
                        lst.Add(D);
                    }
                }
                string jsonContent = JsonConvert.SerializeObject(lst);
                SetStrLisbox(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - ETC -> " + lst.Count(), listBox1);
                KafkaNet.Protocol.Message msg = new KafkaNet.Protocol.Message(jsonContent);

                var options = new KafkaOptions(uri);

                var router = new KafkaNet.BrokerRouter(options);

                var client = new Producer(router);
                SetStrLisbox(" - Send -> ", listBox1);
                msg.Meta = new MessageMetadata()
                {
                    PartitionId = 1,
                    Offset = 1
                };
                client.SendMessageAsync(topic, new List<KafkaNet.Protocol.Message> { msg }).Wait();
                SetStrLisbox(" - Send OK -> ", listBox1);
            });

            sendMsg.Start();
        }
    }
}
