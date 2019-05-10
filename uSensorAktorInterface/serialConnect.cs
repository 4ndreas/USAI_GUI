using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace uSensorAktorInterface
{
    public partial class serialConnect : UserControl
    {
        public SerialPort comport;
        public serialConnect()
        {
            InitializeComponent();
            comport = new SerialPort();
            aktSerialPorts();
            if(comboBoxSerialports.Items.Count > 0)
                comboBoxSerialports.SelectedIndex = 0;
        }

        public bool connected = false;

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (comport.IsOpen)
                {
                    comport.Close();
                    buttonConnect.Text = "Connect";
                    aktSerialPorts();
                    connected = true;
                }
                else
                {
                    comport.BaudRate = Convert.ToInt32(textBoxBaud.Text);
                    comport.PortName = comboBoxSerialports.Text;
                    comport.DtrEnable = true;
                    comport.Open();
                    buttonConnect.Text = "Disconnect";
                    comport.WriteLine("getAll:");
                    connected = false;
                }
            }
            catch (Exception srfail)
            {
                MessageBox.Show(srfail.Message);
                connected = false;
            }
        }

        public void Write(string sr)
        {
            if (comport.IsOpen)
            {
                comport.Write(sr);
            }
        }

        void aktSerialPorts()
        {
            comboBoxSerialports.Items.Clear();
            foreach (string str in SerialPort.GetPortNames())
            {
                comboBoxSerialports.Items.Add(str);
            }
        }

        private void buttonReloadPorts_Click(object sender, EventArgs e)
        {
            aktSerialPorts();
        }

        private void buttonGetALL_Click(object sender, EventArgs e)
        {
            if (comport.IsOpen)
            {
                comport.WriteLine("getAll:");
            }
        }
    }
}
