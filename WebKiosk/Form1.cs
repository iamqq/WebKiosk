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

        private string data = "";
        
        public Form1()
        {
            InitializeComponent();
            port = new SerialPort(); 
            port.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            port.PortName = Properties.Settings.Default.COMPort;
            port.Open();
        }

        private delegate void SetText(string text);

        private void sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
             Thread.Sleep(500);
             data = port.ReadExisting();
             webC.Invoke(new SetText(si_DataReceived), new object[] { data });
        }

        private string getProximity(string data)
        {
            if (data.Substring(8, 2) != "\r\n") return "error";  
            string code = data.Substring(0, 8);
            int num = Convert.ToInt32(code,16);
            if (num == 0) return "error"; 
            int prx = num >> 1;
            prx = prx & 65535;
            string ret = Convert.ToString(prx);
            return ret;
        }
        
        private void si_DataReceived(string data)
        {
            webC.ExecuteJavascriptWithResult("changeProximityCode('"+ getProximity(data) +"')");
            webC.Update();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webC.Source = new Uri(Properties.Settings.Default.BaseURL);
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

    }
}
