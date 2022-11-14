using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    public class WalkingPath
    {
        private List<Point> path = new List<Point>();

        public WalkingPath(List<int> variables)
        {
            double walk = 0;

            for (int i = 0; i < variables.Count; i++)
            {
                if (i != 0)
                {
                    walk += (variables[i]);
                }

                path.Add(new Point(i, walk));
            }
        }

        //20_A: dX = mean * dt + dev * sqrt(dt) * N(0, 1) where dt = 1 / n
        //22_A_GBM: dX = X * (mean * dt + dev * sqrt(dt) * N(0, 1)) where dt = 1 / n
        public WalkingPath(List<double> variables, double mean, double dev, string type, double startingValue)
        {
            double walk = startingValue;

            for (int i = 0; i < variables.Count; i++)
            {
                if (i != 0)
                {
                    if (type.Equals("arithmetic"))
                    {
                        walk += (variables[i] * dev * Math.Sqrt(1.0 / variables.Count)) + mean / variables.Count();
                    }

                    else if (type.Equals("geometric"))
                    {
                        walk += walk * (variables[i] * dev * Math.Sqrt(1.0 / variables.Count) + mean / variables.Count());
                    }
                }

                path.Add(new Point(i, walk));
            }
        }

        //22_A_V: dX = k * (P - X) * dt + dev * sqrt(dt) * N(0, 1)
        public WalkingPath(List<double> variables, double k, double P, double dev, double startingValue)
        {
            double walk = startingValue;

            for (int i = 0; i < variables.Count; i++)
            {
                if (i != 0)
                {
                    walk += (k * (P - walk) / variables.Count) + dev * variables[i] / Math.Sqrt(variables.Count);
                }

                path.Add(new Point(i, walk));
            }
        }

        public WalkingPath(List<Point> points)
        {
            path = points;
        }

        public double getMaximumY(double reference)
        {
            double maximum = reference;

            foreach (Point point in this.path)
            {
                if (point.y > maximum)
                {
                    maximum = point.y;
                }
            }

            return maximum;
        }

        public double getMinimumY(double reference)
        {
            double minimum = reference;

            foreach (Point point in this.path)
            {
                if (point.y < minimum)
                {
                    minimum = point.y;
                }
            }

            return minimum;
        }

        public List<double> getXs()
        {
            List<double> x_coordinates = new List<double>();

            foreach (Point p in this.getPath())
            {
                x_coordinates.Add(p.x);
            }

            return x_coordinates;
        }

        public List<double> getYs()
        {
            List<double> y_coordinates = new List<double>();

            foreach (Point p in this.getPath())
            {
                y_coordinates.Add(p.y);
            }

            return y_coordinates;
        }

        public List<Point> getPath()
        {
            return this.path;
        }

        public void setPath(List<Point> path)
        {
            this.path = path;
        }
    }
}
