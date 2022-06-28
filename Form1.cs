using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Globalization;
using System.IO.Compression;
using System.Xml.Linq;

namespace dslsa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private List<ListViewItem> masterlist_pn;
        private List<ListViewItem> masterlist_projname;
        private List<ListViewItem> masterlist_city;
        private String masteruser = "";
        private String masterpass = "";
        public List<string> report_nums = new List<string>();
        private String dbpath = @"dslsa_database.db";
        private SQLiteConnection con;



        public double ConvertVal { get; private set; }

        //LOAD OPTIONS METHODS.....................................................................
        private void FormMain_Load(object sender, EventArgs e)
        {
            textBox_Results.BackColor = Color.White;

            //load options for states from database
            String sql;
            List<string> state_tables = new List<string>();
            con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();

            //get all tables in database
            sql = @"SELECT name FROM sqlite_schema WHERE type ='table' AND name NOT LIKE 'sqlite_%'";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        state_tables.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(rdr["name"]).ToLower()));

                    }
                }
            }
            state_tables.Remove("Folderpaths");
            state_tables.Sort();
            foreach (String tab in state_tables)
            {
                comboBox_State.Items.Add(tab);

            }
            con.Close();
            comboBox_State.SelectedItem = "Alaska";

            gmap.DragButton = MouseButtons.Left;
            gmap.IgnoreMarkerOnMouseWheel = true;

        }

        private void comboBoxState_SelectedValueChanged(object sender, EventArgs e)
        {
            //clear current items
            listView_PN.Items.Clear();
            listView_ProjName.Items.Clear();
            listView_County.Items.Clear();
            listView_City.Items.Clear();

            //read data from sqlite db to dictionary
            string state = comboBox_State.SelectedItem.ToString();
            Dictionary<string, List<string>> dict_cols = new Dictionary<string, List<string>>();
            dict_cols.Add("projectnumber", new List<string>());
            dict_cols.Add("projectname", new List<string>());
            dict_cols.Add("city", new List<string>());

            con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();

            string[] sql_items = { "projectnumber", "projectname", "city" };
            List<string> sql_list = new List<string>(sql_items);

            foreach (KeyValuePair<string, List<string>> kvp in dict_cols)
            {
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT DISTINCT " + kvp.Key + " FROM " + state.ToUpper(), con))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            kvp.Value.Add(Convert.ToString(rdr[kvp.Key]));
                        }
                    }
                }
                kvp.Value.Sort();
                kvp.Value.RemoveAll(s => s == "");
            }

            con.Close();

            //Add items to listview
            masterlist_pn = new List<ListViewItem>();
            masterlist_projname = new List<ListViewItem>();
            masterlist_city = new List<ListViewItem>();

            listView_PN.BeginUpdate();
            for (int i = 0; i < dict_cols["projectnumber"].Count; i++)
            {
                ListViewItem lvi = new ListViewItem(dict_cols["projectnumber"][i]);
                listView_PN.Items.Add(lvi);
                masterlist_pn.Add(lvi);
            }
            listView_PN.EndUpdate();

            listView_ProjName.BeginUpdate();
            for (int i = 0; i < dict_cols["projectname"].Count; i++)
            {
                ListViewItem lvi = new ListViewItem(dict_cols["projectname"][i]);
                listView_ProjName.Items.Add(lvi);
                masterlist_projname.Add(lvi);
            }
            listView_ProjName.EndUpdate();

            listView_City.BeginUpdate();
            for (int i = 0; i < dict_cols["city"].Count; i++)
            {
                ListViewItem lvi = new ListViewItem(dict_cols["city"][i]);
                listView_City.Items.Add(lvi);
                masterlist_city.Add(lvi);
            }
            listView_City.EndUpdate();
        }



        //TEXT BOX SEARCH METHODS.....................................................................
        private void textBox_PN_TextChanged(object sender, EventArgs e)
        {
            listView_PN.Items.Clear();
            listView_PN.Items.AddRange(masterlist_pn.Where(lvi => lvi.Text.ToLower().Contains(textBox_PN.Text.ToLower())).ToArray());
            foreach (ListViewItem item in masterlist_pn.Where(lvi => lvi.Text.ToLower().Contains(textBox_PN.Text.ToLower()))) ;
        }

        private void textBox_ProjName_TextChanged(object sender, EventArgs e)
        {
            listView_ProjName.Items.Clear();
            listView_ProjName.Items.AddRange(masterlist_projname.Where(lvi => lvi.Text.ToLower().Contains(textBox_ProjName.Text.ToLower())).ToArray());
            foreach (ListViewItem item in masterlist_projname.Where(lvi => lvi.Text.ToLower().Contains(textBox_ProjName.Text.ToLower()))) ;

        }

        private void textBox_County_TextChanged(object sender, EventArgs e)
        {
            //from geocoding

        }

        private void textBox_City_TextChanged(object sender, EventArgs e)
        {
            listView_City.Items.Clear();
            listView_City.Items.AddRange(masterlist_city.Where(lvi => lvi.Text.ToLower().Contains(textBox_City.Text.ToLower())).ToArray());
            foreach (ListViewItem item in masterlist_city.Where(lvi => lvi.Text.ToLower().Contains(textBox_City.Text.ToLower()))) ;

        }

        //MAP METHODS.....................................................................
        private void listView_PN_Click(object sender, EventArgs e)
        {

        }

        private void listView_City_Click(object sender, EventArgs e)
        {
            //get kmz folder from db
            //setup database connection
            SQLiteCommand cmd_sql;
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            string sql = string.Empty;
            string fname = string.Empty;
            string filename;


            //get excel report path
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT value FROM FOLDERPATHS WHERE type='kmzpath'", con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        fname = Convert.ToString(rdr["value"]);
                    }
                }
            }

            //unzip kmz

            var file = File.OpenRead(fname + @"\Bethel.kmz");
            var zip = new ZipArchive(file, ZipArchiveMode.Read);
            XNamespace ns = "http://www.opengis.net/kml/2.2";
            IDictionary<string, List<string>> pointDict = new Dictionary<string, List<string>>();

            pointDict.Add("lat", new List<string>());
            pointDict.Add("lon", new List<string>());
            pointDict.Add("projectname", new List<string>());
            pointDict.Add("file", new List<string>());

            var stream = zip.GetEntry("doc.kml").Open();
            XDocument xDoc = XDocument.Load(stream);
            if (xDoc != null)
            {
                var placemarks = xDoc.Root.Element(ns + "Document").Element(ns + "Folder").Elements(ns + "Placemark");
                foreach (var place in placemarks)
                {
                    var coords = place.Element(ns + "Point").Element(ns + "coordinates").Value;
                    coords = coords.Substring(0, coords.LastIndexOf(','));
                    pointDict["lon"].Add(coords.Substring(0, coords.IndexOf(',')));
                    pointDict["lat"].Add(coords.Substring(coords.IndexOf(',') + 1));

                    var desc = place.Element(ns + "description").Value;

                    // get project name
                    var searchstring = "<td>Project</td>";
                    var startindex = desc.IndexOf(searchstring) + searchstring.Length;
                    var endindex = desc.IndexOf("</tr>", desc.IndexOf(searchstring) + 1);
                    var pname = desc.Substring(startindex, endindex - startindex);
                    pointDict["projectname"].Add(pname.Substring(6, pname.Length - 13));

                    //get file number
                    searchstring = "<td>File</td>";
                    startindex = desc.IndexOf(searchstring) + searchstring.Length;
                    endindex = desc.IndexOf("</tr>", desc.IndexOf(searchstring) + 1);
                    filename = desc.Substring(startindex, endindex - startindex);
                    pointDict["file"].Add(filename.Substring(6, filename.Length - 13));

                }
            }


            // add markers
            GMapOverlay markers = new GMapOverlay("markers");
            for (int i = 0; i < pointDict["lat"].Count(); i++)
            {
                GMapMarker marker =
                    new GMarkerGoogle(
                        new PointLatLng(Convert.ToDouble(pointDict["lat"].ElementAt(i)), Convert.ToDouble(pointDict["lon"].ElementAt(i))),
                        GMarkerGoogleType.blue_pushpin);
                markers.Markers.Add(marker);
                marker.ToolTipText = "\n" + "Project Name: " + pointDict["projectname"].ElementAt(i) + "\n" + "Report Number: " + pointDict["file"].ElementAt(i);
                //marker.ToolTip.Fill = Brushes.Black;
                //marker.ToolTip.Foreground = Brushes.White;
                //marker.ToolTip.Stroke = Pens.Black;
                marker.ToolTip.TextPadding = new Size(20, 20);

            }

            gmap.Overlays.Add(markers);
        }

        private void gmap_Load(object sender, EventArgs e)
        {
            // initialize the map
            gmap.MapProvider = OpenStreetMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(64.200841, -149.493673);
            gmap.ShowCenter = false;

        }

        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            //Console.WriteLine(String.Format("Marker {0} was clicked.", item.Tag));
        }



        //ADMIN TAB METHODS.....................................................................
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String username = textBox_Username.Text;
            String password = textBox_Password.Text;

            if (username == masteruser && password == masterpass)
            {
                tabControl_Login.Visible = true;
                label_LoginMessage.Text = "Login successful!";
                label_LoginMessage.ForeColor = Color.Green;

                //setup database connection
                SQLiteCommand cmd_sql;
                SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
                con.Open();
                string fname = String.Empty;
                //get excel report path to display
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT value FROM FOLDERPATHS WHERE type='excelpath'", con))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            fname = Convert.ToString(rdr["value"]);
                        }
                    }
                }
                label_CurrentExcelPath.Text = fname;
                //get kmz folder path to display
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT value FROM FOLDERPATHS WHERE type='kmzpath'", con))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            fname = Convert.ToString(rdr["value"]);
                        }
                    }
                }
                label_CurrentKMZPath.Text = fname;
                //get pdf folder path to display
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT value FROM FOLDERPATHS WHERE type='pdfpath'", con))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            fname = Convert.ToString(rdr["value"]);
                        }
                    }
                }
                label_CurrentPDFPath.Text = fname;

            }
            else
            {
                label_LoginMessage.Text = "Login unsuccessful! Please try again.";
                label_LoginMessage.ForeColor = Color.Red;
                tabControl_Login.Visible = false;
            }

        }

        private void button_UpdateExcelPath_Click(object sender, EventArgs e)
        {
            string newpath = textBox_NewExcelPath.Text;
            if (newpath.Length <= 5)
            {
                label_ExcelPathMessage.Text = "Add a folder and file name ending in '.xlsx'";
                label_ExcelPathMessage.ForeColor = Color.Red;
                return;
            }
            else if (newpath.Substring(newpath.Length - 5) != ".xlsx")
            {
                label_ExcelPathMessage.Text = "Add the file name ending in '.xlsx'";
                label_ExcelPathMessage.ForeColor = Color.Red;
                return;
            }
            else
            {
                //setup database connection
                SQLiteCommand cmd_sql;
                SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
                con.Open();

                string sql = string.Empty;
                sql = "DELETE FROM FOLDERPATHS WHERE type='excelpath'";
                cmd_sql = new SQLiteCommand(sql, con);
                cmd_sql.ExecuteNonQuery();

                sql = "INSERT INTO FOLDERPATHS (type,value) VALUES ('excelpath','" + newpath + "')";
                cmd_sql = new SQLiteCommand(sql, con);
                cmd_sql.ExecuteNonQuery();

                label_ExcelPathMessage.Text = "Excel folder path and file name updated!";
                label_ExcelPathMessage.ForeColor = Color.Green;

                label_CurrentExcelPath.Text = newpath;
            }

            con.Close();

        }

        private void button_UpdateKMZPath_Click(object sender, EventArgs e)
        {
            //setup database connection
            SQLiteCommand cmd_sql;
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();

            string newpath = textBox_NewKMZPath.Text;

            string sql = string.Empty;
            sql = "DELETE FROM FOLDERPATHS WHERE type='kmzpath'";
            cmd_sql = new SQLiteCommand(sql, con);
            cmd_sql.ExecuteNonQuery();

            sql = "INSERT INTO FOLDERPATHS (type,value) VALUES ('kmzpath','" + newpath + "')";
            cmd_sql = new SQLiteCommand(sql, con);
            cmd_sql.ExecuteNonQuery();

            label_KMZPathMessage.Text = "KMZ folder path updated!";
            label_KMZPathMessage.ForeColor = Color.Green;

            label_CurrentKMZPath.Text = newpath;


            con.Close();
        }

        private void button_UpdatePDFPath_Click(object sender, EventArgs e)
        {

            //setup database connection
            SQLiteCommand cmd_sql;
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();

            string newpath = textBox_NewPDFPath.Text;

            string sql = string.Empty;
            sql = "DELETE FROM FOLDERPATHS WHERE type='pdfpath'";
            cmd_sql = new SQLiteCommand(sql, con);
            cmd_sql.ExecuteNonQuery();

            sql = "INSERT INTO FOLDERPATHS (type,value) VALUES ('pdfpath','" + newpath + "')";
            cmd_sql = new SQLiteCommand(sql, con);
            cmd_sql.ExecuteNonQuery();

            label_PDFPathMessage.Text = "PDF folder path updated!";
            label_PDFPathMessage.ForeColor = Color.Green;

            label_CurrentPDFPath.Text = newpath;


            con.Close();

        }

        private void buttonUpdateDB_Click(object sender, EventArgs e)
        {

            label_UpdateDB.Text = "Uploading data. This operation may take up to 10 seconds.";
            label_UpdateDB.ForeColor = Color.Blue;

            //setup database connection
            SQLiteCommand cmd_sql;
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            string sql = string.Empty;
            string fname = string.Empty;

            //get excel report path
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT value FROM FOLDERPATHS WHERE type='excelpath'", con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        fname = Convert.ToString(rdr["value"]);
                    }
                }
            }


            //send excel data to database
            DataTable dtResult = null;
            int totalSheet = 0;

            try
            {
                using (OleDbConnection objConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fname + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';"))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    OleDbDataAdapter oleda = new OleDbDataAdapter();
                    DataSet ds;
                    DataTable dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    string sheetName = string.Empty;


                    if (dt != null)
                    {
                        foreach (DataRow drs in dt.Rows)
                        {
                            //get data from spreadsheet
                            sheetName = drs["TABLE_NAME"].ToString();
                            if (!sheetName.Contains("FilterDatabase"))
                            {
                                var tempDataTable = (from dataRow in dt.AsEnumerable()
                                                     where !dataRow["TABLE_NAME"].ToString().Contains("FilterDatabase")
                                                     select dataRow).CopyToDataTable();
                                dt = tempDataTable;
                                totalSheet = dt.Rows.Count;

                                cmd.Connection = objConn;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                                oleda = new OleDbDataAdapter(cmd);

                                ds = new DataSet();
                                oleda.Fill(ds, "excelData");
                                dtResult = ds.Tables["excelData"];
                                objConn.Close();

                                //create database table
                                sql = @"CREATE TABLE IF NOT EXISTS " + sheetName.Substring(0, sheetName.Length - 1).ToUpper() + "(" +
                                    "report VARCHAR(255), projectnumber VARCHAR(255), client VARCHAR(255), projectname VARCHAR(255), area VARCHAR(255), city VARCHAR(255)" +
                                    ")";
                                cmd_sql = new SQLiteCommand(sql, con);
                                cmd_sql.ExecuteNonQuery();

                                //clear database table
                                sql = @"DELETE FROM " + sheetName.Substring(0, sheetName.Length - 1).ToUpper();
                                cmd_sql = new SQLiteCommand(sql, con);
                                cmd_sql.ExecuteNonQuery();

                                //send datatable to database
                                cmd_sql = new SQLiteCommand();
                                using (cmd_sql = new SQLiteCommand(con))
                                {
                                    using (var transaction = con.BeginTransaction())
                                    {
                                        foreach (DataRow dataRow in dtResult.Rows)
                                        {
                                            cmd_sql.CommandText = "INSERT INTO " + sheetName.Substring(0, sheetName.Length - 1).ToUpper() + "(report,projectnumber,client,projectname,area,city) VALUES (" +
                                                "'" + dataRow[0].ToString().Replace("'", "''") + "'," +
                                                "'" + dataRow[1].ToString().Replace("'", "''") + "'," +
                                                "'" + dataRow[2].ToString().Replace("'", "''") + "'," +
                                                "'" + dataRow[3].ToString().Replace("'", "''") + "'," +
                                                "'" + dataRow[4].ToString().Replace("'", "''") + "'," +
                                                "'" + dataRow[5].ToString().Replace("'", "''") + "'" +
                                                ")";
                                            cmd_sql.ExecuteNonQuery();
                                        }
                                        transaction.Commit();
                                    }

                                }
                            }

                        }
                    }

                    label_UpdateDB.Text = "Upload complete!";
                    label_UpdateDB.ForeColor = Color.Green;
                }

            }
            catch (Exception)
            {
                label_UpdateDB.Text = "There was an error updating the database. Please verify the soils report record excel file exists in the folder entered in the Folder Paths tab.";
                label_UpdateDB.ForeColor = Color.Red;
            }

            con.Close();


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_UpdateDB.Text = "";
            label_UpdateDB.ForeColor = Color.Black;

            label_ExcelPathMessage.Text = "";
            label_ExcelPathMessage.ForeColor = Color.Black;

            label_KMZPathMessage.Text = "";
            label_KMZPathMessage.ForeColor = Color.Black;

            textBox_NewExcelPath.Text = "";
            textBox_NewKMZPath.Text = "";


            //change accept button based on tab selected
            TabControl tab = sender as TabControl;

            switch (tab.SelectedIndex)
            {
                case 1:
                    AcceptButton = button_Login;
                    break;
                case 0:
                    AcceptButton = button_SearchPDFs;
                    break;
            }

        }



        ////MAIN SEARCH METHOD.....................................................................
        private void button_SearchPDFs_Click(object sender, EventArgs e)
        {
            //build query based on selections
            report_nums.Clear();
            List<string> cols = new List<string>();
            List<string> selectedvals = new List<string>();
            List<string> query_whereclause = new List<string>();
            cols.Add("report");
            string selectedPN = String.Empty;
            string selectedProjName = String.Empty;
            string selectedCity = String.Empty;

            try
            {
                selectedPN = listView_PN.SelectedItems[0].Text.ToString();
                cols.Add("projectnumber");
                query_whereclause.Add("projectnumber='" + selectedPN + "'");
            }
            catch (Exception) { }

            try
            {
                selectedProjName = listView_ProjName.SelectedItems[0].Text.ToString();
                cols.Add("projectname");
                query_whereclause.Add("projectname='" + selectedProjName + "'");

            }
            catch (Exception) { }

            try
            {
                selectedCity = listView_City.SelectedItems[0].Text.ToString();
                cols.Add("city");
                query_whereclause.Add("city='" + selectedCity + "'");

            }
            catch (Exception) { }

            //send error message if no selections made
            if (cols.Count == 1)
            {
                textBox_Results.Text = "Please make at least one selection from a list.";
                textBox_Results.ForeColor = Color.Red;
                return;
            }

            textBox_Results.Text = "";
            textBox_Results.ForeColor = Color.Black;

            string colnames = string.Join(",", cols.ToArray());
            string query_wherestring = string.Join(" AND ", query_whereclause.ToArray());

            //query database for selections
            string state = comboBox_State.SelectedItem.ToString();
            using (SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;"))
            {
                con.Open();
                string sql = "SELECT " + colnames + " FROM " + state.ToUpper() + " WHERE " + query_wherestring;
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            report_nums.Add(Convert.ToString(rdr["report"]));
                        }
                    }
                }
                con.Close();
            }

            //open the search results form
            this.Hide();
            Form2 s = new Form2();
            s.Show();
        }

        private void button_Deselect_Click(object sender, EventArgs e)
        {
            listView_PN.SelectedItems.Clear();
            listView_ProjName.SelectedItems.Clear();
            listView_City.SelectedItems.Clear();
        }
    }
}