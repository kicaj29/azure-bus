using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetStartedQueues.SendReceive;
using GetStartedTopics.SendReceive;

namespace AzureBusExamples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sender.Send();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Receiver.Receive();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Publisher.Publish();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Subscriber.Subscribe("Subscribe_one");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Subscriber.Subscribe("Subscribe_two");
        }
    }
}
