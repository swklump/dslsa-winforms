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
            this.label_SearchResults = new System.Windows.Forms.Label();
            this.label_WhatToDo = new System.Windows.Forms.Label();
            this.comboBox_OpenSave = new System.Windows.Forms.ComboBox();
            this.button_Submit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_SearchResults
            // 
            this.label_SearchResults.Location = new System.Drawing.Point(26, 9);
            this.label_SearchResults.Name = "label_SearchResults";
            this.label_SearchResults.Size = new System.Drawing.Size(345, 57);
            this.label_SearchResults.TabIndex = 0;
            // 
            // label_WhatToDo
            // 
            this.label_WhatToDo.AutoSize = true;
            this.label_WhatToDo.Location = new System.Drawing.Point(26, 83);
            this.label_WhatToDo.Name = "label_WhatToDo";
            this.label_WhatToDo.Size = new System.Drawing.Size(226, 15);
            this.label_WhatToDo.TabIndex = 1;
            this.label_WhatToDo.Text = "What would you like to do with the PDFs?";
            // 
            // comboBox_OpenSave
            // 
            this.comboBox_OpenSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OpenSave.FormattingEnabled = true;
            this.comboBox_OpenSave.Items.AddRange(new object[] {
            "Open PDFs",
            "Save PDFs to Folder",
            "Open and Save PDFs"});
            this.comboBox_OpenSave.Location = new System.Drawing.Point(257, 80);
            this.comboBox_OpenSave.Name = "comboBox_OpenSave";
            this.comboBox_OpenSave.Size = new System.Drawing.Size(142, 23);
            this.comboBox_OpenSave.TabIndex = 2;
            // 
            // button_Submit
            // 
            this.button_Submit.Location = new System.Drawing.Point(414, 79);
            this.button_Submit.Name = "button_Submit";
            this.button_Submit.Size = new System.Drawing.Size(111, 23);
            this.button_Submit.TabIndex = 3;
            this.button_Submit.Text = "Submit";
            this.button_Submit.UseVisualStyleBackColor = true;
            this.button_Submit.Click += new System.EventHandler(this.button_Submit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(385, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Back to Main Menu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_MainMenu_Click);
            // 
            // Form2
            // 
            this.AcceptButton = this.button_Submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 121);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_Submit);
            this.Controls.Add(this.comboBox_OpenSave);
            this.Controls.Add(this.label_WhatToDo);
            this.Controls.Add(this.label_SearchResults);
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

        private Label label_SearchResults;
        private Label label_WhatToDo;
        private ComboBox comboBox_OpenSave;
        private Button button_Submit;
        private Button button2;
    }
}