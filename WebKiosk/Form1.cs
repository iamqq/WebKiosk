using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;

namespace WebKiosk
{
    public partial class Form1 : Form
    {
        static SerialPort port;

        //private string stroka = "";
        
        public Form1()
        {
            InitializeComponent();
            port = new SerialPort(); 
            port.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            port.PortName = "COM15";
            port.Open();
        }

        private delegate void SetTextDeleg(string text);

        private void sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
            
            string data = port.ReadExisting();
            this.BeginInvoke(new SetTextDeleg(si_DataReceived), 
                new object[] { data });

            //if (stroka <> "")
            //{
            //    webC.ExecuteJavascript("var ratevalue = document.getElementById('ratevalue');  ratevalue.value = '" + stroka + "';");
            //}
        }

        private void si_DataReceived(string data)
        {
            webC.ExecuteJavascript("var ratevalue = document.getElementById('ratevalue');  ratevalue.value = '" + data + "';");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webC.Source = new Uri("https://sap-prx.ugmk.com:441/ummc/kiosk");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            webC.Left = 0;
            webC.Top = 0;
            webC.Width = Width;
            webC.Height = Height; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            port.Close();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webC.ExecuteJavascript("var ratevalue = document.getElementById('ratevalue');  ratevalue.value = 'zzzz';");
        }

    }
}
