using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS
{
    public class ArithmeticController
    {
        public double getMean(List<double> values)
        {
            if (values.Count == 0)
            {
                return 0;
            }

            double mean = values[0];

            for (int i = 1; i < values.Count; i++)
            {
                mean += (values[i] - mean) / (double)(i + 1);
            }

            return mean;
        }

        public double getCovariance(List<double> values_X, List<double> values_Y)
        {

            if (values_X.Count == 0 || values_Y.Count == 0)
            {
                return 0;
            }

            double mean_x = values_X[0];
            double mean_y = values_Y[0];
            double cov = 0;

            for (int i = 1; i < values_X.Count; i++)
            {
                mean_y += (values_Y[i] - mean_y) / (double)(i + 1);
                cov += (values_X[i] - mean_x) * (values_Y[i] - mean_y) / (double)(i + 1);
                mean_x += (values_X[i] - mean_x) / (double)(i + 1);
            }

            return cov;
        }

        public List<double> getQuartiles(List<double> points)
        {
            List<double> values = new List<double>();

            for(int i = 0; i < points.Count; i++)
            {
                values.Add(points[i]);
            }

            values.Sort();

            List<double> quartiles = new List<double>();

            double q1, m, q3;

            q1 = values[(int)Math.Ceiling((double)(values.Count / 4))];
            m = values[(int)Math.Ceiling((double)(values.Count / 2))];
            q3 = values[(int)Math.Ceiling((double)(values.Count * 3 / 4))];

            quartiles.Add(q1); quartiles.Add(m); quartiles.Add(q3);

            return quartiles;
        }

    }
}
