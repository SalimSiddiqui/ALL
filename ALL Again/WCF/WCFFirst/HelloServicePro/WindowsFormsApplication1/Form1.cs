using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        System.ServiceModel.ServiceHost host = new ServiceHost(typeof(HelloServicePro.HelloService));
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            host.Open();
            Console.WriteLine("Host Started at" + DateTime.Now.ToString());
          }

        private void button2_Click(object sender, EventArgs e)
        {
            host.Close();
        }
    }
}
