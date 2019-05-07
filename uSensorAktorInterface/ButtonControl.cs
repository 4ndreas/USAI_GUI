using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uSensorAktorInterface
{
    public partial class ButtonControl : UserControl
    {
        public ButtonControl(usai u)
        {
            InitializeComponent();
            myU = u;
            button1.ContextMenuStrip = contextMenuStripButton;
            //CheckBox checkBoxAutoReset = new CheckBox();

            //contextMenuStripButton.Items.Add(checkBoxAutoReset);
            setKlickCounter(0);
            LoadState();
        }
        private bool bstate = false;

        public usai myU;
        public int klicked = 0;

        private void LoadState()
        {
            if (myU.getValue() == 0)
            {
                Bstate = false;
            }
            else
            {
                Bstate = true;
            }

            button1.Text = myU.Name;
        }



        public bool Bstate
        {
            get
            {
                return bstate;
            }
            set
            {
                bstate = value;
                if(bstate)
                {
                    myU.Value = 1;
                    button1.BackColor = Color.Green;
                    klicked++;
                    setKlickCounter(klicked);
                }
                else
                {
                    myU.Value = 0;
                    button1.BackColor = SystemColors.Control;
                }
                OnValueChanged(this);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button bu = (Button)sender;

            if (Bstate)
            {
                Bstate = false;
            }
            else
            {
                Bstate = true;
                //if(toolStripComboBoxPusch)
                if(toolStripMenuItemAutoReset.Checked)
                {
                    timerAutoReset.Enabled = true;
                }
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            //LoadState();
        }

        public event ValueChangedEventHandler ValueChanged;
        //-------------------------------------------------------
        // Invoke the ValueChanged event; called  when value     
        // is changed                                            
        //-------------------------------------------------------
        protected virtual void OnValueChanged(object sender)
        {
            if (ValueChanged != null)
                ValueChanged(sender);
        }

        private void timerAutoReset_Tick(object sender, EventArgs e)
        {
            timerAutoReset.Enabled = false;
            Bstate = false;
        }

        private void toolStripMenuItemRCount_Click(object sender, EventArgs e)
        {
            
            setKlickCounter(0);

        }
        private void setKlickCounter(int val)
        {
            klicked = val;
            toolStripTextBoxklicked.Text = "Klicked: " + klicked.ToString();
        }
    }
}
