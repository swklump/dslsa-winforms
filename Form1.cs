using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Globalization;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace dslsa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        internal string selectedState = "";
        internal string pdffolder = "";
        private List<ListViewItem> masterlist_pn;
        private List<ListViewItem> masterlist_projname;
        private List<ListViewItem> masterlist_county;
        private List<ListViewItem> masterlist_city;
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
        internal string map_type;
        internal string map_depth;
        internal string map_year;

        private IDictionary<string, List<double>> state_centerpoint_dict = new Dictionary<string, List<double>>();


        //LOAD OPTIONS METHODS.....................................................................
        private void FormMain_Load(object sender, EventArgs e)
        {

            //add centerpoints of states for map
            state_centerpoint_dict.Add("alaska", new List<double>(3) { 64.200841, -149.493673, 4 });
            state_centerpoint_dict.Add("arizona", new List<double>(3) { 34.048928, -111.093731, 6.5 });
            state_centerpoint_dict.Add("california", new List<double>(3) { 36.778261, -119.417932, 6.5 });
            state_centerpoint_dict.Add("colorado", new List<double>(3) { 39.550051, -105.782067, 6.5 });
            state_centerpoint_dict.Add("idaho", new List<double>(3) { 44.068202, -114.742041, 6.5 });
            state_centerpoint_dict.Add("kansas", new List<double>(3) { 39.011902, -98.484247, 6.5 });
            state_centerpoint_dict.Add("montana", new List<double>(3) { 46.879682, -110.362566, 6 });
            state_centerpoint_dict.Add("nebraska", new List<double>(3) { 41.492537, -99.901813, 6.5 });
            state_centerpoint_dict.Add("nevada", new List<double>(3) { 38.802610, -116.419389, 6.5 });
            state_centerpoint_dict.Add("new mexico", new List<double>(3) { 34.519940, -105.870090, 6.5 });
            state_centerpoint_dict.Add("north dakota", new List<double>(3) { 47.551493, -101.002012, 6.5 });
            state_centerpoint_dict.Add("oklahoma", new List<double>(3) { 35.007752, -97.092877, 6.5 });
            state_centerpoint_dict.Add("oregon", new List<double>(3) { 43.804133, -120.554201, 6.5 });
            state_centerpoint_dict.Add("south dakota", new List<double>(3) { 43.969515, -99.901813, 6.5 });
            state_centerpoint_dict.Add("texas", new List<double>(3) { 31.968599, -99.901813, 6.5 });
            state_centerpoint_dict.Add("utah", new List<double>(3) { 39.320980, -111.093731, 6.5 });
            state_centerpoint_dict.Add("washington", new List<double>(3) { 47.751074, -120.740138, 6.5 });
            state_centerpoint_dict.Add("wyoming", new List<double>(3) { 43.075968, -107.290284, 6.5 });
            textBox_Results.BackColor = Color.White;

            //load options for states from database
            string sql;
            List<string> state_tables = new List<string>();

            con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();

            //get all tables in database
            sql = "SELECT name FROM sqlite_schema WHERE type ='table' AND name NOT LIKE 'sqlite_%'";
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

            //add them to the combobox
            state_tables.Sort();
            foreach (string tab in state_tables) { comboBox_State.Items.Add(tab); comboBox_StateAdmin.Items.Add(tab); }

            //set last update datetime for record and kmz databases
            string record_datetimeupdate = String.Empty;
            sql = "SELECT value FROM FOLDERPATHS WHERE type ='record_update_datetime'";
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
            string kmz_datetimeupdate = String.Empty;
            sql = "SELECT value FROM FOLDERPATHS WHERE type ='kmz_update_datetime'";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        kmz_datetimeupdate = Convert.ToString(rdr["value"]);
                    }
                }
            }
            label_DBUpdateTime.Text = "Database last updated on: " + record_datetimeupdate;
            label_KMZDBUpdateTime.Text = "Database last updated on: " + kmz_datetimeupdate;

            //show folder paths for excel, kmz, and pdfs
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
            richTextBox_CurrentExcelPath.Text = fname;
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
            richTextBox_CurrentKMZPath.Text = fname;
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
            richTextBox_CurrentPDFPath.Text = fname;
            //get lat lon excel report path to display
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT value FROM FOLDERPATHS WHERE type='latlonexcelpath'", con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        fname = Convert.ToString(rdr["value"]);
                    }
                }
            }
            richTextBox_CurrentLatLonPath.Text = fname;

            con.Close();

            comboBox_State.SelectedItem = "Alaska";
            comboBox_StateAdmin.SelectedItem = "Alaska";
            selectedState = "Alaska";
            comboBox_QueryType.SelectedItem = "AND";
            comboBox_AncGrid.SelectedItem = "";
            textBox_Results.Text = "";
        }

        private void comboBoxState_SelectedValueChanged(object sender, EventArgs e)
        {
            //clear current items
            gmap.Overlays.Clear();
            marker_list.Clear();
            map_report_list.Clear();
            listView_MapReports.Items.Clear();
            List<string> keys;

            List<ListView> items_toclear = new List<ListView>() { listView_PN, listView_ProjName, listView_County, listView_City };
            foreach (ListView listitem in items_toclear) { listitem.Items.Clear(); }

            string state = comboBox_State.SelectedItem.ToString();
            selectedState = state;
            if (state == "Alaska") { label_AncGrid.Visible = true; comboBox_AncGrid.Visible = true; }
            else { label_AncGrid.Visible = false; comboBox_AncGrid.Visible = false; }

            //set state centerpoint
            try
            {
                gmap.Position = new PointLatLng(state_centerpoint_dict[state.ToLower()][0], state_centerpoint_dict[state.ToLower()][1]);
                gmap.Zoom = state_centerpoint_dict[state.ToLower()][2];
            }
            catch (Exception ex) { }

            //read data from sqlite db to dictionary
            Dictionary<string, List<string>> dict_cols = new Dictionary<string, List<string>>();
            if (state == "Alaska") { keys = new List<string>() { "projectnumber", "projectname", "county", "city", "anchoragegrid" }; }
            else { keys = new List<string>() { "projectnumber", "projectname", "county", "city" }; }
            foreach (string k in keys) { dict_cols.Add(k, new List<string>()); }

            con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();

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

            List<object> anchoragegrid_dropdownitems = new List<object>();
            //convert anchoragegrid to int
            if (state == "Alaska")
            {
                foreach (string x in dict_cols["anchoragegrid"])
                {
                    int y = 0;
                    if (Int32.TryParse(x, out y)) { anchoragegrid_dropdownitems.Add(y); }
                }
                anchoragegrid_dropdownitems.Sort();
                anchoragegrid_dropdownitems.Remove(0);

                List<object> anchoragegrid_textitems = new List<object>();
                foreach (string x in dict_cols["anchoragegrid"])
                {
                    int y = 0;
                    if (Int32.TryParse(x, out y)) { continue; }

                    if (!x.Contains(",")) { anchoragegrid_textitems.Add(x); }
                }
                anchoragegrid_textitems.Sort();
                anchoragegrid_dropdownitems.AddRange(anchoragegrid_textitems);
            }

            con.Close();

            //Add items to master lists and listview ui
            masterlist_pn = new List<ListViewItem>();
            masterlist_projname = new List<ListViewItem>();
            masterlist_county = new List<ListViewItem>();
            masterlist_city = new List<ListViewItem>();

            listView_PN.BeginUpdate();
            foreach (string pn in dict_cols["projectnumber"])
            {
                ListViewItem lvi = new ListViewItem(pn);
                listView_PN.Items.Add(lvi);
                masterlist_pn.Add(lvi);
            }
            listView_PN.EndUpdate();

            listView_ProjName.BeginUpdate();
            foreach (string name in dict_cols["projectname"])
            {
                ListViewItem lvi = new ListViewItem(name);
                listView_ProjName.Items.Add(lvi);
                masterlist_projname.Add(lvi);
            }
            listView_ProjName.EndUpdate();

            listView_County.BeginUpdate();
            foreach (string county in dict_cols["county"])
            {
                ListViewItem lvi = new ListViewItem(county);
                listView_County.Items.Add(lvi);
                masterlist_county.Add(lvi);
            }
            listView_County.EndUpdate();

            listView_City.BeginUpdate();
            foreach (string city in dict_cols["city"])
            {
                ListViewItem lvi = new ListViewItem(city);
                listView_City.Items.Add(lvi);
                masterlist_city.Add(lvi);
            }
            listView_City.EndUpdate();

            if (state == "Alaska")
            {
                foreach (object grid in anchoragegrid_dropdownitems) { comboBox_AncGrid.Items.Add(grid); }
            }

            //clear search boxes
            List<TextBox> clearboxes = new List<TextBox>() { textBox_PN, textBox_ProjName, textBox_County, textBox_City };
            foreach (TextBox box in clearboxes) { box.Text = ""; }
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            //clear listview selections
            List<ListView> items_toclear = new List<ListView>() { listView_PN, listView_ProjName, listView_County, listView_City };
            foreach (ListView listitem in items_toclear) { listitem.SelectedItems.Clear(); }

            textBox_Results.Text = "";
            comboBox_QueryType.SelectedItem = "AND";
            comboBox_AncGrid.SelectedItem = "";


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

            //clear search boxes
            List<TextBox> clearboxes = new List<TextBox>() { textBox_PN, textBox_ProjName, textBox_County, textBox_City };
            foreach (TextBox box in clearboxes) { box.Text = ""; }
        }

        private void comboBox_QueryType_SelectedValueChanged(object sender, EventArgs e)
        {
            gmap.Overlays.Clear();
            marker_list.Clear();
            string state = comboBox_State.SelectedItem.ToString();

            //build the where clause based on all selections
            List<string> query_whereclause = new List<string>();
            string selectedPN;
            string selectedProjName;
            string selectedCity;
            string selectedGrid;

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

            try
            {
                selectedCity = listView_City.SelectedItems[0].Text.ToString();
                query_whereclause.Add("city='" + selectedCity + "'");
            }
            catch (Exception) { }
            if (state == "Alaska")
            {
                try
                {
                    selectedGrid = comboBox_AncGrid.Text.ToString();
                    if (selectedGrid != "")
                    {
                        query_whereclause.Add("anchoragegrid='" + selectedGrid + "'");
                    }
                }
                catch (Exception) { }
            }

            string query_type = comboBox_QueryType.SelectedItem.ToString();
            string query_wherestring = string.Join(" " + query_type + " ", query_whereclause.ToArray());
            if (query_whereclause.Count() == 0)
            {
                textBox_Results.Text = "";
                return;
            }

            //reset marker dict
            pointDict.Clear();
            List<string> pointdictkeys = new List<string>() { "report", "projectnumber", "projectname", "client", "lat", "lon", "type", "depth", "year" };
            foreach (string k in pointdictkeys) { pointDict.Add(k, new List<string>()); }

            //setup database connection
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            string sql;

            //get markers
            sql = "SELECT report,projectnumber,projectname,client,lat,lon,type,depth,year FROM " + state.ToUpper() + "KMZ WHERE " + query_wherestring;
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        foreach (KeyValuePair<string, List<string>> kvp in pointDict) { pointDict[kvp.Key].Add(Convert.ToString(rdr[kvp.Key])); }
                    }
                }
            }

            //check if any markers found
            if (pointDict["lat"].Count() == 0)
            {
                textBox_Results.Text = "No georeferencing exists for this selection.";
                textBox_Results.ForeColor = Color.Red;
                try
                {
                    gmap.Position = new PointLatLng(state_centerpoint_dict[state.ToLower()][0], state_centerpoint_dict[state.ToLower()][1]);
                    gmap.Zoom = state_centerpoint_dict[state.ToLower()][2];
                }
                catch (Exception ex) { }
                return;
            }
            textBox_Results.Text = "";

            //get unique list of reports, assign a marker type
            HashSet<string> unique_reports_hash = new HashSet<string>(pointDict["report"]);
            List<string> unique_reports_list = unique_reports_hash.ToList();
            IDictionary<string, string> unique_reports_dict = new Dictionary<string, string>();
            int counter = 1;
            foreach (string r in unique_reports_list)
            {
                unique_reports_dict.Add(r, counter.ToString());
                if (counter < 37) { counter++; }
                else { counter = 1; }

            }

            // add markers
            GMapOverlay markers = new GMapOverlay("markers");
            for (int i = 0; i < pointDict["lat"].Count(); i++)
            {
                GMapMarker marker =
                    new GMarkerGoogle(
                        new PointLatLng(Convert.ToDouble(pointDict["lat"].ElementAt(i)), Convert.ToDouble(pointDict["lon"].ElementAt(i))),
                       (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), unique_reports_dict[pointDict["report"].ElementAt(i)], true));
                markers.Markers.Add(marker);
                marker_list.Add(marker);

            }
            gmap.Overlays.Add(markers);
            gmap.ZoomAndCenterMarkers("markers");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear labels
            List<Label> labels_toclear = new List<Label>() { label_UpdateRecordDB, label_UpdateKMZDB, label_ExcelPathMessage, label_KMZPathMessage, label_PDFPathMessage, label_LatLonPathMessage };
            foreach (Label label in labels_toclear) { label.Text = ""; label.ForeColor = Color.Black; }

            textBox_NewExcelPath.Text = "";
            textBox_NewKMZPath.Text = "";
            textBox_NewPDFPath.Text = "";
            textBox_NewLatLonPath.Text = "";
            label_PDFNotFound.Text = "";
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
            listView_County.Items.Clear();
            listView_County.Items.AddRange(masterlist_county.Where(lvi => lvi.Text.ToLower().Contains(textBox_County.Text.ToLower())).ToArray());
            foreach (ListViewItem item in masterlist_county.Where(lvi => lvi.Text.ToLower().Contains(textBox_County.Text.ToLower()))) ;
        }

        private void textBox_City_TextChanged(object sender, EventArgs e)
        {
            listView_City.Items.Clear();
            listView_City.Items.AddRange(masterlist_city.Where(lvi => lvi.Text.ToLower().Contains(textBox_City.Text.ToLower())).ToArray());
            foreach (ListViewItem item in masterlist_city.Where(lvi => lvi.Text.ToLower().Contains(textBox_City.Text.ToLower()))) ;
        }



        //MAP METHODS.....................................................................
        private void gmap_Load(object sender, EventArgs e)
        {
            // initialize the map
            gmap.MapProvider = OpenStreetMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(64.200841, -149.493673);
            gmap.ShowCenter = false;
            gmap.DisableFocusOnMouseEnter = true;
            gmap.DragButton = MouseButtons.Left;
            gmap.IgnoreMarkerOnMouseWheel = true;
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
            map_type = pointDict["type"][markerindex];
            map_depth = pointDict["depth"][markerindex];
            map_year = pointDict["year"][markerindex];

            Form_MapPopup s = new Form_MapPopup();
            s.Show();
        }

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
            string selectedGrid;

            try
            {
                selectedProjName = listView_ProjName.SelectedItems[0].Text.ToString();
                query_whereclause.Add("projectname='" + selectedProjName + "'");
            }
            catch (Exception) { }

            try
            {
                selectedCity = listView_City.SelectedItems[0].Text.ToString();
                query_whereclause.Add("city='" + selectedCity + "'");
            }
            catch (Exception) { }

            if (state == "Alaska")
            {
                try
                {
                    selectedGrid = comboBox_AncGrid.Text.ToString();
                    if (selectedGrid != "")
                    {
                        query_whereclause.Add("anchoragegrid='" + selectedGrid + "'");
                    }
                }
                catch (Exception) { }
            }

            string query_type = comboBox_QueryType.SelectedItem.ToString();
            string query_wherestring = string.Join(" " + query_type + " ", query_whereclause.ToArray());
            if (query_wherestring == "")
            {
                query_wherestring += "projectnumber='" + selectedPN + "'";
            }
            else
            {
                query_wherestring += " " + query_type + " projectnumber='" + selectedPN + "'";
            }

            //reset marker dict
            pointDict.Clear();
            List<string> pointdictkeys = new List<string>() { "report", "projectnumber", "projectname", "client", "year", "lat", "lon", "type", "depth" };
            foreach (string k in pointdictkeys) { pointDict.Add(k, new List<string>()); }

            //setup database connection
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            string sql;

            //get markers
            sql = "SELECT report,projectnumber,projectname,client,year,lat,lon,type,depth FROM " + state.ToUpper() + "KMZ WHERE " + query_wherestring;
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        foreach (KeyValuePair<string, List<string>> kvp in pointDict) { pointDict[kvp.Key].Add(Convert.ToString(rdr[kvp.Key])); }
                    }
                }
            }

            //check if any markers found
            if (pointDict["lat"].Count() == 0)
            {
                textBox_Results.Text = "No georeferencing exists for this selection.";
                textBox_Results.ForeColor = Color.Red;
                try
                {
                    gmap.Position = new PointLatLng(state_centerpoint_dict[state.ToLower()][0], state_centerpoint_dict[state.ToLower()][1]);
                    gmap.Zoom = state_centerpoint_dict[state.ToLower()][2];
                }
                catch (Exception ex) { }
                return;
            }
            textBox_Results.Text = "";

            //get unique list of reports, assign a marker type
            HashSet<string> unique_reports_hash = new HashSet<string>(pointDict["report"]);
            List<string> unique_reports_list = unique_reports_hash.ToList();
            IDictionary<string, string> unique_reports_dict = new Dictionary<string, string>();
            int counter = 1;
            foreach (string r in unique_reports_list)
            {
                unique_reports_dict.Add(r, counter.ToString());
                if (counter < 37) { counter++; }
                else { counter = 1; }

            }

            // add markers
            GMapOverlay markers = new GMapOverlay("markers");
            for (int i = 0; i < pointDict["lat"].Count(); i++)
            {
                GMapMarker marker =
                    new GMarkerGoogle(
                        new PointLatLng(Convert.ToDouble(pointDict["lat"].ElementAt(i)), Convert.ToDouble(pointDict["lon"].ElementAt(i))),
                       (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), unique_reports_dict[pointDict["report"].ElementAt(i)], true));
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
            string selectedGrid;

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
            if (state == "Alaska")
            {
                try
                {
                    selectedGrid = comboBox_AncGrid.Text.ToString();
                    if (selectedGrid != "")
                    {
                        query_whereclause.Add("anchoragegrid='" + selectedGrid + "'");
                    }
                }
                catch (Exception) { }
            }

            string query_type = comboBox_QueryType.SelectedItem.ToString();
            string query_wherestring = string.Join(" " + query_type + " ", query_whereclause.ToArray());
            if (query_wherestring == "")
            {
                query_wherestring += "projectname='" + selectedProjName + "'";
            }
            else
            {
                query_wherestring += query_type + " projectname='" + selectedProjName + "'";
            }

            //reset marker dict
            pointDict.Clear();
            List<string> pointdictkeys = new List<string>() { "report", "projectnumber", "projectname", "client", "year", "lat", "lon", "type", "depth" };
            foreach (string k in pointdictkeys) { pointDict.Add(k, new List<string>()); }

            //setup database connection
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            string sql;

            //get all tables in database
            sql = "SELECT report,projectnumber,projectname,client,year,lat,lon,type,depth FROM " + state.ToUpper() + "KMZ WHERE " + query_wherestring;
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        foreach (KeyValuePair<string, List<string>> kvp in pointDict) { pointDict[kvp.Key].Add(Convert.ToString(rdr[kvp.Key])); }
                    }
                }
            }

            //check if any markers found
            if (pointDict["lat"].Count() == 0)
            {
                textBox_Results.Text = "No georeferencing exists for this selection.";
                textBox_Results.ForeColor = Color.Red;
                try
                {
                    gmap.Position = new PointLatLng(state_centerpoint_dict[state.ToLower()][0], state_centerpoint_dict[state.ToLower()][1]);
                    gmap.Zoom = state_centerpoint_dict[state.ToLower()][2];
                }
                catch (Exception ex) { }
                return;
            }
            textBox_Results.Text = "";

            //get unique list of reports, assign a marker type
            HashSet<string> unique_reports_hash = new HashSet<string>(pointDict["report"]);
            List<string> unique_reports_list = unique_reports_hash.ToList();
            IDictionary<string, string> unique_reports_dict = new Dictionary<string, string>();
            int counter = 1;
            foreach (string r in unique_reports_list)
            {
                unique_reports_dict.Add(r, counter.ToString());
                if (counter < 37) { counter++; }
                else { counter = 1; }

            }

            // add markers
            GMapOverlay markers = new GMapOverlay("markers");
            for (int i = 0; i < pointDict["lat"].Count(); i++)
            {
                GMapMarker marker =
                    new GMarkerGoogle(
                        new PointLatLng(Convert.ToDouble(pointDict["lat"].ElementAt(i)), Convert.ToDouble(pointDict["lon"].ElementAt(i))),
                       (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), unique_reports_dict[pointDict["report"].ElementAt(i)], true));
                markers.Markers.Add(marker);
                marker_list.Add(marker);

            }
            gmap.Overlays.Add(markers);
            gmap.ZoomAndCenterMarkers("markers");
        }

        private void listView_County_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCounty;
            try { selectedCounty = listView_County.SelectedItems[0].Text.ToString(); }
            catch (Exception ex)
            {
                listView_City.Items.Clear();
                listView_City.BeginUpdate();
                for (int i = 0; i < masterlist_city.Count; i++)
                {
                    listView_City.Items.Add(masterlist_city[i]);
                }
                listView_City.EndUpdate();
                return;
            }

            string state = comboBox_State.SelectedItem.ToString();
            List<string> filtered_cities = new List<string>();

            //get cities based on selected county
            con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT DISTINCT city FROM " + state.ToUpper() + " WHERE county='" + selectedCounty + "'", con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        filtered_cities.Add(Convert.ToString(rdr["city"]));
                    }
                }
            }
            filtered_cities.Sort();

            listView_City.Items.Clear();
            listView_City.BeginUpdate();
            for (int i = 0; i < filtered_cities.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(filtered_cities[i]);
                listView_City.Items.Add(lvi);
            }
            listView_City.EndUpdate();
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
            string selectedGrid;

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
            if (state == "Alaska")
            {
                try
                {
                    selectedGrid = comboBox_AncGrid.Text.ToString();
                    if (selectedGrid != "")
                    {
                        query_whereclause.Add("anchoragegrid='" + selectedGrid + "'");
                    }
                }
                catch (Exception) { }
            }

            string query_type = comboBox_QueryType.SelectedItem.ToString();
            string query_wherestring = string.Join(" " + query_type + " ", query_whereclause.ToArray());
            if (query_wherestring == "")
            {
                query_wherestring += "city='" + selectedCity + "'";
            }
            else
            {
                query_wherestring += query_type + " city='" + selectedCity + "'";
            }

            //reset marker dict
            pointDict.Clear();
            List<string> pointdictkeys = new List<string>() { "report", "projectnumber", "projectname", "client", "year", "lat", "lon", "type", "depth" };
            foreach (string k in pointdictkeys) { pointDict.Add(k, new List<string>()); }

            //setup database connection
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            string sql;

            //get all tables in database
            sql = "SELECT report,projectnumber,projectname,client,year,lat,lon,type,depth FROM " + state.ToUpper() + "KMZ WHERE " + query_wherestring;
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        foreach (KeyValuePair<string, List<string>> kvp in pointDict) { pointDict[kvp.Key].Add(Convert.ToString(rdr[kvp.Key])); }
                    }
                }
            }

            //check if any markers found
            if (pointDict["lat"].Count() == 0)
            {
                textBox_Results.Text = "No georeferencing exists for this selection.";
                textBox_Results.ForeColor = Color.Red;
                try
                {
                    gmap.Position = new PointLatLng(state_centerpoint_dict[state.ToLower()][0], state_centerpoint_dict[state.ToLower()][1]);
                    gmap.Zoom = state_centerpoint_dict[state.ToLower()][2];
                }
                catch (Exception ex) { }
                return;
            }
            textBox_Results.Text = "";

            //get unique list of reports, assign a marker type
            HashSet<string> unique_reports_hash = new HashSet<string>(pointDict["report"]);
            List<string> unique_reports_list = unique_reports_hash.ToList();
            IDictionary<string, string> unique_reports_dict = new Dictionary<string, string>();
            int counter = 1;
            foreach (string r in unique_reports_list)
            {
                unique_reports_dict.Add(r, counter.ToString());
                if (counter < 37) { counter++; }
                else { counter = 1; }

            }

            // add markers
            GMapOverlay markers = new GMapOverlay("markers");
            for (int i = 0; i < pointDict["lat"].Count(); i++)
            {
                GMapMarker marker =
                    new GMarkerGoogle(
                        new PointLatLng(Convert.ToDouble(pointDict["lat"].ElementAt(i)), Convert.ToDouble(pointDict["lon"].ElementAt(i))),
                       (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), unique_reports_dict[pointDict["report"].ElementAt(i)], true));
                markers.Markers.Add(marker);
                marker_list.Add(marker);

            }
            gmap.Overlays.Add(markers);
            gmap.ZoomAndCenterMarkers("markers");
        }

        private void comboBox_AncGrid_SelectedValueChanged(object sender, EventArgs e)
        {
            gmap.Overlays.Clear();
            marker_list.Clear();
            string state = comboBox_State.SelectedItem.ToString();

            //build the where clause based on all selections
            List<string> query_whereclause = new List<string>();
            string selectedPN;
            string selectedProjName;
            string selectedCity;
            string selectedGrid;

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

            try
            {
                selectedCity = listView_City.SelectedItems[0].Text.ToString();
                query_whereclause.Add("city='" + selectedCity + "'");
            }
            catch (Exception) { }

            if (state == "Alaska")
            {
                try
                {
                    selectedGrid = comboBox_AncGrid.Text.ToString();
                    if (selectedGrid != "") { query_whereclause.Add("anchoragegrid='" + selectedGrid + "'"); }
                }
                catch (Exception) { }
            }

            if (query_whereclause.Count() == 0)
            {
                try
                {
                    gmap.Position = new PointLatLng(state_centerpoint_dict[state.ToLower()][0], state_centerpoint_dict[state.ToLower()][1]);
                    gmap.Zoom = state_centerpoint_dict[state.ToLower()][2];
                }
                catch (Exception ex) { }
                return;
            }
            string query_type = comboBox_QueryType.SelectedItem.ToString();
            string query_wherestring = string.Join(" " + query_type + " ", query_whereclause.ToArray());

            //reset marker dict
            pointDict.Clear();
            List<string> pointdictkeys = new List<string>() { "report", "projectnumber", "projectname", "client", "year", "lat", "lon", "type", "depth" };
            foreach (string k in pointdictkeys) { pointDict.Add(k, new List<string>()); }

            //setup database connection
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            string sql;

            //get markers
            sql = "SELECT report,projectnumber,projectname,client,year, lat,lon,type,depth FROM " + state.ToUpper() + "KMZ WHERE " + query_wherestring;
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        foreach (KeyValuePair<string, List<string>> kvp in pointDict) { pointDict[kvp.Key].Add(Convert.ToString(rdr[kvp.Key])); }
                    }
                }
            }

            //check if any markers found
            if (pointDict["lat"].Count() == 0)
            {
                textBox_Results.Text = "No georeferencing exists for this selection.";
                textBox_Results.ForeColor = Color.Red;
                try
                {
                    gmap.Position = new PointLatLng(state_centerpoint_dict[state.ToLower()][0], state_centerpoint_dict[state.ToLower()][1]);
                    gmap.Zoom = state_centerpoint_dict[state.ToLower()][2];
                }
                catch (Exception ex) { }
                return;
            }
            textBox_Results.Text = "";

            //get unique list of reports, assign a marker type
            HashSet<string> unique_reports_hash = new HashSet<string>(pointDict["report"]);
            List<string> unique_reports_list = unique_reports_hash.ToList();
            IDictionary<string, string> unique_reports_dict = new Dictionary<string, string>();
            int counter = 1;
            foreach (string r in unique_reports_list)
            {
                unique_reports_dict.Add(r, counter.ToString());
                if (counter < 37) { counter++; }
                else { counter = 1; }

            }

            // add markers
            GMapOverlay markers = new GMapOverlay("markers");
            for (int i = 0; i < pointDict["lat"].Count(); i++)
            {
                GMapMarker marker =
                    new GMarkerGoogle(
                        new PointLatLng(Convert.ToDouble(pointDict["lat"].ElementAt(i)), Convert.ToDouble(pointDict["lon"].ElementAt(i))),
                       (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), unique_reports_dict[pointDict["report"].ElementAt(i)], true));
                markers.Markers.Add(marker);
                marker_list.Add(marker);

            }
            gmap.Overlays.Add(markers);
            gmap.ZoomAndCenterMarkers("markers");
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

        private void button_ClearMapList_Click(object sender, EventArgs e)
        {
            map_report_list.Clear();
            listView_MapReports.Items.Clear();
        }

        private void button_SearchMapPDFs_Click(object sender, EventArgs e)
        {
            textBox_Results.Text = "";
            textBox_Results.ForeColor = Color.Black;

            report_nums = map_report_list;

            //if popup form is open, close it
            if (Application.OpenForms.OfType<Form_MapPopup>().Any())
            {
                Application.OpenForms.OfType<Form_MapPopup>().First().Close();
            }

            //open the search results form
            this.Hide();
            Form2 s = new Form2();
            s.Show();
        }



        //ADMIN TAB METHODS.....................................................................

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
            //check the excel file is found
            if (!File.Exists(newpath))
            {
                label_ExcelPathMessage.Text = "The record excel file does not exist in the path entered. Please enter the correct path.";
                label_ExcelPathMessage.ForeColor = Color.Red;
                return;
            }

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

            richTextBox_CurrentExcelPath.Text = newpath;

            con.Close();
        }

        private void button_UpdateKMZPath_Click(object sender, EventArgs e)
        {
            SQLiteCommand cmd_sql;
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();

            string newpath = textBox_NewKMZPath.Text;
            List<string> ancfiles = new List<string>();

            //check if directory exists
            if (!Directory.Exists(newpath))
            {
                label_KMZPathMessage.Text = "The specifed folder does not exist. Please select the folder with state subdirectories and associated soils library KMZs.";
                label_KMZPathMessage.ForeColor = Color.Red;
                con.Close();
                return;
            }

            //check that Alaska>>Anchorage>>soilslibrary.kmz exists in specified folder
            try { ancfiles = Directory.GetFiles(newpath + @"\Alaska\Anchorage" + @"\", "*").ToList(); }
            catch (Exception ex)
            {
                label_KMZPathMessage.Text = "The specifed folder is not correct. Please select the folder with state subdirectories and associated soils library KMZs.";
                label_KMZPathMessage.ForeColor = Color.Red;
                con.Close();
                return;
            }
            bool filefound = false;

            foreach (string ancfile in ancfiles)
            {
                string filename = ancfile.Replace(newpath + @"\Alaska\Anchorage" + @"\", "").ToLower();
                if (filename.Contains("soilslibrary") && !filename.Contains("project"))
                {
                    filefound = true;
                }
            }
            if (!filefound)
            {
                label_KMZPathMessage.Text = "The specifed folder is not correct. Please select the folder with state subdirectories and associated soils library KMZs.";
                label_KMZPathMessage.ForeColor = Color.Red;
                con.Close();
                return;
            }
            string sql = string.Empty;
            sql = "DELETE FROM FOLDERPATHS WHERE type='kmzpath'";
            cmd_sql = new SQLiteCommand(sql, con);
            cmd_sql.ExecuteNonQuery();

            sql = string.Format("INSERT INTO FOLDERPATHS (type,value) VALUES ('kmzpath','{0}')", newpath);
            cmd_sql = new SQLiteCommand(sql, con);
            cmd_sql.ExecuteNonQuery();

            label_KMZPathMessage.Text = "KMZ folder path updated!";
            label_KMZPathMessage.ForeColor = Color.Green;

            richTextBox_CurrentKMZPath.Text = newpath;

            con.Close();
        }

        private void button_UpdatePDFPath_Click(object sender, EventArgs e)
        {
            SQLiteCommand cmd_sql;
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();

            string newpath = textBox_NewPDFPath.Text;

            string sql = string.Empty;
            sql = "DELETE FROM FOLDERPATHS WHERE type='pdfpath'";
            cmd_sql = new SQLiteCommand(sql, con);
            cmd_sql.ExecuteNonQuery();

            sql = string.Format("INSERT INTO FOLDERPATHS (type,value) VALUES ('pdfpath','{0}')", newpath);
            cmd_sql = new SQLiteCommand(sql, con);
            cmd_sql.ExecuteNonQuery();

            label_PDFPathMessage.Text = "PDF folder path updated!";
            label_PDFPathMessage.ForeColor = Color.Green;

            richTextBox_CurrentPDFPath.Text = newpath;

            con.Close();
        }

        private void button_UpdateLatLonPath_Click(object sender, EventArgs e)
        {
            string newpath = textBox_NewLatLonPath.Text;
            if (newpath.Length <= 5)
            {
                label_LatLonPathMessage.Text = "Add a folder and file name ending in '.xlsx'";
                label_LatLonPathMessage.ForeColor = Color.Red;
                return;
            }
            else if (newpath.Substring(newpath.Length - 5) != ".xlsx")
            {
                label_LatLonPathMessage.Text = "Add the file name ending in '.xlsx'";
                label_LatLonPathMessage.ForeColor = Color.Red;
                return;
            }

            //check the excel file is found
            if (!File.Exists(newpath))
            {
                label_LatLonPathMessage.Text = "The lat lon excel file does not exist in the path entered. Please enter the correct path.";
                label_LatLonPathMessage.ForeColor = Color.Red;
                return;
            }

            SQLiteCommand cmd_sql;
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();

            string sql = string.Empty;
            sql = "DELETE FROM FOLDERPATHS WHERE type='latlonexcelpath'";
            cmd_sql = new SQLiteCommand(sql, con);
            cmd_sql.ExecuteNonQuery();

            sql = "INSERT INTO FOLDERPATHS (type,value) VALUES ('latlonexcelpath','" + newpath + "')";
            cmd_sql = new SQLiteCommand(sql, con);
            cmd_sql.ExecuteNonQuery();

            label_LatLonPathMessage.Text = "Lat Lon Excel folder path and file name updated!";
            label_LatLonPathMessage.ForeColor = Color.Green;

            richTextBox_CurrentLatLonPath.Text = newpath;


            con.Close();
        }

        private void buttonUpdateRecordDB_Click(object sender, EventArgs e)
        {
            string labelmessageintro = "Uploading data. This operation may take up to 1 minute.";
            label_UpdateRecordDB.Text = labelmessageintro;
            label_UpdateRecordDB.ForeColor = Color.Blue;
            label_UpdateRecordDB.Invalidate();
            label_UpdateRecordDB.Update();

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

            //drop all soils report tables
            List<string> drop_tables = new List<string>();
            sql = "SELECT name FROM sqlite_schema WHERE type ='table' AND name NOT LIKE 'sqlite_%'";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        string table_name = Convert.ToString(rdr["name"]).ToLower();
                        if (!table_name.Contains("kmz") && table_name != "folderpaths")
                        {
                            drop_tables.Add(table_name);
                        }
                    }
                }
            }
            foreach (string drop_table in drop_tables)
            {
                sql = string.Format("DROP TABLE {0}", drop_table);
                cmd_sql = new SQLiteCommand(sql, con);
                cmd_sql.ExecuteNonQuery();
            }

            //send excel data to database
            DataTable dtResult = null;
            int totalSheet = 0;

            //check that excel file found
            if (!File.Exists(fname))
            {
                label_UpdateRecordDB.Text = "The record excel file does not exist in the path entered. Please enter the correct path at the bottom of the page (include the file name).";
                label_UpdateRecordDB.ForeColor = Color.Red;
                return;
            }
            try
            {

                OleDbConnection objConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fname + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
                objConn.Open();
                objConn.Close();
            }
            catch (Exception)
            {
                label_UpdateRecordDB.Text = "Please close the excel file when updating the database.";
                label_UpdateRecordDB.ForeColor = Color.Red;
                return;
            }

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
                    string state = string.Empty;

                    if (dt != null)
                    {
                        foreach (DataRow drs in dt.Rows)
                        {
                            //get data from spreadsheet
                            sheetName = drs["TABLE_NAME"].ToString();
                            if (!sheetName.Contains("FilterDatabase"))
                            {
                                state = sheetName.Substring(0, sheetName.Length - 1).ToUpper();

                                label_UpdateRecordDB.Text = labelmessageintro + "\n" + string.Format("Parsing {0}...", state);
                                label_UpdateRecordDB.ForeColor = Color.Blue;
                                label_UpdateRecordDB.Invalidate();
                                label_UpdateRecordDB.Update();

                                var tempDataTable = (from dataRow in dt.AsEnumerable()
                                                     where !dataRow["TABLE_NAME"].ToString().Contains("FilterDatabase")
                                                     select dataRow).CopyToDataTable();
                                dt = tempDataTable;
                                totalSheet = dt.Rows.Count;

                                //get all data from sheet
                                cmd.Connection = objConn;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                                oleda = new OleDbDataAdapter(cmd);

                                //send data to a datatable
                                ds = new DataSet();
                                oleda.Fill(ds, "excelData");
                                dtResult = ds.Tables["excelData"];
                                objConn.Close();

                                //create database table, diff columns for alaska
                                if (state == "ALASKA")
                                {
                                    sql = "CREATE TABLE IF NOT EXISTS ALASKA(" +
                                        "report VARCHAR(255), projectnumber VARCHAR(255), client VARCHAR(255), projectname VARCHAR(255), area VARCHAR(255), city VARCHAR(255), anchoragegrid VARCHAR(255), year INT" +
                                        ")";
                                }
                                else
                                {
                                    sql = string.Format("CREATE TABLE IF NOT EXISTS {0}(" +
                                        "report VARCHAR(255), projectnumber VARCHAR(255), client VARCHAR(255), projectname VARCHAR(255), city VARCHAR(255), year INT" +
                                        ")", state);
                                }
                                cmd_sql = new SQLiteCommand(sql, con);
                                cmd_sql.ExecuteNonQuery();


                                //send datatable to database, Alaska columns difference
                                if (state == "ALASKA")
                                {
                                    using (cmd_sql = new SQLiteCommand(con))
                                    {
                                        using (var transaction = con.BeginTransaction())
                                        {
                                            foreach (DataRow dataRow in dtResult.Rows)
                                            {
                                                cmd_sql.CommandText = "INSERT INTO ALASKA(report,projectnumber,client,projectname,area,city,anchoragegrid,year) VALUES (";
                                                for (int i = 0; i < 8; i++)
                                                {
                                                    if (i == 7)
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
                                //other states
                                else
                                {
                                    using (cmd_sql = new SQLiteCommand(con))
                                    {
                                        using (var transaction = con.BeginTransaction())
                                        {
                                            foreach (DataRow dataRow in dtResult.Rows)
                                            {
                                                cmd_sql.CommandText = string.Format("INSERT INTO {0}(report,projectnumber,client,projectname,city,year) VALUES (", state);
                                                for (int i = 0; i < 6; i++)
                                                {
                                                    if (i == 5)
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

                                //get counties
                                //create sql table from dictionary for county lookup
                                sql = "CREATE TABLE COUNTYLOOKUP(city VARCHAR(255), county VARCHAR(255))";
                                cmd_sql = new SQLiteCommand(sql, con);
                                cmd_sql.ExecuteNonQuery();

                                //create dictionary for unique city and county
                                List<string> cities_unique = new List<string>();
                                using (SQLiteCommand cmd_ = new SQLiteCommand("SELECT DISTINCT city FROM " + state, con))
                                {
                                    using (SQLiteDataReader rdr = cmd_.ExecuteReader())
                                    {
                                        while (rdr.Read())
                                        {
                                            cities_unique.Add(Convert.ToString(rdr["city"]));
                                        }
                                    }
                                }

                                label_UpdateRecordDB.Text = labelmessageintro + "\n" + string.Format("Parsing {0}...", state);
                                label_UpdateRecordDB.Text += "\nGetting counties from Google Maps API...";
                                label_UpdateRecordDB.ForeColor = Color.Blue;
                                label_UpdateRecordDB.Invalidate();
                                label_UpdateRecordDB.Update();
                                //do api calls to google to get county from city, state. insert into countylookuptable
                                using (cmd_sql = new SQLiteCommand(con))
                                {
                                    using (var transaction = con.BeginTransaction())
                                    {
                                        foreach (string city in cities_unique)
                                        {
                                            string county = String.Empty;
                                            string address = city + ", " + sheetName.Substring(0, sheetName.Length - 1);
                                            string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={1}&address={0}&sensor=false", Uri.EscapeDataString(address), "AIzaSyAwpzN_I-e7VkE2G1uPy5_Ydk3C3xiH_xg");

                                            try
                                            {
                                                WebRequest request = WebRequest.Create(requestUri);
                                                WebResponse response = request.GetResponse();
                                                XDocument xdoc = XDocument.Load(response.GetResponseStream());

                                                XElement result = xdoc.Element("GeocodeResponse").Element("result");
                                                foreach (var el in result.Elements())
                                                {
                                                    if (el.Name == "address_component")
                                                    {
                                                        if (el.Element("type").Value == "administrative_area_level_2")
                                                        {
                                                            county = el.Element("long_name").Value;
                                                        }
                                                    }
                                                }
                                            }
                                            catch (Exception ex) { }

                                            cmd_sql.CommandText = string.Format("INSERT INTO COUNTYLOOKUP(city,county) VALUES('{0}','{1}')", city.Replace("'", "''"), county.Replace("'", "''"));
                                            cmd_sql.ExecuteNonQuery();
                                        }
                                        transaction.Commit();
                                    }
                                }

                                //join counties to the alaska table
                                sql = string.Format("ALTER TABLE {0} ADD COLUMN county VARCHAR(255)", state);
                                cmd_sql = new SQLiteCommand(sql, con);
                                cmd_sql.ExecuteNonQuery();
                                sql = string.Format("UPDATE {0} SET county = (SELECT county FROM COUNTYLOOKUP WHERE city = {0}.city)", state);
                                cmd_sql = new SQLiteCommand(sql, con);
                                cmd_sql.ExecuteNonQuery();

                                //delete lookup table
                                sql = "DROP TABLE COUNTYLOOKUP";
                                cmd_sql = new SQLiteCommand(sql, con);
                                cmd_sql.ExecuteNonQuery();
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

                    label_UpdateRecordDB.Text = "The database has been successfully updated!";
                    label_UpdateRecordDB.ForeColor = Color.Green;
                    label_UpdateRecordDB.Invalidate();
                    label_UpdateRecordDB.Update();
                }

            }

            catch (Exception)
            {
                label_UpdateRecordDB.Text = "There was an error updating the database. Please verify the soils report record excel file exists in the folder entered in the Folder Paths tab. Make sure no columns have moved in the Excel file and that all tabs have state names spelled out.";
                label_UpdateRecordDB.ForeColor = Color.Red;
                return;
            }

            //load options for states from database
            List<string> state_tables = new List<string>();
            comboBox_State.Items.Clear();
            sql = "SELECT name FROM sqlite_schema WHERE type ='table' AND name NOT LIKE 'sqlite_%'";
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
            foreach (string tab in state_tables) { comboBox_State.Items.Add(tab); comboBox_StateAdmin.Items.Add(tab); }
            comboBox_State.SelectedItem = "Alaska";
            comboBox_StateAdmin.SelectedItem = "Alaska";
            comboBoxState_SelectedValueChanged(sender, e);
            con.Close();
        }

        private void button_UpdateKMZDB_Click(object sender, EventArgs e)
        {
            string labelmessageintro = "Uploading data. This operation may take up to 1 minute.";
            label_UpdateKMZDB.Text = labelmessageintro;
            label_UpdateKMZDB.ForeColor = Color.Blue;
            label_UpdateKMZDB.Invalidate();
            label_UpdateKMZDB.Update();

            //setup database connection
            SQLiteCommand cmd_sql;
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            string sql = string.Empty;
            string fname = string.Empty;
            string fname_latlon = string.Empty;

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

            //check that Alaska>>Anchorage>>soilslibrary.kmz exists in specified folder
            try { List<string> ancfiles = Directory.GetFiles(fname + @"\Alaska\Anchorage" + @"\", "*").ToList(); }
            catch (Exception ex)
            {
                label_UpdateKMZDB.Text = "The KMZ folder is not correct. Please select the folder with state subdirectories and associated soils library KMZs.";
                label_UpdateKMZDB.ForeColor = Color.Red;
                con.Close();
                return;
            }

            //drop all kmz tables
            List<string> drop_tables = new List<string>();
            sql = "SELECT name FROM sqlite_schema WHERE type ='table' AND name NOT LIKE 'sqlite_%'";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        string table_name = Convert.ToString(rdr["name"]).ToLower();
                        if (table_name.Contains("kmz")) { drop_tables.Add(table_name); }
                    }
                }
            }
            foreach (string drop_table in drop_tables)
            {
                sql = string.Format("DROP TABLE {0}", drop_table);
                cmd_sql = new SQLiteCommand(sql, con);
                cmd_sql.ExecuteNonQuery();
            }

            string searchstring;
            int startindex;
            int endindex;
            string state_name;
            XNamespace ns = "http://www.opengis.net/kml/2.2";

            try
            {
                //first get kmz data for alaska
                List<string> ak_final_files = new List<string>();

                //create database table
                sql = "CREATE TABLE IF NOT EXISTS KMZ(report VARCHAR(255), lat FLOAT, lon FLOAT, type VARCHAR(255), depth FLOAT)";
                cmd_sql = new SQLiteCommand(sql, con);
                cmd_sql.ExecuteNonQuery();

                //loop through each city folder in the state folder
                List<string> directories_cities = Directory.GetDirectories(fname + @"\Alaska\").ToList();
                foreach (string dir_city in directories_cities)
                {
                    //loop through each kmz file in the city folder
                    List<string> kmz_files = Directory.GetFiles(dir_city, "*.kmz").ToList();
                    foreach (string kmz_file in kmz_files)
                    {
                        string filename = kmz_file.Replace(dir_city + @"\", "").ToLower();
                        if (filename.Contains("soilslibrary") && !filename.Contains("project"))
                        {
                            ak_final_files.Add(kmz_file);
                        }
                    }
                }

                //loop through each file and parse kmz
                foreach (string file in ak_final_files)
                {
                    using (var cmd = new SQLiteCommand(con))
                    {
                        try
                        {
                            using (var transaction = con.BeginTransaction())
                            {
                                label_UpdateKMZDB.Text = labelmessageintro + "\n" + string.Format("Parsing '{0}'....", file);
                                label_UpdateKMZDB.ForeColor = Color.Blue;
                                label_UpdateKMZDB.Invalidate();
                                label_UpdateKMZDB.Update();

                                var file_open = File.OpenRead(file);
                                var zip = new ZipArchive(file_open, ZipArchiveMode.Read);
                                var stream = zip.GetEntry("doc.kml").Open();
                                XDocument xDoc = XDocument.Load(stream);

                                if (xDoc != null)
                                {
                                    var placemarks = xDoc.Root.Element(ns + "Document").Element(ns + "Folder").Elements(ns + "Placemark");

                                    foreach (var place in placemarks)
                                    {
                                        IDictionary<string, string> pointDict = new Dictionary<string, string>();
                                        List<string> dictkeys = new List<string>() { "report", "lat", "lon", "type", "depth" };
                                        foreach (string key in dictkeys) { pointDict.Add(key, ""); }

                                        //get lat lons
                                        var coords = place.Element(ns + "Point").Element(ns + "coordinates").Value;
                                        coords = coords.Substring(0, coords.LastIndexOf(','));
                                        pointDict["lon"] = coords.Substring(0, coords.IndexOf(','));
                                        pointDict["lat"] = coords.Substring(coords.IndexOf(',') + 1);

                                        var desc = place.Element(ns + "description").Value.ToLower();

                                        //get file(report), type, depth, year
                                        string dummyvar;
                                        bool cont = true;
                                        List<string> searchstrings = new List<string>() { "file", "type", "depth" };
                                        foreach (string s in searchstrings)
                                        {
                                            if (cont)
                                            {
                                                searchstring = string.Format("<td>{0}</td>", s);
                                                if (s == "file" && desc.IndexOf(searchstring) == -1)
                                                {
                                                    searchstring = "<td>redfile</td>";
                                                    if (desc.IndexOf(searchstring) == -1)
                                                    {
                                                        searchstring = "<td>soilslibrary</td>";
                                                        if (desc.IndexOf(searchstring) == -1)
                                                        {
                                                            searchstring = "<td>soils library</td>";
                                                        }
                                                    }
                                                }

                                                startindex = desc.IndexOf(searchstring) + searchstring.Length;
                                                endindex = desc.IndexOf("</tr>", desc.IndexOf(searchstring) + 1);
                                                dummyvar = desc.Substring(startindex, endindex - startindex);

                                                if (s == "file")
                                                {
                                                    if (dummyvar.Substring(6, dummyvar.Length - 13).ToString().Replace("'", "''") == "")
                                                    {
                                                        cont = false; continue;
                                                    }
                                                    else { pointDict["report"] = dummyvar.Substring(6, dummyvar.Length - 13).ToString().Replace("'", "''"); }
                                                }
                                                else { pointDict[s.ToLower()] = dummyvar.Substring(6, dummyvar.Length - 13).ToString().Replace("'", "''"); }

                                            }
                                        }

                                        cmd.CommandText = string.Format("INSERT INTO KMZ (report,lat,lon,type,depth) VALUES ('{0}','{1}','{2}','{3}','{4}')", pointDict["report"], pointDict["lat"], pointDict["lon"], pointDict["type"], pointDict["depth"]);
                                        cmd.ExecuteNonQuery();
                                    }
                                    transaction.Commit();
                                }
                            }
                        }
                        catch (Exception)
                        {
                            label_UpdateKMZDB.Text = "Error parsing data from " + file + ". Please verify the attribute names in this file match those of the other KMZs.";
                            label_UpdateKMZDB.ForeColor = Color.Red;
                            label_UpdateRecordDB.Invalidate();
                            label_UpdateRecordDB.Update();
                            return;
                        }
                    }
                }


                //create the join table
                sql = "CREATE TABLE IF NOT EXISTS ALASKAKMZ(report VARCHAR(255), lat FLOAT, lon FLOAT, type VARCHAR(255), depth FLOAT, projectnumber VARCHAR(255), client VARCHAR(255), projectname VARCHAR(255), area VARCHAR(255), city VARCHAR(255), anchoragegrid VARCHAR(255), year INT)";
                cmd_sql = new SQLiteCommand(sql, con);
                cmd_sql.ExecuteNonQuery();

                sql = "INSERT INTO ALASKAKMZ SELECT KMZ.report, lat, lon, type, depth, projectnumber, client, projectname, area, city, anchoragegrid, year FROM KMZ " +
                    "LEFT JOIN ALASKA " +
                    "ON (KMZ.report=ALASKA.report)";

                cmd_sql = new SQLiteCommand(sql, con);
                cmd_sql.ExecuteNonQuery();

                sql = "DELETE FROM ALASKAKMZ WHERE report=''";
                cmd_sql = new SQLiteCommand(sql, con);
                cmd_sql.ExecuteNonQuery();

                //drop kmz table
                sql = "DROP TABLE KMZ";
                cmd_sql = new SQLiteCommand(sql, con);
                cmd_sql.ExecuteNonQuery();



                //now parse the Excel for the other states
                //get excel latlon path
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT value FROM FOLDERPATHS WHERE type='latlonexcelpath'", con))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            fname_latlon = Convert.ToString(rdr["value"]);
                        }
                    }
                }
                //check that excel file found
                if (!File.Exists(fname_latlon))
                {
                    label_UpdateKMZDB.Text = "The lat lon excel file does not exist in the path entered. Please enter the correct path at the bottom of the page (include the file name).";
                    label_UpdateKMZDB.ForeColor = Color.Red;
                    return;
                }
                try
                {

                    OleDbConnection objConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fname_latlon + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
                    objConn.Open();
                    objConn.Close();
                }
                catch (Exception)
                {
                    label_UpdateKMZDB.Text = "Please close the lat lon excel file when updating the database.";
                    label_UpdateKMZDB.ForeColor = Color.Red;
                    return;
                }

                using (OleDbConnection objConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fname_latlon + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';"))
                {
                    DataTable dtResult = null;
                    int totalSheet = 0;
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    OleDbDataAdapter oleda = new OleDbDataAdapter();
                    DataSet ds;
                    DataTable dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    string sheetName = string.Empty;
                    string state = string.Empty;

                    if (dt != null)
                    {
                        foreach (DataRow drs in dt.Rows)
                        {
                            //create database table
                            sql = "CREATE TABLE IF NOT EXISTS KMZ(report VARCHAR(255), lat FLOAT, lon FLOAT, type VARCHAR(255), depth FLOAT)";
                            cmd_sql = new SQLiteCommand(sql, con);
                            cmd_sql.ExecuteNonQuery();

                            //get data from spreadsheet
                            sheetName = drs["TABLE_NAME"].ToString();
                            if (!sheetName.Contains("FilterDatabase"))
                            {
                                state = sheetName.Substring(0, sheetName.Length - 1).ToUpper();

                                label_UpdateKMZDB.Text = labelmessageintro + "\n" + string.Format("Parsing {0}...", state);
                                label_UpdateKMZDB.ForeColor = Color.Blue;
                                label_UpdateKMZDB.Invalidate();
                                label_UpdateKMZDB.Update();

                                var tempDataTable = (from dataRow in dt.AsEnumerable()
                                                     where !dataRow["TABLE_NAME"].ToString().Contains("FilterDatabase")
                                                     select dataRow).CopyToDataTable();
                                dt = tempDataTable;
                                totalSheet = dt.Rows.Count;

                                //get all data from sheet
                                cmd.Connection = objConn;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                                oleda = new OleDbDataAdapter(cmd);

                                //send data to a datatable
                                ds = new DataSet();
                                oleda.Fill(ds, "excelData");
                                dtResult = ds.Tables["excelData"];
                                objConn.Close();

                                //other states
                                using (cmd_sql = new SQLiteCommand(con))
                                {
                                    using (var transaction = con.BeginTransaction())
                                    {
                                        foreach (DataRow dataRow in dtResult.Rows)
                                        {
                                            cmd_sql.CommandText = "INSERT INTO KMZ(report,lat,lon,type,depth) VALUES (";
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
                                //create the join table
                                sql = String.Format("CREATE TABLE IF NOT EXISTS {0}KMZ(report VARCHAR(255), lat FLOAT, lon FLOAT, type VARCHAR(255), depth FLOAT, projectnumber VARCHAR(255), client VARCHAR(255), projectname VARCHAR(255), city VARCHAR(255), year INT)", state);
                                cmd_sql = new SQLiteCommand(sql, con);
                                cmd_sql.ExecuteNonQuery();

                                try
                                {
                                    sql = String.Format("INSERT INTO {0}KMZ SELECT KMZ.report, lat, lon, type, depth, projectnumber, client, projectname, city, year FROM KMZ " +
                                        "LEFT JOIN {0} " +
                                        "ON (KMZ.report={0}.report)", state);

                                    cmd_sql = new SQLiteCommand(sql, con);
                                    cmd_sql.ExecuteNonQuery();
                                }
                                catch (Exception)
                                {
                                    label_UpdateKMZDB.Text = String.Format("A table for {0} cannot be found. Add a tab for {0} and fill in data for it in the Soils Report Record spreadsheet, update the Record database (button above on this page), then try again.", state);
                                    label_UpdateKMZDB.ForeColor = Color.Red;
                                    return;
                                }

                                sql = string.Format("DELETE FROM {0}KMZ WHERE report=''", state);
                                cmd_sql = new SQLiteCommand(sql, con);
                                cmd_sql.ExecuteNonQuery();

                                //drop kmz table
                                sql = "DROP TABLE KMZ";
                                cmd_sql = new SQLiteCommand(sql, con);
                                cmd_sql.ExecuteNonQuery();

                            }
                        }
                    }
                }
                //reset datetime of update
                DateTime now = DateTime.Now;
                sql = "DELETE FROM FOLDERPATHS WHERE type='kmz_update_datetime'";
                cmd_sql = new SQLiteCommand(sql, con);
                cmd_sql.ExecuteNonQuery();
                sql = "INSERT INTO FOLDERPATHS (type,value) VALUES ('kmz_update_datetime','" + now + "')";
                cmd_sql = new SQLiteCommand(sql, con);
                cmd_sql.ExecuteNonQuery();
                label_KMZDBUpdateTime.Text = "Database last updated on: " + now;

                label_UpdateKMZDB.Text = "Upload complete!";
                label_UpdateKMZDB.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                label_UpdateKMZDB.Text = "There was an error updating the kmz database. Please verify the kmz files exist in the folder entered in the Folder Paths tab.";
                label_UpdateKMZDB.ForeColor = Color.Red;
                return;
            }
        }

        private void button_ShowReportsNotFound_Click(object sender, EventArgs e)
        {
            richTextBox_PDFsNotInFolder.Text = "";

            //add pdfs not found in folder but in record excel file
            con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();

            //get distinct unique numbers in database
            List<string> unique_reports = new List<string>();
            string sql = String.Format("SELECT DISTINCT(report) FROM {0}", comboBox_StateAdmin.SelectedItem.ToString().ToUpper());
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        unique_reports.Add(Convert.ToString(rdr["report"]));
                    }
                }
            }

            //get pdffolder and files
            sql = string.Empty;
            using (SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;"))
            {
                con.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT value FROM FOLDERPATHS WHERE type='pdfpath'", con))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            pdffolder = Convert.ToString(rdr["value"]) + @"\" + comboBox_StateAdmin.SelectedItem.ToString() + @"\";
                        }
                    }
                }
                con.Close();
            }
            if (!Directory.Exists(pdffolder))
            {
                label_PDFNotFound.Text = "The PDF folder does not exist. Enter the correct PDF folder at the bottom of this tab.";
                label_PDFNotFound.ForeColor = Color.Red;
                return;
            }
            List<string> pdffiles = Directory.GetFiles(pdffolder, "*.pdf").ToList();

            //get edited pdf file names
            List<string> pdffiles_edited = new List<string>();
            string fname_edited = string.Empty;
            foreach (string f in pdffiles)
            {
                string filename = f.Replace(pdffolder, "");
                int index_space = filename.IndexOf(" ");
                if (index_space == -1) { fname_edited = filename.Replace(".pdf", ""); }
                else { fname_edited = filename.Substring(0, index_space); }
                pdffiles_edited.Add(fname_edited);
            }
            StringBuilder boxtext = new StringBuilder(richTextBox_PDFsNotInFolder.Text);
            //check if unique report in pdffiles, add to textbox if not
            foreach (string r in unique_reports)
            {
                if (!pdffiles_edited.Contains(r))
                {
                    boxtext.AppendFormat(r + "\n");
                }
            }
            richTextBox_PDFsNotInFolder.Text = boxtext.ToString();
            label_PDFNotFound.Text = "";
            label_PDFNotFound.ForeColor = Color.Black;

        }



        ////MAIN SEARCH METHOD.....................................................................
        private void button_SearchPDFs_Click(object sender, EventArgs e)
        {

            //check that pdffolder exists
            SQLiteCommand cmd_sql;
            string sql = string.Empty;
            using (SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;"))
            {
                con.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT value FROM FOLDERPATHS WHERE type='pdfpath'", con))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            pdffolder = Convert.ToString(rdr["value"]) + @"\" + selectedState + @"\";
                        }
                    }
                }
                con.Close();
            }
            if (!Directory.Exists(pdffolder))
            {
                textBox_Results.Text = "The PDF folder does not exist. Enter the correct PDF folder in the Admin tab.";
                textBox_Results.ForeColor = Color.Red;
                return;
            }

            //build query based on selections
            report_nums.Clear();
            List<string> cols = new List<string>();
            List<string> selectedvals = new List<string>();
            List<string> query_whereclause = new List<string>();
            cols.Add("report");
            string selectedPN = String.Empty;
            string selectedProjName = String.Empty;
            string selectedCounty = String.Empty;
            string selectedCity = String.Empty;
            string selectedGrid = String.Empty;
            string state = comboBox_State.SelectedItem.ToString();
            selectedState = state;

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
                selectedCounty = listView_County.SelectedItems[0].Text.ToString();
                cols.Add("county");
                query_whereclause.Add("county='" + selectedCounty + "'");

            }
            catch (Exception) { }

            try
            {
                selectedCity = listView_City.SelectedItems[0].Text.ToString();
                cols.Add("city");
                query_whereclause.Add("city='" + selectedCity + "'");

            }
            catch (Exception) { }
            if (state == "Alaska")
            {
                try
                {
                    selectedGrid = comboBox_AncGrid.Text.ToString();
                    if (selectedGrid != "")
                    {
                        cols.Add("anchoragegrid");
                        query_whereclause.Add("anchoragegrid='" + selectedGrid + "'");
                    }


                }
                catch (Exception) { }
            }

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
            string query_type = comboBox_QueryType.SelectedItem.ToString();
            string query_wherestring = string.Join(" " + query_type + " ", query_whereclause.ToArray());

            //query database for selections

            using (SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;"))
            {
                con.Open();
                sql = "SELECT " + colnames + " FROM " + state.ToUpper() + " WHERE " + query_wherestring;
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

            //if popup form is open, close it
            if (Application.OpenForms.OfType<Form_MapPopup>().Any())
            {
                Application.OpenForms.OfType<Form_MapPopup>().First().Close();
            }

            //open the search results form
            this.Hide();
            Form2 s = new Form2();
            s.Show();
        }



    }
}