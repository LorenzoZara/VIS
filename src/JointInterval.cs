using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS
{
    public class JointInterval
    {

        private double x_lowerBound;
        private double x_upperBound;
        private double y_lowerBound;
        private double y_upperBound;
        private int joint_frequency = 0;

        public JointInterval(double x_lowerBound, double x_upperBound, double y_lowerBound, double y_upperBound)
        {
            this.X_lowerBound = x_lowerBound;
            this.X_upperBound = x_upperBound;
            this.Y_lowerBound = y_lowerBound;
            this.Y_upperBound = y_upperBound;
        }

        public JointInterval(double x_lowerBound, double x_upperBound)
        {
            this.X_lowerBound = x_lowerBound;
            this.X_upperBound = x_upperBound;
        }

        public int Joint_frequency { get => joint_frequency; set => joint_frequency = value; }
        public double X_lowerBound { get => x_lowerBound; set => x_lowerBound = value; }
        public double X_upperBound { get => x_upperBound; set => x_upperBound = value; }
        public double Y_lowerBound { get => y_lowerBound; set => y_lowerBound = value; }
        public double Y_upperBound { get => y_upperBound; set => y_upperBound = value; }

    }
}
