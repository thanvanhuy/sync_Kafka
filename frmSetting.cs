using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sync_Kafka
{
    public partial class frmSetting : Form
    {
        private ProcessXML.ProcessXML configXML;
        public frmSetting()
        {
            InitializeComponent();
        }
        private void frmSetting_Load(object sender, EventArgs e)
        {
            string SVR;
            string User;
            string Pass;
            string Catalog;

            string Img;
            string ImgPlate;
            int TimeETC;
            int TImeMTC;
            Boolean AutoRun;

            string Host1;
            string TopicEtc1, TopicMtc1, TopicEtc2, TopicMtc2;
            string Host2;
            string Topic2;
            string RunSVR;
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
            TopicEtc1 = configXML.XmlNodeValue("TopicEtc1", "Kafka", "");
            TopicMtc1 = configXML.XmlNodeValue("TopicMtc1", "Kafka", "");

            Host2 = configXML.XmlNodeValue("Host2", "Kafka", "");
            TopicEtc2 = configXML.XmlNodeValue("TopicEtc2", "Kafka", "");
            TopicMtc2 = configXML.XmlNodeValue("TopicMtc2", "Kafka", "");

            RunSVR = configXML.XmlNodeValue("RunSVR", "Kafka", "");

            Encryption.Encryption.Decode("ITVVA", ref User, User);
            Encryption.Encryption.Decode("ITVVA", ref Pass, Pass);
            txtServer.Text = SVR;
            txtCatalog.Text = Catalog;
            txtUser.Text = User;
            txtPass.Text = Pass;

            txtPathImg.Text = Img;
            txtPathImgPlate.Text = ImgPlate;
            txtTimeETC.Value = TimeETC;
            txtTimeMTC.Value = TImeMTC;
            CbRunAuto.Checked = AutoRun;

            txtHost1.Text = Host1;
            txtTopicETC1.Text = TopicEtc1;
            txtTopicMTC1.Text = TopicMtc1;

            txtHost2.Text = Host2;
            txtTopicETC2.Text = TopicEtc2;
            txtTopicMTC2.Text = TopicMtc2;

            if (RunSVR == "1")
                rbKafka1.Checked = true;
            else
                rbKafka2.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string SVR = txtServer.Text;
            string User = txtUser.Text;
            string Pass = txtPass.Text;
            string Catalog = txtCatalog.Text;

            string Img = txtPathImg.Text;
            string ImgPlate = txtPathImgPlate.Text;
            int TimeETC = (int)txtTimeETC.Value;
            int TImeMTC = (int)txtTimeMTC.Value;
            Boolean AutoRun = CbRunAuto.Checked;

            string Host1 = txtHost1.Text;
            string TopicETC1 = txtTopicETC1.Text;
            string Host2 = txtHost2.Text;
            string TopicETC2 = txtTopicETC2.Text;
            Encryption.Encryption.Encode("ITVVA", User, ref User);
            Encryption.Encryption.Encode("ITVVA", Pass, ref Pass);

            configXML.WriteNode("Server", "SQL", SVR);
            configXML.WriteNode("DatabaseServer", "SQL", Catalog);
            configXML.WriteNode("UserServer", "SQL", User);
            configXML.WriteNode("PasswordServer", "SQL", Pass);

            configXML.WriteNode("PathImg", "General", Img);
            configXML.WriteNode("PathImgPlate", "General", ImgPlate);
            configXML.WriteNode("SendETC", "General", TimeETC.ToString());
            configXML.WriteNode("SendMTC", "General", TImeMTC.ToString());
            configXML.WriteNode("AutoRun", "General", AutoRun ? "1" : "0");

            configXML.WriteNode("Host1", "Kafka", Host1);
            configXML.WriteNode("TopicEtc1", "Kafka", TopicETC1);
            configXML.WriteNode("TopicMtc1", "Kafka", txtTopicMTC1.Text);
            configXML.WriteNode("Host2", "Kafka", Host2);
            configXML.WriteNode("TopicEtc2", "Kafka", TopicETC2);
            configXML.WriteNode("TopicMtc2", "Kafka", txtTopicMTC2.Text);
            configXML.WriteNode("RunSVR", "Kafka", rbKafka1.Checked ? "1" : "2"); ;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
