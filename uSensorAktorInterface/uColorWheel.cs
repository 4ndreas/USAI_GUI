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
    public partial class uColorWheel : UserControl
    {

        public usai myU;

        int red;
        int green;
        int blue;
        Color rgbCol;
        UInt32 i32col;

        public uColorWheel(usai u)
        {
            InitializeComponent();
            myU = u;
            setColor((UInt32)u.Value);


            colorWheel2.HueChanged += ColorWheel2_Changed;
            colorWheel2.SLChanged += ColorWheel2_Changed;
        }

        //-------------------------------------------------------
        // An event that clients can use to be notified whenever 
        // the Value is Changed.                                 
        //-------------------------------------------------------
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

        private void ColorWheel2_Changed(object sender, EventArgs e)
        {
            HslColor hslCol = new HslColor(colorWheel2.Hue, colorWheel2.Saturation, colorWheel2.Lightness);
            rgbCol = ColorMath.HslToRgb(hslCol);

            red = rgbCol.R;
            green = rgbCol.G;
            blue = rgbCol.B;

            //i32col = (UInt32)(red + green << 8 + blue << 16);

            i32col = (UInt32)red;
            i32col <<= 8;
            i32col |= (UInt32)green;
            i32col <<= 8;
            i32col |= (UInt32)blue;
            myU.Value = i32col;
            // call delegate  
            OnValueChanged(this);
        }

        public void setHue(byte hue)
        {
            colorWheel2.Hue = hue;
            ColorWheel2_Changed(this, null);
        }

        public void setLightness(byte li)
        {
            colorWheel2.Lightness = li;
            ColorWheel2_Changed(this, null);
        }
        public void setSaturation(byte sat)
        {
            colorWheel2.Saturation = sat;
            ColorWheel2_Changed(this, null);
        }


        public void setColor(Color c)
        {
            HslColor hslCol = ColorMath.RgbToHsl(c);
            colorWheel2.Hue = hslCol.H;
            colorWheel2.Saturation = hslCol.S;
            colorWheel2.Lightness = hslCol.L;
        }
        public void setColor(UInt32 c)
        {
            Color c2 = Color.FromArgb((int)c);

            HslColor hslCol = ColorMath.RgbToHsl(c2);
            colorWheel2.Hue = hslCol.H;
            colorWheel2.Saturation = hslCol.S;
            colorWheel2.Lightness = hslCol.L;
        }
    }
}
