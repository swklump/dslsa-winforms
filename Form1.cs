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
        private string masteruser = "";
        private string masterpass = "";
        private string dbpath = @"dslsa_database.db";
        private SQLiteConnection con;

        internal List<string> report_nums = new List<string>();
        private IDictionary<string, List<string>> pointDict = new Dictionary<string, List<string>>();
        internal int mouse_x;
        internal int mouse_y;
        private List<GMapMarker> marker_list = new List<GMapMarker>();

        internal string map_report;
        internal List<string> map_report_list = new List<string>();
        internal string map_projnum;
        internal string map_projname;
        internal string map_client;

        private IDictionary<string, List<double>> state_centerpoint_dict = new Dictionary<string, List<double>>();




        //LOAD OPTIONS METHODS.....................................................................
        private void FormMain_Load(object sender, EventArgs e)
        {

            state_centerpoint_dict.Add("alaska", new List<double>(3) { 64.200841, -149.493673, 4 });
            state_centerpoint_dict.Add("arizona", new List<double>(3) { 34.048928, -111.093731, 6.5 });
            state_centerpoint_dict.Add("montana", new List<double>(3) { 46.879682, -110.362566, 6 });
            state_centerpoint_dict.Add("oregon", new List<double>(3) { 43.804133, -120.554201, 6.5 });
            state_centerpoint_dict.Add("washington", new List<double>(3) { 47.751074, -120.740138, 6.5 });
            state_centerpoint_dict.Add("wyoming", new List<double>(3) { 43.075968, -107.290284, 6.5 });
            textBox_Results.BackColor = Color.White;

            //load options for states from database
            string sql;
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
                        string state = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(rdr["name"]).ToLower());
                        if (!state.ToLower().Contains("kmz") && state.ToLower() != "folderpaths")
                        {
                            state_tables.Add(state);
                        }
                    }
                }
            }
            state_tables.Sort();
            foreach (string tab in state_tables)
            {
                comboBox_State.Items.Add(tab);
            }

            //set last update datetime for databases
            string record_datetimeupdate = String.Empty;
            sql = @"SELECT value FROM FOLDERPATHS WHERE type ='record_update_datetime'";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        record_datetimeupdate = Convert.ToString(rdr["value"]);
                    }
                }
            }
            label_DBUpdateTime.Text = "Database last updated on: " + record_datetimeupdate;
            con.Close();

            comboBox_State.SelectedItem = "Alaska";

            gmap.DragButton = MouseButtons.Left;
            gmap.IgnoreMarkerOnMouseWheel = true;

        }

        private void comboBoxState_SelectedValueChanged(object sender, EventArgs e)
        {
            //clear current items
            gmap.Overlays.Clear();
            marker_list.Clear();
            map_report_list.Clear();
            listView_MapReports.Items.Clear();

            listView_PN.Items.Clear();
            listView_ProjName.Items.Clear();
            listView_County.Items.Clear();
            listView_City.Items.Clear();

            //read data from sqlite db to dictionary
            string state = comboBox_State.SelectedItem.ToString();
            try
            {
                gmap.Position = new PointLatLng(state_centerpoint_dict[state.ToLower()][0], state_centerpoint_dict[state.ToLower()][1]);
                gmap.Zoom = state_centerpoint_dict[state.ToLower()][2];
            }
            catch (Exception ex) { }

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

            textBox_PN.Text = "";
            textBox_ProjName.Text = "";
            textBox_County.Text = "";
            textBox_City.Text = "";
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
            gmap.Overlays.Clear();
            marker_list.Clear();
            string state = comboBox_State.SelectedItem.ToString();

            //build the where clause based on all selections
            List<string> query_whereclause = new List<string>();
            string selectedPN = listView_PN.SelectedItems[0].Text.ToString();
            string selectedProjName;
            string selectedCity;

            try
            {
                selectedProjName = listView_ProjName.SelectedItems[0].Text.ToString();
                query_whereclause.Add("projectname='" + selectedProjName + "'");
            }
            catch (Exception) { }

            try
            {
                selectedCity = listView_City.SelectedItems[0].Text.ToString();
                query_whereclause.Add("city='" + selectedPN + "'");
            }
            catch (Exception) { }


            string query_wherestring = string.Join(" OR ", query_whereclause.ToArray());
            if (query_wherestring == "")
            {
                query_wherestring += "projectnumber='" + selectedPN + "'";
            }
            else
            {
                query_wherestring += "OR projectnumber='" + selectedPN + "'";
            }

            //setup database connection
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            string sql;

            pointDict.Clear();
            pointDict.Add("report", new List<string>());
            pointDict.Add("projectnumber", new List<string>());
            pointDict.Add("projectname", new List<string>());
            pointDict.Add("client", new List<string>());
            pointDict.Add("lat", new List<string>());
            pointDict.Add("lon", new List<string>());

            //get all tables in database
            sql = @"SELECT report,projectnumber,projectname,client,lat,lon FROM " + state.ToUpper() + "KMZ WHERE " + query_wherestring;
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        pointDict["report"].Add(Convert.ToString(rdr["report"]));
                        pointDict["projectnumber"].Add(Convert.ToString(rdr["projectnumber"]));
                        pointDict["projectname"].Add(Convert.ToString(rdr["projectname"]));
                        pointDict["client"].Add(Convert.ToString(rdr["client"]));
                        pointDict["lat"].Add(Convert.ToString(rdr["lat"]));
                        pointDict["lon"].Add(Convert.ToString(rdr["lon"]));
                    }
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
                marker_list.Add(marker);
            }
            gmap.Overlays.Add(markers);
            gmap.ZoomAndCenterMarkers("markers");
        }

        private void listView_ProjName_Click(object sender, EventArgs e)
        {
            gmap.Overlays.Clear();
            marker_list.Clear();
            string state = comboBox_State.SelectedItem.ToString();

            //build the where clause based on all selections
            List<string> query_whereclause = new List<string>();
            string selectedProjName = listView_ProjName.SelectedItems[0].Text.ToString();
            string selectedPN;
            string selectedCity;

            try
            {
                selectedPN = listView_PN.SelectedItems[0].Text.ToString();
                query_whereclause.Add("projectnumber='" + selectedPN + "'");
            }
            catch (Exception) { }

            try
            {
                selectedCity = listView_City.SelectedItems[0].Text.ToString();
                query_whereclause.Add("city='" + selectedCity + "'");
            }
            catch (Exception) { }
            string query_wherestring = string.Join(" OR ", query_whereclause.ToArray());
            if (query_wherestring == "")
            {
                query_wherestring += "projectname='" + selectedProjName + "'";
            }
            else
            {
                query_wherestring += "OR projectname='" + selectedProjName + "'";
            }

            //setup database connection
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            string sql;

            pointDict.Clear();
            pointDict.Add("report", new List<string>());
            pointDict.Add("projectnumber", new List<string>());
            pointDict.Add("projectname", new List<string>());
            pointDict.Add("client", new List<string>());
            pointDict.Add("lat", new List<string>());
            pointDict.Add("lon", new List<string>());

            //get all tables in database
            sql = @"SELECT report,projectnumber,projectname,client,lat,lon FROM " + state.ToUpper() + "KMZ WHERE " + query_wherestring;
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        pointDict["report"].Add(Convert.ToString(rdr["report"]));
                        pointDict["projectnumber"].Add(Convert.ToString(rdr["projectnumber"]));
                        pointDict["projectname"].Add(Convert.ToString(rdr["projectname"]));
                        pointDict["client"].Add(Convert.ToString(rdr["client"]));
                        pointDict["lat"].Add(Convert.ToString(rdr["lat"]));
                        pointDict["lon"].Add(Convert.ToString(rdr["lon"]));
                    }
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
                marker_list.Add(marker);
            }
            gmap.Overlays.Add(markers);
            gmap.ZoomAndCenterMarkers("markers");
        }

        private void listView_City_Click(object sender, EventArgs e)
        {
            gmap.Overlays.Clear();
            marker_list.Clear();
            string state = comboBox_State.SelectedItem.ToString();

            //build the where clause based on all selections
            List<string> query_whereclause = new List<string>();
            string selectedCity = listView_City.SelectedItems[0].Text.ToString();
            string selectedPN;
            string selectedProjName;

            try
            {
                selectedPN = listView_PN.SelectedItems[0].Text.ToString();
                query_whereclause.Add("projectnumber='" + selectedPN + "'");
            }
            catch (Exception) { }

            try
            {
                selectedProjName = listView_ProjName.SelectedItems[0].Text.ToString();
                query_whereclause.Add("projectname='" + selectedProjName + "'");
            }
            catch (Exception) { }
            string query_wherestring = string.Join(" OR ", query_whereclause.ToArray());
            if (query_wherestring == "")
            {
                query_wherestring += "city='" + selectedCity + "'";
            }
            else
            {
                query_wherestring += "OR city='" + selectedCity + "'";
            }

            //setup database connection
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            string sql;

            pointDict.Clear();
            pointDict.Add("report", new List<string>());
            pointDict.Add("projectnumber", new List<string>());
            pointDict.Add("projectname", new List<string>());
            pointDict.Add("client", new List<string>());
            pointDict.Add("lat", new List<string>());
            pointDict.Add("lon", new List<string>());

            //get all tables in database
            sql = @"SELECT report,projectnumber,projectname,client,lat,lon FROM " + state.ToUpper() + "KMZ WHERE " + query_wherestring;
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        pointDict["report"].Add(Convert.ToString(rdr["report"]));
                        pointDict["projectnumber"].Add(Convert.ToString(rdr["projectnumber"]));
                        pointDict["projectname"].Add(Convert.ToString(rdr["projectname"]));
                        pointDict["client"].Add(Convert.ToString(rdr["client"]));
                        pointDict["lat"].Add(Convert.ToString(rdr["lat"]));
                        pointDict["lon"].Add(Convert.ToString(rdr["lon"]));
                    }
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
                marker_list.Add(marker);
            }
            gmap.Overlays.Add(markers);
            gmap.ZoomAndCenterMarkers("markers");
        }

        private void gmap_Load(object sender, EventArgs e)
        {
            // initialize the map
            gmap.MapProvider = OpenStreetMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(64.200841, -149.493673);
            gmap.ShowCenter = false;
            gmap.DisableFocusOnMouseEnter = true;

        }

        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            //if form is open, close it
            if (Application.OpenForms.OfType<Form_MapPopup>().Any())
            {
                Application.OpenForms.OfType<Form_MapPopup>().First().Close();
            }
            mouse_x = MousePosition.X;
            mouse_y = MousePosition.Y;

            int markerindex = marker_list.IndexOf(item);
            map_report = pointDict["report"][markerindex];
            map_projnum = pointDict["projectnumber"][markerindex];
            map_projname = pointDict["projectname"][markerindex];
            map_client = pointDict["client"][markerindex];

            Form_MapPopup s = new Form_MapPopup();
            s.Show();
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

        private void buttonUpdateRecordDB_Click(object sender, EventArgs e)
        {

            label_UpdateRecordDB.Text = "Uploading data. This operation may take up to 10 seconds.";
            label_UpdateRecordDB.ForeColor = Color.Blue;

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
                                if (sheetName.Substring(0, sheetName.Length - 1) == "Alaska")
                                {
                                    sql = @"CREATE TABLE IF NOT EXISTS ALASKA(" +
                                        "report VARCHAR(255), projectnumber VARCHAR(255), client VARCHAR(255), projectname VARCHAR(255), area VARCHAR(255), city VARCHAR(255), anchoragegrid VARCHAR(255)" +
                                        ")";
                                }
                                else
                                {
                                    sql = @"CREATE TABLE IF NOT EXISTS " + sheetName.Substring(0, sheetName.Length - 1).ToUpper() + "(" +
                                        "report VARCHAR(255), projectnumber VARCHAR(255), client VARCHAR(255), projectname VARCHAR(255), city VARCHAR(255)" +
                                        ")";
                                }
                                cmd_sql = new SQLiteCommand(sql, con);
                                cmd_sql.ExecuteNonQuery();

                                //clear database table
                                sql = @"DELETE FROM " + sheetName.Substring(0, sheetName.Length - 1).ToUpper();
                                cmd_sql = new SQLiteCommand(sql, con);
                                cmd_sql.ExecuteNonQuery();

                                //send datatable to database, Alaska tables are different than others
                                cmd_sql = new SQLiteCommand();
                                if (sheetName.Substring(0, sheetName.Length - 1) == "Alaska")
                                {
                                    using (cmd_sql = new SQLiteCommand(con))
                                    {
                                        using (var transaction = con.BeginTransaction())
                                        {
                                            foreach (DataRow dataRow in dtResult.Rows)
                                            {
                                                cmd_sql.CommandText = "INSERT INTO ALASKA(report,projectnumber,client,projectname,area,city,anchoragegrid) VALUES (";
                                                for (int i = 0; i < 7; i++)
                                                {
                                                    if (i == 6)
                                                    {
                                                        cmd_sql.CommandText = cmd_sql.CommandText + "'" + dataRow[i].ToString().Replace("'", "''") + "'";
                                                    }
                                                    else
                                                    {
                                                        cmd_sql.CommandText = cmd_sql.CommandText + "'" + dataRow[i].ToString().Replace("'", "''") + "',";
                                                    }
                                                }

                                                cmd_sql.CommandText = cmd_sql.CommandText + ")";
                                                cmd_sql.ExecuteNonQuery();
                                            }
                                            transaction.Commit();
                                        }

                                    }
                                }
                                else
                                {
                                    using (cmd_sql = new SQLiteCommand(con))
                                    {
                                        using (var transaction = con.BeginTransaction())
                                        {
                                            foreach (DataRow dataRow in dtResult.Rows)
                                            {
                                                cmd_sql.CommandText = "INSERT INTO " + sheetName.Substring(0, sheetName.Length - 1).ToUpper() + "(report,projectnumber,client,projectname,city) VALUES (";
                                                for (int i = 0; i < 5; i++)
                                                {
                                                    if (i == 4)
                                                    {
                                                        cmd_sql.CommandText = cmd_sql.CommandText + "'" + dataRow[i].ToString().Replace("'", "''") + "'";
                                                    }
                                                    else
                                                    {
                                                        cmd_sql.CommandText = cmd_sql.CommandText + "'" + dataRow[i].ToString().Replace("'", "''") + "',";
                                                    }
                                                }
                                                cmd_sql.CommandText = cmd_sql.CommandText + ")";
                                                cmd_sql.ExecuteNonQuery();
                                            }
                                            transaction.Commit();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //reset datetime of update
                    DateTime now = DateTime.Now;
                    sql = "DELETE FROM FOLDERPATHS WHERE type='record_update_datetime'";
                    cmd_sql = new SQLiteCommand(sql, con);
                    cmd_sql.ExecuteNonQuery();
                    sql = "INSERT INTO FOLDERPATHS (type,value) VALUES ('record_update_datetime','" + now + "')";
                    cmd_sql = new SQLiteCommand(sql, con);
                    cmd_sql.ExecuteNonQuery();
                    label_DBUpdateTime.Text = "Database last updated on: " + now;

                    label_UpdateRecordDB.Text = "Upload complete!";
                    label_UpdateRecordDB.ForeColor = Color.Green;
                }

            }
            catch (Exception)
            {
                label_UpdateRecordDB.Text = "There was an error updating the database. Please verify the soils report record excel file exists in the folder entered in the Folder Paths tab.";
                label_UpdateRecordDB.ForeColor = Color.Red;
            }

            //load options for states from database
            List<string> state_tables = new List<string>();
            comboBox_State.Items.Clear();
            //get all tables in database
            sql = @"SELECT name FROM sqlite_schema WHERE type ='table' AND name NOT LIKE 'sqlite_%'";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        string state = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(rdr["name"]).ToLower());
                        if (!state.ToLower().Contains("kmz") && state.ToLower() != "folderpaths")
                        {
                            state_tables.Add(state);
                        }
                    }
                }
            }
            state_tables.Sort();
            foreach (string tab in state_tables)
            {
                comboBox_State.Items.Add(tab);
            }
            comboBox_State.SelectedItem = "Alaska";
            comboBoxState_SelectedValueChanged(sender, e);


            con.Close();


        }

        private void button_UpdateKMZDB_Click(object sender, EventArgs e)
        {
            label_UpdateKMZDB.Text = "Uploading data. This operation may take up to 10 seconds.";
            label_UpdateKMZDB.ForeColor = Color.Blue;

            //setup database connection
            SQLiteCommand cmd_sql;
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            string sql = string.Empty;
            string fname = string.Empty;

            //get kmz path
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

            //get kmz file names
            string searchstring;
            int startindex;
            int endindex;
            string reportnum;
            string state_name;
            //loop through each state folder in the kmz path
            List<string> final_files = new List<string>();
            List<string> directories_states = Directory.GetDirectories(fname).ToList();
            foreach (string dir_state in directories_states)
            {
                state_name = dir_state.Replace(fname + @"\", "").ToUpper();
                //loop through each city folder in the state folder
                List<string> directories_cities = Directory.GetDirectories(dir_state).ToList();
                foreach (string dir_city in directories_cities)
                {
                    //loop through each kmz file in the city folder
                    List<string> kmz_files = Directory.GetFiles(dir_city, "*.kmz").ToList();
                    foreach (string kmz_file in kmz_files)
                    {
                        if (kmz_file.ToLower().Contains("redfiles") && !kmz_file.ToLower().Contains("project"))
                        {
                            final_files.Add(kmz_file);
                        }
                    }
                }

                IDictionary<string, List<string>> pointDict = new Dictionary<string, List<string>>();
                pointDict.Add("report", new List<string>());
                pointDict.Add("lat", new List<string>());
                pointDict.Add("lon", new List<string>());
                XNamespace ns = "http://www.opengis.net/kml/2.2";

                //loop through each file and parse kmz
                foreach (string file in final_files)
                {
                    var file_open = File.OpenRead(file);
                    var zip = new ZipArchive(file_open, ZipArchiveMode.Read);
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

                            //get file number
                            searchstring = "<td>File</td>";
                            if (desc.IndexOf(searchstring) == -1)
                            {
                                searchstring = "<td>redfile</td>";
                            }
                            startindex = desc.IndexOf(searchstring) + searchstring.Length;
                            endindex = desc.IndexOf("</tr>", desc.IndexOf(searchstring) + 1);
                            reportnum = desc.Substring(startindex, endindex - startindex);
                            pointDict["report"].Add(reportnum.Substring(6, reportnum.Length - 13));

                        }
                    }
                }

                //create database table
                sql = "CREATE TABLE IF NOT EXISTS KMZ(report VARCHAR(255), lat FLOAT, lon FLOAT)";
                cmd_sql = new SQLiteCommand(sql, con);
                cmd_sql.ExecuteNonQuery();

                //clear database table
                sql = "DELETE FROM KMZ";
                cmd_sql = new SQLiteCommand(sql, con);
                cmd_sql.ExecuteNonQuery();

                //add dictionary to the database
                for (int i = 0; i < pointDict["report"].Count(); i++)
                {
                    sql = "INSERT INTO KMZ (report,lat,lon) VALUES ('" + pointDict["report"][i] + "','" + pointDict["lat"][i] + "','" + pointDict["lon"][i] + "')";
                    cmd_sql = new SQLiteCommand(sql, con);
                    cmd_sql.ExecuteNonQuery();
                }

                //create a join table with record columns
                if (state_name == "ALASKA")
                {
                    //create the join table
                    sql = "CREATE TABLE IF NOT EXISTS ALASKAKMZ(report VARCHAR(255), lat FLOAT, lon FLOAT, projectnumber VARCHAR(255), client VARCHAR(255), projectname VARCHAR(255), area VARCHAR(255), city VARCHAR(255), anchoragegrid VARCHAR(255))";
                    cmd_sql = new SQLiteCommand(sql, con);
                    cmd_sql.ExecuteNonQuery();

                    //clear database table
                    sql = "DELETE FROM ALASKAKMZ";
                    cmd_sql = new SQLiteCommand(sql, con);
                    cmd_sql.ExecuteNonQuery();

                    sql = "INSERT INTO ALASKAKMZ SELECT KMZ.report, lat, lon, ALASKA.projectnumber, client, projectname, area, city, anchoragegrid FROM KMZ " +
                        "LEFT JOIN ALASKA " +
                        "ON (KMZ.report=ALASKA.report)";

                    cmd_sql = new SQLiteCommand(sql, con);
                    cmd_sql.ExecuteNonQuery();
                }
                else
                {
                    //create the join table
                    sql = "CREATE TABLE IF NOT EXISTS " + state_name + "KMZ(report VARCHAR(255), lat FLOAT, lon FLOAT, projectnumber VARCHAR(255), client VARCHAR(255), projectname VARCHAR(255), city VARCHAR(255))";
                    cmd_sql = new SQLiteCommand(sql, con);
                    cmd_sql.ExecuteNonQuery();

                    //clear database table
                    sql = "DELETE FROM " + state_name + "KMZ";
                    cmd_sql = new SQLiteCommand(sql, con);
                    cmd_sql.ExecuteNonQuery();

                    sql = "INSERT INTO " + state_name + "KMZ SELECT KMZ.report, lat, lon, projectnumber, client, projectname, city FROM KMZ " +
                        "LEFT JOIN " + state_name + " " +
                        "ON (KMZ.report=" + state_name + ".report)";

                    cmd_sql = new SQLiteCommand(sql, con);
                    cmd_sql.ExecuteNonQuery();
                }
            }

            label_UpdateKMZDB.Text = "Upload complete!";
            label_UpdateKMZDB.ForeColor = Color.Green;



        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_UpdateRecordDB.Text = "";
            label_UpdateRecordDB.ForeColor = Color.Black;
            label_UpdateKMZDB.Text = "";
            label_UpdateKMZDB.ForeColor = Color.Black;

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

        private void button_Reset_Click(object sender, EventArgs e)
        {
            listView_PN.SelectedItems.Clear();
            listView_ProjName.SelectedItems.Clear();
            listView_City.SelectedItems.Clear();

            gmap.Overlays.Clear();
            map_report_list.Clear();
            listView_MapReports.Items.Clear();
            string state = comboBox_State.SelectedItem.ToString();
            try
            {
                gmap.Position = new PointLatLng(state_centerpoint_dict[state.ToLower()][0], state_centerpoint_dict[state.ToLower()][1]);
                gmap.Zoom = state_centerpoint_dict[state.ToLower()][2];
            }
            catch (Exception ex) { }

            textBox_PN.Text = "";
            textBox_ProjName.Text = "";
            textBox_County.Text = "";
            textBox_City.Text = "";
        }

        private void listView_MapReports_DoubleClick(object sender, EventArgs e)
        {
            string selectedreport = listView_MapReports.SelectedItems[0].Text.ToString();
            map_report_list.Remove(selectedreport);
            listView_MapReports.Items.Clear();
            map_report_list.Sort();
            foreach (string r in map_report_list)
            {
                ListViewItem lvi = new ListViewItem(r);
                listView_MapReports.Items.Add(lvi);
            }

        }

        private void button_SearchMapPDFs_Click(object sender, EventArgs e)
        {
            textBox_Results.Text = "";
            textBox_Results.ForeColor = Color.Black;

            report_nums = map_report_list;
            //open the search results form
            this.Hide();
            Form2 s = new Form2();
            s.Show();
        }

        private void button_ClearMapList_Click(object sender, EventArgs e)
        {
            map_report_list.Clear();
            listView_MapReports.Items.Clear();
        }
    }
}