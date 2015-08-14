namespace MP3Boss
{
    partial class FormMP3Boss
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMP3Boss));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuOpenDeep = new System.Windows.Forms.ToolStripMenuItem();
            this.tBoxTitle = new System.Windows.Forms.TextBox();
            this.tBoxContArtists = new System.Windows.Forms.TextBox();
            this.tBoxAlbumArtist = new System.Windows.Forms.TextBox();
            this.tBoxAlbum = new System.Windows.Forms.TextBox();
            this.tBoxYear = new System.Windows.Forms.TextBox();
            this.tBoxTrackNo = new System.Windows.Forms.TextBox();
            this.tBoxGenre = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.cBoxApplyToAll = new System.Windows.Forms.CheckBox();
            this.fBDialogLoadMP3s = new System.Windows.Forms.FolderBrowserDialog();
            this.listViewMP3s = new System.Windows.Forms.ListView();
            this.cBoxTitle = new System.Windows.Forms.CheckBox();
            this.cBoxAlbumArtist = new System.Windows.Forms.CheckBox();
            this.cBoxContArtists = new System.Windows.Forms.CheckBox();
            this.cBoxAlbum = new System.Windows.Forms.CheckBox();
            this.cBoxYear = new System.Windows.Forms.CheckBox();
            this.cBoxTrackNo = new System.Windows.Forms.CheckBox();
            this.cBoxGenre = new System.Windows.Forms.CheckBox();
            this.cBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(811, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(333, 220);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(898, 24);
            this.menuStrip.TabIndex = 2;
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuOpen,
            this.fileMenuOpenDeep});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // fileMenuOpen
            // 
            this.fileMenuOpen.Name = "fileMenuOpen";
            this.fileMenuOpen.Size = new System.Drawing.Size(181, 22);
            this.fileMenuOpen.Text = "Find files (shallow)...";
            this.fileMenuOpen.Click += new System.EventHandler(this.fileMenuOpen_Click);
            // 
            // fileMenuOpenDeep
            // 
            this.fileMenuOpenDeep.Name = "fileMenuOpenDeep";
            this.fileMenuOpenDeep.Size = new System.Drawing.Size(181, 22);
            this.fileMenuOpenDeep.Text = "Find files (deep)...";
            this.fileMenuOpenDeep.Click += new System.EventHandler(this.fileMenuOpenDeep_Click);
            // 
            // tBoxTitle
            // 
            this.tBoxTitle.Location = new System.Drawing.Point(151, 34);
            this.tBoxTitle.Name = "tBoxTitle";
            this.tBoxTitle.Size = new System.Drawing.Size(347, 20);
            this.tBoxTitle.TabIndex = 0;
            // 
            // tBoxContArtists
            // 
            this.tBoxContArtists.Location = new System.Drawing.Point(151, 88);
            this.tBoxContArtists.Name = "tBoxContArtists";
            this.tBoxContArtists.Size = new System.Drawing.Size(347, 20);
            this.tBoxContArtists.TabIndex = 2;
            // 
            // tBoxAlbumArtist
            // 
            this.tBoxAlbumArtist.Location = new System.Drawing.Point(151, 62);
            this.tBoxAlbumArtist.Name = "tBoxAlbumArtist";
            this.tBoxAlbumArtist.Size = new System.Drawing.Size(347, 20);
            this.tBoxAlbumArtist.TabIndex = 1;
            // 
            // tBoxAlbum
            // 
            this.tBoxAlbum.Location = new System.Drawing.Point(151, 114);
            this.tBoxAlbum.Name = "tBoxAlbum";
            this.tBoxAlbum.Size = new System.Drawing.Size(347, 20);
            this.tBoxAlbum.TabIndex = 3;
            // 
            // tBoxYear
            // 
            this.tBoxYear.Location = new System.Drawing.Point(151, 140);
            this.tBoxYear.Name = "tBoxYear";
            this.tBoxYear.Size = new System.Drawing.Size(347, 20);
            this.tBoxYear.TabIndex = 4;
            // 
            // tBoxTrackNo
            // 
            this.tBoxTrackNo.Location = new System.Drawing.Point(151, 166);
            this.tBoxTrackNo.Name = "tBoxTrackNo";
            this.tBoxTrackNo.Size = new System.Drawing.Size(347, 20);
            this.tBoxTrackNo.TabIndex = 5;
            // 
            // tBoxGenre
            // 
            this.tBoxGenre.Location = new System.Drawing.Point(151, 192);
            this.tBoxGenre.Name = "tBoxGenre";
            this.tBoxGenre.Size = new System.Drawing.Size(347, 20);
            this.tBoxGenre.TabIndex = 6;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(252, 220);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cBoxApplyToAll
            // 
            this.cBoxApplyToAll.AutoSize = true;
            this.cBoxApplyToAll.Location = new System.Drawing.Point(728, 224);
            this.cBoxApplyToAll.Name = "cBoxApplyToAll";
            this.cBoxApplyToAll.Size = new System.Drawing.Size(77, 17);
            this.cBoxApplyToAll.TabIndex = 17;
            this.cBoxApplyToAll.Text = "Apply to all";
            this.cBoxApplyToAll.UseVisualStyleBackColor = true;
            // 
            // listViewMP3s
            // 
            this.listViewMP3s.Location = new System.Drawing.Point(504, 35);
            this.listViewMP3s.MaximumSize = new System.Drawing.Size(382, 177);
            this.listViewMP3s.MinimumSize = new System.Drawing.Size(382, 177);
            this.listViewMP3s.Name = "listViewMP3s";
            this.listViewMP3s.Size = new System.Drawing.Size(382, 177);
            this.listViewMP3s.TabIndex = 19;
            this.listViewMP3s.UseCompatibleStateImageBehavior = false;
            this.listViewMP3s.View = System.Windows.Forms.View.List;
            this.listViewMP3s.SelectedIndexChanged += new System.EventHandler(this.listViewMP3s_SelectedIndexChanged);
            // 
            // cBoxTitle
            // 
            this.cBoxTitle.AutoSize = true;
            this.cBoxTitle.Location = new System.Drawing.Point(16, 37);
            this.cBoxTitle.Name = "cBoxTitle";
            this.cBoxTitle.Size = new System.Drawing.Size(49, 17);
            this.cBoxTitle.TabIndex = 7;
            this.cBoxTitle.Text = "Title:";
            this.cBoxTitle.UseVisualStyleBackColor = true;
            // 
            // cBoxAlbumArtist
            // 
            this.cBoxAlbumArtist.AutoSize = true;
            this.cBoxAlbumArtist.Location = new System.Drawing.Point(16, 65);
            this.cBoxAlbumArtist.Name = "cBoxAlbumArtist";
            this.cBoxAlbumArtist.Size = new System.Drawing.Size(83, 17);
            this.cBoxAlbumArtist.TabIndex = 8;
            this.cBoxAlbumArtist.Text = "Album artist:";
            this.cBoxAlbumArtist.UseVisualStyleBackColor = true;
            // 
            // cBoxContArtists
            // 
            this.cBoxContArtists.AutoSize = true;
            this.cBoxContArtists.Location = new System.Drawing.Point(16, 91);
            this.cBoxContArtists.Name = "cBoxContArtists";
            this.cBoxContArtists.Size = new System.Drawing.Size(115, 17);
            this.cBoxContArtists.TabIndex = 9;
            this.cBoxContArtists.Text = "Contributing artists:";
            this.cBoxContArtists.UseVisualStyleBackColor = true;
            // 
            // cBoxAlbum
            // 
            this.cBoxAlbum.AutoSize = true;
            this.cBoxAlbum.Location = new System.Drawing.Point(16, 117);
            this.cBoxAlbum.Name = "cBoxAlbum";
            this.cBoxAlbum.Size = new System.Drawing.Size(58, 17);
            this.cBoxAlbum.TabIndex = 10;
            this.cBoxAlbum.Text = "Album:";
            this.cBoxAlbum.UseVisualStyleBackColor = true;
            // 
            // cBoxYear
            // 
            this.cBoxYear.AutoSize = true;
            this.cBoxYear.Location = new System.Drawing.Point(16, 143);
            this.cBoxYear.Name = "cBoxYear";
            this.cBoxYear.Size = new System.Drawing.Size(51, 17);
            this.cBoxYear.TabIndex = 11;
            this.cBoxYear.Text = "Year:";
            this.cBoxYear.UseVisualStyleBackColor = true;
            // 
            // cBoxTrackNo
            // 
            this.cBoxTrackNo.AutoSize = true;
            this.cBoxTrackNo.Location = new System.Drawing.Point(16, 169);
            this.cBoxTrackNo.Name = "cBoxTrackNo";
            this.cBoxTrackNo.Size = new System.Drawing.Size(77, 17);
            this.cBoxTrackNo.TabIndex = 12;
            this.cBoxTrackNo.Text = "Track No.:";
            this.cBoxTrackNo.UseVisualStyleBackColor = true;
            // 
            // cBoxGenre
            // 
            this.cBoxGenre.AutoSize = true;
            this.cBoxGenre.Location = new System.Drawing.Point(16, 195);
            this.cBoxGenre.Name = "cBoxGenre";
            this.cBoxGenre.Size = new System.Drawing.Size(58, 17);
            this.cBoxGenre.TabIndex = 13;
            this.cBoxGenre.Text = "Genre:";
            this.cBoxGenre.UseVisualStyleBackColor = true;
            // 
            // cBoxSelectAll
            // 
            this.cBoxSelectAll.AutoSize = true;
            this.cBoxSelectAll.Location = new System.Drawing.Point(16, 224);
            this.cBoxSelectAll.Name = "cBoxSelectAll";
            this.cBoxSelectAll.Size = new System.Drawing.Size(70, 17);
            this.cBoxSelectAll.TabIndex = 14;
            this.cBoxSelectAll.Text = "Select All";
            this.cBoxSelectAll.UseVisualStyleBackColor = true;
            this.cBoxSelectAll.CheckedChanged += new System.EventHandler(this.cBoxSelectAll_CheckedChanged);
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.Items.AddRange(new object[] {
            "None",
            "1: #. Title - Artist",
            "2: #. Artist - Title",
            "3: Artist - Title",
            "4: #. Title",
            "5: Title - Artist"});
            this.comboBoxFormat.Location = new System.Drawing.Point(549, 220);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(92, 21);
            this.comboBoxFormat.TabIndex = 21;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(501, 225);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(42, 13);
            this.lblFormat.TabIndex = 22;
            this.lblFormat.Text = "Format:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(647, 220);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 23;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FormMP3Boss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 253);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.comboBoxFormat);
            this.Controls.Add(this.cBoxSelectAll);
            this.Controls.Add(this.cBoxGenre);
            this.Controls.Add(this.cBoxTrackNo);
            this.Controls.Add(this.cBoxYear);
            this.Controls.Add(this.cBoxAlbum);
            this.Controls.Add(this.cBoxContArtists);
            this.Controls.Add(this.cBoxAlbumArtist);
            this.Controls.Add(this.cBoxTitle);
            this.Controls.Add(this.listViewMP3s);
            this.Controls.Add(this.cBoxApplyToAll);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.tBoxGenre);
            this.Controls.Add(this.tBoxTrackNo);
            this.Controls.Add(this.tBoxYear);
            this.Controls.Add(this.tBoxAlbum);
            this.Controls.Add(this.tBoxAlbumArtist);
            this.Controls.Add(this.tBoxContArtists);
            this.Controls.Add(this.tBoxTitle);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(914, 291);
            this.MinimumSize = new System.Drawing.Size(914, 291);
            this.Name = "FormMP3Boss";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MP3Boss";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenuOpen;
        internal System.Windows.Forms.FolderBrowserDialog fBDialogLoadMP3s;
        internal System.Windows.Forms.TextBox tBoxTitle;
        internal System.Windows.Forms.TextBox tBoxContArtists;
        internal System.Windows.Forms.TextBox tBoxAlbumArtist;
        internal System.Windows.Forms.TextBox tBoxAlbum;
        internal System.Windows.Forms.TextBox tBoxYear;
        internal System.Windows.Forms.TextBox tBoxTrackNo;
        internal System.Windows.Forms.TextBox tBoxGenre;
        internal System.Windows.Forms.Button btnReset;
        internal System.Windows.Forms.CheckBox cBoxApplyToAll;
        internal System.Windows.Forms.ListView listViewMP3s;
        internal System.Windows.Forms.CheckBox cBoxTitle;
        internal System.Windows.Forms.CheckBox cBoxAlbumArtist;
        internal System.Windows.Forms.CheckBox cBoxContArtists;
        internal System.Windows.Forms.CheckBox cBoxAlbum;
        internal System.Windows.Forms.CheckBox cBoxYear;
        internal System.Windows.Forms.CheckBox cBoxTrackNo;
        internal System.Windows.Forms.CheckBox cBoxGenre;
        internal System.Windows.Forms.CheckBox cBoxSelectAll;
        internal System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolStripMenuItem fileMenuOpenDeep;
    }
}

