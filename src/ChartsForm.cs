using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIS
{
    public partial class ChartsForm : Form
    {
        private List<double> x_points;
        private List<double> y_points;
        private string attrX;
        private string attrY;
        private int no_intervals;
        private Bitmap bitmap;
        private Graphics graphics;
        private Rectangle contingencyViewPort;

        public ChartsForm(List<double> x_points, List<double> y_points, int no_intervals, string attrX, string attrY)
        {
            InitializeComponent();            
            this.x_points = x_points;
            this.y_points = y_points;
            this.no_intervals = no_intervals;
            this.attrX = attrX;
            this.attrY = attrY;

            draw();
        }

        private void draw()
        {
                pictureBox1.Width = this.Width - pictureBox1.Location.X - 10;
                pictureBox1.Height = this.Height - pictureBox1.Location.Y - 70;

                Brush contingencyBrush, scatterBrush;
                Pen contingencyPen, scatterPen, scatterMean;

                try
                {

                    bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                }
                catch (ArgumentException) { }

                graphics = Graphics.FromImage(bitmap);

                GraphicsEngine GE = new GraphicsEngine();
                ProbabilityController PC = new ProbabilityController();
                FrequencyController FC = new FrequencyController();
                ArithmeticController AC = new ArithmeticController();

                int contingencyViewPortStartX = 0;
                int contingencyViewPortStartY = 0;
                int contingencyViewPortRangeX = (pictureBox1.Width / 4) - 1;
                int contingencyViewPortRangeY = (pictureBox1.Height / 4) - 1;

                contingencyViewPort = new Rectangle(
                    contingencyViewPortStartX,
                    contingencyViewPortStartY,
                    contingencyViewPortRangeX,
                    contingencyViewPortRangeY
                    );

                List<List<JointInterval>> matrix;
                List<Interval> distributionX;
                List<Interval> distributionY;

                distributionX = PC.getDistribution(x_points, no_intervals);
                distributionY = PC.getDistribution(y_points, no_intervals);

                if ((!distributionX[0].IsDistribution) || (!distributionY[0].IsDistribution))
                {
                    return;
                }

                matrix = FC.getFrequencyMatrix(x_points, y_points, distributionX, distributionY);

                int x_size = 5 + (int)((double)contingencyViewPortRangeX / (no_intervals + 2));
                int y_size = 5 + (int)((double)contingencyViewPortRangeY / (no_intervals + 2));

                if (contingency_checkbox.Checked)
                {
                    contingencyBrush = Brushes.Salmon;
                    contingencyPen = Pens.Black;
                }
                else
                {
                    contingencyBrush = Brushes.DarkSlateGray;
                    contingencyPen = Pens.DarkSlateGray;
                }

                if (scatter_checkbox.Checked)
                {
                    scatterBrush = Brushes.Salmon;
                    scatterPen = Pens.Blue;
                    scatterMean = new Pen(Color.Yellow, 2);
                }
                else
                {
                    scatterBrush = Brushes.DarkSlateGray;
                    scatterPen = Pens.DarkSlateGray;
                    scatterMean = Pens.DarkSlateGray;
                }

                List<double> marginalX = FC.getMarginalX(matrix);
                List<double> marginalY = FC.getMarginalY(matrix);

                if (absolute_radiobutton.Checked)
                {
                    GE.drawContingencyTable(graphics, matrix, x_size, y_size, Pens.PaleGoldenrod, Brushes.PaleGoldenrod);
                }
                else if (relativeX_radiobutton.Checked)
                {
                    GE.drawContingencyTable_RelFreq(graphics, matrix, marginalX, false, x_size, y_size, Pens.PaleGoldenrod, Brushes.PaleGoldenrod);
                }
                else if (relativeY_radiobutton.Checked)
                {
                    GE.drawContingencyTable_RelFreq(graphics, matrix, marginalY, true, x_size, y_size, Pens.PaleGoldenrod, Brushes.PaleGoldenrod);
                }

                int dim;
                if (matrix.Count < matrix[0].Count) dim = matrix.Count;
                else dim = matrix[0].Count;

                GE.drawReverseContingencyHistogram(graphics, contingencyViewPort, marginalX, x_size, y_size, dim * y_size + 2 * y_size, 0.5, contingencyBrush, contingencyPen);
                GE.drawLandscapeContingencyHistogram(graphics, contingencyViewPort, marginalY, x_size, y_size, dim * x_size + 2 * x_size, 0.5, contingencyBrush, contingencyPen);

                int scatterViewPortStartX = 25;
                int scatterViewPortStartY = (no_intervals + 1 + 5) * y_size;
                int scatterViewPortRangeX = (int)(no_intervals * x_size * 3.5);
                int scatterViewPortRangeY = (int)(no_intervals * y_size * 2);
                pictureBox1.Height = this.Height - pictureBox1.Top - 1;

                Rectangle scatterViewPort = new Rectangle(scatterViewPortStartX, scatterViewPortStartY,
                                                        scatterViewPortRangeX, scatterViewPortRangeY);

                graphics.DrawRectangle(Pens.Blue, scatterViewPort);
                graphics.FillRectangle(Brushes.DarkSlateGray, scatterViewPort);
                GE.drawScatterplot(graphics, scatterViewPort, x_points, y_points);

                double SCALE = 0.5;
                
                List<Interval> x_intervals = PC.getDistribution(x_points, no_intervals);
                List<Interval> y_intervals = PC.getDistribution(y_points, no_intervals);                

                GE.drawReverseScatterHistogram(graphics, pictureBox1, scatterViewPort, marginalX, x_intervals, SCALE, (int)(x_size * 3.5), scatterBrush, scatterPen, scatterMean);
                GE.drawLandscapeScatterHistogram(graphics, scatterViewPort, marginalY, y_intervals, SCALE, (int)(y_size * 2), scatterBrush, scatterPen, scatterMean);

                double x_mean = AC.getMean(x_points);
                double y_mean = AC.getMean(y_points);

                double var_x = AC.getCovariance(x_points, x_points);
                double var_y = AC.getCovariance(y_points, y_points);
                double cov_x = AC.getCovariance(x_points, y_points);

                GE.drawRegressionLine(graphics, new Pen(Color.FromArgb(255, 0, 255, 0), 2), scatterViewPort, var_x, cov_x, x_mean, y_mean, x_points, y_points);
                GE.drawRegressionLineII(graphics, new Pen(Color.FromArgb(255, 255, 0, 0), 2), scatterViewPort, x_points, y_points);

                double SStot = 0, SSexp, SSres;
                for (int i = 0; i < y_points.Count; i++)
                {
                    SStot += Math.Pow(y_points[i] - y_mean, 2);
                }
                SStot /= y_points.Count();

                double r = cov_x / (Math.Sqrt(var_x) * Math.Sqrt(var_y));
                SSexp = SStot * Math.Pow(r, 2);
                SSres = SStot - SSexp;

                correlation_coefficient_label.Text = "Correlation" + Environment.NewLine + "Coefficient" + Environment.NewLine + "r = " + Math.Round(r, 4);
                SStot_label.Text = "Total          = " + Math.Round(SStot, 4);
                SSres_label.Text = "Residual   = " + Math.Round(SSres * 100 / SStot, 4) + " %";
                SSexp_label.Text = "Explained = " + Math.Round(SSexp * 100 / SStot, 4) + " %";

                List<double> quartilesX = AC.getQuartiles(x_points);
                List<double> quartilesY = AC.getQuartiles(y_points);

                for (int i = 0; i < 3; i++) //drawing quartiles lines
                {
                    string str;

                    if (i + 1 == 2) str = "m";
                    else str = "q" + (i + 1).ToString();

                    // x quartiles
                    graphics.DrawLine(Pens.Black,
                        (float)GE.convertXToViewPort(quartilesX[i], scatterViewPort, x_points.Min(), x_points.Max() - x_points.Min()),
                        (float)GE.convertYToViewPort(0, scatterViewPort, 0, scatterViewPort.Height),
                        (float)GE.convertXToViewPort(quartilesX[i], scatterViewPort, x_points.Min(), x_points.Max() - x_points.Min()),
                        (float)GE.convertYToViewPort(scatterViewPort.Height, scatterViewPort, 0, scatterViewPort.Height)
                        );

                    graphics.DrawString(str, new Font(FontFamily.GenericSerif, 10.0f), Brushes.PaleGoldenrod,
                        (float)GE.convertXToViewPort(quartilesX[i], scatterViewPort, x_points.Min(), x_points.Max() - x_points.Min()),
                        (float)GE.convertYToViewPort(scatterViewPort.Height, scatterViewPort, 0, scatterViewPort.Height) - 25);

                    // y quartiles
                    graphics.DrawLine(Pens.Black,
                        (float)GE.convertXToViewPort(scatterViewPort.Width, scatterViewPort, 0, scatterViewPort.Width),
                        (float)GE.convertYToViewPort(quartilesY[i], scatterViewPort, y_points.Min(), y_points.Max() - y_points.Min()),
                        (float)GE.convertXToViewPort(0, scatterViewPort, 0, scatterViewPort.Width),
                        (float)GE.convertYToViewPort(quartilesY[i], scatterViewPort, y_points.Min(), y_points.Max() - y_points.Min())
                        );

                    graphics.DrawString(str, new Font(FontFamily.GenericSerif, 10.0f), Brushes.PaleGoldenrod,
                        (float)GE.convertXToViewPort(0, scatterViewPort, 0, scatterViewPort.Width) - 25,
                        (float)GE.convertYToViewPort(quartilesY[i], scatterViewPort, y_points.Min(), y_points.Max() - y_points.Min()) - 5);
                }

                q1_label1.Text = "1st quartile = " + quartilesX[0];
                m_label1.Text = "median = " + quartilesX[1];
                q3_label1.Text = "3rd quartile = " + quartilesX[2];
                min_label1.Text = "min = " + x_points.Min();
                mean_label1.Text = "mean = " + Math.Round(AC.getMean(x_points), 2);
                max_label1.Text = "max = " + x_points.Max();

                q1_label2.Text = "1st quartile = " + quartilesY[0];
                m_label2.Text = "median = " + quartilesY[1];
                q3_label2.Text = "3rd quartile = " + quartilesY[2];
                min_label2.Text = "min = " + y_points.Min();
                mean_label2.Text = "mean = " + Math.Round(AC.getMean(y_points), 2);
                max_label2.Text = "max = " + y_points.Max();

                //draw coordinates symbols...
                Font font = new Font("Helvetica", (float)13, FontStyle.Italic);

                // ...on contingency table
                graphics.DrawString("y", font, Brushes.PaleGoldenrod, 0, (no_intervals + 2) * y_size + 5);
                graphics.DrawString("x", font, Brushes.PaleGoldenrod, (no_intervals + 2) * x_size + 5, 0);

                // ...on scatterplot
                graphics.DrawString("x", font, Brushes.PaleGoldenrod,
                    (float)GE.convertXToViewPort(scatterViewPort.Width, scatterViewPort, 0, scatterViewPort.Width) + 20,
                    (float)GE.convertYToViewPort(0, scatterViewPort, 0, scatterViewPort.Height) + 5);

                graphics.DrawString("y", font, Brushes.PaleGoldenrod,
                    (float)GE.convertXToViewPort(0, scatterViewPort, 0, scatterViewPort.Width) - 15,
                    (float)GE.convertYToViewPort(scatterViewPort.Height, scatterViewPort, 0, scatterViewPort.Height));

                x_coordinate_label1.Text = "x = " + attrX.ToString();
                y_coordinate_label1.Text = "y = " + attrY.ToString();
                x_groupBox.Text = "x = " + attrX.ToString();
                y_groupBox.Text = "y = " + attrY.ToString();
                pictureBox1.Image = bitmap;
            
        }

        private void contingency_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            draw();
        }

        private void scatter_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            draw();
        }

        private void relativeX_radiobutton_CheckedChanged(object sender, EventArgs e)
        {
            draw();
        }

        private void relativeY_radiobutton_CheckedChanged(object sender, EventArgs e)
        {
            draw();
        }

        private void ChartsForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) draw();
            else draw();
        }        

        private void ChartsForm_ResizeEnd(object sender, EventArgs e)
        {
            draw();
        }
    }
}
