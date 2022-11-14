using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS
{
    public class Interval
    {
        private double lowerBound;
        private double upperBound;
        private int counter;
        private double mean;
        private bool isDistribution;
        private bool isLast;

        public Interval(double lowerBound, double upperBound)
        {
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
            this.Counter = 0;
            this.Mean = 0;
            this.IsLast = false;
        }

        public double LowerBound { get => lowerBound; set => lowerBound = value; }
        public double UpperBound { get => upperBound; set => upperBound = value; }
        public int Counter { get => counter; set => counter = value; }
        public double Mean { get => mean; set => mean = value; }
        public bool IsDistribution { get => isDistribution; set => isDistribution = value; }
        public bool IsLast { get => isLast; set => isLast = value; }
    }
}
