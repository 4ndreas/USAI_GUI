using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;


namespace uSensorAktorInterface
{
    public partial class midiConnect : UserControl
    {
        InputDevice inDevice;
        public midiConnect(InputDevice midiInput)
        {
            InitializeComponent();
            inDevice = midiInput;
            labelID.Text = inDevice.DeviceID.ToString();
        }


        bool isOpen = false;
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if(isOpen)
            {
                // disable Midi
                try
                {
                    inDevice.StopRecording();
                    inDevice.Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                isOpen = false;

                Button bu = (Button)sender;
                bu.Text = "Open";
            }
            else
            {
                // try enable midi
                try
                {
                    inDevice.StartRecording();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                isOpen = true;

                Button bu = (Button)sender;
                bu.Text = "Close";
            }
            

        }
    }
}
