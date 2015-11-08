namespace MP3Boss.Source.Forms
{
    partial class SearchAndReplaceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchAndReplaceForm));
            this.tBoxFind = new System.Windows.Forms.TextBox();
            this.tBoxReplace = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.lblFind = new System.Windows.Forms.Label();
            this.lblReplace = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.cBoxSearchAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tBoxFind
            // 
            this.tBoxFind.Location = new System.Drawing.Point(67, 24);
            this.tBoxFind.Name = "tBoxFind";
            this.tBoxFind.Size = new System.Drawing.Size(191, 20);
            this.tBoxFind.TabIndex = 0;
            // 
            // tBoxReplace
            // 
            this.tBoxReplace.Location = new System.Drawing.Point(67, 60);
            this.tBoxReplace.Name = "tBoxReplace";
            this.tBoxReplace.Size = new System.Drawing.Size(191, 20);
            this.tBoxReplace.TabIndex = 1;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(177, 97);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(81, 23);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "Change!";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(12, 27);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(30, 13);
            this.lblFind.TabIndex = 3;
            this.lblFind.Text = "Find:";
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Location = new System.Drawing.Point(12, 63);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(50, 13);
            this.lblReplace.TabIndex = 4;
            this.lblReplace.Text = "Replace:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(13, 102);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(38, 13);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "Count:";
            // 
            // cBoxSearchAll
            // 
            this.cBoxSearchAll.AutoSize = true;
            this.cBoxSearchAll.Location = new System.Drawing.Point(97, 101);
            this.cBoxSearchAll.Name = "cBoxSearchAll";
            this.cBoxSearchAll.Size = new System.Drawing.Size(74, 17);
            this.cBoxSearchAll.TabIndex = 6;
            this.cBoxSearchAll.Text = "Search All";
            this.cBoxSearchAll.UseVisualStyleBackColor = true;
            // 
            // SearchAndReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 134);
            this.Controls.Add(this.cBoxSearchAll);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblReplace);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.tBoxReplace);
            this.Controls.Add(this.tBoxFind);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(285, 172);
            this.MinimumSize = new System.Drawing.Size(285, 172);
            this.Name = "SearchAndReplaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search & Replace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBoxFind;
        private System.Windows.Forms.TextBox tBoxReplace;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Label lblReplace;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.CheckBox cBoxSearchAll;
    }
}