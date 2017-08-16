using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Drawing;
using System.IO.Ports;

namespace uSensorAktorInterface
{
    public enum cmdType
    {
        Graph, Control, Config
    };

    public enum dataType
    {
        _void,
        _bool,
        _char,
        _int,
        _long,
        _float,
        _string,
        _color
    };

    public class usai
    {
        public string Name;
        public cmdType Cmd;
        public Type _Type;
        public int ID;
        public object Value;
        private dataType dType;
        public bool updated = false;
        public int minimum = 0;
        public int maximum = 1;
        public GraphPoints myGraphPoints;
        public bool logData = false;
        public bool showGraph = false;
        public int midiChannel = 0;
        public Color graphColor = Color.Red;
        public bool updateGraphSettings = true;
        public object sender;

        internal dataType DType
        {
            get
            {
                return dType;
            }

            set
            {
                dType = value;
                switch (dType)
                {
                    case dataType._bool:
                        _Type = typeof(Boolean);
                        break;
                    case dataType._char:
                        _Type = typeof(Char);
                        break;
                    case dataType._int:
                    case dataType._long:
                        _Type = typeof(Int32);
                        break;
                    case dataType._float:
                        _Type = typeof(Double);
                        break;
                }
            }
        }

        public usai()
        {
            myGraphPoints = new GraphPoints();
        }

        public void refreshValue()
        {
            Write("get:"+ID.ToString() + Environment.NewLine);
            //Write("getAll:" + Environment.NewLine);
        }

        public void sendValue()
        {
            string send = Name + ":" + Value.ToString() + Environment.NewLine;
            send = send.Replace(',', '.');
            Write(send);
        }

        void Write(string sr)
        {
            if (sender.GetType() == typeof(SerialPort))
            {
                SerialPort comport = (SerialPort)sender;
                comport.Write(sr);
            }
            else if (sender.GetType() == typeof(udpConnect))
            {
                udpConnect udpport = (udpConnect)sender;
                udpport.Write(sr);
            }
        }

        public void setValue(string str)
        {
            if(dType.GetType() != null)
            {
                switch (dType)
                {
                    case dataType._bool:
                        if(str == "0")
                        {
                            Value = 0;
                        }
                        else
                        {
                            Value = 1;
                        }
                        break;
                    case dataType._char:
                        Value = Convert.ToChar(str);
                        break;
                    case dataType._int:
                    case dataType._long:
                        Value = Convert.ToInt32(str);
                        break;
                    case dataType._float:
                        Value = Convert.ToDouble(str, CultureInfo.CreateSpecificCulture("en-GB"));
                        break;
                    case dataType._color:
                        Value = Convert.ToUInt32(str);
                        break;
                }
                updated = true;
                if (logData)
                {
                    myGraphPoints.addRawValue(getDValue());
                }
            }
        }
        public void setValue(int val)
        {
            Value = val;
            updated = true;
            if (logData)
            {
                myGraphPoints.addRawValue(getDValue());
            }
        }

        public int getValue()
        {
            return ((int)Value);
        }

        public double getDValue()
        {
            double ret= Convert.ToDouble(Value);
            return ret;
        }
    }
}
