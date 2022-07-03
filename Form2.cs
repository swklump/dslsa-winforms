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
        private string pdffolder;
        private string selectedState;
        private string dbpath = @"dslsa_database.db";

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
            selectedState = ((Form1)f).selectedState + @"\";
            if (report_nums.Count() > 20)
            {
                button_OpenPDFs.Visible = false;
            }
            textBox_SearchResults.BackColor = SystemColors.Control;

            //display number of results to label
            if (report_nums.Count == 0)
            {
                textBox_SearchResults.Text = "There were no reports found! Please return to the main menu and try another selection.";
                textBox_SearchResults.ForeColor = Color.Red;

                List<Button> buttons_tohide = new List<Button>() { button_OpenPDFs, button_SavePDFs, button_EmailPDFs };
                foreach (Button button in buttons_tohide) { button.Visible = false; }
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

        private void button_OpenPDFs_Click(object sender, EventArgs e)
        {
            textBox_SearchResults.Text = "Processing...";
            textBox_SearchResults.ForeColor = Color.Blue;
            textBox_SearchResults.Invalidate();
            textBox_SearchResults.Update();

            List<string> pdfsnotfound = new List<string>();
            string message = string.Empty;
            string reportstring = string.Empty;

            //open the pdfs, start outlook if not already open
            using (Process p = new Process())
            {
                foreach (var report in report_nums)
                {
                    if (File.Exists(pdffolder + report + ".pdf"))
                    {
                        p.StartInfo = new ProcessStartInfo()
                        {
                            CreateNoWindow = true,
                            UseShellExecute = true,
                            FileName = pdffolder + report + ".pdf"
                        };
                        p.Start();
                    }
                    else
                    {
                        pdfsnotfound.Add(report);
                    }
                }
            }

            //change the label message depending on what reports exist
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
            string folderName = String.Empty;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderName = folderBrowserDialog1.SelectedPath;
                try { Directory.CreateDirectory(folderName + @"\SoilReportPDFs"); }
                catch (UnauthorizedAccessException)
                {
                    textBox_SearchResults.Text = "Cannot save files in that folder. Please select a different folder.";
                    textBox_SearchResults.ForeColor = Color.Red;
                    return;
                }

                textBox_SearchResults.Text = "Processing...";
                textBox_SearchResults.ForeColor = Color.Blue;
                textBox_SearchResults.Invalidate();
                textBox_SearchResults.Update();

                //copy files to selected folder
                List<string> pdfsnotfound = new List<string>();
                foreach (var report in report_nums)
                {
                    string sourceFile = pdffolder + report + ".pdf";
                    string destFile = folderName + @"\SoilReportPDFs\" + report + ".pdf";
                    if (File.Exists(pdffolder + report + ".pdf"))
                    {
                        File.Copy(sourceFile, destFile, true);
                    }
                    else
                    {
                        pdfsnotfound.Add(report);
                    }
                }


                //zip files
                try { ZipFile.CreateFromDirectory(folderName + @"\SoilReportPDFs", folderName + @"\SoilReportPDFs.zip"); }
                catch (Exception ex)
                {
                    Directory.Delete(folderName + @"\SoilReportPDFs", true);
                    textBox_SearchResults.Text = "Cannot save files in that folder. Please select a different folder. You either do not have access or there is already a folder called 'SoilsReportPDFs.zip' in that directory.";
                    textBox_SearchResults.ForeColor = Color.Red;
                    return;
                }

                //change the label message depending on what reports exist
                string message = string.Empty;
                string reportstring = string.Empty;
                if (pdfsnotfound.Count == report_nums.Count)
                {
                    message = "No PDFs have been saved! The following PDFs are shown in the Excel file but do not exist in the PDF folder: ";
                    reportstring = string.Join(",", pdfsnotfound.ToArray());
                    textBox_SearchResults.Text = message + reportstring;
                    textBox_SearchResults.ForeColor = Color.Red;
                }
                else if (pdfsnotfound.Count == 0)
                {
                    textBox_SearchResults.Text = "All PDFs have been successfully saved in the selected folder!";
                    textBox_SearchResults.ForeColor = Color.Green;
                }
                else
                {
                    message = "PDFs have been saved in the selected folder! The following PDFs are shown in the Excel file but do not exist in the PDF folder: ";
                    reportstring = string.Join(",", pdfsnotfound.ToArray());
                    textBox_SearchResults.Text = message + reportstring;
                    textBox_SearchResults.ForeColor = Color.Green;
                }
            }
            else
            {
                textBox_SearchResults.Text = "No save folder specified.";
                textBox_SearchResults.ForeColor = Color.Red;
            }
        }

        private void button_EmailPDFs_Click(object sender, EventArgs e)
        {
            textBox_SearchResults.Text = "Processing...";
            textBox_SearchResults.ForeColor = Color.Blue;
            textBox_SearchResults.Invalidate();
            textBox_SearchResults.Update();

            //create a temp folder
            string tempPath = Path.GetTempPath();
            Directory.CreateDirectory(tempPath + @"\SoilReportPDFs");

            //copy files to temp folder
            List<string> pdfsnotfound = new List<string>();
            foreach (var report in report_nums)
            {
                string sourceFile = pdffolder + report + ".pdf";
                string destFile = tempPath + @"\SoilReportPDFs\" + report + ".pdf";
                try
                {
                    File.Copy(sourceFile, destFile, true);
                }
                catch (Exception ex)
                {
                    pdfsnotfound.Add(report);
                }
            }
            //zip folder
            try { ZipFile.CreateFromDirectory(tempPath + @"\SoilReportPDFs", tempPath + @"\SoilReportPDFs.zip"); }
            catch (IOException)
            {
                textBox_SearchResults.Text = "A folder called 'SoilsReportPDFs' already exists in the directory specified. Please delete the existing folder or select a different directory.";
                textBox_SearchResults.ForeColor = Color.Red;
                return;
            }

            //create outlook message
            try
            {
                if (Process.GetProcessesByName("outlook").Length == 0)
                {
                    Process.Start("OutLook.exe");
                }
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
                Outlook.Attachment oAttach = oMsg.Attachments.Add(tempPath + @"\SoilReportPDFs.zip", attachType, pos, "SoilReportPDFs.zip");
                oMsg.Display(false);

                //delete the temp folders
                Directory.Delete(tempPath + @"\SoilReportPDFs", true);
                File.Delete(tempPath + @"\SoilReportPDFs.zip");

                textBox_SearchResults.Text = "Email draft has been successfully opened!";
                textBox_SearchResults.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                textBox_SearchResults.Text = "Email draft could not be created. Restart Outlook and try again.";
                textBox_SearchResults.ForeColor = Color.Red;
            }
        }
    }
}
