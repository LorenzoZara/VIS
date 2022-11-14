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
    public partial class WordCloudForm : Form
    {
        private List<string> strings;
        private string attr;
        private Bitmap bitmap;
        private Graphics graphics;
        private Dictionary<string, int> frequencies;

        public WordCloudForm(List<string> strings, string attr)
        {
            InitializeComponent();
            this.strings = strings;
            this.attr = attr;

            frequencies = new Dictionary<string, int>();

            for(int i = 0; i < strings.Count; i++)
            {
                try
                {
                    frequencies.Add(strings[i], 1);
                }
                catch (ArgumentException)
                {
                    frequencies[strings[i]] ++ ;
                }
            }


            draw(frequencies);
        }

        private void initialize_pic()
        { 
            pictureBox1.Width = Width - pictureBox1.Location.X - 2;
            pictureBox1.Height = Height - pictureBox1.Location.Y - 2;
        }

        private void draw(Dictionary<string, int> frequencies)
        {
            initialize_pic();

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            GraphicsEngine GE = new GraphicsEngine();

            GE.drawWordCloud(frequencies, graphics, pictureBox1);

            pictureBox1.Image = bitmap;


        }

        private void WordCloudForm_ResizeEnd(object sender, EventArgs e)
        {
            draw(frequencies);
        }
    }
}
