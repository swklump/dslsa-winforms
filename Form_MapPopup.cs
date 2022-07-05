using System.Data.SQLite;
using System.Diagnostics;
using Outlook = Microsoft.Office.Interop.Outlook;

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
        private string type;
        private string depth;
        private string year;
        private string selectedState;
        private string pdffolder;
        private string dbpath = @"dslsa_database.db";

        private void Form_MapPopup_Load(object sender, EventArgs e)
        {
            mouse_x = ((Form1)f).mouse_x;
            mouse_y = ((Form1)f).mouse_y;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(mouse_x, mouse_y);

            selectedState = ((Form1)f).selectedState + @"\";

            report = ((Form1)f).map_report;
            projnum = ((Form1)f).map_projnum;
            projname = ((Form1)f).map_projname;
            client = ((Form1)f).map_client;
            type = ((Form1)f).map_type;
            depth = ((Form1)f).map_depth;
            year = ((Form1)f).map_year;

            richTextBox_Report.Text = "Report: " + report;
            richTextBox_PN.Text = "Project Number: " + projnum;
            richTextBox_ProjName.Text = "Project Name: " + projname;
            richTextBox_Client.Text = "Client: " + client;
            richTextBox_Type.Text = "Type: " + type;
            richTextBox_Depth.Text = "Depth: " + depth;
            richTextBox_Year.Text = "Year: " + year;

            // get pdf folder
            SQLiteCommand cmd_sql;
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbpath + "; Version=3;");
            con.Open();
            string sql = string.Empty;
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT value FROM FOLDERPATHS WHERE type='pdfpath'", con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        pdffolder = Convert.ToString(rdr["value"]) + @"\" + selectedState;
                    }
                }
            }
        }

        private void button_OpenPDF_Click(object sender, EventArgs e)
        {
            label_Message.Text = "Processing...";
            label_Message.ForeColor = Color.Blue;
            label_Message.Invalidate();
            label_Message.Update();

            //open the pdf
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

        private void button_EmailPDF_Click(object sender, EventArgs e)
        {
            label_Message.Text = "Processing...";
            label_Message.ForeColor = Color.Blue;
            label_Message.Invalidate();
            label_Message.Update();

            if (!File.Exists(pdffolder + report + ".pdf"))
            {
                label_Message.Text = "Report " + report + " does not exist in the PDF folder.";
                label_Message.ForeColor = Color.Red;
                return;
            }

            if (Process.GetProcessesByName("outlook").Length == 0)
            {
                label_Message.Text = "Please open the Outlook application, then try again.";
                label_Message.ForeColor = Color.Red;
                return;
            }

            //create outlook message
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

                oMsg.Subject = "Soils Report PDF Attached";
                oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
                oMsg.HTMLBody = "Hello,<br/>";
                oMsg.HTMLBody += "<br/>";
                oMsg.HTMLBody += "See attached for requested soils report.<br/>";
                oMsg.HTMLBody += "<br/>";
                oMsg.HTMLBody += "Thanks,";
                int pos = (int)oMsg.Body.Length + 1;
                int attachType = (int)Outlook.OlAttachmentType.olByValue;
                Outlook.Attachment oAttach = oMsg.Attachments.Add(pdffolder + report + ".pdf", attachType, pos, report + ".pdf");
                oMsg.Display(false);

                label_Message.Text = "Email draft created!";
                label_Message.ForeColor = Color.Green;

            }
            catch (Exception ex)
            {
                label_Message.Text = "Email draft could not be created. Restart Outlook and try again.";
                label_Message.ForeColor = Color.Red;
            }
        }

    }
}

