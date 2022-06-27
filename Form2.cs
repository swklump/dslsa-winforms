using System.Data.SQLite;
using System.Diagnostics;
using System.IO.Compression;

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
        private String dbpath = @"C:\Users\klump\OneDrive\Programming\dslsa\dslsa_database.db";

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
            comboBox_OpenSave.SelectedIndex = 0;
            report_nums = ((Form1)f).report_nums;

            //display number of results to label
            if (report_nums.Count == 0)
            {
                label_SearchResults.Text = "There were no reports found! Please return to the main menu and try another selection.";
                label_SearchResults.ForeColor = Color.Red;
                comboBox_OpenSave.Visible = false;
                button_Submit.Visible = false;
                label_WhatToDo.Visible = false;
            }
            else if (report_nums.Count == 1)
            {
                label_SearchResults.Text = "There was 1 report returned!";
                label_SearchResults.ForeColor = Color.Green;
            }
            else
            {
                label_SearchResults.Text = string.Format("There were {0} reports found!", report_nums.Count.ToString());
                label_SearchResults.ForeColor = Color.Green;
            }
        }

        private void button_Submit_Click(object sender, EventArgs e)
        {
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

            //save pdfs if desired
            string open_save = comboBox_OpenSave.SelectedItem.ToString();
            if (open_save == "Save PDFs to Folder" || open_save == "Open and Save PDFs")
            {
                //folder select dialog
                folderBrowserDialog1 = new FolderBrowserDialog();
                folderBrowserDialog1.ShowDialog();
                string folderName = String.Empty;
                folderName = folderBrowserDialog1.SelectedPath;
                Directory.CreateDirectory(folderName + @"\SoilReportPDFs");


                //copy files to selected folder
                foreach (var report in report_nums)
                {
                    string sourceFile = pdffolder + report + ".pdf";
                    string destFile = folderName + @"\SoilReportPDFs\" + report + ".pdf";
                    Console.WriteLine(sourceFile);
                    Console.WriteLine(destFile);
                    File.Copy(sourceFile, destFile, true);
                }


                //zip files
                try { ZipFile.CreateFromDirectory(folderName + @"\SoilReportPDFs", folderName + @"\SoilReportPDFs.zip"); }
                catch (IOException)
                {
                    label_SearchResults.Text = "A folder called 'SoilsReportPDFs' already exists in the directory specified. Please delete the existing folder or select a different directory.";
                    label_SearchResults.ForeColor = Color.Red;
                    return;

                }

                //start outlook message

                Process.Start(@"mailto:name@domain.com?Subject=SubjTxt&Body=Bod_Txt&Attachment=C:\Users\klump\OneDrive\file.txt");

                this.Close();
                ((Form1)f).Show();
                ((Form1)f).label_NoResults.Text = "PDFs have been successfully saved! A folder called 'SoilReportPDFs' and a zipped file called 'SoilsReportPDFs.zip' have been created.";
                ((Form1)f).label_NoResults.ForeColor = Color.Green;

            }

            //open pdfs if desired
            if (open_save == "Open PDFs" || open_save == "Open and Save PDFs")
            {
                using (Process p = new Process())
                {
                    foreach (var report in report_nums)
                    {
                        p.StartInfo = new ProcessStartInfo()
                        {
                            CreateNoWindow = true,
                            UseShellExecute = true,
                            FileName = pdffolder + report + ".pdf"
                        };

                        p.Start();

                    }

                }

                this.Close();
                ((Form1)f).Show();
                ((Form1)f).label_NoResults.Text = "PDFs have been successfully opened!";
                ((Form1)f).label_NoResults.ForeColor = Color.Green;

            }
        }
    }
}
