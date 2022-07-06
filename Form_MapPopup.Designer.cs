namespace dslsa
{
    partial class Form_MapPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MapPopup));
            this.button_OpenPDF = new System.Windows.Forms.Button();
            this.button_AddToList = new System.Windows.Forms.Button();
            this.label_Message = new System.Windows.Forms.Label();
            this.button_EmailPDF = new System.Windows.Forms.Button();
            this.richTextBox_ProjName = new System.Windows.Forms.RichTextBox();
            this.richTextBox_PN = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Client = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Report = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Type = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Depth = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Year = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button_OpenPDF
            // 
            this.button_OpenPDF.Location = new System.Drawing.Point(12, 126);
            this.button_OpenPDF.Name = "button_OpenPDF";
            this.button_OpenPDF.Size = new System.Drawing.Size(112, 23);
            this.button_OpenPDF.TabIndex = 4;
            this.button_OpenPDF.Text = "Open PDF";
            this.button_OpenPDF.UseVisualStyleBackColor = true;
            this.button_OpenPDF.Click += new System.EventHandler(this.button_OpenPDF_Click);
            // 
            // button_AddToList
            // 
            this.button_AddToList.Location = new System.Drawing.Point(278, 126);
            this.button_AddToList.Name = "button_AddToList";
            this.button_AddToList.Size = new System.Drawing.Size(116, 23);
            this.button_AddToList.TabIndex = 4;
            this.button_AddToList.Text = "Add to list";
            this.button_AddToList.UseVisualStyleBackColor = true;
            this.button_AddToList.Click += new System.EventHandler(this.button_AddToList_Click);
            // 
            // label_Message
            // 
            this.label_Message.AutoSize = true;
            this.label_Message.Location = new System.Drawing.Point(12, 152);
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(0, 15);
            this.label_Message.TabIndex = 3;
            // 
            // button_EmailPDF
            // 
            this.button_EmailPDF.Location = new System.Drawing.Point(142, 126);
            this.button_EmailPDF.Name = "button_EmailPDF";
            this.button_EmailPDF.Size = new System.Drawing.Size(119, 23);
            this.button_EmailPDF.TabIndex = 4;
            this.button_EmailPDF.Text = "Email PDF";
            this.button_EmailPDF.UseVisualStyleBackColor = true;
            this.button_EmailPDF.Click += new System.EventHandler(this.button_EmailPDF_Click);
            // 
            // richTextBox_ProjName
            // 
            this.richTextBox_ProjName.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox_ProjName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_ProjName.Location = new System.Drawing.Point(17, 72);
            this.richTextBox_ProjName.Name = "richTextBox_ProjName";
            this.richTextBox_ProjName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_ProjName.Size = new System.Drawing.Size(224, 34);
            this.richTextBox_ProjName.TabIndex = 6;
            this.richTextBox_ProjName.Text = "Project Name:";
            // 
            // richTextBox_PN
            // 
            this.richTextBox_PN.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox_PN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_PN.Location = new System.Drawing.Point(17, 52);
            this.richTextBox_PN.Name = "richTextBox_PN";
            this.richTextBox_PN.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_PN.Size = new System.Drawing.Size(224, 18);
            this.richTextBox_PN.TabIndex = 6;
            this.richTextBox_PN.Text = "Project Number:";
            // 
            // richTextBox_Client
            // 
            this.richTextBox_Client.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox_Client.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Client.Location = new System.Drawing.Point(17, 32);
            this.richTextBox_Client.Name = "richTextBox_Client";
            this.richTextBox_Client.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_Client.Size = new System.Drawing.Size(224, 18);
            this.richTextBox_Client.TabIndex = 6;
            this.richTextBox_Client.Text = "Client:";
            // 
            // richTextBox_Report
            // 
            this.richTextBox_Report.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox_Report.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Report.Location = new System.Drawing.Point(17, 12);
            this.richTextBox_Report.Name = "richTextBox_Report";
            this.richTextBox_Report.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_Report.Size = new System.Drawing.Size(224, 18);
            this.richTextBox_Report.TabIndex = 6;
            this.richTextBox_Report.Text = "Report:";
            // 
            // richTextBox_Type
            // 
            this.richTextBox_Type.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox_Type.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Type.Location = new System.Drawing.Point(260, 12);
            this.richTextBox_Type.Name = "richTextBox_Type";
            this.richTextBox_Type.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_Type.Size = new System.Drawing.Size(119, 18);
            this.richTextBox_Type.TabIndex = 6;
            this.richTextBox_Type.Text = "Type:";
            // 
            // richTextBox_Depth
            // 
            this.richTextBox_Depth.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox_Depth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Depth.Location = new System.Drawing.Point(260, 32);
            this.richTextBox_Depth.Name = "richTextBox_Depth";
            this.richTextBox_Depth.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_Depth.Size = new System.Drawing.Size(119, 18);
            this.richTextBox_Depth.TabIndex = 6;
            this.richTextBox_Depth.Text = "Depth:";
            // 
            // richTextBox_Year
            // 
            this.richTextBox_Year.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox_Year.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Year.Location = new System.Drawing.Point(260, 52);
            this.richTextBox_Year.Name = "richTextBox_Year";
            this.richTextBox_Year.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_Year.Size = new System.Drawing.Size(119, 18);
            this.richTextBox_Year.TabIndex = 6;
            this.richTextBox_Year.Text = "Year:";
            // 
            // Form_MapPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(411, 182);
            this.Controls.Add(this.richTextBox_Year);
            this.Controls.Add(this.richTextBox_Depth);
            this.Controls.Add(this.richTextBox_Type);
            this.Controls.Add(this.richTextBox_Report);
            this.Controls.Add(this.richTextBox_Client);
            this.Controls.Add(this.richTextBox_PN);
            this.Controls.Add(this.richTextBox_ProjName);
            this.Controls.Add(this.button_AddToList);
            this.Controls.Add(this.button_EmailPDF);
            this.Controls.Add(this.button_OpenPDF);
            this.Controls.Add(this.label_Message);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_MapPopup";
            this.Text = "Marker Info";
            this.Load += new System.EventHandler(this.Form_MapPopup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button_OpenPDF;
        private Button button_AddToList;
        private Label label_Message;
        private Button button_EmailPDF;
        private RichTextBox richTextBox_ProjName;
        private RichTextBox richTextBox_PN;
        private RichTextBox richTextBox_Client;
        private RichTextBox richTextBox_Report;
        private RichTextBox richTextBox_Type;
        private RichTextBox richTextBox_Depth;
        private RichTextBox richTextBox_Year;
    }
}