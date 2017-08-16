using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace uSensorAktorInterface
{
    public struct rawValuesTupple
    {
        public double raw;
        public DateTime time;
    }

    public class GraphPoints
    {
        //public List<Double> rawValues;
        public List<rawValuesTupple> rawValues;

        public Point[] drawPoints;

        int pointDistance = 1;
        int numberOfSamplestoDraw = 100;
        double scaleFactor = 1;

        public int Xoffset = 0;
        public int Yoffset = 0;

        public bool setPauseTime = false;
        public DateTime paustime = DateTime.Now;


        public int PointDistance
        {
            get { return pointDistance; }
            set
            {
                pointDistance = value;
            }
        }
        

        public double ScaleFactor
        {
            get { return scaleFactor; }
            set
            {
                scaleFactor = value;
            }
        }

        public double getNewest()
        {
            if (rawValues.Count > 0)
                return rawValues[rawValues.Count - 1].raw;
            else
                return (0);
        }

        public int NumberOfSamplestoDraw
        {
            get { return numberOfSamplestoDraw; }
            set
            {
                numberOfSamplestoDraw = value;
                drawPoints = new Point[numberOfSamplestoDraw];
            }
        }

        public TimeSpan TimeToDraw = new TimeSpan(0,0,30);

        public GraphPoints()
        {
            rawValues = new List<rawValuesTupple>();
            drawPoints = new Point[numberOfSamplestoDraw];
            numberOfSamplestoDraw = 1;
        }

        public void addRawValue(double rawV)
        {
            rawValuesTupple ad = new rawValuesTupple();
            ad.raw = rawV;
            ad.time = DateTime.Now;
            rawValues.Add(ad);
        }

        public void makeDrawTimePoints()
        {
            DateTime now = DateTime.Now;

            if(setPauseTime)
            {
                now = paustime;
            }


            TimeSpan timePerPixel = new TimeSpan(TimeToDraw.Ticks / NumberOfSamplestoDraw);

            int scaledValue = 0;

            int lastIndex = rawValues.Count;

            int numberOfPixeltoDraw = NumberOfSamplestoDraw;

            int pixelCount = 0;

            for (int i = lastIndex-1; i > 0; i--)
            {
                if(pixelCount > numberOfPixeltoDraw)
                {
                    break;
                }

                TimeSpan interval_A = new TimeSpan(timePerPixel.Ticks * pixelCount);
                // TimeSpan interval_B = new TimeSpan(timePerPixel.Ticks * (pixelCount - 1));
                // value > now + 1


                //if ( (rawValues[i].time.Add(interval_A)).CompareTo(now) > 0 )
                while (rawValues[i].time.CompareTo(now.Subtract(interval_A)) < 0)
                {
                    if (pixelCount > numberOfPixeltoDraw)
                    {
                        break;
                    }
                    scaledValue = (int)(rawValues[i].raw * scaleFactor);
                    Point p = new Point(Xoffset - pointDistance * pixelCount, Yoffset - scaledValue); 

                    if (!((p.X == 0) && (p.Y == 0)))
                    {
                        if (pixelCount < drawPoints.Count())
                        {
                            drawPoints[pixelCount] = p;
                        }
                    }
                    pixelCount++;
                    interval_A = new TimeSpan(timePerPixel.Ticks * pixelCount);
                }
            }
            if (pixelCount > 0)
            {
                for (int i = pixelCount; i < numberOfPixeltoDraw; i++)
                {
                    drawPoints[i] = drawPoints[pixelCount - 1];
                }
            }
        }
    }
}
