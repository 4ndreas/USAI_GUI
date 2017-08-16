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
    public partial class uGraph : UserControl
    {
        public uGraph()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.uGraph_Resize);
            graphs = new List<usai>();
        }

        Graphics Scope;
        Image _backBuffer;
        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrush = new SolidBrush(Color.LightGray);
        List<usai> graphs;

        int border = 10;
        int AxisDistance = 100;
        int scale = 1;
        int TimeScale = 100;

        bool pauseTime = false;
        DateTime pauseTimeVal = DateTime.Now;
        TimeSpan showtime = new TimeSpan(0, 1, 0);

        public void CreateNewGraph()
        {
            Scope = pictureBoxGraph.CreateGraphics();
            createAxis(Scope);
            _backBuffer = new Bitmap(pictureBoxGraph.Width, pictureBoxGraph.Height);

            int xSize = pictureBoxGraph.Width - border;
            int ySize = pictureBoxGraph.Height - border;


            foreach (usai ud in graphs)
            {
                if (ud.logData && ud.showGraph)
                {
                    int size = ud.maximum - ud.minimum;
                     
                    ud.myGraphPoints.NumberOfSamplestoDraw = xSize - border;
                    ud.myGraphPoints.PointDistance = 1; // set to 1 pixel
                    ud.myGraphPoints.Xoffset = xSize;   // time
                    
                    ud.myGraphPoints.ScaleFactor = ((double)ySize - border) / size;
                    ud.myGraphPoints.Yoffset = ySize + (int)(ud.minimum * ud.myGraphPoints.ScaleFactor);
                }
            }
        }

        public void addUSAI(usai usai)
        {
            graphs.Add(usai);
            HslColor col = new HslColor((byte)(graphs.Count * 83), 255, 127);
            usai.graphColor = ColorMath.HslToRgb(col);
            CreateNewGraph();
        }

        public void clearUSAI()
        {
            graphs.Clear();
        }

        public void redraw()
        {
            drawScope();
        }

        private void uGraph_Resize(object sender, System.EventArgs e)
        {
            CreateNewGraph();
            Refresh();
        }

        private Graphics createAxis(Graphics Axis)
        {
            Axis.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Axis.Clear(System.Drawing.Color.White);


            Pen AxisLine = new Pen(Color.LightGray);



            PointF ZeroZero = new PointF(Axis.VisibleClipBounds.Width - border, Axis.VisibleClipBounds.Height - border);
            PointF MaxZero = new PointF(Axis.VisibleClipBounds.Width - border, border);

            PointF TopMax = new PointF(border, border);
            PointF ZeroMax = new PointF(border, Axis.VisibleClipBounds.Height - border);

            Axis.DrawLine(AxisLine, ZeroZero, MaxZero);
            Axis.DrawLine(AxisLine, TopMax, ZeroMax);
            Axis.DrawLine(AxisLine, ZeroZero, ZeroMax);
            Axis.DrawLine(AxisLine, TopMax, MaxZero);
            //Axis.DrawString("0", drawFont, drawBrush, MaxZero);

            // Y Achse
            for (int i = 0; i < Axis.VisibleClipBounds.Height - (2 * border); i += AxisDistance)
            {
                PointF left = new PointF(border, Axis.VisibleClipBounds.Height - border - i);
                PointF right = new PointF(Axis.VisibleClipBounds.Width - border, Axis.VisibleClipBounds.Height - border - i);
                Axis.DrawLine(AxisLine, left, right);
                left.Y -= drawFont.Height;
                Axis.DrawString((i / scale).ToString(), drawFont, drawBrush, left);
            }

            //X-Achse 

            for (int i = 1 * TimeScale; i < Axis.VisibleClipBounds.Width - (TimeScale); i += 1 * TimeScale)
            {
                PointF left = new PointF(Axis.VisibleClipBounds.Width - border - i, border);
                PointF right = new PointF(Axis.VisibleClipBounds.Width - border - i, Axis.VisibleClipBounds.Height - border);
                Axis.DrawLine(AxisLine, left, right);
                left.X -= drawFont.Height;
                right.Y -= drawFont.Height;
                Axis.DrawString((i / TimeScale).ToString() + "s", drawFont, drawBrush, right);
            }
            return (Axis);
        }

        SolidBrush textColor = new SolidBrush(Color.LightGray);

        public void drawScope()
        {
            this.DoubleBuffered = true;

            Graphics g = Graphics.FromImage(_backBuffer);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            createAxis(g);
            int nameoffset = 10;
            foreach (usai ud in graphs)
            {
                if (ud.logData && ud.showGraph)
                {
                    Pen ScopeLine = new Pen(ud.graphColor);
                    //if (radioButtonCurve.Checked)
                    //    g.DrawCurve(ScopeLine, Data.Mess.PointArr());

                    if(ud.updateGraphSettings)
                    {
                        CreateNewGraph();
                        ud.updateGraphSettings = false;
                    }

                    //else if (radioButtonLine.Checked)
                    ud.myGraphPoints.makeDrawTimePoints();
                    ud.myGraphPoints.paustime = pauseTimeVal;
                    ud.myGraphPoints.setPauseTime = pauseTime;
                    ud.myGraphPoints.TimeToDraw = showtime;

                    g.DrawLines(ScopeLine, ud.myGraphPoints.drawPoints);

                    PointF Value = new PointF(20,nameoffset);
                    //double current = (Data.Mess.getMaxValue() - (Data.Mess.LastPoint().Y)) / Data.Mess.GetScale();

                    textColor.Color = ud.graphColor;

                    //g.DrawString(current.ToString(), drawFont, textColor, Value);

                    g.DrawString(ud.myGraphPoints.getNewest().ToString() + "  " + ud.Name, drawFont, textColor, Value);
                    nameoffset += 25;
                }
            }

            g.Dispose();
            Scope.DrawImageUnscaled(_backBuffer, 0, 0);
        }

        private void pictureBoxGraph_Click(object sender, EventArgs e)
        {
            //pauseTimeVal = DateTime.Now;

            //if (pauseTime)
            //{
            //    pauseTime = false;
            //}
            //else
            //{
            //    pauseTime = true;
            //}
        }


        Point mouseDownCoordinates;
        bool mouseDown = false;
        private void pictureBoxGraph_MouseDown(object sender, MouseEventArgs e)
        {
            //MouseEventArgs me = (MouseEventArgs)e;
            //mouseDownCoordinates = me.Location;
            //mouseDown = true;
            ////pauseTime = true;
        }

        private void pictureBoxGraph_MouseUp(object sender, MouseEventArgs e)
        {
            //if (mouseDown)
            //{
            //    //MouseEventArgs me = (MouseEventArgs)e;
            //    //Point coordinates = me.Location;
            //    mouseDown = false;
            //}
        }

        private void pictureBoxGraph_MouseMove(object sender, MouseEventArgs e)
        {
            //if (mouseDown)
            //{
            //    MouseEventArgs me = (MouseEventArgs)e;
            //    Point coordinates = me.Location;

            //    int ymove = coordinates.X - mouseDownCoordinates.X;
            //    //pauseTimeVal.AddSeconds(ymove);
            //    pauseTime = false;
            //    showtime = new TimeSpan(0, 0, (int)showtime.TotalSeconds + (ymove / 100) );

            //    if((int)showtime.TotalSeconds < 10 )
            //    {
            //        TimeSpan showtime = new TimeSpan(0, 0, 10);
            //    }

            //    //mouseDownCoordinates = coordinates;
            //}
        }
    }
}
