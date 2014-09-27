using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace WebKiosk
{
    class ComPort
    {
        static SerialPort port;
        public ComPort()
        {
            string[] portnames = SerialPort.GetPortNames();
        //  SeriPort 
                port = new SerialPort( ); // ″COM3″ , 9600, Parity.None, 8, StopBits.One);
            port.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            port.PortName = "COM3";
            port.Open();
//            int databyte = port.ReadByte();
            //port.Close();
        }
        private string stroka = "";

        private void sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (!port.IsOpen)
            {
                port.Open();
            }
            stroka = port.ReadExisting();
        }
        private void DoUpdate(object s, EventArgs e)
        {
//            stroka = stroka + serialPort1.ReadExisting();
        }

        public void ComPort_SendK()
        {
            byte[] data = { 107 };
            port.Write(data, 0, data.Length);
        }

        public void ComPort_Close()
        {
            port.Close();
        }
    }
}
