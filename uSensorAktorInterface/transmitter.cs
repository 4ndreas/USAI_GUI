using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uSensorAktorInterface
{
    class transmitter
    {


        public transmitter()
        {

        }

        public void send(string sr)
        {

        }


        public delegate void SenderHandler(object sender, DatenEventArgs e);
        public event SenderHandler DataResceived;
        public string received_data;

    }

    public class DatenEventArgs : EventArgs
    {
        public readonly string Text;

        public DatenEventArgs(string text)
        {
            Text = text;
        }
    }
    }
