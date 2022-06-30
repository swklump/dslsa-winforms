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
            this.label_Report = new System.Windows.Forms.Label();
            this.label_ProjNum = new System.Windows.Forms.Label();
            this.label_ProjName = new System.Windows.Forms.Label();
            this.label_Client = new System.Windows.Forms.Label();
            this.button_OpenPDF = new System.Windows.Forms.Button();
            this.button_AddToList = new System.Windows.Forms.Button();
            this.label_Message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Report
            // 
            this.label_Report.AutoSize = true;
            this.label_Report.Location = new System.Drawing.Point(17, 12);
            this.label_Report.Name = "label_Report";
            this.label_Report.Size = new System.Drawing.Size(45, 15);
            this.label_Report.TabIndex = 0;
            this.label_Report.Text = "Report:";
            // 
            // label_ProjNum
            // 
            this.label_ProjNum.AutoSize = true;
            this.label_ProjNum.Location = new System.Drawing.Point(17, 36);
            this.label_ProjNum.Name = "label_ProjNum";
            this.label_ProjNum.Size = new System.Drawing.Size(94, 15);
            this.label_ProjNum.TabIndex = 1;
            this.label_ProjNum.Text = "Project Number:";
            // 
            // label_ProjName
            // 
            this.label_ProjName.AutoSize = true;
            this.label_ProjName.Location = new System.Drawing.Point(17, 60);
            this.label_ProjName.Name = "label_ProjName";
            this.label_ProjName.Size = new System.Drawing.Size(82, 15);
            this.label_ProjName.TabIndex = 2;
            this.label_ProjName.Text = "Project Name:";
            // 
            // label_Client
            // 
            this.label_Client.AutoSize = true;
            this.label_Client.Location = new System.Drawing.Point(17, 84);
            this.label_Client.Name = "label_Client";
            this.label_Client.Size = new System.Drawing.Size(41, 15);
            this.label_Client.TabIndex = 3;
            this.label_Client.Text = "Client:";
            // 
            // button_OpenPDF
            // 
            this.button_OpenPDF.Location = new System.Drawing.Point(17, 118);
            this.button_OpenPDF.Name = "button_OpenPDF";
            this.button_OpenPDF.Size = new System.Drawing.Size(165, 23);
            this.button_OpenPDF.TabIndex = 4;
            this.button_OpenPDF.Text = "Open PDF";
            this.button_OpenPDF.UseVisualStyleBackColor = true;
            this.button_OpenPDF.Click += new System.EventHandler(this.button_OpenPDF_Click);
            // 
            // button_AddToList
            // 
            this.button_AddToList.Location = new System.Drawing.Point(202, 118);
            this.button_AddToList.Name = "button_AddToList";
            this.button_AddToList.Size = new System.Drawing.Size(165, 23);
            this.button_AddToList.TabIndex = 4;
            this.button_AddToList.Text = "Add to list";
            this.button_AddToList.UseVisualStyleBackColor = true;
            this.button_AddToList.Click += new System.EventHandler(this.button_AddToList_Click);
            // 
            // label_Message
            // 
            this.label_Message.AutoSize = true;
            this.label_Message.Location = new System.Drawing.Point(17, 144);
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(0, 15);
            this.label_Message.TabIndex = 3;
            // 
            // Form_MapPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 175);
            this.Controls.Add(this.button_AddToList);
            this.Controls.Add(this.button_OpenPDF);
            this.Controls.Add(this.label_Message);
            this.Controls.Add(this.label_Client);
            this.Controls.Add(this.label_ProjName);
            this.Controls.Add(this.label_ProjNum);
            this.Controls.Add(this.label_Report);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_MapPopup";
            this.Text = "Marker Info";
            this.Load += new System.EventHandler(this.Form_MapPopup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_Report;
        private Label label_ProjNum;
        private Label label_ProjName;
        private Label label_Client;
        private Button button_OpenPDF;
        private Button button_AddToList;
        private Label label_Message;
    }
}