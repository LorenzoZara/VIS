namespace VIS
{
    partial class Home
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.noIntervals_combobox = new System.Windows.Forms.ComboBox();
            this.showCharts_button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chooseY_combobox = new System.Windows.Forms.ComboBox();
            this.chooseX_combobox = new System.Windows.Forms.ComboBox();
            this.newtype_combobox = new System.Windows.Forms.ComboBox();
            this.attribute_combobox = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.change_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.semicolon_radiobutton = new System.Windows.Forms.RadioButton();
            this.tab_radiobutton = new System.Windows.Forms.RadioButton();
            this.comma_radiobutton = new System.Windows.Forms.RadioButton();
            this.colon_radiobutton = new System.Windows.Forms.RadioButton();
            this.names_checkbox = new System.Windows.Forms.CheckBox();
            this.path_richtextbox = new System.Windows.Forms.RichTextBox();
            this.reading_richtextbox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.read_button = new System.Windows.Forms.Button();
            this.open_button = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.wordCloudX_button = new System.Windows.Forms.Button();
            this.wordCloudY_button = new System.Windows.Forms.Button();
            this.wcx_label = new System.Windows.Forms.Label();
            this.wcy_label = new System.Windows.Forms.Label();
            this.error_log = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.label6.Location = new System.Drawing.Point(15, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 19);
            this.label6.TabIndex = 90;
            this.label6.Text = "Number of intervals\r\n";
            // 
            // noIntervals_combobox
            // 
            this.noIntervals_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.noIntervals_combobox.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.noIntervals_combobox.Enabled = false;
            this.noIntervals_combobox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noIntervals_combobox.FormattingEnabled = true;
            this.noIntervals_combobox.Location = new System.Drawing.Point(8, 235);
            this.noIntervals_combobox.Name = "noIntervals_combobox";
            this.noIntervals_combobox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.noIntervals_combobox.Size = new System.Drawing.Size(203, 27);
            this.noIntervals_combobox.TabIndex = 89;
            this.noIntervals_combobox.Text = "5";
            // 
            // showCharts_button
            // 
            this.showCharts_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showCharts_button.BackColor = System.Drawing.Color.DarkGray;
            this.showCharts_button.Enabled = false;
            this.showCharts_button.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showCharts_button.ForeColor = System.Drawing.Color.Black;
            this.showCharts_button.Location = new System.Drawing.Point(7, 293);
            this.showCharts_button.Name = "showCharts_button";
            this.showCharts_button.Size = new System.Drawing.Size(203, 62);
            this.showCharts_button.TabIndex = 85;
            this.showCharts_button.Text = "CARRY OUT STATISTICS!";
            this.showCharts_button.UseVisualStyleBackColor = false;
            this.showCharts_button.Click += new System.EventHandler(this.showCharts_button_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.label8.Location = new System.Drawing.Point(15, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 19);
            this.label8.TabIndex = 84;
            this.label8.Text = "Choose attribute Y";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.label7.Location = new System.Drawing.Point(15, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 19);
            this.label7.TabIndex = 83;
            this.label7.Text = "Choose attribute X";
            // 
            // chooseY_combobox
            // 
            this.chooseY_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseY_combobox.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.chooseY_combobox.Enabled = false;
            this.chooseY_combobox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseY_combobox.FormattingEnabled = true;
            this.chooseY_combobox.Location = new System.Drawing.Point(8, 148);
            this.chooseY_combobox.Name = "chooseY_combobox";
            this.chooseY_combobox.Size = new System.Drawing.Size(158, 27);
            this.chooseY_combobox.TabIndex = 82;
            // 
            // chooseX_combobox
            // 
            this.chooseX_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseX_combobox.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.chooseX_combobox.Enabled = false;
            this.chooseX_combobox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseX_combobox.FormattingEnabled = true;
            this.chooseX_combobox.Location = new System.Drawing.Point(8, 63);
            this.chooseX_combobox.Name = "chooseX_combobox";
            this.chooseX_combobox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chooseX_combobox.Size = new System.Drawing.Size(158, 27);
            this.chooseX_combobox.TabIndex = 81;
            // 
            // newtype_combobox
            // 
            this.newtype_combobox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newtype_combobox.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.newtype_combobox.Enabled = false;
            this.newtype_combobox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newtype_combobox.FormattingEnabled = true;
            this.newtype_combobox.Location = new System.Drawing.Point(114, 574);
            this.newtype_combobox.Name = "newtype_combobox";
            this.newtype_combobox.Size = new System.Drawing.Size(108, 27);
            this.newtype_combobox.TabIndex = 79;
            // 
            // attribute_combobox
            // 
            this.attribute_combobox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.attribute_combobox.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.attribute_combobox.Enabled = false;
            this.attribute_combobox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attribute_combobox.FormattingEnabled = true;
            this.attribute_combobox.Location = new System.Drawing.Point(114, 537);
            this.attribute_combobox.Name = "attribute_combobox";
            this.attribute_combobox.Size = new System.Drawing.Size(108, 27);
            this.attribute_combobox.TabIndex = 78;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dataGridView.BackgroundColor = System.Drawing.Color.PaleGoldenrod;
            this.dataGridView.GridColor = System.Drawing.Color.PaleGoldenrod;
            this.dataGridView.Location = new System.Drawing.Point(239, 276);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 100;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Salmon;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.Size = new System.Drawing.Size(539, 408);
            this.dataGridView.TabIndex = 77;
            // 
            // change_button
            // 
            this.change_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.change_button.BackColor = System.Drawing.Color.DarkGray;
            this.change_button.Enabled = false;
            this.change_button.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change_button.ForeColor = System.Drawing.Color.Black;
            this.change_button.Location = new System.Drawing.Point(10, 308);
            this.change_button.Name = "change_button";
            this.change_button.Size = new System.Drawing.Size(209, 56);
            this.change_button.TabIndex = 76;
            this.change_button.Text = "Change data type";
            this.change_button.UseVisualStyleBackColor = false;
            this.change_button.Click += new System.EventHandler(this.change_button_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.label4.Location = new System.Drawing.Point(15, 576);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 19);
            this.label4.TabIndex = 75;
            this.label4.Text = "New Type";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Location = new System.Drawing.Point(10, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 74;
            this.label3.Text = "Attribute";
            // 
            // treeView
            // 
            this.treeView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.treeView.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.treeView.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Italic);
            this.treeView.Location = new System.Drawing.Point(8, 30);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(204, 183);
            this.treeView.TabIndex = 72;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.semicolon_radiobutton);
            this.groupBox1.Controls.Add(this.tab_radiobutton);
            this.groupBox1.Controls.Add(this.comma_radiobutton);
            this.groupBox1.Controls.Add(this.colon_radiobutton);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.groupBox1.Location = new System.Drawing.Point(12, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 130);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select a delimiter";
            // 
            // semicolon_radiobutton
            // 
            this.semicolon_radiobutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.semicolon_radiobutton.AutoSize = true;
            this.semicolon_radiobutton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semicolon_radiobutton.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.semicolon_radiobutton.Location = new System.Drawing.Point(6, 46);
            this.semicolon_radiobutton.Name = "semicolon_radiobutton";
            this.semicolon_radiobutton.Size = new System.Drawing.Size(118, 23);
            this.semicolon_radiobutton.TabIndex = 18;
            this.semicolon_radiobutton.Text = "Semicolon    ;";
            this.semicolon_radiobutton.UseVisualStyleBackColor = true;
            // 
            // tab_radiobutton
            // 
            this.tab_radiobutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tab_radiobutton.AutoSize = true;
            this.tab_radiobutton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_radiobutton.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.tab_radiobutton.Location = new System.Drawing.Point(6, 101);
            this.tab_radiobutton.Name = "tab_radiobutton";
            this.tab_radiobutton.Size = new System.Drawing.Size(124, 23);
            this.tab_radiobutton.TabIndex = 20;
            this.tab_radiobutton.Text = "Tabulation \'\\t\'";
            this.tab_radiobutton.UseVisualStyleBackColor = true;
            // 
            // comma_radiobutton
            // 
            this.comma_radiobutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comma_radiobutton.AutoSize = true;
            this.comma_radiobutton.Checked = true;
            this.comma_radiobutton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comma_radiobutton.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.comma_radiobutton.Location = new System.Drawing.Point(6, 20);
            this.comma_radiobutton.Name = "comma_radiobutton";
            this.comma_radiobutton.Size = new System.Drawing.Size(118, 23);
            this.comma_radiobutton.TabIndex = 17;
            this.comma_radiobutton.TabStop = true;
            this.comma_radiobutton.Text = "Comma         ,";
            this.comma_radiobutton.UseVisualStyleBackColor = true;
            // 
            // colon_radiobutton
            // 
            this.colon_radiobutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.colon_radiobutton.AutoSize = true;
            this.colon_radiobutton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colon_radiobutton.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.colon_radiobutton.Location = new System.Drawing.Point(6, 74);
            this.colon_radiobutton.Name = "colon_radiobutton";
            this.colon_radiobutton.Size = new System.Drawing.Size(118, 23);
            this.colon_radiobutton.TabIndex = 19;
            this.colon_radiobutton.Text = "Colon            :";
            this.colon_radiobutton.UseVisualStyleBackColor = true;
            // 
            // names_checkbox
            // 
            this.names_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.names_checkbox.AutoSize = true;
            this.names_checkbox.Checked = true;
            this.names_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.names_checkbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.names_checkbox.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.names_checkbox.Location = new System.Drawing.Point(239, 112);
            this.names_checkbox.Name = "names_checkbox";
            this.names_checkbox.Size = new System.Drawing.Size(194, 23);
            this.names_checkbox.TabIndex = 70;
            this.names_checkbox.Text = "Contains columns\' name";
            this.names_checkbox.UseVisualStyleBackColor = true;
            this.names_checkbox.CheckedChanged += new System.EventHandler(this.names_checkbox_CheckedChanged);
            // 
            // path_richtextbox
            // 
            this.path_richtextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.path_richtextbox.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.path_richtextbox.Location = new System.Drawing.Point(239, 71);
            this.path_richtextbox.Name = "path_richtextbox";
            this.path_richtextbox.Size = new System.Drawing.Size(539, 22);
            this.path_richtextbox.TabIndex = 68;
            this.path_richtextbox.Text = "";
            this.path_richtextbox.TextChanged += new System.EventHandler(this.path_richtextbox_TextChanged);
            // 
            // reading_richtextbox
            // 
            this.reading_richtextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.reading_richtextbox.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.reading_richtextbox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reading_richtextbox.Location = new System.Drawing.Point(239, 136);
            this.reading_richtextbox.Name = "reading_richtextbox";
            this.reading_richtextbox.ReadOnly = true;
            this.reading_richtextbox.Size = new System.Drawing.Size(539, 120);
            this.reading_richtextbox.TabIndex = 67;
            this.reading_richtextbox.Text = "";
            this.reading_richtextbox.WordWrap = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Salmon;
            this.label1.Location = new System.Drawing.Point(291, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 36);
            this.label1.TabIndex = 65;
            this.label1.Text = "VIS - Virtual Inferential Statistician";
            // 
            // read_button
            // 
            this.read_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.read_button.BackColor = System.Drawing.Color.DarkGray;
            this.read_button.Enabled = false;
            this.read_button.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.read_button.Location = new System.Drawing.Point(15, 276);
            this.read_button.Name = "read_button";
            this.read_button.Size = new System.Drawing.Size(209, 31);
            this.read_button.TabIndex = 64;
            this.read_button.Text = "Read CSV";
            this.read_button.UseVisualStyleBackColor = false;
            this.read_button.Click += new System.EventHandler(this.read_button_Click);
            // 
            // open_button
            // 
            this.open_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.open_button.BackColor = System.Drawing.Color.DarkGray;
            this.open_button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.open_button.FlatAppearance.BorderSize = 0;
            this.open_button.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.open_button.Location = new System.Drawing.Point(12, 65);
            this.open_button.Margin = new System.Windows.Forms.Padding(0);
            this.open_button.Name = "open_button";
            this.open_button.Size = new System.Drawing.Size(212, 32);
            this.open_button.TabIndex = 63;
            this.open_button.Text = "Select CSV file";
            this.open_button.UseVisualStyleBackColor = false;
            this.open_button.Click += new System.EventHandler(this.open_button_Click);
            // 
            // clear_button
            // 
            this.clear_button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.clear_button.BackColor = System.Drawing.Color.DarkGray;
            this.clear_button.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear_button.Location = new System.Drawing.Point(784, 644);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(217, 40);
            this.clear_button.TabIndex = 91;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = false;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // wordCloudX_button
            // 
            this.wordCloudX_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wordCloudX_button.BackColor = System.Drawing.Color.DarkGray;
            this.wordCloudX_button.Font = new System.Drawing.Font("Azonix", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordCloudX_button.ForeColor = System.Drawing.Color.Black;
            this.wordCloudX_button.Location = new System.Drawing.Point(172, 63);
            this.wordCloudX_button.Name = "wordCloudX_button";
            this.wordCloudX_button.Size = new System.Drawing.Size(39, 25);
            this.wordCloudX_button.TabIndex = 92;
            this.wordCloudX_button.Text = "W";
            this.wordCloudX_button.UseVisualStyleBackColor = false;
            this.wordCloudX_button.Click += new System.EventHandler(this.wordCloudX_button_Click);
            this.wordCloudX_button.MouseEnter += new System.EventHandler(this.wordCloudX_button_MouseEnter);
            this.wordCloudX_button.MouseLeave += new System.EventHandler(this.wordCloudX_button_MouseLeave);
            // 
            // wordCloudY_button
            // 
            this.wordCloudY_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wordCloudY_button.BackColor = System.Drawing.Color.DarkGray;
            this.wordCloudY_button.Font = new System.Drawing.Font("Azonix", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordCloudY_button.ForeColor = System.Drawing.Color.Black;
            this.wordCloudY_button.Location = new System.Drawing.Point(172, 150);
            this.wordCloudY_button.Name = "wordCloudY_button";
            this.wordCloudY_button.Size = new System.Drawing.Size(39, 25);
            this.wordCloudY_button.TabIndex = 93;
            this.wordCloudY_button.Text = "W";
            this.wordCloudY_button.UseVisualStyleBackColor = false;
            this.wordCloudY_button.Click += new System.EventHandler(this.wordCloudY_button_Click);
            this.wordCloudY_button.MouseEnter += new System.EventHandler(this.wordCloudY_button_MouseEnter);
            this.wordCloudY_button.MouseLeave += new System.EventHandler(this.wordCloudY_button_MouseLeave);
            // 
            // wcx_label
            // 
            this.wcx_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wcx_label.AutoSize = true;
            this.wcx_label.Font = new System.Drawing.Font("Calibri", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.wcx_label.ForeColor = System.Drawing.Color.Salmon;
            this.wcx_label.Location = new System.Drawing.Point(45, 93);
            this.wcx_label.Name = "wcx_label";
            this.wcx_label.Size = new System.Drawing.Size(126, 24);
            this.wcx_label.TabIndex = 94;
            this.wcx_label.Text = "WORD CLOUD";
            this.wcx_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.wcx_label.Visible = false;
            // 
            // wcy_label
            // 
            this.wcy_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wcy_label.AutoSize = true;
            this.wcy_label.Font = new System.Drawing.Font("Calibri", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.wcy_label.ForeColor = System.Drawing.Color.Salmon;
            this.wcy_label.Location = new System.Drawing.Point(45, 179);
            this.wcy_label.Name = "wcy_label";
            this.wcy_label.Size = new System.Drawing.Size(126, 24);
            this.wcy_label.TabIndex = 95;
            this.wcy_label.Text = "WORD CLOUD";
            this.wcy_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.wcy_label.Visible = false;
            // 
            // error_log
            // 
            this.error_log.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.error_log.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.error_log.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error_log.Location = new System.Drawing.Point(790, 137);
            this.error_log.Name = "error_log";
            this.error_log.ReadOnly = true;
            this.error_log.Size = new System.Drawing.Size(206, 119);
            this.error_log.TabIndex = 98;
            this.error_log.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.label2.Location = new System.Drawing.Point(820, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 29);
            this.label2.TabIndex = 99;
            this.label2.Text = "Message Log";
            // 
            // timer1
            // 
            this.timer1.Interval = 65;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.chooseX_combobox);
            this.groupBox2.Controls.Add(this.chooseY_combobox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.showCharts_button);
            this.groupBox2.Controls.Add(this.wcx_label);
            this.groupBox2.Controls.Add(this.noIntervals_combobox);
            this.groupBox2.Controls.Add(this.wcy_label);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.wordCloudX_button);
            this.groupBox2.Controls.Add(this.wordCloudY_button);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.groupBox2.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.groupBox2.Location = new System.Drawing.Point(784, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 364);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GRAPHICS";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.treeView);
            this.groupBox3.Controls.Add(this.change_button);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.groupBox3.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.groupBox3.Location = new System.Drawing.Point(6, 311);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 373);
            this.groupBox3.TabIndex = 102;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data types";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Salmon;
            this.label5.Location = new System.Drawing.Point(533, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 13);
            this.label5.TabIndex = 103;
            this.label5.Text = "A virtual friend for your Statistics need.";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.label9.Location = new System.Drawing.Point(832, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 65);
            this.label9.TabIndex = 104;
            this.label9.Text = "1 - Select a CSV\r\n2 - Read your CSV\r\n3 - Set your favorite data types\r\n4 - Get yo" +
    "ur CHARTS!\r\n5 - Get your WORLD CLOUD!";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.label10.Location = new System.Drawing.Point(12, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 105;
            this.label10.Text = "or drag and drop one";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1008, 690);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.error_log);
            this.Controls.Add(this.names_checkbox);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.newtype_combobox);
            this.Controls.Add(this.attribute_combobox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.path_richtextbox);
            this.Controls.Add(this.reading_richtextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.read_button);
            this.Controls.Add(this.open_button);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Text = "Home - VIS";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox noIntervals_combobox;
        private System.Windows.Forms.Button showCharts_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox chooseY_combobox;
        private System.Windows.Forms.ComboBox chooseX_combobox;
        private System.Windows.Forms.ComboBox newtype_combobox;
        private System.Windows.Forms.ComboBox attribute_combobox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button change_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox names_checkbox;
        private System.Windows.Forms.RichTextBox path_richtextbox;
        private System.Windows.Forms.RichTextBox reading_richtextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button read_button;
        private System.Windows.Forms.Button open_button;
        private System.Windows.Forms.RadioButton semicolon_radiobutton;
        private System.Windows.Forms.RadioButton tab_radiobutton;
        private System.Windows.Forms.RadioButton comma_radiobutton;
        private System.Windows.Forms.RadioButton colon_radiobutton;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button wordCloudX_button;
        private System.Windows.Forms.Button wordCloudY_button;
        private System.Windows.Forms.Label wcx_label;
        private System.Windows.Forms.Label wcy_label;
        private System.Windows.Forms.RichTextBox error_log;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

