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
            this.textBox_Report = new System.Windows.Forms.TextBox();
            this.textBox_PN = new System.Windows.Forms.TextBox();
            this.textBox_ProjName = new System.Windows.Forms.TextBox();
            this.textBox_Client = new System.Windows.Forms.TextBox();
            this.textBox_Type = new System.Windows.Forms.TextBox();
            this.textBox_Depth = new System.Windows.Forms.TextBox();
            this.textBox_Year = new System.Windows.Forms.TextBox();
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
            // textBox_Report
            // 
            this.textBox_Report.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox_Report.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Report.Location = new System.Drawing.Point(17, 12);
            this.textBox_Report.Multiline = true;
            this.textBox_Report.Name = "textBox_Report";
            this.textBox_Report.ReadOnly = true;
            this.textBox_Report.Size = new System.Drawing.Size(224, 18);
            this.textBox_Report.TabIndex = 5;
            this.textBox_Report.Text = "Report: ";
            // 
            // textBox_PN
            // 
            this.textBox_PN.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox_PN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_PN.Location = new System.Drawing.Point(17, 52);
            this.textBox_PN.Multiline = true;
            this.textBox_PN.Name = "textBox_PN";
            this.textBox_PN.ReadOnly = true;
            this.textBox_PN.Size = new System.Drawing.Size(224, 18);
            this.textBox_PN.TabIndex = 5;
            this.textBox_PN.Text = "Project Number:";
            // 
            // textBox_ProjName
            // 
            this.textBox_ProjName.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox_ProjName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_ProjName.Location = new System.Drawing.Point(17, 72);
            this.textBox_ProjName.Multiline = true;
            this.textBox_ProjName.Name = "textBox_ProjName";
            this.textBox_ProjName.ReadOnly = true;
            this.textBox_ProjName.Size = new System.Drawing.Size(224, 34);
            this.textBox_ProjName.TabIndex = 5;
            this.textBox_ProjName.Text = "Project Name:";
            // 
            // textBox_Client
            // 
            this.textBox_Client.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox_Client.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Client.Location = new System.Drawing.Point(17, 32);
            this.textBox_Client.Multiline = true;
            this.textBox_Client.Name = "textBox_Client";
            this.textBox_Client.ReadOnly = true;
            this.textBox_Client.Size = new System.Drawing.Size(224, 18);
            this.textBox_Client.TabIndex = 5;
            this.textBox_Client.Text = "Client:";
            // 
            // textBox_Type
            // 
            this.textBox_Type.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox_Type.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Type.Location = new System.Drawing.Point(260, 12);
            this.textBox_Type.Multiline = true;
            this.textBox_Type.Name = "textBox_Type";
            this.textBox_Type.ReadOnly = true;
            this.textBox_Type.Size = new System.Drawing.Size(119, 18);
            this.textBox_Type.TabIndex = 5;
            this.textBox_Type.Text = "Type:";
            // 
            // textBox_Depth
            // 
            this.textBox_Depth.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox_Depth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Depth.Location = new System.Drawing.Point(260, 32);
            this.textBox_Depth.Multiline = true;
            this.textBox_Depth.Name = "textBox_Depth";
            this.textBox_Depth.ReadOnly = true;
            this.textBox_Depth.Size = new System.Drawing.Size(119, 18);
            this.textBox_Depth.TabIndex = 5;
            this.textBox_Depth.Text = "Depth:";
            // 
            // textBox_Year
            // 
            this.textBox_Year.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox_Year.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Year.Location = new System.Drawing.Point(260, 52);
            this.textBox_Year.Multiline = true;
            this.textBox_Year.Name = "textBox_Year";
            this.textBox_Year.ReadOnly = true;
            this.textBox_Year.Size = new System.Drawing.Size(119, 18);
            this.textBox_Year.TabIndex = 5;
            this.textBox_Year.Text = "Year:";
            // 
            // Form_MapPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 182);
            this.Controls.Add(this.textBox_Client);
            this.Controls.Add(this.textBox_ProjName);
            this.Controls.Add(this.textBox_PN);
            this.Controls.Add(this.textBox_Year);
            this.Controls.Add(this.textBox_Depth);
            this.Controls.Add(this.textBox_Type);
            this.Controls.Add(this.textBox_Report);
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
        private TextBox textBox_Report;
        private TextBox textBox_PN;
        private TextBox textBox_ProjName;
        private TextBox textBox_Client;
        private TextBox textBox_Type;
        private TextBox textBox_Depth;
        private TextBox textBox_Year;
    }
}