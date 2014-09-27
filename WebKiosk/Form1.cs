using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WebKiosk
{
    public partial class Form1 : Form
    {
        static SerialPort _serialPort;

        public Form1()
        {
            InitializeComponent();
//            SerialPort port = new SerialPort( ″COM1″ , 9600, Parity.None, 8, StopBits.One);
            //_serialPort.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webControl1.Source = new Uri("http://ya.ru");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            webControl1.Left = 0;
            webControl1.Top = 0;
            webControl1.Width = Width;
            webControl1.Height = Height; 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
