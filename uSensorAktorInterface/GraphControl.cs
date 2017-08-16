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
    public partial class GraphControl : UserControl
    {
        public GraphControl(usai u)
        {
            myU = u;
            InitializeComponent();
            textBoxName.Text = myU.Name;
            textBoxValue.Text = myU.Value.ToString();
        }

        usai myU;
        public void UpdateData()
        {
            textBoxName.Text = myU.Name;
            textBoxValue.Text = myU.Value.ToString();
            myU.updated = false;
        }
    }
}
