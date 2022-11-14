using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    public class Path
    {
        private List<Point> path = new List<Point>();

        public Path(List<int> variables)
        {
            double mean = 0;

            for (int i = 0; i < variables.Count; i++)
            {
                if (i == 0)
                {
                    mean = variables[0];
                }
                else
                {
                    mean += (variables[i] - mean) / (double)(i + 1);
                }

                path.Add(new Point(i + 1, mean));
            }
        }

        public Path(List<Point> points)
        {
            path = points;
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
