namespace dslsa
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_Deselect = new System.Windows.Forms.Button();
            this.textBox_Results = new System.Windows.Forms.TextBox();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_County = new System.Windows.Forms.TextBox();
            this.textBox_City = new System.Windows.Forms.TextBox();
            this.listView_County = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.listView_City = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_PN = new System.Windows.Forms.TextBox();
            this.textBox_ProjName = new System.Windows.Forms.TextBox();
            this.listView_PN = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.listView_ProjName = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.button_SearchPDFs = new System.Windows.Forms.Button();
            this.comboBox_State = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label_LoginMessage = new System.Windows.Forms.Label();
            this.tabControl_Login = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label_UpdateDB = new System.Windows.Forms.Label();
            this.button_UpdateDB = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button_UpdatePDFPath = new System.Windows.Forms.Button();
            this.button_UpdateKMZPath = new System.Windows.Forms.Button();
            this.button_UpdateExcelPath = new System.Windows.Forms.Button();
            this.textBox_NewPDFPath = new System.Windows.Forms.TextBox();
            this.textBox_NewKMZPath = new System.Windows.Forms.TextBox();
            this.textBox_NewExcelPath = new System.Windows.Forms.TextBox();
            this.label_CurrentPDFPath = new System.Windows.Forms.Label();
            this.label_CurrentKMZPath = new System.Windows.Forms.Label();
            this.label_CurrentExcelPath = new System.Windows.Forms.Label();
            this.label_PDFPathMessage = new System.Windows.Forms.Label();
            this.label_KMZPathMessage = new System.Windows.Forms.Label();
            this.label_ExcelPathMessage = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_Login = new System.Windows.Forms.Button();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl_Login.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160, 587);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_Deselect);
            this.tabPage1.Controls.Add(this.textBox_Results);
            this.tabPage1.Controls.Add(this.gmap);
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.button_SearchPDFs);
            this.tabPage1.Controls.Add(this.comboBox_State);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1152, 559);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Application";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_Deselect
            // 
            this.button_Deselect.Location = new System.Drawing.Point(311, 9);
            this.button_Deselect.Name = "button_Deselect";
            this.button_Deselect.Size = new System.Drawing.Size(105, 23);
            this.button_Deselect.TabIndex = 8;
            this.button_Deselect.Text = "Deselect All";
            this.button_Deselect.UseVisualStyleBackColor = true;
            this.button_Deselect.Click += new System.EventHandler(this.button_Deselect_Click);
            // 
            // textBox_Results
            // 
            this.textBox_Results.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_Results.Location = new System.Drawing.Point(609, 7);
            this.textBox_Results.Multiline = true;
            this.textBox_Results.Name = "textBox_Results";
            this.textBox_Results.ReadOnly = true;
            this.textBox_Results.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Results.Size = new System.Drawing.Size(537, 44);
            this.textBox_Results.TabIndex = 7;
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemory = 5;
            this.gmap.Location = new System.Drawing.Point(609, 57);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(537, 496);
            this.gmap.TabIndex = 5;
            this.gmap.Zoom = 4D;
            this.gmap.Load += new System.EventHandler(this.gmap_Load);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_County, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox_City, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.listView_County, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.listView_City, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 311);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(580, 242);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Search for county...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Search for city...";
            // 
            // textBox_County
            // 
            this.textBox_County.Location = new System.Drawing.Point(3, 18);
            this.textBox_County.Name = "textBox_County";
            this.textBox_County.Size = new System.Drawing.Size(280, 23);
            this.textBox_County.TabIndex = 3;
            this.textBox_County.TextChanged += new System.EventHandler(this.textBox_County_TextChanged);
            // 
            // textBox_City
            // 
            this.textBox_City.Location = new System.Drawing.Point(293, 18);
            this.textBox_City.Name = "textBox_City";
            this.textBox_City.Size = new System.Drawing.Size(283, 23);
            this.textBox_City.TabIndex = 4;
            this.textBox_City.TextChanged += new System.EventHandler(this.textBox_City_TextChanged);
            // 
            // listView_County
            // 
            this.listView_County.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listView_County.Location = new System.Drawing.Point(3, 45);
            this.listView_County.Name = "listView_County";
            this.listView_County.Size = new System.Drawing.Size(280, 192);
            this.listView_County.TabIndex = 9;
            this.listView_County.UseCompatibleStateImageBehavior = false;
            this.listView_County.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "County/Borough";
            this.columnHeader3.Width = 276;
            // 
            // listView_City
            // 
            this.listView_City.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.listView_City.Location = new System.Drawing.Point(293, 45);
            this.listView_City.Name = "listView_City";
            this.listView_City.Size = new System.Drawing.Size(280, 192);
            this.listView_City.TabIndex = 10;
            this.listView_City.UseCompatibleStateImageBehavior = false;
            this.listView_City.View = System.Windows.Forms.View.Details;
            this.listView_City.Click += new System.EventHandler(this.listView_City_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "City";
            this.columnHeader4.Width = 276;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_PN, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_ProjName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.listView_PN, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.listView_ProjName, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 57);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(580, 248);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search for project number...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Search for project name...";
            // 
            // textBox_PN
            // 
            this.textBox_PN.Location = new System.Drawing.Point(3, 18);
            this.textBox_PN.Name = "textBox_PN";
            this.textBox_PN.Size = new System.Drawing.Size(280, 23);
            this.textBox_PN.TabIndex = 1;
            this.textBox_PN.TextChanged += new System.EventHandler(this.textBox_PN_TextChanged);
            // 
            // textBox_ProjName
            // 
            this.textBox_ProjName.Location = new System.Drawing.Point(293, 18);
            this.textBox_ProjName.Name = "textBox_ProjName";
            this.textBox_ProjName.Size = new System.Drawing.Size(280, 23);
            this.textBox_ProjName.TabIndex = 2;
            this.textBox_ProjName.TextChanged += new System.EventHandler(this.textBox_ProjName_TextChanged);
            // 
            // listView_PN
            // 
            this.listView_PN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView_PN.Location = new System.Drawing.Point(3, 46);
            this.listView_PN.MultiSelect = false;
            this.listView_PN.Name = "listView_PN";
            this.listView_PN.Size = new System.Drawing.Size(280, 199);
            this.listView_PN.TabIndex = 7;
            this.listView_PN.UseCompatibleStateImageBehavior = false;
            this.listView_PN.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Project Number";
            this.columnHeader1.Width = 276;
            // 
            // listView_ProjName
            // 
            this.listView_ProjName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listView_ProjName.Location = new System.Drawing.Point(293, 46);
            this.listView_ProjName.Name = "listView_ProjName";
            this.listView_ProjName.Size = new System.Drawing.Size(283, 199);
            this.listView_ProjName.TabIndex = 8;
            this.listView_ProjName.UseCompatibleStateImageBehavior = false;
            this.listView_ProjName.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Project Name";
            this.columnHeader2.Width = 276;
            // 
            // button_SearchPDFs
            // 
            this.button_SearchPDFs.Location = new System.Drawing.Point(454, 10);
            this.button_SearchPDFs.Name = "button_SearchPDFs";
            this.button_SearchPDFs.Size = new System.Drawing.Size(132, 23);
            this.button_SearchPDFs.TabIndex = 6;
            this.button_SearchPDFs.Text = "Search for PDFs";
            this.button_SearchPDFs.UseVisualStyleBackColor = true;
            this.button_SearchPDFs.Click += new System.EventHandler(this.button_SearchPDFs_Click);
            // 
            // comboBox_State
            // 
            this.comboBox_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_State.FormattingEnabled = true;
            this.comboBox_State.Location = new System.Drawing.Point(96, 10);
            this.comboBox_State.Name = "comboBox_State";
            this.comboBox_State.Size = new System.Drawing.Size(145, 23);
            this.comboBox_State.TabIndex = 0;
            this.comboBox_State.SelectedValueChanged += new System.EventHandler(this.comboBoxState_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a state...";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label_LoginMessage);
            this.tabPage2.Controls.Add(this.tabControl_Login);
            this.tabPage2.Controls.Add(this.button_Login);
            this.tabPage2.Controls.Add(this.textBox_Password);
            this.tabPage2.Controls.Add(this.textBox_Username);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1152, 559);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Admin";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label_LoginMessage
            // 
            this.label_LoginMessage.Location = new System.Drawing.Point(7, 123);
            this.label_LoginMessage.Name = "label_LoginMessage";
            this.label_LoginMessage.Size = new System.Drawing.Size(198, 46);
            this.label_LoginMessage.TabIndex = 7;
            // 
            // tabControl_Login
            // 
            this.tabControl_Login.Controls.Add(this.tabPage3);
            this.tabControl_Login.Controls.Add(this.tabPage4);
            this.tabControl_Login.Location = new System.Drawing.Point(234, 3);
            this.tabControl_Login.Name = "tabControl_Login";
            this.tabControl_Login.SelectedIndex = 0;
            this.tabControl_Login.Size = new System.Drawing.Size(912, 550);
            this.tabControl_Login.TabIndex = 6;
            this.tabControl_Login.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label_UpdateDB);
            this.tabPage3.Controls.Add(this.button_UpdateDB);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(904, 522);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Database Update";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label_UpdateDB
            // 
            this.label_UpdateDB.Location = new System.Drawing.Point(19, 76);
            this.label_UpdateDB.Name = "label_UpdateDB";
            this.label_UpdateDB.Size = new System.Drawing.Size(415, 45);
            this.label_UpdateDB.TabIndex = 2;
            // 
            // button_UpdateDB
            // 
            this.button_UpdateDB.Location = new System.Drawing.Point(19, 38);
            this.button_UpdateDB.Name = "button_UpdateDB";
            this.button_UpdateDB.Size = new System.Drawing.Size(143, 23);
            this.button_UpdateDB.TabIndex = 1;
            this.button_UpdateDB.Text = "Update Database";
            this.button_UpdateDB.UseVisualStyleBackColor = true;
            this.button_UpdateDB.Click += new System.EventHandler(this.buttonUpdateDB_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Database last updated on:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button_UpdatePDFPath);
            this.tabPage4.Controls.Add(this.button_UpdateKMZPath);
            this.tabPage4.Controls.Add(this.button_UpdateExcelPath);
            this.tabPage4.Controls.Add(this.textBox_NewPDFPath);
            this.tabPage4.Controls.Add(this.textBox_NewKMZPath);
            this.tabPage4.Controls.Add(this.textBox_NewExcelPath);
            this.tabPage4.Controls.Add(this.label_CurrentPDFPath);
            this.tabPage4.Controls.Add(this.label_CurrentKMZPath);
            this.tabPage4.Controls.Add(this.label_CurrentExcelPath);
            this.tabPage4.Controls.Add(this.label_PDFPathMessage);
            this.tabPage4.Controls.Add(this.label_KMZPathMessage);
            this.tabPage4.Controls.Add(this.label_ExcelPathMessage);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(904, 522);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Folder Paths";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button_UpdatePDFPath
            // 
            this.button_UpdatePDFPath.Location = new System.Drawing.Point(822, 188);
            this.button_UpdatePDFPath.Name = "button_UpdatePDFPath";
            this.button_UpdatePDFPath.Size = new System.Drawing.Size(75, 23);
            this.button_UpdatePDFPath.TabIndex = 4;
            this.button_UpdatePDFPath.Text = "Update";
            this.button_UpdatePDFPath.UseVisualStyleBackColor = true;
            this.button_UpdatePDFPath.Click += new System.EventHandler(this.button_UpdatePDFPath_Click);
            // 
            // button_UpdateKMZPath
            // 
            this.button_UpdateKMZPath.Location = new System.Drawing.Point(822, 113);
            this.button_UpdateKMZPath.Name = "button_UpdateKMZPath";
            this.button_UpdateKMZPath.Size = new System.Drawing.Size(75, 23);
            this.button_UpdateKMZPath.TabIndex = 4;
            this.button_UpdateKMZPath.Text = "Update";
            this.button_UpdateKMZPath.UseVisualStyleBackColor = true;
            this.button_UpdateKMZPath.Click += new System.EventHandler(this.button_UpdateKMZPath_Click);
            // 
            // button_UpdateExcelPath
            // 
            this.button_UpdateExcelPath.Location = new System.Drawing.Point(822, 39);
            this.button_UpdateExcelPath.Name = "button_UpdateExcelPath";
            this.button_UpdateExcelPath.Size = new System.Drawing.Size(75, 23);
            this.button_UpdateExcelPath.TabIndex = 4;
            this.button_UpdateExcelPath.Text = "Update";
            this.button_UpdateExcelPath.UseVisualStyleBackColor = true;
            this.button_UpdateExcelPath.Click += new System.EventHandler(this.button_UpdateExcelPath_Click);
            // 
            // textBox_NewPDFPath
            // 
            this.textBox_NewPDFPath.Location = new System.Drawing.Point(523, 188);
            this.textBox_NewPDFPath.Name = "textBox_NewPDFPath";
            this.textBox_NewPDFPath.Size = new System.Drawing.Size(287, 23);
            this.textBox_NewPDFPath.TabIndex = 3;
            // 
            // textBox_NewKMZPath
            // 
            this.textBox_NewKMZPath.Location = new System.Drawing.Point(523, 113);
            this.textBox_NewKMZPath.Name = "textBox_NewKMZPath";
            this.textBox_NewKMZPath.Size = new System.Drawing.Size(287, 23);
            this.textBox_NewKMZPath.TabIndex = 3;
            // 
            // textBox_NewExcelPath
            // 
            this.textBox_NewExcelPath.Location = new System.Drawing.Point(523, 39);
            this.textBox_NewExcelPath.Name = "textBox_NewExcelPath";
            this.textBox_NewExcelPath.Size = new System.Drawing.Size(175, 23);
            this.textBox_NewExcelPath.TabIndex = 3;
            // 
            // label_CurrentPDFPath
            // 
            this.label_CurrentPDFPath.Location = new System.Drawing.Point(239, 191);
            this.label_CurrentPDFPath.Name = "label_CurrentPDFPath";
            this.label_CurrentPDFPath.Size = new System.Drawing.Size(265, 31);
            this.label_CurrentPDFPath.TabIndex = 2;
            // 
            // label_CurrentKMZPath
            // 
            this.label_CurrentKMZPath.Location = new System.Drawing.Point(239, 116);
            this.label_CurrentKMZPath.Name = "label_CurrentKMZPath";
            this.label_CurrentKMZPath.Size = new System.Drawing.Size(265, 31);
            this.label_CurrentKMZPath.TabIndex = 2;
            // 
            // label_CurrentExcelPath
            // 
            this.label_CurrentExcelPath.Location = new System.Drawing.Point(239, 42);
            this.label_CurrentExcelPath.Name = "label_CurrentExcelPath";
            this.label_CurrentExcelPath.Size = new System.Drawing.Size(265, 31);
            this.label_CurrentExcelPath.TabIndex = 2;
            // 
            // label_PDFPathMessage
            // 
            this.label_PDFPathMessage.AutoSize = true;
            this.label_PDFPathMessage.Location = new System.Drawing.Point(523, 214);
            this.label_PDFPathMessage.Name = "label_PDFPathMessage";
            this.label_PDFPathMessage.Size = new System.Drawing.Size(0, 15);
            this.label_PDFPathMessage.TabIndex = 2;
            // 
            // label_KMZPathMessage
            // 
            this.label_KMZPathMessage.AutoSize = true;
            this.label_KMZPathMessage.Location = new System.Drawing.Point(523, 139);
            this.label_KMZPathMessage.Name = "label_KMZPathMessage";
            this.label_KMZPathMessage.Size = new System.Drawing.Size(0, 15);
            this.label_KMZPathMessage.TabIndex = 2;
            // 
            // label_ExcelPathMessage
            // 
            this.label_ExcelPathMessage.AutoSize = true;
            this.label_ExcelPathMessage.Location = new System.Drawing.Point(523, 65);
            this.label_ExcelPathMessage.Name = "label_ExcelPathMessage";
            this.label_ExcelPathMessage.Size = new System.Drawing.Size(0, 15);
            this.label_ExcelPathMessage.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(240, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "Current folder path";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(524, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "New folder path";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(15, 191);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(184, 31);
            this.label15.TabIndex = 0;
            this.label15.Text = "Change the folder path for the PDF reports:";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(15, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(184, 31);
            this.label11.TabIndex = 0;
            this.label11.Text = "Change the folder path for the KMZ files:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(704, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "(include file name)";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(15, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 34);
            this.label9.TabIndex = 0;
            this.label9.Text = "Change the folder path for the soils record excel file:";
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(130, 95);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(75, 23);
            this.button_Login.TabIndex = 2;
            this.button_Login.Text = "Submit";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(75, 66);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(130, 23);
            this.textBox_Password.TabIndex = 1;
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(75, 39);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(130, 23);
            this.textBox_Username.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Username:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Please log in below.";
            // 
            // Form1
            // 
            this.AcceptButton = this.button_SearchPDFs;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 650);
            this.MinimumSize = new System.Drawing.Size(1200, 650);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DOWL Soils Library Search App";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl_Login.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label4;
        private Label label5;
        private TextBox textBox_County;
        private TextBox textBox_City;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label3;
        private TextBox textBox_PN;
        private TextBox textBox_ProjName;
        private Button button_SearchPDFs;
        private ComboBox comboBox_State;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button button_Login;
        private TextBox textBox_Password;
        private TextBox textBox_Username;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label_LoginMessage;
        private TabControl tabControl_Login;
        private TabPage tabPage3;
        private Button button_UpdateDB;
        private Label label10;
        private TabPage tabPage4;
        private Label label_UpdateDB;
        internal ListView listView_PN;
        internal ListView listView_County;
        internal ListView listView_City;
        internal ListView listView_ProjName;
        private TextBox textBox_NewExcelPath;
        private Label label12;
        private Label label9;
        private Label label_CurrentExcelPath;
        private Label label13;
        private Button button_UpdateKMZPath;
        private Button button_UpdateExcelPath;
        private TextBox textBox_NewKMZPath;
        private Label label_CurrentKMZPath;
        private Label label11;
        private Label label14;
        private Label label_KMZPathMessage;
        private Label label_ExcelPathMessage;
        private Button button_UpdatePDFPath;
        private TextBox textBox_NewPDFPath;
        private Label label_CurrentPDFPath;
        private Label label_PDFPathMessage;
        private Label label15;
        internal TextBox textBox_Results;
        private Button button_Deselect;
    }
}