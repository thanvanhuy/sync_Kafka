using KafkaNet.Model;
using KafkaNet;
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

namespace sync_Kafka
{
    public partial class frmConsumer : Form
    {
        private Thread sendMsg;
        private delegate void strDeledate(string str, Control control);
        private void SetStrvalue(string str, Control control)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new strDeledate(SetStrvalue), str, control);
                return;
            }

            control.Text = str;
        }
        public frmConsumer()
        {
            InitializeComponent();
        }
        private void frmConsumer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendMsg = new Thread(() =>
            {
                string topic = textBox3.Text;
                Uri uri = new Uri(textBox2.Text);
                var options = new KafkaOptions(uri);
                var router = new BrokerRouter(options);
                var consumer = new Consumer(new ConsumerOptions(topic, router));
                int stt = 0;
                foreach (var message in consumer.Consume())
                {
                    SetStrvalue(Encoding.UTF8.GetString(message.Value), textBox1);
                    stt++;
                    SetStrvalue(stt.ToString(), this);
                }
            });

            sendMsg.Start();
        }

        private void frmConsumer_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (sendMsg != null)
                    sendMsg.Abort();
            }
            catch { }
        }
    }
}
