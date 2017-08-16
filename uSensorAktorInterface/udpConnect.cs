using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace uSensorAktorInterface
{
    public partial class udpConnect : UserControl
    {

        public string ip
        {
            get { return ipstring; }
            set
            {
                ipstring = value;
                targeIP = IPAddress.Parse(value);
            }
        }

        public string errorMsG;

        public int sendPort;

        public IPAddress targeIP;

        private string ipstring;

        private UdpClient udpClient;

        private int listenPort = 8888;

        public int ID;
        public udpConnect()
        {
            InitializeComponent();
            Random random = new Random();
            int ID = random.Next(0, 32000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (udpClient != null)
            {
                udpClient.Client.Shutdown(SocketShutdown.Both);
                udpClient.Close();
                udpClient = null;
                button2.Text = "Connect";
            }
            else
            {
                sendPort = Convert.ToInt32(textBoxPort.Text);
                ip = textBoxIPAdress.Text;
                udpClient = new UdpClient(sendPort);
                Write("getAll:" + Environment.NewLine);
                regRxPort();
                button2.Text = "Disconnect";
            }
        }

        public void wirteln(string s)
        {
            Write(s + Environment.NewLine);
        }

        public void Write(string sr)
        {
            Byte[] sendBytes = Encoding.ASCII.GetBytes(sr);
            send(sendBytes);
        }

        public void send(byte cmd, byte value)
        {
            Byte[] sendBytes = new Byte[2];

            sendBytes[0] = cmd;
            sendBytes[1] = value;
            send(sendBytes);
        }

        public void send(byte[] sBytes)
        {

            //udpClient = new UdpClient(sendPort);
            try
            {
                udpClient.Connect(targeIP, sendPort);

                // Sends a message to the host to which you have connected.
                //Byte[] sendBytes = Encoding.ASCII.GetBytes(send);

                udpClient.Send(sBytes, sBytes.Length);

                //udpClient.Close();

            }
            catch (Exception ex)
            {
                errorMsG = ex.Message;
                //MessageBox.Show(ex.ToString());
            }

        }

        /*****************************************************************/
        //
        //  Empfangen
        //
        /*****************************************************************/

        public delegate void SenderHandler(object sender, DatenEventArgs e);
        public event SenderHandler UDP_DataResceived;

        public string received_data;

        public bool regRxPort(int port = 65507)
        {
            listenPort = port;
            //udpListener = new UdpClient(port);
            try
            {
                udpClient.BeginReceive(new AsyncCallback(recv), null);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        private void recv(IAsyncResult res)
        {
            try
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, listenPort);

                byte[] received = udpClient.EndReceive(res, ref RemoteIpEndPoint);

                //Process codes
                received_data = Encoding.UTF8.GetString(received);

                if (UDP_DataResceived != null)
                {
                    DatenEventArgs daten = new DatenEventArgs(received_data);
                    UDP_DataResceived(this, daten);
                }

                udpClient.BeginReceive(new AsyncCallback(recv), null);
            }
            catch(Exception ex)
            {

            }
        }


        public class DatenEventArgs : EventArgs
        {
            public readonly string Text;

            public DatenEventArgs(string text)
            {
                Text = text;
            }
        }

        private void buttonGetALL_Click(object sender, EventArgs e)
        {
            if (udpClient != null)
            {
                Write("getAll:" + Environment.NewLine);
            }
        }
    }
}
