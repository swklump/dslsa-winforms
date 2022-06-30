using System.Data.SQLite;
using System.Diagnostics;

namespace dslsa
{
    public partial class Form_MapPopup : Form
    {
        public Form_MapPopup()
        {
            InitializeComponent();


        }
        private Form f = Application.OpenForms["Form1"];
        private int mouse_x;
        private int mouse_y;
        private string report;
        private string projnum;
        private string projname;
        private string client;
        private string pdffolder;
        private string dbpath = @"dslsa_database.db";

        private void Form_MapPopup_Load(object sender, EventArgs e)
        {
            mouse_x = ((Form1)f).mouse_x;
            mouse_y = ((Form1)f).mouse_y;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(mouse_x, mouse_y);

            report = ((Form1)f).map_report;
            projnum = ((Form1)f).map_projnum;
            projname = ((Form1)f).map_projname;
            client = ((Form1)f).map_client;

            label_Report.Text = "Report: " + report;
            label_ProjNum.Text = "Project Number: " + projnum;
            label_ProjName.Text = "Project Name: " + projname;
            label_Client.Text = "Client: " + client;

            // get pdf folder
            //setup database connection
            SQLiteCommand cmd_sql;
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            string sql = string.Empty;

            //get excel report path
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT value FROM FOLDERPATHS WHERE type='pdfpath'", con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        pdffolder = Convert.ToString(rdr["value"]) + @"\";
                    }
                }
            }
        }

        private void button_OpenPDF_Click(object sender, EventArgs e)
        {
            using (Process p = new Process())
            {
                try
                {
                    p.StartInfo = new ProcessStartInfo()
                    {
                        CreateNoWindow = true,
                        UseShellExecute = true,
                        FileName = pdffolder + report + ".pdf"
                    };
                    p.Start();
                    label_Message.Text = "The report was opened!";
                    label_Message.ForeColor = Color.Green;
                }
                catch (Exception ex)
                {
                    label_Message.Text = "Report " + report + " does not exist in the PDF folder.";
                    label_Message.ForeColor = Color.Red;
                }

            }

        }

        private void button_AddToList_Click(object sender, EventArgs e)
        {
            if (!((Form1)f).map_report_list.Contains(report))
            {
                ((Form1)f).map_report_list.Add(report);
                label_Message.Text = "Report " + report + " added to the list.";
                label_Message.ForeColor = Color.Green;
            }
            else
            {
                label_Message.Text = "Report " + report + " is already in the list.";
                label_Message.ForeColor = Color.Red;
            }
            ((Form1)f).listView_MapReports.Items.Clear();
            ((Form1)f).map_report_list.Sort();
            foreach (string r in ((Form1)f).map_report_list)
            {
                ListViewItem lvi = new ListViewItem(r);
                ((Form1)f).listView_MapReports.Items.Add(lvi);
            }

        }
    }
}
