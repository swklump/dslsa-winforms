using System.Data.SQLite;
using System.Diagnostics;
using System.IO.Compression;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace dslsa
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form f = Application.OpenForms["Form1"];
        public List<string> report_nums = new List<string>();
        private FolderBrowserDialog folderBrowserDialog1;
        private String pdffolder;
        private String dbpath = @"dslsa_database.db";

        //NAVIGATION METHODS............................................................
        private void button_MainMenu_Click(object sender, EventArgs e)
        {
            Close();
            ((Form1)f).Show();
        }

        private void Form_SearchResults_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)f).Show();
        }


        //PROCESSING METHODS..................................................................................................
        private void Form_SearchResults_Load(object sender, EventArgs e)
        {
            report_nums = ((Form1)f).report_nums;
            textBox_SearchResults.BackColor = Color.White;

            //display number of results to label
            if (report_nums.Count == 0)
            {
                textBox_SearchResults.Text = "There were no reports found! Please return to the main menu and try another selection.";
                textBox_SearchResults.ForeColor = Color.Red;

                button_OpenPDFs.Visible = false;
                button_SavePDFs.Visible = false;
                button_EmailPDFs.Visible = false;
                label_WhatToDo.Visible = false;
            }
            else if (report_nums.Count == 1)
            {
                textBox_SearchResults.Text = "There was 1 report found!";
                textBox_SearchResults.ForeColor = Color.Green;
            }
            else
            {
                textBox_SearchResults.Text = string.Format("There were {0} reports found!", report_nums.Count.ToString());
                textBox_SearchResults.ForeColor = Color.Green;
            }

            //get pdf folder
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

        private void button_OpenPDFs_Click(object sender, EventArgs e)
        {
            List<string> pdfsnotfound = new List<string>();
            string message = string.Empty;
            string reportstring = string.Empty;
            using (Process p = new Process())
            {
                foreach (var report in report_nums)
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
                    }
                    catch (Exception ex)
                    {
                        pdfsnotfound.Add(report);
                    }
                }
            }

            if (pdfsnotfound.Count == report_nums.Count)
            {
                message = "No PDFs have been opened! The following PDFs are shown in the Excel file but do not exist in the PDF folder: ";
                reportstring = string.Join(",", pdfsnotfound.ToArray());
                textBox_SearchResults.Text = message + reportstring;
                textBox_SearchResults.ForeColor = Color.Red;
            }
            else if (pdfsnotfound.Count == 0)
            {
                textBox_SearchResults.Text = "All PDFs have been successfully opened!";
                textBox_SearchResults.ForeColor = Color.Green;
            }
            else
            {
                message = "PDFs have been opened! The following PDFs are shown in the Excel file but do not exist in the PDF folder: ";
                reportstring = string.Join(",", pdfsnotfound.ToArray());
                textBox_SearchResults.Text = message + reportstring;
                textBox_SearchResults.ForeColor = Color.Green;
            }

        }

        private void button_SavePDFs_Click(object sender, EventArgs e)
        {
            //folder select dialog
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.ShowDialog();
            string folderName = String.Empty;
            folderName = folderBrowserDialog1.SelectedPath;
            Directory.CreateDirectory(folderName + @"\SoilReportPDFs");


            //copy files to selected folder
            List<string> pdfsnotfound = new List<string>();
            foreach (var report in report_nums)
            {
                string sourceFile = pdffolder + report + ".pdf";
                string destFile = folderName + @"\SoilReportPDFs\" + report + ".pdf";
                try
                {
                    File.Copy(sourceFile, destFile, true);
                }
                catch (Exception ex)
                {
                    pdfsnotfound.Add(report);
                }
            }


            //zip files
            try { ZipFile.CreateFromDirectory(folderName + @"\SoilReportPDFs", folderName + @"\SoilReportPDFs.zip"); }
            catch (IOException)
            {
                textBox_SearchResults.Text = "A folder called 'SoilsReportPDFs' already exists in the directory specified. Please delete the existing folder or select a different directory.";
                textBox_SearchResults.ForeColor = Color.Red;
                return;
            }

            textBox_SearchResults.Text = "PDF saved in specified folder!";
            textBox_SearchResults.ForeColor = Color.Green;
        }

        private void button_EmailPDFs_Click(object sender, EventArgs e)
        {
            //start outlook message
            Outlook.Application oApp = new Outlook.Application();
            Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

            oMsg.Subject = "Soils Report PDF Attached";
            oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
            oMsg.HTMLBody = "Hello, see attached for requested soils report.";
            int pos = (int)oMsg.Body.Length + 1;
            int attachType = (int)Outlook.OlAttachmentType.olByValue;

            //send files to a zipped folder, then attach
            //see how to build a temp zipped folder

            Outlook.Attachment oAttach = oMsg.Attachments.Add(@"C:\Users\klump\OneDrive\Programming\5990.zip", attachType, pos, "SoilsReports.zip");
            oMsg.Display(false); //In order to display it in modal inspector change the argument to true


            textBox_SearchResults.Text = "Email draft has been successfully opened!";
            textBox_SearchResults.ForeColor = Color.Green;

        }
    }
}
