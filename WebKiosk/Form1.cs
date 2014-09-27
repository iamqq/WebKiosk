using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace WebKiosk
{
    public partial class Form1 : Form
    {
//        static SerialPort _serialPort;
        private static ComPort _com;

        private static System.Timers.Timer aTimer;

        public Form1()
        {
            InitializeComponent();
            _com = new ComPort();
            aTimer = new System.Timers.Timer(10000);

            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            // Set the Interval to 2 seconds (2000 milliseconds).
            aTimer.Interval = 2000;
            aTimer.Enabled = true;

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
            _com.ComPort_Close();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _com.ComPort_SendK();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            _com.ComPort_SendK();
        }

    }
}
