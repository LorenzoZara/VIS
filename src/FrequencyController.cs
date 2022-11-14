using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS
{
    public class FrequencyController
    {

        public List<List<JointInterval>> getFrequencyMatrix(List<double> x_points, List<double> y_points, List<Interval> x_distribution, List<Interval> y_distribution)
        {

            int numberOfObservations = x_points.Count();
            int dim = x_distribution.Count();
            List<List<JointInterval>> matrix = new List<List<JointInterval>>();

            for (int i = 0; i < dim; i++)
            {
                List<JointInterval> matrixRow = new List<JointInterval>();
                
                for(int j = 0; j < dim; j++)
                {
                    matrixRow.Add(new JointInterval(x_distribution[i].LowerBound, x_distribution[i].UpperBound));

                    matrixRow[j].Y_lowerBound = y_distribution[j].LowerBound;
                    matrixRow[j].Y_upperBound = y_distribution[j].UpperBound;
                }

                matrix.Add(matrixRow);
            }

            Dictionary<int, bool> available_indexes = new Dictionary<int, bool>();
            for(int index = 0; index < x_points.Count; index++)
            {
                available_indexes.Add(index, true);
            }

            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)   
                {
                    for(int index = 0; index < numberOfObservations; index++)
                    {
                        if ((i == dim - 1) || (j == dim - 1))
                        {
                            if (
                            ((x_points[index] >= matrix[i][j].X_lowerBound - 0.0001) && (x_points[index] <= matrix[i][j].X_upperBound + 0.0001))
                            &&
                            ((y_points[index] >= matrix[i][j].Y_lowerBound - 0.0001) && (y_points[index] <= matrix[i][j].Y_upperBound + 0.0001))
                            )
                            {
                                if (available_indexes[index])
                                {
                                    matrix[i][j].Joint_frequency++;
                                    available_indexes[index] = false;                                    
                                }
                                continue;
                            }
                        }

                        else
                        {
                            if (
                                ((x_points[index] >= matrix[i][j].X_lowerBound - 0.0001) && (x_points[index] < matrix[i][j].X_upperBound + 0.0001))
                                &&
                                ((y_points[index] >= matrix[i][j].Y_lowerBound - 0.0001) && (y_points[index] < matrix[i][j].Y_upperBound + 0.0001))
                                )
                            {
                                if (available_indexes[index])
                                {
                                    matrix[i][j].Joint_frequency++;
                                    available_indexes[index] = false;
                                }
                                continue;
                            }
                        }
                    }
                }
            }

            return matrix;            
        }

        public List<double> getMarginalX(List<List<JointInterval>> matrix)
        {
            List<double> marginal = new List<double>();

            int rows = matrix.Count;
            int columns = matrix[0].Count;

            for (int i = 0; i < rows; i++)
            {
                double total = 0;

                for (int j = 0; j < columns; j++)
                {
                    total += matrix[i][j].Joint_frequency;
                }

                marginal.Add(total);
            }


            return marginal;
        }

        public List<double> getMarginalY(List<List<JointInterval>> matrix)
        {
            List<double> marginal = new List<double>();

            int rows = matrix.Count;
            int columns = matrix[0].Count;

            for (int i = 0; i < columns; i++)
            {
                double total = 0;

                for (int j = 0; j < rows; j++)
                {
                    total += matrix[j][i].Joint_frequency;
                }

                marginal.Add(total);
            }

            return marginal;
        }
    }
}
