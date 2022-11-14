using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace VIS
{
    public class GraphicsEngine
    {
        private Random R;

        public GraphicsEngine()
        {
            R = new Random();
        }              
        
        public void drawReverseContingencyHistogram(Graphics graphics, Rectangle viewPort, List<double> values, int x_size, int y_size, int starting_point, double SCALE, Brush brush, Pen pen)
        {
            int n = values.Count;

            double max = values.Max();
            double depth;

            for (int i = 0; i < n; i++)
            {
                depth = (70 * values[i]) / max;

                Rectangle histoBar = new Rectangle(i * x_size + x_size, starting_point + 1, x_size, (int)depth);

                graphics.FillRectangle(brush, histoBar);
                graphics.DrawRectangle(pen, histoBar);
            }
        }

        public void drawLandscapeContingencyHistogram(Graphics graphics, Rectangle viewPort, List<double> values, int x_size, int y_size, int starting_point, double SCALE, Brush brush, Pen pen)
        {
            int n = values.Count;

            double max = values.Sum();
            double length;

            for (int i = 0; i < n; i++)
            {
                length = (3 * x_size * values[i]) / max;

                Rectangle histoBar = new Rectangle(starting_point + 1, y_size + i * y_size, (int)(length), y_size);

                graphics.FillRectangle(brush, histoBar);
                graphics.DrawRectangle(pen, histoBar);
            }
        }

        public void drawReverseScatterHistogram(Graphics graphics, PictureBox pic, Rectangle viewPort, List<double> values, List<Interval> intervals, double SCALE, int size, Brush brush, Pen pen, Pen meanPen)
        {
            int n = values.Count;
            double min = intervals[0].LowerBound;
            double width = intervals[n - 1].UpperBound - min;
            double max = values.Max();
            double depth;


            for (int i = 0; i < n; i++)
            {
                //depth = ((size * 2) * values[i]) / max;
                depth = (pic.Bottom - (int)convertYToViewPort(0, viewPort, 0, viewPort.Height) - 100) * values[i] / max;

                Rectangle histoBar = new Rectangle(
                                        (int)convertXToViewPort(i * size, viewPort, 0, viewPort.Width),
                                        (int)convertYToViewPort(0, viewPort, 0, viewPort.Height) + 1,
                                        size,
                                        (int)depth
                                        );

                graphics.FillRectangle(brush, histoBar);

                graphics.DrawRectangle(pen, histoBar);

                graphics.DrawLine(meanPen,
                    (float)convertXToViewPort(intervals[i].Mean, viewPort, min, width),
                    (float)convertYToViewPort(0, viewPort, 0, viewPort.Height) + 1,
                    (float)convertXToViewPort(intervals[i].Mean, viewPort, min, width),
                    (float)convertYToViewPort(0, viewPort, 0, viewPort.Height) + (int)(depth));
            }
        }

        public void drawLandscapeScatterHistogram(Graphics graphics, Rectangle viewPort, List<double> values, List<Interval> intervals, double SCALE, int size, Brush brush, Pen pen, Pen meanPen)
        {
            int n = values.Count;
            double min = intervals[0].LowerBound;
            double height = intervals[n - 1].UpperBound - min;
            double max = values.Sum();
            double length;

            for (int i = 0; i < n; i++)
            {
                length = (2 * size * values[i]) / max;

                Rectangle histoBar = new Rectangle(
                                        (int)convertXToViewPort(viewPort.Width, viewPort, 0, viewPort.Width) + 1,
                                        (int)convertYToViewPort(i * size + size, viewPort, 0, viewPort.Height),
                                        (int)length,
                                        size
                                        );

                graphics.FillRectangle(brush, histoBar);

                graphics.DrawRectangle(pen, histoBar);
                try
                {
                 graphics.DrawLine(meanPen,
                    (float)convertXToViewPort(viewPort.Width, viewPort, 0, viewPort.Width) + 1,
                    (float)convertYToViewPort(intervals[i].Mean, viewPort, min, height),
                    (float)convertXToViewPort(viewPort.Width, viewPort, 0, viewPort.Width) + (int)(length),
                    (float)convertYToViewPort(intervals[i].Mean, viewPort, min, height));

                }catch (OverflowException)
                {

                }
            }
        }        

        public void drawContingencyTable(Graphics graphics, List<List<JointInterval>> matrix,
            int x_size, int y_size, Pen pen, Brush stringBrush)
        {           

            Font font = new Font("Helvetica", (float)8.20);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            List<int> marginal_X = new List<int>();
            List<int> marginal_Y = new List<int>();

            Rectangle rect;

            int dim;
            if (matrix.Count < matrix[0].Count) dim = matrix.Count;
            else dim = matrix[0].Count;

            for (int i = 0; i < dim + 2; i++)
            {
                if (i >= dim)
                {
                    // cells (n-2, n-2) and (n-2, n-1)
                    Rectangle cellMY1 = new Rectangle(dim * x_size, i * y_size, x_size, y_size);
                    //graphics.FillRectangle(innerBrush, cellMY1);
                    graphics.DrawRectangle(pen, cellMY1);

                    // cells (n-1, n-2) and (n-1, n-1)
                    Rectangle cellMY2 = new Rectangle((dim + 1) * x_size, i * y_size, x_size, y_size);
                    //graphics.FillRectangle(innerBrush, cellMY2);
                    graphics.DrawRectangle(pen, cellMY2);

                    if (i == dim) //cell (n-2, 0)
                    {
                        rect = new Rectangle((int)(i * x_size), 0, x_size, y_size);

                        string str = Math.Round(matrix[i - 1][0].X_lowerBound, 2) + Environment.NewLine + Math.Round(matrix[i - 1][0].X_upperBound, 2);
                        graphics.DrawString(str,
                                font, stringBrush,
                                rect, stringFormat);
                    }


                }
                else
                {
                    for (int j = 0; j < dim + 2; j++)
                    {

                        if (j >= dim)
                        {
                            // rows (n-2) and (n-1) until n-2 column
                            Rectangle cellMX = new Rectangle(i * x_size, j * y_size, x_size, y_size);                            
                            graphics.DrawRectangle(pen, cellMX);

                            // columns (n-1) and (n) until m-2
                            Rectangle cellMY = new Rectangle(j * x_size, i * y_size, x_size, y_size);                           
                            graphics.DrawRectangle(pen, cellMY);

                            if ((i == 0) && (j == dim)) //first column last element (interval name)
                            {
                                rect = new Rectangle((int)(i * x_size), j * y_size, x_size, y_size);
                                graphics.DrawString(Math.Round(matrix[i][j - 1].Y_lowerBound, 2) + Environment.NewLine + Math.Round(matrix[i][j - 1].Y_upperBound, 2),
                                font, stringBrush,
                                rect, stringFormat);

                            }
                        }
                        else
                        {
                            // matrix (n-2)x(m-2)
                            Rectangle cell = new Rectangle(i * x_size, j * y_size, x_size, y_size);                            
                            graphics.DrawRectangle(pen, cell);

                            //matrix values
                            rect = new Rectangle(x_size + (int)(i * x_size), (int)y_size + j * y_size, x_size, y_size);
                            graphics.DrawString(matrix[i][j].Joint_frequency.ToString(),
                                    font, stringBrush,                                                                     
                                    rect, stringFormat);

                            if ((i != 0) && (j == 0)) //first row - 1 (interval names line)
                            {
                                rect = new Rectangle((int)(i * x_size), j * y_size, x_size, y_size);

                                graphics.DrawString(Math.Round(matrix[i - 1][j].X_lowerBound, 2) + Environment.NewLine + Math.Round(matrix[i - 1][j].X_upperBound, 2),
                                font, stringBrush,
                                rect, stringFormat);
                            }
                            else if ((i == 0) && (j != 0)) //first column - 1 (interval names column)
                            {
                                rect = new Rectangle((int)(i * x_size), j * y_size, x_size, y_size);
                                graphics.DrawString(Math.Round(matrix[i][j - 1].Y_lowerBound, 2) + Environment.NewLine + Math.Round(matrix[i][j - 1].Y_upperBound, 2),
                                font, stringBrush,
                                rect, stringFormat);
                            }

                        }

                    }
                }
            }



            for (int i = 0; i < dim; i++)
            {
                int marginalXi = 0;

                for (int j = 0; j < dim; j++)
                {

                    try
                    {
                        marginalXi += matrix[i][j].Joint_frequency;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        continue;
                    }

                }
                marginal_X.Add(marginalXi);
            }

            for (int j = 0; j < dim; j++)
            {
                int marginalYj = 0;

                for (int i = 0; i < dim; i++)
                {
                    try
                    {
                        marginalYj += matrix[i][j].Joint_frequency;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        continue;
                    }

                }
                marginal_Y.Add(marginalYj);
            }

            int dimMarginal;

            if (marginal_X.Count < marginal_Y.Count) dimMarginal = marginal_X.Count;
            else dimMarginal = marginal_Y.Count;

            //PRINT MARGINAL X
            for (int i = 0; i < dimMarginal; i++) // marginal x values
            {
                rect = new Rectangle(x_size + x_size * marginal_Y.Count, y_size + i * y_size, x_size, y_size);
                graphics.DrawString(marginal_Y[i].ToString(),
                    font, stringBrush,
                    rect, stringFormat);
            }

            //PRINT MARGINAL Y
            for (int i = 0; i < dimMarginal; i++) // marginal y values
            {
                rect = new Rectangle(x_size + x_size * i, y_size + y_size * marginal_X.Count, x_size, y_size);
                graphics.DrawString(marginal_X[i].ToString(),
                    font, stringBrush,
                    rect, stringFormat);

            }

        }

        public void drawContingencyTable_RelFreq(Graphics graphics, List<List<JointInterval>> matrix,
            List<double> marginal, bool x_or_y, int x_size, int y_size, Pen pen, Brush stringBrush)
        {
            
            Font font = new Font("Helvetica", (float)8.20, FontStyle.Regular);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            List<int> marginal_X = new List<int>();
            List<int> marginal_Y = new List<int>();

            Rectangle rect;

            int dim;
            if (matrix.Count < matrix[0].Count) dim = matrix.Count;
            else dim = matrix[0].Count;

            for (int i = 0; i < dim + 2; i++)
            {
                if (i >= dim)
                {
                    // cells (n-2, n-2) and (n-2, n-1)
                    Rectangle cellMY1 = new Rectangle(dim * x_size, i * y_size, x_size, y_size);
                    graphics.DrawRectangle(pen, cellMY1);

                    // cells (n-1, n-2) and (n-1, n-1)
                    Rectangle cellMY2 = new Rectangle((dim + 1) * x_size, i * y_size, x_size, y_size);
                    graphics.DrawRectangle(pen, cellMY2);

                    if (i == dim) //cell (n-2, 0)
                    {
                        rect = new Rectangle(i * x_size, 0, x_size, y_size);

                        string str = Math.Round(matrix[i - 1][0].X_lowerBound, 2) + Environment.NewLine + Math.Round(matrix[i - 1][0].X_upperBound, 2);
                        graphics.DrawString(str, font, stringBrush, rect, stringFormat);
                    }


                }
                else
                {
                    for (int j = 0; j < dim + 2; j++)
                    {

                        if (j >= dim)
                        {
                            // rows (n-2) and (n-1) until n-2 column
                            Rectangle cellMX = new Rectangle(i * x_size, j * y_size, x_size, y_size);
                            graphics.DrawRectangle(pen, cellMX);

                            // columns (n-1) and (n) until m-2
                            Rectangle cellMY = new Rectangle(j * x_size, i * y_size, x_size, y_size);
                            graphics.DrawRectangle(pen, cellMY);

                            if ((i == 0) && (j == dim)) //first column last element (interval name)
                            {
                                rect = new Rectangle(i * x_size, j * y_size, x_size, y_size);
                                graphics.DrawString(Math.Round(matrix[i][j - 1].Y_lowerBound, 2) + Environment.NewLine + Math.Round(matrix[i][j - 1].Y_upperBound, 2),
                                    font, stringBrush, rect, stringFormat);

    }
}
                        else
                        {
                            // matrix (n-2)x(m-2)
                            Rectangle cell = new Rectangle(i * x_size, j * y_size, x_size, y_size);
                            graphics.DrawRectangle(pen, cell);

                            //matrix values
                            string str;

                            if (x_or_y)
                            {
                                if (marginal[j] != 0)
                                {
                                    str = (Math.Round(matrix[i][j].Joint_frequency / marginal[j], 4) * 100).ToString() + " %";
                                }
                                else
                                {
                                    str = "0 %";
                                }

                            }
                            else
                            {
                                if (marginal[i] != 0)
                                {
                                    str = (Math.Round(matrix[i][j].Joint_frequency / marginal[i], 4) * 100).ToString() + " %";
                                }
                                else
                                {
                                    str = "0 %";
                                }

                            }

                            rect = new Rectangle(x_size + (int)(i * x_size), (int)y_size + j * y_size, x_size, y_size);
                            graphics.DrawString(str, font, stringBrush, rect, stringFormat);

                            if ((i != 0) && (j == 0)) //first row - 1 (interval names line)
                            {
                                rect = new Rectangle(i * x_size, j * y_size, x_size, y_size);
                                graphics.DrawString(Math.Round(matrix[i - 1][j].X_lowerBound, 2) + Environment.NewLine + Math.Round(matrix[i - 1][j].X_upperBound, 2),
                                    font, stringBrush, rect, stringFormat);
                            }
                            else if ((i == 0) && (j != 0)) //first column - 1 (interval names column)
                            {
                                rect = new Rectangle((int)(i * x_size), j * y_size, x_size, y_size);
                                graphics.DrawString(Math.Round(matrix[i][j - 1].Y_lowerBound, 2) + Environment.NewLine + Math.Round(matrix[i][j - 1].Y_upperBound, 2),
                                    font, stringBrush, rect, stringFormat);
                            }

                        }

                    }
                }
            }

            for (int i = 0; i < dim; i++)
            {
                int marginalXi = 0;

                for (int j = 0; j < dim; j++)
                {
                    marginalXi += matrix[i][j].Joint_frequency;
                }
                marginal_X.Add(marginalXi);
            }

            for (int j = 0; j < dim; j++)
            {
                int marginalYj = 0;

                for (int i = 0; i < dim; i++)
                {
                    marginalYj += matrix[i][j].Joint_frequency;
                }
                marginal_Y.Add(marginalYj);
            }

            int dimMarginal;
            if (marginal_X.Count < marginal_Y.Count) dimMarginal = marginal_X.Count;
            else dimMarginal = marginal_Y.Count;

            //PRINT MARGINAL X
            for (int i = 0; i < dimMarginal; i++) // marginal x values
            {
                rect = new Rectangle(x_size + x_size * marginal_Y.Count, y_size + i * y_size, x_size, y_size);
                graphics.DrawString(marginal_Y[i].ToString(), font, stringBrush, rect, stringFormat);
            }

            //PRINT MARGINAL Y
            for (int i = 0; i < dimMarginal; i++) // marginal y values
            {
                rect = new Rectangle(x_size + x_size * i, y_size + y_size * marginal_X.Count, x_size, y_size);
                graphics.DrawString(marginal_X[i].ToString(), font, stringBrush, rect, stringFormat);
            }

        }


        public void drawScatterplot(Graphics graphics, Rectangle viewPort, List<double> x_point, List<double> y_point)
        {


            //Initialize ScatterPlot

            double minX = x_point.Min();
            double maxX = x_point.Max();
            double minY = y_point.Min();
            double maxY = y_point.Max();
            double rangeX = maxX - minX;
            double rangeY = maxY - minY;

            //Initialize ViewPort

            graphics.FillRectangle(Brushes.White, viewPort);
            SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(128, 50, 0, 0));

            for (int i = 0; i < x_point.Count; i++)
            {
                try
                {
                    graphics.DrawEllipse(Pens.Black,
                        new Rectangle(
                           (int)convertXToViewPort(x_point[i], viewPort, minX, rangeX) - 2,
                           (int)convertYToViewPort(y_point[i], viewPort, minY, rangeY) - 2,
                           4, 4)
                        );

                    graphics.FillEllipse(Brushes.Blue,
                            new Rectangle(
                               (int)convertXToViewPort(x_point[i], viewPort, minX, rangeX) - 2,
                               (int)convertYToViewPort(y_point[i], viewPort, minY, rangeY) - 2,
                               4, 4)
                            );
                }
                catch (OverflowException)
                {

                }        
            }
        }

        //Regression Line:  y = (cov/var) * (x - mean(x_points)) + mean(y_points)
        public void drawRegressionLine(Graphics graphics, Pen pen, Rectangle viewPort, double variance, double covariance, double meanX, double meanY,
            List<double> x_points, List<double> y_points)
        {
            float startX, startY, endX, endY;

            double minX = x_points.Min();
            double maxX = x_points.Max();
            double minY = y_points.Min();
            double maxY = y_points.Max();
            double rangeX = maxX - minX;
            double rangeY = maxY - minY;

            List<double> xs = new List<double>(), ys = new List<double>();

            for (int i = 0; i < x_points.Count; i++)
            {
                xs.Add(x_points[i]);
            }

            for (int i = 0; i < y_points.Count; i++)
            {
                ys.Add(y_points[i]);
            }

            startX = (float)convertXToViewPort(xs.Min(), viewPort, minX, rangeX);
            endX = (float)convertXToViewPort(xs.Max(), viewPort, minX, rangeX);

            startY = (float)convertYToViewPort((covariance / variance) * (xs.Min() - meanX) + meanY,

                                                    viewPort, minY, rangeY);

            endY = (float)convertYToViewPort((covariance / variance) * (xs.Max() - meanX) + meanY,

                                                    viewPort, minY, rangeY);

            while ((startY > viewPort.Y + viewPort.Height) || (startY < viewPort.Y))
            {
                xs.Remove(xs.Min());
                startX = (float)convertXToViewPort(xs.Min(), viewPort, minX, rangeX);
                startY = (float)convertYToViewPort((covariance / variance) * (xs.Min() - meanX) + meanY,
                                                    viewPort, minY, rangeY);                
            }

            while ((endY > viewPort.Y + viewPort.Height) || (endY < viewPort.Y))
            {
                xs.Remove(xs.Max());
                endX = (float)convertXToViewPort(xs.Max(), viewPort, minX, rangeX);
                endY = (float)convertYToViewPort((covariance / variance) * (xs.Max() - meanX) + meanY,
                                                    viewPort, minY, rangeY);
            }



            graphics.DrawLine(pen, startX, startY, endX, endY);
        }

        public void drawRegressionLineII(Graphics graphics, Pen pen, Rectangle viewPort, List<double> x_points, List<double> y_points)
        {
            double minX = x_points.Min();
            double maxX = x_points.Max();
            double minY = y_points.Min();
            double maxY = y_points.Max();
            double rangeX = maxX - minX;
            double rangeY = maxY - minY;

            List<System.Drawing.Point> points = new List<System.Drawing.Point>();

            double S11 = 0;
            double sum_x = 0;

            foreach (double x in x_points)
            {
                S11 += Math.Pow(x, 2);
                sum_x += x;
            }

            S11 -= (Math.Pow(sum_x, 2) / (double)x_points.Count);

            double S12 = 0;
            double sum_x2 = 0;

            foreach (double x in x_points)
            {
                S12 += (x * Math.Pow(x, 2));
                sum_x2 += Math.Pow(x, 2);
            }

            S12 -= (sum_x * sum_x2) / (double)x_points.Count;

            double S22 = 0;
            double sum_x4 = Math.Pow(sum_x2, 2);

            foreach (double x in x_points)
            {
                S22 += Math.Pow(x, 4);
            }

            S22 -= sum_x4 / (double)x_points.Count;

            double SY1 = 0;
            double sum_y = 0;

            for (int i = 0; i < x_points.Count; i++)
            {
                SY1 += x_points[i] * y_points[i];
                sum_y += y_points[i];
            }

            SY1 -= (sum_x * sum_y) / (double)x_points.Count;

            double SY2 = 0;

            for (int i = 0; i < x_points.Count; i++)
            {
                SY2 += y_points[i] * Math.Pow(x_points[i], 2);
            }

            SY2 -= (sum_y * sum_x2) / (double)x_points.Count;

            double x_mean = sum_x / (double)x_points.Count;
            double x2_mean = sum_x2 / (double)x_points.Count;
            double y_mean = sum_y / (double)x_points.Count;
            double b2 = ((SY1 * S22) - (SY2 * S12)) / ((S22 * S11) - Math.Pow(S12, 2));
            double b3 = ((SY2 * S11) - (SY1 * S12)) / ((S22 * S11) - Math.Pow(S12, 2));
            double b1 = y_mean - (b2 * x_mean) - (b3 * x2_mean);

            for (int i = 0; i < x_points.Count; i++)
            {
                double y = (Math.Pow(x_points[i], 2) * b3) + (x_points[i] * b2) + b1;
                int viewport_y = (int)convertYToViewPort(y, viewPort, minY, rangeY);
                if (y < maxY)
                {
                    points.Add(new System.Drawing.Point((int)convertXToViewPort(x_points[i], viewPort, minX, rangeX), viewport_y));
                }
            }
            
            try
            {
                points = points.OrderBy(p => p.X).ToList();
                graphics.DrawCurve(pen, points.ToArray());
            }
            catch (ArgumentException)
            {

            }
            
        }

        public void drawWordCloud(Dictionary<string, int> frequencies, Graphics graphics, PictureBox pictureBox)
        {
            SolidBrush brush;
            Font font, font2, font3;
            List<Rectangle> containers = new List<Rectangle>();
            containers.Add(new Rectangle(0, 0, 0, 0));
            Rectangle picture = new Rectangle(pictureBox.Left, pictureBox.Top, pictureBox.Width - 100, pictureBox.Height - 50);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            Dictionary<string, int>.KeyCollection keys = frequencies.Keys;
            Dictionary<string, int>.ValueCollection values = frequencies.Values;
            float maxSize = 100;
            int totalFrequency = values.Sum();

            foreach (String s in keys)
            {
                float fontSize = (float)(maxSize * frequencies[s] / (double)totalFrequency);
                font = new Font("Calibri", fontSize, FontStyle.Regular);
                font2 = new Font("Calibri", 8, FontStyle.Regular);
                font3 = new Font("Calibri", fontSize + 10, FontStyle.Regular);
                Color color = Color.FromArgb(R.Next(50, 255), R.Next(50, 255), R.Next(50, 255));                
                brush = new SolidBrush(color);

                SizeF size = new SizeF();
                size = graphics.MeasureString(s, font);

                bool drawable;
                while (true)
                {
                    drawable = true;

                    Rectangle stringContainer = new Rectangle(R.Next(pictureBox.Left, pictureBox.Right), R.Next(pictureBox.Top, pictureBox.Bottom),
                                                                (int)size.Width + (int)(size.Width / 3.0), (int)size.Height + (int)(size.Height / 3.0));
                    
                    for(int i = 0; i < containers.Count; i++)
                    {
                        if (Rectangle.Intersect(stringContainer, containers[i]) != Rectangle.Empty)
                        {
                            drawable = false;
                            break;
                        }
                    }

                    if ((drawable) && (Rectangle.Intersect(stringContainer, picture) == stringContainer))
                    {
                        
                        if (font.Size < 8)
                        {
                            graphics.DrawString(s, font2, brush, R.Next(pictureBox.Width - 100), R.Next(pictureBox.Height - 50));
                        }
                        else
                        {
                            graphics.DrawString(s, font, brush, stringContainer);
                        }                                         
                        containers.Add(stringContainer);
                        break;
                    }                                        
                }
            }
        }

        public double convertXToViewPort(double x, Rectangle viewPort, double minX, double rangeX)
        {
            return viewPort.Left + viewPort.Width * ((x - minX) / rangeX);
        }

        public double convertYToViewPort(double y, Rectangle viewPort, double minY, double rangeY)
        {
           return viewPort.Top + viewPort.Height - viewPort.Height * ((y - minY) / rangeY);
        }
    }
}
