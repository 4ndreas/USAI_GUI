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
    public partial class usaiPrameter : UserControl
    {
        public usaiPrameter(usai u)
        {
            myU = u;
            InitializeComponent();
            UpdateData();
        }

        public usai myU;
        public void UpdateData()
        {
            textBoxName.Text = myU.Name;
            textBoxValue.Text = myU.Value.ToString().Replace(',', '.');
            numericUpDownMin.Value = myU.minimum;
            numericUpDownMax.Value = myU.maximum;
            checkBoxGraph.Checked = myU.showGraph;
        }
        private void checkBoxGraph_CheckedChanged(object sender, EventArgs e)
        {
            myU.showGraph = checkBoxGraph.Checked;
            myU.updateGraphSettings = true;
        }

        private void numericUpDownMin_ValueChanged(object sender, EventArgs e)
        {
            myU.minimum = (int)numericUpDownMin.Value;
            myU.updateGraphSettings = true;
        }

        private void numericUpDownMax_ValueChanged(object sender, EventArgs e)
        {
            myU.maximum = (int)numericUpDownMax.Value;
            myU.updateGraphSettings = true;
        }

        private void buttonGET_Click(object sender, EventArgs e)
        {
            myU.refreshValue();
        }

        private void buttonSET_Click(object sender, EventArgs e)
        {
            myU.setValue(textBoxValue.Text.Replace(',', '.'));
            textBoxValue.Text = textBoxValue.Text.Replace(',', '.');
            myU.sendValue();
        }
    }
}
