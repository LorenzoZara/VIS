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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.path_richtextbox.AllowDrop = true;
            this.path_richtextbox.DragDrop += new DragEventHandler(path_richtextbox_DragDrop);
            first_line = names_checkbox.Checked;
            disable(read_button);
            disable(attribute_combobox);
            disable(newtype_combobox);
            disable(change_button);
            disable(chooseX_combobox);
            disable(chooseY_combobox);
            this.noIntervals_combobox.Items.AddRange(INTERVALS_CHOICE.ToArray());
            this.noIntervals_combobox.DropDownWidth = INTERVALS_CHOICE.Count();
            this.noIntervals_combobox.Text = "5";
            disable(noIntervals_combobox);
            disable(showCharts_button);
            errors = 0;
            pulses = 0;
            
        }

        private const string APPNAME = "VIS - Virtual Inferential Statistician";

        private string[] DELIMITERS;
        private const int PAD = 5;
        private readonly string[] DATATYPES_STRINGS = { "bool", "Int32", "Int64", "double", "string" };
        private readonly string[] INTERVALS_CHOICE = { "2", "3", "4", "5", "6", "7", "8", "9", "10"};
        List<Type> DATATYPES = new List<Type> { new bool().GetType(), new Int32().GetType(), new Int64().GetType(),
                                                new double().GetType(), "".GetType()};

        private int errors;
        private int pulses;
        

        bool first_line = false; //first line of variable names

        int type;
        /*
         * 0 -> boolean
         * 1 -> 32-bits integer
         * 2 -> 64-bits integer
         * 3 -> double
         * 4 -> DateTime
         * 5 -> string
        */

        // dictionary for columns' name-and-types
        Dictionary<string, Type> header = new Dictionary<string, Type>();

        // columns names
        List<string> columnNames = new List<String>();

        // column names found
        bool columnNamesFound = false;

        List<bool> typeCaptured = new List<bool>();

        // +++ PAY ATTENTION: deprecated +++
        List<List<dynamic>> datapoints = new List<List<dynamic>>();

        // ---> evolution of datapoints
        List<DataPoint> observations = new List<DataPoint>();


        /* DRAG AND DROP implementation */
        private void path_richtextbox_DragDrop(object sender, DragEventArgs e)
        {
            clear_button_Click(sender, e);

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));

                foreach (string path in filePaths)

                    if (System.IO.File.Exists(path))
                    {
                        path_richtextbox.Clear();
                        path_richtextbox.Text = System.IO.Path.GetFullPath(path);
                    }
            }
        }
        /*******************************/


        /* OPEN FILE DIALOG implementation */
        private void open_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog.ShowDialog();

            if (!openFileDialog.FileName.Equals(""))
            {
                clear_button_Click(sender, e);
                path_richtextbox.Clear();
                path_richtextbox.Text = openFileDialog.FileName.ToString();
                errors = 0;
            }
        }
        /**********************************/
       
        private void rawData_()
        {
            // empty the reading rich text box
            reading_richtextbox.Clear();
            error_log.Clear();

            try
            {
                using (Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(path_richtextbox.Text))
                {
                    parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;

                    parser.Delimiters = new string[] { "@$@$RRR$@$@" };

                    string[] currentValue;
                    datapoints.Clear();

                    while (!parser.EndOfData)
                    {


                        try
                        {
                            currentValue = parser.ReadFields();
                        }
                        catch (Microsoft.VisualBasic.FileIO.MalformedLineException)
                        {
                            continue;
                        }

                        for (int i = 0; i < currentValue.Count(); i++)
                        {
                            reading_richtextbox.AppendText(currentValue[i] + Environment.NewLine);
                        }
                    }
                }
            }
            catch (System.ArgumentNullException)
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "("+errors+")No file selected.");
                errors++;
            }
            catch (System.IO.FileNotFoundException)
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "("+errors+")File not found.");
                errors++;
            }


        }


        /* CSV READING implementation */
        private void read_button_Click(object sender, EventArgs e)
        {            
            chooseX_combobox.Items.Clear();
            chooseY_combobox.Items.Clear();
            attribute_combobox.Items.Clear();
            newtype_combobox.Items.Clear();
            first_line = true;
            typeCaptured.Clear();
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            observations.Clear();
            datapoints.Clear();
            columnNames.Clear();
            columnNamesFound = false;

            header.Clear();



            // CONTROL: path must not be null
            if (path_richtextbox.Text.Equals(""))
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "(" + errors + ")Please select a file.");
                errors++;
                return;
            }

            // CONTROL: file must be a csv one
            if (!path_richtextbox.Text.Contains(".csv") && path_richtextbox.Text != "")
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "(" + errors + ")The file must be in .csv format!");
                errors++;
                return;
            }
            /* TEXT FIELD PARSER implementation */

            try
            {

            

            using (Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(path_richtextbox.Text))
            {
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;

                // POINT OUT THE DELIMITER
                if (comma_radiobutton.Checked) DELIMITERS = new string[] { "," };
                else if (semicolon_radiobutton.Checked) DELIMITERS = new string[] { ";" };
                else if (colon_radiobutton.Checked) DELIMITERS = new string[] { ":" };
                else if (tab_radiobutton.Checked) DELIMITERS = new string[] { "\t" };

                parser.Delimiters = DELIMITERS;

                string[] currentValue;
                datapoints.Clear();

                while (!parser.EndOfData)
                {

                    /****************************************************************************************************************************/

                    currentValue = parser.ReadFields();

                    // the case in which the csv file contains the first line with variables' name
                    if (first_line)
                    {
                        first_line = false;

                        if (names_checkbox.Checked)
                        {
                            for (int i = 0; i < currentValue.Count(); i++)
                            {
                                //reading_richtextbox.AppendText(currentValue[i].PadRight(PAD, ' '));

                                columnNames.Add(currentValue[i]); // adding column name to column names string-list

                                // evolution: datagrid
                                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                                col.Name = columnNames[i];
                                dataGridView.Columns.Add(col);

                                columnNamesFound = true;

                                typeCaptured.Add(false);




                            }

                            continue; // goto the next line / entry
                        }
                        else 
                        {
                            if (!columnNamesFound)
                            {
                                for (int i = 0; i < currentValue.Count(); i++)
                                {
                                    columnNames.Add("Attribute " + i);

                                    typeCaptured.Add(false);
                                }

                                foreach (string elem in columnNames)
                                {
                                    // evolution: datagrid
                                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                                    col.Name = elem;
                                    dataGridView.Columns.Add(col);

                                    columnNamesFound = true;

                                    continue; // goto the next line / entry
                                }
                            }
                        }
                    }

                    List<dynamic> attributes = new List<dynamic>();

                    try
                    {
                        

                        for (int i = 0; i < currentValue.Count(); i++)
                        {
                            dynamic convertedValue = ParseString(currentValue[i]);

                            Type datatype;

                            switch (type)
                            {
                                case 0:
                                    attributes.Add((bool)convertedValue);
                                    datatype = new bool().GetType();
                                    break;
                                case 1:
                                    attributes.Add((Int32)convertedValue);
                                    datatype = new Int32().GetType();
                                    break;
                                case 2:
                                    attributes.Add((Int64)convertedValue);
                                    datatype = new Int64().GetType();
                                    break;
                                case 3:
                                    attributes.Add((double)convertedValue);
                                    datatype = new double().GetType();
                                    break;
                                case 4:
                                    attributes.Add((DateTime)convertedValue);
                                    datatype = new DateTime().GetType();
                                    break;
                                case 5:
                                    attributes.Add(currentValue[i]);
                                    datatype = "".GetType();
                                    break;
                                default:
                                    datatype = Type.GetType("null");
                                    timer1.Enabled = true;
                                    error_log.AppendText(Environment.NewLine + "(" + errors + ")No data type recognized");
                                    errors++;
                                    break;
                            }

                            if (!typeCaptured[i])
                            { //type guessing at second line

                                header.Add(columnNames[i], datatype);

                                typeCaptured[i] = true;

                            }



                        }
                        reading_richtextbox.AppendText(Environment.NewLine);

                        datapoints.Add(attributes);

                        observations.Add(new DataPoint(attributes));

                    }
                    catch (Microsoft.VisualBasic.FileIO.MalformedLineException exception)
                    {
                        timer1.Enabled = true;
                        error_log.AppendText(Environment.NewLine + "(" + errors + ")Line " + exception.Message + " is invalid.");
                        errors++;
                    }
                    /************************************/
                }

                for (int i = 0; i < observations.Count(); i++)
                {
                    dataGridView.Rows.Add(observations[i].getAttributes().ToArray());

                    dataGridView.AutoResizeRow(i);
                }

                dataGridView.AutoResizeColumns();
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                attribute_combobox.Items.AddRange(columnNames.ToArray());
                attribute_combobox.DropDownWidth = columnNames.Count();

                newtype_combobox.Items.AddRange(DATATYPES_STRINGS.ToArray());
                newtype_combobox.DropDownWidth = DATATYPES_STRINGS.Count();

                chooseX_combobox.Items.AddRange(columnNames.ToArray());
                chooseY_combobox.Items.AddRange(columnNames.ToArray());
            }
            }
            catch (System.IO.FileNotFoundException)
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "(" + errors + ")File not found.");
                errors = 0;
                return;
            }
            /******************************************************************************************************************************/

            enable(attribute_combobox);
            enable(newtype_combobox);
            enable(change_button);
            enable(chooseX_combobox);
            enable(chooseY_combobox);
            enable(noIntervals_combobox);
            enable(showCharts_button);

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.Width = dataGridView.Width / dataGridView.ColumnCount;
            }

            hints_button_Click(sender, e);
        }

        /* GET DATA TYPE implementation */

        private dynamic ParseString(string str)
        {

            bool boolValue;     //0
            Int32 intValue;     //1
            Int64 bigintValue;  //2
            double doubleValue; //3
            DateTime dateTimeValue; //4


            if (bool.TryParse(str, out boolValue))
            {
                type = 0;
                return boolValue;  //return boolean conversion
            }
            else
            if (Int32.TryParse(str, out intValue))
            {
                type = 1;
                return intValue;    //return 32-bits integer conversion
            }
            else
            if (Int64.TryParse(str, out bigintValue))
            {
                type = 2;
                return bigintValue;
            }
            else
            if (double.TryParse(str, out doubleValue))
            {
                type = 3;                
                try
                {
                    return double.Parse(str, System.Globalization.CultureInfo.InvariantCulture);
                } catch (FormatException)
                {
                    return doubleValue;
                }
            }
            else
            if (DateTime.TryParse(str, out dateTimeValue))
            {
                type = 4;
                return dateTimeValue;
            }
            else
            {
                type = 5;
                return str;
            }
        }

        private void hints_button_Click(object sender, EventArgs e)
        {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            treeView.Nodes.Add("FIELDS");

            try
            {
                for (int i = 0; i < observations[0].getAttributes().Count; i++)
                {
                    treeView.Nodes[0].Nodes.Add(columnNames[i]);
                    treeView.Nodes[0].Nodes[i].Nodes.Add(header[columnNames[i]].ToString());
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "(" + errors + ")Types unavailable: no CSV File read yet.");
                errors++;
            }

            treeView.EndUpdate();
            treeView.ExpandAll();
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            if (!attribute_combobox.Text.Equals("") && !newtype_combobox.Text.Equals(""))
            {
                for (int i = 0; i < DATATYPES.Count(); i++)
                {
                    if (newtype_combobox.Text.Equals(DATATYPES_STRINGS[i]))
                    {
                        header[attribute_combobox.Text] = DATATYPES[i];
                    }
                }
            }


            hints_button_Click(this, e);
        }

        private void wordCloudX_button_Click(object sender, EventArgs e)
        {
            string attrX = chooseX_combobox.Text;

            Type X_type = null;

            try
            {
                X_type = header[attrX];
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "(" + errors + ")No attribute selected or found.");
                errors++;
                return;
            }

            if (X_type != "".GetType())
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "(" + errors + ")Convert type into a string first!");
                errors++;
                return;
            }

            int x_index = 0;

            for (int i = 0; i < columnNames.Count(); i++)
            {
                if (attrX.Equals(columnNames[i])) x_index = i;
            }

            List<string> x_strings = new List<string>();

            string str;
            

            for (int i = 0; i < observations.Count; i++)
            {
                try
                {
                    str = observations[i].getAttributes()[x_index].ToString();

                    if (str == null)
                    {
                        x_strings.Add("");
                    }
                    else
                    {
                        x_strings.Add(str);
                    }
                }
                catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
                {
                    
                    x_strings.RemoveAt(x_strings.Count - 1);
                    continue;
                }


            }

            WordCloudForm form = new WordCloudForm(x_strings, attrX);
            try
            {
                form.Show();
            }
            catch (System.InvalidOperationException)
            {

            }
        }

        private void wordCloudY_button_Click(object sender, EventArgs e)
        {
            string attrY = chooseY_combobox.Text;

            Type Y_type = null;

            try
            {
                Y_type = header[attrY];
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "(" + errors + ")No attribute selected or found.");
                errors++;
                return;
            }

            if (Y_type != "".GetType())
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "(" + errors + ")Convert type into a string first!");
                errors++;
                return;
            }

            int y_index = 0;

            for (int i = 0; i < columnNames.Count(); i++)
            {
                if (attrY.Equals(columnNames[i])) y_index = i;
            }

            List<string> y_strings = new List<string>();

            string str;

            for (int i = 0; i < observations.Count; i++)
            {
                try
                {
                    str = observations[i].getAttributes()[y_index].ToString();

                    if (str == null)
                    {
                        y_strings.Add("");
                    }
                    else
                    {
                        y_strings.Add(str);
                    }
                }
                catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
                {

                    y_strings.RemoveAt(y_strings.Count - 1);
                    continue;
                }


            }

            WordCloudForm form = new WordCloudForm(y_strings, attrY);
            try
            {
                form.Show();
            }
            catch (System.InvalidOperationException)
            {

            }
        }

        private void showCharts_button_Click(object sender, EventArgs e)
        {


            string attrX = chooseX_combobox.Text;
            string attrY = chooseY_combobox.Text;

            Type X_type = null;
            Type Y_type = null;

            try
            {
                X_type = header[attrX];
                Y_type = header[attrY];
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "(" + errors + ")No attributes selected or found.");
                errors++;
                return;
            }

            if ((
                (X_type != new Int32().GetType())
                &&
                (X_type != new Int64().GetType())
                &&
                (X_type != new double().GetType())
                )
                ||
                (Y_type != new Int32().GetType())
                &&
                (Y_type != new Int64().GetType())
                &&
                (Y_type != new double().GetType())
                )
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "(" + errors + ")Attributes are not drawable!");
                errors++;
                return;
            }

            int x_index = 0, y_index = 0;

            for (int i = 0; i < columnNames.Count(); i++)
            {
                if (attrX.Equals(columnNames[i])) x_index = i;
                if (attrY.Equals(columnNames[i])) y_index = i;
            }

            numericStats(attrX, attrY, x_index, y_index, X_type, Y_type);
        }

        private void numericStats(string attrX, string attrY, int x_index, int y_index, Type x_type, Type y_type)
        {
            List<double> x_points = new List<double>();
            List<double> y_points = new List<double>();

            for (int i = 0; i < observations.Count; i++)
            {
                try
                {
                    if (observations[i].getAttributes()[x_index] == null)
                    {
                        x_points.Add((Double)0);
                    }
                    else
                    {
                        
                        if (x_type == new Int32().GetType() || x_type == new Int64().GetType())
                        {
                            string str = Convert.ToString(observations[i].getAttributes()[x_index]);
                            int separator1 = str.IndexOf(".");
                            int separator2 = str.IndexOf(",");
                            if (separator1 > 0)
                            {
                                str = str.Remove(separator1, str.Length - separator1);
                            }
                            if (separator2 > 0)
                            {
                                str = str.Remove(separator2, str.Length - separator2);
                            }
                            double dbl = double.Parse(str);
                            x_points.Add(dbl);
                        }
                        else
                        {
                            x_points.Add(observations[i].getAttributes()[x_index]);
                        }
                    }
                }
                catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
                {
                    continue;
                }
                catch (FormatException)
                {
                    x_points.Add((Double)0);
                }

                try
                {
                    if (observations[i].getAttributes()[y_index] == null)
                    {
                        y_points.Add((Double)0);
                    }
                    else
                    {                        
                        if (y_type == new Int32().GetType() || y_type == new Int64().GetType())
                        {
                            string str = Convert.ToString(observations[i].getAttributes()[y_index]);
                            int separator1 = str.IndexOf(".");
                            int separator2 = str.IndexOf(",");
                            if (separator1 > 0)
                            {
                                str = str.Remove(separator1, str.Length - separator1);
                            }
                            if (separator2 > 0)
                            {
                                str = str.Remove(separator2, str.Length - separator2);
                            }
                            double dbl = double.Parse(str);
                            y_points.Add(dbl);
                        }
                        else
                        {
                            y_points.Add(observations[i].getAttributes()[y_index]);
                        }
                    }
                }
                catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
                {
                    x_points.RemoveAt(x_points.Count - 1);
                    continue;
                }
                catch (FormatException)
                {
                    y_points.Add((Double)0);
                }


            }

            int no_intervals = Convert.ToInt16(noIntervals_combobox.Text);

            
            try
            {
                ChartsForm form = new ChartsForm(x_points, y_points, no_intervals, attrX, attrY);
                form.Show();
            }
            catch (System.InvalidOperationException)
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "(" + errors + ")Attributes are not drawable!");
                errors++;
                return;
            }
            catch (OverflowException)
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "(" + errors + ")Attributes are not drawable!");
                errors++;
                return;
            }
        }

        private void names_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            first_line = names_checkbox.Checked;
        }

        /**********************************/

        private void enable(Button b)
        {
            b.Enabled = true;
            b.BackColor = System.Drawing.Color.DarkGray;
        }

        private void enable(ComboBox cb)
        {
            cb.Enabled = true;
        }

        private void disable(Button b)
        {
            b.Enabled = false;
            b.BackColor = System.Drawing.Color.DarkSlateGray;
        }

        private void disable(ComboBox cb)
        {
            cb.Enabled = false;
        }

        private void path_richtextbox_TextChanged(object sender, EventArgs e)
        {
            if (!path_richtextbox.Text.Contains(".csv") && path_richtextbox.Text != "")
            {
                timer1.Enabled = true;
                error_log.AppendText(Environment.NewLine + "(" + errors + ")File must be a .csv!");
                errors++;
                clear_button_Click(sender, e, error_log);
                return;
            }
            errors = 0;
            
            enable(read_button);
            if (path_richtextbox.Text == "")
            {
                disable(read_button);
                return;
            }
            rawData_();
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            chooseX_combobox.Text = "";
            chooseY_combobox.Text = "";
            chooseX_combobox.Items.Clear();
            chooseY_combobox.Items.Clear();
            attribute_combobox.Text = "";
            newtype_combobox.Text = "";
            attribute_combobox.Items.Clear();
            newtype_combobox.Items.Clear();
            first_line = true;
            typeCaptured.Clear();
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            observations.Clear();
            datapoints.Clear();
            columnNames.Clear();
            columnNamesFound = false;
            error_log.Clear();
            errors = 0;

            header.Clear();

            disable(read_button);
            disable(attribute_combobox);
            disable(newtype_combobox);
            disable(change_button);
            disable(chooseX_combobox);
            disable(chooseY_combobox);
            disable(noIntervals_combobox);
            disable(showCharts_button);

            path_richtextbox.Clear();
            reading_richtextbox.Clear();
            treeView.Nodes.Clear();
        }

        private void clear_button_Click(object sender, EventArgs e, RichTextBox except)
        {
            chooseX_combobox.Text = "";
            chooseY_combobox.Text = "";
            chooseX_combobox.Items.Clear();
            chooseY_combobox.Items.Clear();
            attribute_combobox.Text = "";
            newtype_combobox.Text = "";
            attribute_combobox.Items.Clear();
            newtype_combobox.Items.Clear();
            first_line = true;
            typeCaptured.Clear();
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            observations.Clear();
            datapoints.Clear();
            columnNames.Clear();
            columnNamesFound = false;

            header.Clear();

            disable(read_button);
            disable(attribute_combobox);
            disable(newtype_combobox);
            disable(change_button);
            disable(chooseX_combobox);
            disable(chooseY_combobox);
            disable(noIntervals_combobox);
            disable(showCharts_button);

            path_richtextbox.Clear();
            reading_richtextbox.Clear();
            treeView.Nodes.Clear();
        }

        private void wordCloudX_button_MouseEnter(object sender, EventArgs e)
        {
            wcx_label.Visible = true;
        }

        private void wordCloudX_button_MouseLeave(object sender, EventArgs e)
        {
            wcx_label.Visible = false;
        }

        private void wordCloudY_button_MouseEnter(object sender, EventArgs e)
        {
            wcy_label.Visible = true;
        }

        private void wordCloudY_button_MouseLeave(object sender, EventArgs e)
        {
            wcy_label.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pulses % 2 == 0)
            {
                error_log.BackColor = Color.Red;
            }
            else
            {
                error_log.BackColor = Color.PaleGoldenrod;
            }

            pulses++;
            if (pulses == 8)
            {
                timer1.Enabled = false;
                pulses = 0;
            }
        }
    }
}
