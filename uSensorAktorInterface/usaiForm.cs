using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;
using System.IO.Ports;

namespace uSensorAktorInterface
{
    public partial class usaiForm : Form
    {
        public usaiForm()
        {
            InitializeComponent();

            Sensors = new List<usai>();
            mainGraph = new uGraph();

            mainGraph.Size = tabPageGraph.Size;
            mainGraph.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            tabPageGraph.Controls.Add(mainGraph);
            mainGraph.CreateNewGraph();
            mainGraph.drawScope();


            serialConnect serc = new serialConnect();
            flowLayoutPanelConnections.Controls.Add(serc);
            serc.comport.DataReceived += serialPort1_DataReceived;

            udpConnect udpc = new udpConnect();
            flowLayoutPanelConnections.Controls.Add(udpc);
            udpc.UDP_DataResceived += Udpc_UDP_DataResceived;
        }

        // MIDI
        private bool useMidi = false;
        private const int SysExBufferSize = 128;
        private InputDevice inDevice = null;
        private SynchronizationContext context;

        int usedMidiKnobs = 0;
        int usedMidiButtons = 0;
        protected override void OnLoad(EventArgs e)
        {

            if (InputDevice.DeviceCount == 0)
            {
                //MessageBox.Show("No MIDI input devices available.", "Error!",
                //    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //Close();
            }
            else
            {
                try
                {
                    context = SynchronizationContext.Current;

                    inDevice = new InputDevice(0);
                    inDevice.ChannelMessageReceived += HandleChannelMessageReceived;
                    //inDevice.SysCommonMessageReceived += HandleSysCommonMessageReceived;
                    //inDevice.SysExMessageReceived += HandleSysExMessageReceived;
                    //inDevice.SysRealtimeMessageReceived += HandleSysRealtimeMessageReceived;
                    inDevice.Error += new EventHandler<ErrorEventArgs>(inDevice_Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //Close();
                }
                useMidi = true;
            }

            if (inDevice != null)
            {
                midiConnect midiCon = new midiConnect(inDevice);
                flowLayoutPanelConnections.Controls.Add(midiCon);
            }

            base.OnLoad(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            if (inDevice != null)
            {
                inDevice.Close();
            }

            base.OnClosed(e);
        }

        private void inDevice_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Error.Message, "Error!",
                   MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private int map(int x, int in_min, int in_max, int out_min, int out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }


        private bool isConnected()
        {
            //foreach(Control cr in flowLayoutPanelConnections.Controls)
            //{
            //    serialConnect sc = (serialConnect)cr;
            //    if(sc.connected == true)
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

        private void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
        {
            try
            {
                context.Post(delegate (object dummy)
                {
                    e.Message.Command.ToString();
                    e.Message.MidiChannel.ToString();
                    e.Message.Data1.ToString();
                    e.Message.Data2.ToString();

                    foreach (Control cr in flowLayoutPanel1.Controls)
                    {
                        if (cr is KnobControl)
                        {
                            if (((KnobControl)cr).myU.midiChannel == e.Message.Data1)
                            {
                                int target = map(e.Message.Data2, 0, 127, ((KnobControl)cr).myU.minimum, ((KnobControl)cr).myU.maximum);
                                ((KnobControl)cr).Value = target;
                            }
                        }
                        else if (cr is ButtonControl)
                        {
                            if (((ButtonControl)cr).myU.midiChannel == e.Message.Data1)
                            {
                                if (e.Message.Data2 == 0)
                                {
                                    ((ButtonControl)cr).Bstate = false;
                                }
                                else
                                {
                                    ((ButtonControl)cr).Bstate = true;
                                }
                            }
                        }
                        else if (cr is uColorWheel)
                        {
                            if (((uColorWheel)cr).myU.midiChannel == e.Message.Data1)
                            {
                                int target = map(e.Message.Data2, 0, 127, 0, 255);
                                ((uColorWheel)cr).setHue((byte)target);
                            }
                            else if (((uColorWheel)cr).myU.midiChannel + 1 == e.Message.Data1)
                            {
                                int target = map(e.Message.Data2, 0, 127, 0, 255);
                                ((uColorWheel)cr).setLightness((byte)target);
                            }
                            else if (((uColorWheel)cr).myU.midiChannel + 2 == e.Message.Data1)
                            {
                                int target = map(e.Message.Data2, 0, 127, 0, 255);
                                ((uColorWheel)cr).setSaturation((byte)target);
                            }
                        }
                    }

                }, null);
            }catch(Exception ex)
            {

            }
        }

        //end MIDI

        uGraph mainGraph;
        List<usai> Sensors;

        private delegate void delAddControl();

        bool globalUpdate = false;

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string rxString;
            SerialPort sPort = (SerialPort)sender;
            try
            {
                if (sPort.IsOpen)
                {
                    while ((rxString = sPort.ReadLine()) != null)
                    {
                        processValue(rxString, sender);
                    }
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //toolStripStatusLabelInfo.Text = ex.Message;
            }
        }

        public void processValue(string sr, object sender)
        {
            if (sr.Contains(':'))
            {
                string name = sr.Substring(0, sr.IndexOf(':'));
                if (name.Equals("ID"))
                {
                    // new ? 
                    bool isNew = true;
                    string[] values = sr.Substring(sr.IndexOf(':') + 1).Split(';');
                    foreach (usai u in Sensors)
                    {
                        if ((u.Name.Equals(values[1]))&&(u.sender == sender))
                        {
                            isNew = false;

                            u.sender = sender;
                            u.ID = Convert.ToInt32(values[0]);
                            u.Name = values[1];
                            u.Cmd = (cmdType)Convert.ToInt32(values[2]);
                            u.DType = (dataType)Convert.ToInt32(values[3]);
                            u.setValue(values[4]);
                            u.minimum = Convert.ToInt32(values[5]);
                            u.maximum = Convert.ToInt32(values[6]);

                            foreach (usaiPrameter up in flowLayoutPanelConfig.Controls)
                                {
                                    if(up.myU == u)
                                    {
                                    this.Invoke((delAddControl)delegate
                                    {
                                        up.myU = u;
                                        up.UpdateData();
                                        //up.Refresh();
                                    });
                                    
                                    }
                                }
                            break;
                        }
                    }
                    foreach(Control cr in flowLayoutPanel1.Controls)
                    {
                        this.Invoke((delAddControl)delegate
                        {
                            cr.Refresh();
                        });
                    }
                    if (isNew)
                    {
                        usai u = new usai();

                        u.sender = sender;
                        u.ID = Convert.ToInt32(values[0]);
                        u.Name = values[1];
                        u.Cmd = (cmdType)Convert.ToInt32(values[2]);
                        u.DType = (dataType)Convert.ToInt32(values[3]);
                        u.setValue(values[4]);
                        u.minimum = Convert.ToInt32(values[5]);
                        u.maximum = Convert.ToInt32(values[6]);

                        Sensors.Add(u);
                        u.logData = true;
                        mainGraph.addUSAI(u);

                        if (u.Cmd == cmdType.Graph)
                        {
                            u.showGraph = false;
                            GraphControl gc = new GraphControl(u);
                            this.Invoke((delAddControl)delegate
                            {
                                flowLayoutPanel1.Controls.Add(gc);
                            });
                        }
                        else if (u.Cmd == cmdType.Control)
                        {
                            if (u.DType == dataType._bool)
                            {
                                u.midiChannel = 9 + usedMidiButtons;
                                usedMidiButtons++;
                                ButtonControl buk = new ButtonControl(u);
                                buk.ValueChanged += Buk_ValueChanged;
                                this.Invoke((delAddControl)delegate
                                {
                                    flowLayoutPanel1.Controls.Add(buk);
                                });
                            }
                            else if (u.DType == dataType._color)
                            {
                                u.midiChannel = 21 + usedMidiKnobs;
                                usedMidiKnobs += 2;
                                uColorWheel cw = new uColorWheel(u);
                                cw.ValueChanged += Cw_ValueChanged;
                                this.Invoke((delAddControl)delegate
                                {
                                    flowLayoutPanel1.Controls.Add(cw);
                                });
                            }
                            else
                            {
                                u.midiChannel = 21 + usedMidiKnobs;
                                usedMidiKnobs++;
                                KnobControl k = new KnobControl(u);
                                k.ValueChanged += K_ValueChanged;
                                this.Invoke((delAddControl)delegate
                                {
                                    flowLayoutPanel1.Controls.Add(k);
                                });
                            }
                        }

                        usaiPrameter uP = new usaiPrameter(u);
                        this.Invoke((delAddControl)delegate
                        {
                            flowLayoutPanelConfig.Controls.Add(uP);
                        });
                    }
                }
                else
                {
                    foreach (usai u in Sensors)
                    {
                        if ((u.Name.Equals(name)) && (u.sender == sender))
                        {
                            string[] values = sr.Split(':');
                            u.setValue(values[1]);
                            globalUpdate = true;
                            break;
                        }
                    }
                }
            }
        }

        private void Cw_ValueChanged(object Sender)
        {
            ((uColorWheel)Sender).myU.sendValue();
        }

        private void Buk_ValueChanged(object Sender)
        {
            ButtonControl kn = (ButtonControl)Sender;
            kn.myU.sendValue();
        }

        private void K_ValueChanged(object Sender)
        {
            KnobControl kn = (KnobControl)Sender;
            kn.myU.setValue(kn.Value);
            kn.myU.sendValue();
        }



        /*
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Button bu = (Button)sender;
            if (serialPort1.IsOpen)
            {
                //serialPort1.DtrEnable = false;
                serialPort1.DiscardInBuffer();
                serialPort1.DiscardOutBuffer();
                serialPort1.Close();
                bu.Text = "Connect";

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
            }
            else
            {
                clearAll();
                mainGraph.CreateNewGraph();
                serialPort1.Open();
                //serialPort1.DtrEnable = true;
                serialPort1.WriteLine("getAll:");
                bu.Text = "Close";

                // try enable midi
                try
                {
                    inDevice.StartRecording();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        */

        public void clearAll()
        {
            Sensors.Clear();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanelConfig.Controls.Clear();
            mainGraph.clearUSAI();

            usedMidiButtons = 0;
            usedMidiKnobs = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (globalUpdate)
            {
                foreach (Control cr in flowLayoutPanel1.Controls)
                {
                    if (cr is GraphControl)
                    {
                        ((GraphControl)cr).UpdateData();
                    }
                   
                }
                mainGraph.redraw();
                //toolStripStatusLabelInfo.Text = 
                globalUpdate = false;
            } 
        }

        private void buttonAddUdp_Click(object sender, EventArgs e)
        {
            udpConnect udpc = new udpConnect();
            flowLayoutPanelConnections.Controls.Add(udpc);
            udpc.UDP_DataResceived += Udpc_UDP_DataResceived;
        }

        private void Udpc_UDP_DataResceived(object sender, udpConnect.DatenEventArgs e)
        {
            string[] liness = e.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (String l in liness)
            {
                processValue(l, sender);
            }
        }

        private void buttonAddSerial_Click(object sender, EventArgs e)
        {
            serialConnect serc = new serialConnect();
            flowLayoutPanelConnections.Controls.Add(serc);
            serc.comport.DataReceived += serialPort1_DataReceived;
        }
    }
}
