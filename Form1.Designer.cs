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
            this.label_AncGrid = new System.Windows.Forms.Label();
            this.button_ClearMapList = new System.Windows.Forms.Button();
            this.button_SearchMapPDFs = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.listView_MapReports = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.button_Reset = new System.Windows.Forms.Button();
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
            this.comboBox_AncGrid = new System.Windows.Forms.ComboBox();
            this.comboBox_QueryType = new System.Windows.Forms.ComboBox();
            this.comboBox_State = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label_LoginMessage = new System.Windows.Forms.Label();
            this.tabControl_Login = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
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
            this.label_UpdateKMZDB = new System.Windows.Forms.Label();
            this.label_UpdateRecordDB = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_UpdateKMZDB = new System.Windows.Forms.Button();
            this.button_UpdateRecordDB = new System.Windows.Forms.Button();
            this.label_KMZDBUpdateTime = new System.Windows.Forms.Label();
            this.label_DBUpdateTime = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
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
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1245, 723);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label_AncGrid);
            this.tabPage1.Controls.Add(this.button_ClearMapList);
            this.tabPage1.Controls.Add(this.button_SearchMapPDFs);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.listView_MapReports);
            this.tabPage1.Controls.Add(this.button_Reset);
            this.tabPage1.Controls.Add(this.textBox_Results);
            this.tabPage1.Controls.Add(this.gmap);
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.button_SearchPDFs);
            this.tabPage1.Controls.Add(this.comboBox_AncGrid);
            this.tabPage1.Controls.Add(this.comboBox_QueryType);
            this.tabPage1.Controls.Add(this.comboBox_State);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1237, 695);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Application";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label_AncGrid
            // 
            this.label_AncGrid.Location = new System.Drawing.Point(397, 48);
            this.label_AncGrid.Name = "label_AncGrid";
            this.label_AncGrid.Size = new System.Drawing.Size(81, 20);
            this.label_AncGrid.TabIndex = 12;
            this.label_AncGrid.Text = "Select a grid...";
            this.label_AncGrid.Visible = false;
            // 
            // button_ClearMapList
            // 
            this.button_ClearMapList.Location = new System.Drawing.Point(1115, 664);
            this.button_ClearMapList.Name = "button_ClearMapList";
            this.button_ClearMapList.Size = new System.Drawing.Size(116, 23);
            this.button_ClearMapList.TabIndex = 11;
            this.button_ClearMapList.Text = "Clear List";
            this.button_ClearMapList.UseVisualStyleBackColor = true;
            this.button_ClearMapList.Click += new System.EventHandler(this.button_ClearMapList_Click);
            // 
            // button_SearchMapPDFs
            // 
            this.button_SearchMapPDFs.Location = new System.Drawing.Point(986, 664);
            this.button_SearchMapPDFs.Name = "button_SearchMapPDFs";
            this.button_SearchMapPDFs.Size = new System.Drawing.Size(123, 23);
            this.button_SearchMapPDFs.TabIndex = 11;
            this.button_SearchMapPDFs.Text = "Search Map PDFs";
            this.button_SearchMapPDFs.UseVisualStyleBackColor = true;
            this.button_SearchMapPDFs.Click += new System.EventHandler(this.button_SearchMapPDFs_Click);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(592, 654);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label16.Size = new System.Drawing.Size(231, 36);
            this.label16.TabIndex = 10;
            this.label16.Text = "Select from the project number, name, or city lists to view report locations.";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(986, 638);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label17.Size = new System.Drawing.Size(245, 52);
            this.label17.TabIndex = 10;
            this.label17.Text = "Double-click item to remove from list.";
            // 
            // listView_MapReports
            // 
            this.listView_MapReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.listView_MapReports.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_MapReports.Location = new System.Drawing.Point(986, 494);
            this.listView_MapReports.Name = "listView_MapReports";
            this.listView_MapReports.Size = new System.Drawing.Size(245, 141);
            this.listView_MapReports.TabIndex = 9;
            this.listView_MapReports.UseCompatibleStateImageBehavior = false;
            this.listView_MapReports.View = System.Windows.Forms.View.Details;
            this.listView_MapReports.DoubleClick += new System.EventHandler(this.listView_MapReports_DoubleClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Reports Added from Map:";
            this.columnHeader5.Width = 235;
            // 
            // button_Reset
            // 
            this.button_Reset.Location = new System.Drawing.Point(311, 9);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(105, 23);
            this.button_Reset.TabIndex = 8;
            this.button_Reset.Text = "Reset All";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // textBox_Results
            // 
            this.textBox_Results.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Results.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Results.Location = new System.Drawing.Point(592, 7);
            this.textBox_Results.Multiline = true;
            this.textBox_Results.Name = "textBox_Results";
            this.textBox_Results.ReadOnly = true;
            this.textBox_Results.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Results.Size = new System.Drawing.Size(639, 44);
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
            this.gmap.Location = new System.Drawing.Point(592, 57);
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
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Fractional;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(639, 632);
            this.gmap.TabIndex = 5;
            this.gmap.Zoom = 4D;
            this.gmap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmap_OnMarkerClick);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 390);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(580, 305);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Search for county/borough...(filters city list)";
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
            this.listView_County.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_County.Location = new System.Drawing.Point(3, 48);
            this.listView_County.MultiSelect = false;
            this.listView_County.Name = "listView_County";
            this.listView_County.Size = new System.Drawing.Size(280, 254);
            this.listView_County.TabIndex = 9;
            this.listView_County.UseCompatibleStateImageBehavior = false;
            this.listView_County.View = System.Windows.Forms.View.Details;
            this.listView_County.SelectedIndexChanged += new System.EventHandler(this.listView_County_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "County/Borough";
            this.columnHeader3.Width = 270;
            // 
            // listView_City
            // 
            this.listView_City.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.listView_City.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_City.Location = new System.Drawing.Point(293, 48);
            this.listView_City.MultiSelect = false;
            this.listView_City.Name = "listView_City";
            this.listView_City.Size = new System.Drawing.Size(280, 254);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 84);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(580, 303);
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
            this.listView_PN.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_PN.Location = new System.Drawing.Point(3, 48);
            this.listView_PN.MultiSelect = false;
            this.listView_PN.Name = "listView_PN";
            this.listView_PN.Size = new System.Drawing.Size(280, 252);
            this.listView_PN.TabIndex = 7;
            this.listView_PN.UseCompatibleStateImageBehavior = false;
            this.listView_PN.View = System.Windows.Forms.View.Details;
            this.listView_PN.Click += new System.EventHandler(this.listView_PN_Click);
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
            this.listView_ProjName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_ProjName.Location = new System.Drawing.Point(293, 48);
            this.listView_ProjName.MultiSelect = false;
            this.listView_ProjName.Name = "listView_ProjName";
            this.listView_ProjName.Size = new System.Drawing.Size(283, 252);
            this.listView_ProjName.TabIndex = 8;
            this.listView_ProjName.UseCompatibleStateImageBehavior = false;
            this.listView_ProjName.View = System.Windows.Forms.View.Details;
            this.listView_ProjName.Click += new System.EventHandler(this.listView_ProjName_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Project Name";
            this.columnHeader2.Width = 276;
            // 
            // button_SearchPDFs
            // 
            this.button_SearchPDFs.Location = new System.Drawing.Point(447, 10);
            this.button_SearchPDFs.Name = "button_SearchPDFs";
            this.button_SearchPDFs.Size = new System.Drawing.Size(132, 23);
            this.button_SearchPDFs.TabIndex = 6;
            this.button_SearchPDFs.Text = "Search for PDFs";
            this.button_SearchPDFs.UseVisualStyleBackColor = true;
            this.button_SearchPDFs.Click += new System.EventHandler(this.button_SearchPDFs_Click);
            // 
            // comboBox_AncGrid
            // 
            this.comboBox_AncGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AncGrid.FormattingEnabled = true;
            this.comboBox_AncGrid.Location = new System.Drawing.Point(484, 45);
            this.comboBox_AncGrid.Name = "comboBox_AncGrid";
            this.comboBox_AncGrid.Size = new System.Drawing.Size(95, 23);
            this.comboBox_AncGrid.TabIndex = 0;
            this.comboBox_AncGrid.Visible = false;
            this.comboBox_AncGrid.SelectedValueChanged += new System.EventHandler(this.comboBox_AncGrid_SelectedValueChanged);
            // 
            // comboBox_QueryType
            // 
            this.comboBox_QueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_QueryType.FormattingEnabled = true;
            this.comboBox_QueryType.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.comboBox_QueryType.Location = new System.Drawing.Point(311, 45);
            this.comboBox_QueryType.Name = "comboBox_QueryType";
            this.comboBox_QueryType.Size = new System.Drawing.Size(65, 23);
            this.comboBox_QueryType.TabIndex = 0;
            this.comboBox_QueryType.SelectedValueChanged += new System.EventHandler(this.comboBox_QueryType_SelectedValueChanged);
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
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(307, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "Select a query method for multiple attribute selections...";
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
            this.tabPage2.Size = new System.Drawing.Size(1237, 695);
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
            this.tabControl_Login.Size = new System.Drawing.Size(1000, 696);
            this.tabControl_Login.TabIndex = 6;
            this.tabControl_Login.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button_UpdatePDFPath);
            this.tabPage3.Controls.Add(this.button_UpdateKMZPath);
            this.tabPage3.Controls.Add(this.button_UpdateExcelPath);
            this.tabPage3.Controls.Add(this.textBox_NewPDFPath);
            this.tabPage3.Controls.Add(this.textBox_NewKMZPath);
            this.tabPage3.Controls.Add(this.textBox_NewExcelPath);
            this.tabPage3.Controls.Add(this.label_CurrentPDFPath);
            this.tabPage3.Controls.Add(this.label_CurrentKMZPath);
            this.tabPage3.Controls.Add(this.label_CurrentExcelPath);
            this.tabPage3.Controls.Add(this.label_PDFPathMessage);
            this.tabPage3.Controls.Add(this.label_KMZPathMessage);
            this.tabPage3.Controls.Add(this.label_ExcelPathMessage);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label_UpdateKMZDB);
            this.tabPage3.Controls.Add(this.label_UpdateRecordDB);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.button_UpdateKMZDB);
            this.tabPage3.Controls.Add(this.button_UpdateRecordDB);
            this.tabPage3.Controls.Add(this.label_KMZDBUpdateTime);
            this.tabPage3.Controls.Add(this.label_DBUpdateTime);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(992, 668);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Database Update";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button_UpdatePDFPath
            // 
            this.button_UpdatePDFPath.Location = new System.Drawing.Point(902, 591);
            this.button_UpdatePDFPath.Name = "button_UpdatePDFPath";
            this.button_UpdatePDFPath.Size = new System.Drawing.Size(75, 22);
            this.button_UpdatePDFPath.TabIndex = 22;
            this.button_UpdatePDFPath.Text = "Update";
            this.button_UpdatePDFPath.UseVisualStyleBackColor = true;
            this.button_UpdatePDFPath.Click += new System.EventHandler(this.button_UpdatePDFPath_Click);
            // 
            // button_UpdateKMZPath
            // 
            this.button_UpdateKMZPath.Location = new System.Drawing.Point(902, 516);
            this.button_UpdateKMZPath.Name = "button_UpdateKMZPath";
            this.button_UpdateKMZPath.Size = new System.Drawing.Size(75, 22);
            this.button_UpdateKMZPath.TabIndex = 21;
            this.button_UpdateKMZPath.Text = "Update";
            this.button_UpdateKMZPath.UseVisualStyleBackColor = true;
            this.button_UpdateKMZPath.Click += new System.EventHandler(this.button_UpdateKMZPath_Click);
            // 
            // button_UpdateExcelPath
            // 
            this.button_UpdateExcelPath.Location = new System.Drawing.Point(902, 442);
            this.button_UpdateExcelPath.Name = "button_UpdateExcelPath";
            this.button_UpdateExcelPath.Size = new System.Drawing.Size(75, 22);
            this.button_UpdateExcelPath.TabIndex = 20;
            this.button_UpdateExcelPath.Text = "Update";
            this.button_UpdateExcelPath.UseVisualStyleBackColor = true;
            this.button_UpdateExcelPath.Click += new System.EventHandler(this.button_UpdateExcelPath_Click);
            // 
            // textBox_NewPDFPath
            // 
            this.textBox_NewPDFPath.Location = new System.Drawing.Point(514, 591);
            this.textBox_NewPDFPath.Name = "textBox_NewPDFPath";
            this.textBox_NewPDFPath.Size = new System.Drawing.Size(382, 23);
            this.textBox_NewPDFPath.TabIndex = 19;
            // 
            // textBox_NewKMZPath
            // 
            this.textBox_NewKMZPath.Location = new System.Drawing.Point(514, 516);
            this.textBox_NewKMZPath.Name = "textBox_NewKMZPath";
            this.textBox_NewKMZPath.Size = new System.Drawing.Size(382, 23);
            this.textBox_NewKMZPath.TabIndex = 18;
            // 
            // textBox_NewExcelPath
            // 
            this.textBox_NewExcelPath.Location = new System.Drawing.Point(514, 442);
            this.textBox_NewExcelPath.Name = "textBox_NewExcelPath";
            this.textBox_NewExcelPath.Size = new System.Drawing.Size(270, 23);
            this.textBox_NewExcelPath.TabIndex = 17;
            // 
            // label_CurrentPDFPath
            // 
            this.label_CurrentPDFPath.Location = new System.Drawing.Point(230, 577);
            this.label_CurrentPDFPath.Name = "label_CurrentPDFPath";
            this.label_CurrentPDFPath.Size = new System.Drawing.Size(265, 48);
            this.label_CurrentPDFPath.TabIndex = 15;
            // 
            // label_CurrentKMZPath
            // 
            this.label_CurrentKMZPath.Location = new System.Drawing.Point(230, 502);
            this.label_CurrentKMZPath.Name = "label_CurrentKMZPath";
            this.label_CurrentKMZPath.Size = new System.Drawing.Size(265, 48);
            this.label_CurrentKMZPath.TabIndex = 16;
            // 
            // label_CurrentExcelPath
            // 
            this.label_CurrentExcelPath.Location = new System.Drawing.Point(230, 428);
            this.label_CurrentExcelPath.Name = "label_CurrentExcelPath";
            this.label_CurrentExcelPath.Size = new System.Drawing.Size(265, 48);
            this.label_CurrentExcelPath.TabIndex = 14;
            // 
            // label_PDFPathMessage
            // 
            this.label_PDFPathMessage.Location = new System.Drawing.Point(514, 617);
            this.label_PDFPathMessage.Name = "label_PDFPathMessage";
            this.label_PDFPathMessage.Size = new System.Drawing.Size(463, 45);
            this.label_PDFPathMessage.TabIndex = 13;
            // 
            // label_KMZPathMessage
            // 
            this.label_KMZPathMessage.Location = new System.Drawing.Point(514, 542);
            this.label_KMZPathMessage.Name = "label_KMZPathMessage";
            this.label_KMZPathMessage.Size = new System.Drawing.Size(463, 46);
            this.label_KMZPathMessage.TabIndex = 12;
            // 
            // label_ExcelPathMessage
            // 
            this.label_ExcelPathMessage.Location = new System.Drawing.Point(514, 468);
            this.label_ExcelPathMessage.Name = "label_ExcelPathMessage";
            this.label_ExcelPathMessage.Size = new System.Drawing.Size(463, 45);
            this.label_ExcelPathMessage.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(230, 403);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 15);
            this.label13.TabIndex = 10;
            this.label13.Text = "Current folder path";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(514, 403);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 15);
            this.label12.TabIndex = 9;
            this.label12.Text = "New folder path";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(6, 577);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(184, 48);
            this.label15.TabIndex = 7;
            this.label15.Text = "Change the folder path for the PDF reports:";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 502);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(184, 48);
            this.label11.TabIndex = 6;
            this.label11.Text = "Change the folder path for the KMZ files:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(790, 445);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 15);
            this.label14.TabIndex = 8;
            this.label14.Text = "(include file name)";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 425);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 51);
            this.label9.TabIndex = 5;
            this.label9.Text = "Change the folder path for the soils record excel file:";
            // 
            // label_UpdateKMZDB
            // 
            this.label_UpdateKMZDB.Location = new System.Drawing.Point(19, 208);
            this.label_UpdateKMZDB.Name = "label_UpdateKMZDB";
            this.label_UpdateKMZDB.Size = new System.Drawing.Size(415, 179);
            this.label_UpdateKMZDB.TabIndex = 2;
            // 
            // label_UpdateRecordDB
            // 
            this.label_UpdateRecordDB.Location = new System.Drawing.Point(19, 76);
            this.label_UpdateRecordDB.Name = "label_UpdateRecordDB";
            this.label_UpdateRecordDB.Size = new System.Drawing.Size(415, 45);
            this.label_UpdateRecordDB.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Export KMZ Database to Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_UpdateKMZDB_Click);
            // 
            // button_UpdateKMZDB
            // 
            this.button_UpdateKMZDB.Location = new System.Drawing.Point(19, 168);
            this.button_UpdateKMZDB.Name = "button_UpdateKMZDB";
            this.button_UpdateKMZDB.Size = new System.Drawing.Size(225, 23);
            this.button_UpdateKMZDB.TabIndex = 1;
            this.button_UpdateKMZDB.Text = "Update KMZ Database";
            this.button_UpdateKMZDB.UseVisualStyleBackColor = true;
            this.button_UpdateKMZDB.Click += new System.EventHandler(this.button_UpdateKMZDB_Click);
            // 
            // button_UpdateRecordDB
            // 
            this.button_UpdateRecordDB.Location = new System.Drawing.Point(19, 38);
            this.button_UpdateRecordDB.Name = "button_UpdateRecordDB";
            this.button_UpdateRecordDB.Size = new System.Drawing.Size(225, 23);
            this.button_UpdateRecordDB.TabIndex = 1;
            this.button_UpdateRecordDB.Text = "Update Soils Record (Excel) Database";
            this.button_UpdateRecordDB.UseVisualStyleBackColor = true;
            this.button_UpdateRecordDB.Click += new System.EventHandler(this.buttonUpdateRecordDB_Click);
            // 
            // label_KMZDBUpdateTime
            // 
            this.label_KMZDBUpdateTime.AutoSize = true;
            this.label_KMZDBUpdateTime.Location = new System.Drawing.Point(19, 150);
            this.label_KMZDBUpdateTime.Name = "label_KMZDBUpdateTime";
            this.label_KMZDBUpdateTime.Size = new System.Drawing.Size(143, 15);
            this.label_KMZDBUpdateTime.TabIndex = 0;
            this.label_KMZDBUpdateTime.Text = "Database last updated on:";
            // 
            // label_DBUpdateTime
            // 
            this.label_DBUpdateTime.AutoSize = true;
            this.label_DBUpdateTime.Location = new System.Drawing.Point(19, 19);
            this.label_DBUpdateTime.Name = "label_DBUpdateTime";
            this.label_DBUpdateTime.Size = new System.Drawing.Size(143, 15);
            this.label_DBUpdateTime.TabIndex = 0;
            this.label_DBUpdateTime.Text = "Database last updated on:";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(992, 668);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Missing PDFs";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.ClientSize = new System.Drawing.Size(1262, 747);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
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
        private Button button_UpdateRecordDB;
        private Label label_DBUpdateTime;
        private TabPage tabPage4;
        private Label label_UpdateRecordDB;
        internal ListView listView_PN;
        internal ListView listView_County;
        internal ListView listView_City;
        internal ListView listView_ProjName;
        internal TextBox textBox_Results;
        private Button button_Reset;
        private Button button_UpdateKMZDB;
        private Label label_KMZDBUpdateTime;
        private Label label_UpdateKMZDB;
        private ColumnHeader columnHeader5;
        internal ListView listView_MapReports;
        private Button button_SearchMapPDFs;
        private Label label17;
        private Button button_ClearMapList;
        private Button button_UpdatePDFPath;
        private Button button_UpdateKMZPath;
        private Button button_UpdateExcelPath;
        private TextBox textBox_NewPDFPath;
        private TextBox textBox_NewKMZPath;
        private TextBox textBox_NewExcelPath;
        private Label label_CurrentPDFPath;
        private Label label_CurrentKMZPath;
        private Label label_CurrentExcelPath;
        private Label label_PDFPathMessage;
        private Label label_KMZPathMessage;
        private Label label_ExcelPathMessage;
        private Label label13;
        private Label label12;
        private Label label15;
        private Label label11;
        private Label label14;
        private Label label9;
        private Button button1;
        private ComboBox comboBox_QueryType;
        private Label label10;
        private Label label16;
        private Label label_AncGrid;
        private ComboBox comboBox_AncGrid;
    }
}