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
            if(myU.getValue() == 0)
            {
                Bstate = false;
            }
            else
            {
                Bstate = true;
            }
            
            button1.Text = myU.Name;
        }
        private bool bstate = false;

        public usai myU;

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
            }
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
    }
}
