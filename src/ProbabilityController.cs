using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS
{
    public class ProbabilityController
    {
        //returns the distribution of a list of values given the number of frequency intervals
        public List<Interval> getDistribution(List<double> values, int intervalNumber)
        {
            List<Interval> intervals = new List<Interval>();

            double min, max;

            try
            {
                min = values.Min();
                max = values.Max();
            }
            catch (System.InvalidOperationException)
            {
                intervals.Add(new Interval(0, 0));
                intervals[0].IsDistribution = false;
                return intervals;
            }


            double intervalSize = (max - min) / (double)intervalNumber;
            double lower = min;
            double upper = lower + intervalSize;

            for(int i = 0; i < intervalNumber; i++)
            {
                Interval interval = new Interval(lower, upper);
                lower = upper;
                upper = lower + intervalSize;
                if (i == intervalNumber - 1) interval.IsLast = true;
                intervals.Add(interval);                
            }

            Console.WriteLine(values.Min());

            foreach (double value in values)
            {
                foreach (Interval currentInterval in intervals)
                {
                    if (value < currentInterval.UpperBound && value >= currentInterval.LowerBound)
                    {
                        currentInterval.Counter++;
                        currentInterval.Mean += (value - currentInterval.Mean) / currentInterval.Counter;
                    }

                    if (value >= values.Max() && currentInterval.IsLast)
                    {
                        currentInterval.Counter++;
                        currentInterval.Mean += (value - currentInterval.Mean) / currentInterval.Counter;
                    }
                }                
            }

            intervals[0].IsDistribution = true;
            Console.WriteLine(values.Min());

            return intervals;
        }
    }
}
