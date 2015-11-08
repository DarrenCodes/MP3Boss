namespace MP3Boss.Source.Forms
{
    partial class CheckMessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckMessageForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnMsgBoxYes = new System.Windows.Forms.Button();
            this.btnMsgBoxSkip = new System.Windows.Forms.Button();
            this.btnMsgBoxContinue = new System.Windows.Forms.Button();
            this.cMsgBoxApplyToAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "All fields not filled. Fill now? \r\nSelecting Yes will allow you to edit the probl" +
    "em tag.\r\nSelecting Continue will re-format using existing tags. \r\nSelecting Skip" +
    " will skip the problem file.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnMsgBoxYes
            // 
            this.btnMsgBoxYes.Location = new System.Drawing.Point(22, 75);
            this.btnMsgBoxYes.Name = "btnMsgBoxYes";
            this.btnMsgBoxYes.Size = new System.Drawing.Size(75, 23);
            this.btnMsgBoxYes.TabIndex = 1;
            this.btnMsgBoxYes.Text = "Yes";
            this.btnMsgBoxYes.UseVisualStyleBackColor = true;
            this.btnMsgBoxYes.Click += new System.EventHandler(this.btnMsgBoxYes_Click);
            // 
            // btnMsgBoxSkip
            // 
            this.btnMsgBoxSkip.Location = new System.Drawing.Point(182, 75);
            this.btnMsgBoxSkip.Name = "btnMsgBoxSkip";
            this.btnMsgBoxSkip.Size = new System.Drawing.Size(75, 23);
            this.btnMsgBoxSkip.TabIndex = 3;
            this.btnMsgBoxSkip.Text = "Skip";
            this.btnMsgBoxSkip.UseVisualStyleBackColor = true;
            this.btnMsgBoxSkip.Click += new System.EventHandler(this.btnMsgBoxSkip_Click);
            // 
            // btnMsgBoxContinue
            // 
            this.btnMsgBoxContinue.Location = new System.Drawing.Point(103, 75);
            this.btnMsgBoxContinue.Name = "btnMsgBoxContinue";
            this.btnMsgBoxContinue.Size = new System.Drawing.Size(75, 23);
            this.btnMsgBoxContinue.TabIndex = 4;
            this.btnMsgBoxContinue.Text = "Continue";
            this.btnMsgBoxContinue.UseVisualStyleBackColor = true;
            this.btnMsgBoxContinue.Click += new System.EventHandler(this.btnMsgBoxContinue_Click);
            // 
            // cMsgBoxApplyToAll
            // 
            this.cMsgBoxApplyToAll.AutoSize = true;
            this.cMsgBoxApplyToAll.Location = new System.Drawing.Point(96, 107);
            this.cMsgBoxApplyToAll.Name = "cMsgBoxApplyToAll";
            this.cMsgBoxApplyToAll.Size = new System.Drawing.Size(82, 17);
            this.cMsgBoxApplyToAll.TabIndex = 5;
            this.cMsgBoxApplyToAll.Text = "Apply To All";
            this.cMsgBoxApplyToAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cMsgBoxApplyToAll.UseVisualStyleBackColor = true;
            this.cMsgBoxApplyToAll.CheckedChanged += new System.EventHandler(this.cMsgBoxApplyToAll_CheckedChanged);
            // 
            // CheckMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 136);
            this.Controls.Add(this.cMsgBoxApplyToAll);
            this.Controls.Add(this.btnMsgBoxContinue);
            this.Controls.Add(this.btnMsgBoxSkip);
            this.Controls.Add(this.btnMsgBoxYes);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(294, 174);
            this.MinimumSize = new System.Drawing.Size(294, 174);
            this.Name = "CheckMessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Important!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMsgBoxYes;
        private System.Windows.Forms.Button btnMsgBoxSkip;
        private System.Windows.Forms.Button btnMsgBoxContinue;
        private System.Windows.Forms.CheckBox cMsgBoxApplyToAll;
    }
}