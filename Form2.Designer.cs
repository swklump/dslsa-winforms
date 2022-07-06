namespace dslsa
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label_WhatToDo = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button_OpenPDFs = new System.Windows.Forms.Button();
            this.button_SavePDFs = new System.Windows.Forms.Button();
            this.button_EmailPDFs = new System.Windows.Forms.Button();
            this.textBox_SearchResults = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_WhatToDo
            // 
            this.label_WhatToDo.AutoSize = true;
            this.label_WhatToDo.Location = new System.Drawing.Point(26, 109);
            this.label_WhatToDo.Name = "label_WhatToDo";
            this.label_WhatToDo.Size = new System.Drawing.Size(226, 15);
            this.label_WhatToDo.TabIndex = 1;
            this.label_WhatToDo.Text = "What would you like to do with the PDFs?";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(320, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Back to Main Menu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_MainMenu_Click);
            // 
            // button_OpenPDFs
            // 
            this.button_OpenPDFs.Location = new System.Drawing.Point(26, 141);
            this.button_OpenPDFs.Name = "button_OpenPDFs";
            this.button_OpenPDFs.Size = new System.Drawing.Size(111, 23);
            this.button_OpenPDFs.TabIndex = 3;
            this.button_OpenPDFs.Text = "Open PDFs";
            this.button_OpenPDFs.UseVisualStyleBackColor = true;
            this.button_OpenPDFs.Click += new System.EventHandler(this.button_OpenPDFs_Click);
            // 
            // button_SavePDFs
            // 
            this.button_SavePDFs.Location = new System.Drawing.Point(186, 141);
            this.button_SavePDFs.Name = "button_SavePDFs";
            this.button_SavePDFs.Size = new System.Drawing.Size(111, 23);
            this.button_SavePDFs.TabIndex = 3;
            this.button_SavePDFs.Text = "Save PDFs";
            this.button_SavePDFs.UseVisualStyleBackColor = true;
            this.button_SavePDFs.Click += new System.EventHandler(this.button_SavePDFs_Click);
            // 
            // button_EmailPDFs
            // 
            this.button_EmailPDFs.Location = new System.Drawing.Point(349, 141);
            this.button_EmailPDFs.Name = "button_EmailPDFs";
            this.button_EmailPDFs.Size = new System.Drawing.Size(111, 23);
            this.button_EmailPDFs.TabIndex = 3;
            this.button_EmailPDFs.Text = "Email PDFs";
            this.button_EmailPDFs.UseVisualStyleBackColor = true;
            this.button_EmailPDFs.Click += new System.EventHandler(this.button_EmailPDFs_Click);
            // 
            // textBox_SearchResults
            // 
            this.textBox_SearchResults.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_SearchResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_SearchResults.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox_SearchResults.Location = new System.Drawing.Point(26, 9);
            this.textBox_SearchResults.Multiline = true;
            this.textBox_SearchResults.Name = "textBox_SearchResults";
            this.textBox_SearchResults.ReadOnly = true;
            this.textBox_SearchResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_SearchResults.Size = new System.Drawing.Size(271, 83);
            this.textBox_SearchResults.TabIndex = 5;
            // 
            // Form2
            // 
            this.AcceptButton = this.button_OpenPDFs;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(472, 180);
            this.Controls.Add(this.textBox_SearchResults);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_EmailPDFs);
            this.Controls.Add(this.button_SavePDFs);
            this.Controls.Add(this.button_OpenPDFs);
            this.Controls.Add(this.label_WhatToDo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Results";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_SearchResults_FormClosed);
            this.Load += new System.EventHandler(this.Form_SearchResults_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label_WhatToDo;
        private Button button2;
        private Button button_OpenPDFs;
        private Button button_SavePDFs;
        private Button button_EmailPDFs;
        private TextBox textBox_SearchResults;
    }
}