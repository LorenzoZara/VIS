using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    public class ProbabilityController
    {
        private Random R;

        public ProbabilityController()
        {
            this.R = new Random();


        }

        //returns the outcome of a B(1, p)
        private int bernoulli_outcome(double p)
        {
            double random_outcome = R.NextDouble();

            if (random_outcome <= p) return 1;
            else return 0;
        }

        //returns a list of rademacher outcomes
        private int rademacher_outcome()
        {
            double p = 0.5;

            double random_outcome = R.NextDouble();
            if (random_outcome <= p) return 1;
            else return -1;
        }

        //returns a list of bernoulli outcomes
        public List<int> createListOfBernoullis(int n, double p)
        {
            List<int> bernoullis = new List<int>();

            for (int i = 0; i < n; i++)
            {
                bernoullis.Add(bernoulli_outcome(p));
            }

            return bernoullis;
        }

        // MARSAGLIA POLAR METHOD: https://en.wikipedia.org/wiki/Marsaglia_polar_method
        private static double spare;
        private static bool hasSpare = false;
        private double normal_outcome(double mean, double stdDev) // Marsaglia polar method 
        {
            if (hasSpare)
            {
                hasSpare = false;
                return spare * stdDev + mean;
            }
            else
            {
                double u, v, s;

                do
                {
                    u = R.NextDouble() * 2 - 1;
                    v = R.NextDouble() * 2 - 1;
                    s = u * u + v * v;

                } while (s >= 1 || s == 0);

                s = Math.Sqrt(-2.0 * Math.Log(s) / s);

                spare = v * s;
                hasSpare = true;

                return mean + stdDev * u * s;
            }
        }

        //returns a list of normal outcomes
        public List<double> createListOfNormals(int n, double mean, double stdDev)
        {
            List<double> normals = new List<double>();

            for (int i = 0; i < n; i++)
            {
                normals.Add(normal_outcome(mean, stdDev));
            }

            return normals;
        }

        //returns a list of rademacher outcomes (p = 50%)
        public List<int> createListOfRademachers(int n)
        {
            List<int> rademachers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                rademachers.Add(rademacher_outcome());
            }

            return rademachers;
        }

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
            /*
            for (double i = min; i < max; i += intervalSize)
            {
                Interval interval = new Interval(i, i + intervalSize);
                intervals.Add(interval);
            }*/

            double lower = min;
            double upper = lower + intervalSize;

            for(int i = 0; i < intervalNumber; i++)
            {
                Interval interval = new Interval(lower, upper);
                lower = upper;
                upper = lower + intervalSize;
                intervals.Add(interval);
            }

            foreach (int value in values)
            {
                foreach (Interval currentInterval in intervals)
                {
                    if (value < currentInterval.UpperBound && value >= currentInterval.LowerBound)
                    {
                        currentInterval.Counter++;
                        currentInterval.Mean += (value - currentInterval.Mean) / currentInterval.Counter;
                    }
                }
            }

            intervals[0].IsDistribution = true;

            return intervals;
        }

        //returns the distribution in a specific step of a graph with (x=trial, y=rel_freq)
        public List<Interval> getSpecificDistribution(List<Path> paths, int noIntervals, int step)
        {


            List<double> frequencies = new List<double>();

            for (int i = 0; i < paths.Count; i++)
            {
                for (int k = 0; k < paths[i].getPath().Count; k++)
                {
                    if (paths[i].getPath()[k].x == step)
                    {
                        frequencies.Add(paths[i].getPath()[k].y);
                    }
                }
            }

            List<Interval> intervals = new List<Interval>();

            double intervalLength = 1.0 / (double)noIntervals;

            for (int i = 0; i < noIntervals; i++)
            {
                intervals.Add(new Interval(i * intervalLength, (i + 1) * intervalLength));
            }

            for (int i = 0; i < intervals.Count; i++)
            {
                for (int k = 0; k < frequencies.Count; k++)
                {
                    if ((frequencies[k] >= intervals[i].LowerBound) && (frequencies[k] < intervals[i].UpperBound))
                    {
                        intervals[i].Counter++;
                    }
                }
            }

            return intervals;
        }

        //returns the distribution in a specific step of a graph with (x=trial, y=random_walk_position)
        public List<Interval> getSpecificWalkingDistribution(List<WalkingPath> paths, int noIntervals, int step)
        {
            double maxPoint = 0;
            double minPoint = 0;

            List<double> frequencies = new List<double>();

            for (int i = 0; i < paths.Count; i++)
            {
                for (int k = 0; k < paths[i].getPath().Count; k++)
                {
                    if (paths[i].getPath()[k].x == step)
                    {
                        frequencies.Add(paths[i].getPath()[k].y);

                        if (paths[i].getPath()[k].y > maxPoint)
                            maxPoint = paths[i].getPath()[k].y;

                        if (paths[i].getPath()[k].y < minPoint)
                            minPoint = paths[i].getPath()[k].y;
                    }
                }
            }

            List<Interval> intervals = new List<Interval>();

            double intervalLength = (maxPoint - minPoint + 1.0) / (double)noIntervals;

            for (int i = 0; i < noIntervals; i++)
            {
                intervals.Add(new Interval(i * intervalLength, (i + 1) * intervalLength));
            }

            for (int i = 0; i < intervals.Count; i++)
            {
                for (int k = 0; k < frequencies.Count; k++)
                {
                    if ((frequencies[k] >= intervals[i].LowerBound) && (frequencies[k] < intervals[i].UpperBound))
                    {
                        intervals[i].Counter++;
                    }
                }
            }

            return intervals;
        }

        //returns the distribution in a specific step of a graph with (x=trial, y=random_walk_position)
        public List<Interval> getSpecificWalkingDistributionNeg(List<WalkingPath> paths, int noIntervals, int step)
        {
            double maxPoint = 0;
            double minPoint = 0;

            List<double> frequencies = new List<double>();

            for (int i = 0; i < paths.Count; i++)
            {
                for (int k = 0; k < paths[i].getPath().Count; k++)
                {
                    if (paths[i].getPath()[k].x == step)
                    {
                        frequencies.Add(paths[i].getPath()[k].y);

                        if (paths[i].getPath()[k].y > maxPoint)
                            maxPoint = paths[i].getPath()[k].y;

                        if (paths[i].getPath()[k].y < minPoint)
                            minPoint = paths[i].getPath()[k].y;
                    }
                }
            }

            List<Interval> intervals = new List<Interval>();

            double intervalLength = (maxPoint - minPoint + 1.0) / (double)noIntervals;

            /*for (int i = -noIntervals / 2; i < noIntervals / 2; i++)
            {
                intervals.Add(new Interval(i * intervalLength, (i + 1) * intervalLength));
            }*/

            for (int i = 0; i < noIntervals; i++)
            {
                intervals.Add(new Interval(minPoint + i * intervalLength, minPoint + (i + 1) * intervalLength));
            }

            for (int i = 0; i < intervals.Count; i++)
            {
                for (int k = 0; k < frequencies.Count; k++)
                {
                    if ((frequencies[k] >= intervals[i].LowerBound) && (frequencies[k] < intervals[i].UpperBound))
                    {
                        intervals[i].Counter++;
                    }
                }
            }

            return intervals;
        }

        public List<Interval> getDistancesDistribution(List<List<int>> values, int intervalNumber)
        {
            List<Interval> intervals = new List<Interval>();
            int min = 200;
            int max = 0;

            foreach (List<int> cons in values)
            {
                foreach (int value in cons)
                {
                    if (value > max)
                    {
                        max = value;
                    }
                    if (value < min)
                    {
                        min = value;
                    }
                }
            }


            double intervalSize = (max - min) / (double)intervalNumber;

            for (double i = min; i < max; i += intervalSize)
            {
                Interval interval = new Interval(i, i + intervalSize);
                intervals.Add(interval);
            }

            foreach (List<int> cons in values)
            {
                foreach (int value in cons)
                {
                    foreach (Interval currentInterval in intervals)
                    {
                        if (value < currentInterval.UpperBound && value >= currentInterval.LowerBound)
                        {
                            currentInterval.Counter++;
                        }
                    }
                }
            }

            return intervals;
        }

        public List<int> getConsecutiveDistances(List<int> values)
        {
            int previous = 0;
            bool firstCase = true;

            List<int> distances = new List<int>();

            for (int i = 0; i < values.Count(); i++)
            {
                if (values[i] == 1)
                {
                    if (!firstCase)
                    {
                        distances.Add(i - previous);
                    }
                    else
                    {
                        firstCase = false;
                    }

                    previous = i;

                }
            }

            return distances;
        }

        public List<int> getFromOriginDistances(List<int> values)
        {
            List<int> distances = new List<int>();

            for (int i = 0; i < values.Count(); i++)
            {
                if (values[i] == 1)
                {
                    distances.Add(i);
                }
            }

            return distances;
        }

        //return a list of uniform random variables
        public List<UniformRandomVariable> getUniformRandomVariables(int n, int minUniformLowerBound, int maxUniformUpperBound, int rand)
        {
            List<UniformRandomVariable> variables = new List<UniformRandomVariable>();

            int inf, sup;

            for (int i = 0; i < n; i++)
            {
                if (rand == 1)
                {
                    inf = R.Next(minUniformLowerBound, maxUniformUpperBound);
                    sup = R.Next(inf, maxUniformUpperBound);


                }
                else
                {
                    inf = minUniformLowerBound;
                    sup = maxUniformUpperBound;
                }

                UniformRandomVariable var = new UniformRandomVariable(inf, sup);

                variables.Add(var);
            }

            return variables;
        }

        //return the list of means obtained from a list of processes, each of which is a list of trial's outcome.
        public List<double> getMeans(int number_of_proc, int number_of_rv, List<UniformRandomVariable> variables, List<List<int>> processes)
        {
            List<double> means = new List<double>();

            for (int i = 0; i < number_of_proc; i++)
            {
                means.Add(0);

                List<int> proc_values = new List<int>();

                for (int j = 0; j < number_of_rv; j++)
                {
                    proc_values.Add(variables[j].getValue());

                    means[i] += (proc_values[j] - means[i]) / (double)(j + 1);

                }

                processes.Add(proc_values);
            }

            return means;

        }
    }
}
