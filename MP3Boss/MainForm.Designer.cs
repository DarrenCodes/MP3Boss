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
            tBoxTitle = new System.Windows.Forms.TextBox();
            tBoxContArtists = new System.Windows.Forms.TextBox();
            tBoxAlbumArtist = new System.Windows.Forms.TextBox();
            tBoxAlbum = new System.Windows.Forms.TextBox();
            tBoxYear = new System.Windows.Forms.TextBox();
            tBoxTrackNo = new System.Windows.Forms.TextBox();
            tBoxGenre = new System.Windows.Forms.TextBox();
            btnReset = new System.Windows.Forms.Button();
            cBoxApplyToAll = new System.Windows.Forms.CheckBox();
            this.fBDialogLoadMP3s = new System.Windows.Forms.FolderBrowserDialog();
            listViewMP3s = new System.Windows.Forms.ListView();
            cBoxTitle = new System.Windows.Forms.CheckBox();
            cBoxAlbumArtist = new System.Windows.Forms.CheckBox();
            cBoxContArtists = new System.Windows.Forms.CheckBox();
            cBoxAlbum = new System.Windows.Forms.CheckBox();
            cBoxYear = new System.Windows.Forms.CheckBox();
            cBoxTrackNo = new System.Windows.Forms.CheckBox();
            cBoxGenre = new System.Windows.Forms.CheckBox();
            cBoxSelectAll = new System.Windows.Forms.CheckBox();
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
            this.btnClear.Location = new System.Drawing.Point(423, 220);
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
            this.fileMenuOpen});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // fileMenuOpen
            // 
            this.fileMenuOpen.Name = "fileMenuOpen";
            this.fileMenuOpen.Size = new System.Drawing.Size(112, 22);
            this.fileMenuOpen.Text = "Open...";
            this.fileMenuOpen.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // tBoxTitle
            // 
            tBoxTitle.Location = new System.Drawing.Point(151, 34);
            tBoxTitle.Name = "tBoxTitle";
            tBoxTitle.Size = new System.Drawing.Size(347, 20);
            tBoxTitle.TabIndex = 0;
            // 
            // tBoxContArtists
            // 
            tBoxContArtists.Location = new System.Drawing.Point(151, 88);
            tBoxContArtists.Name = "tBoxContArtists";
            tBoxContArtists.Size = new System.Drawing.Size(347, 20);
            tBoxContArtists.TabIndex = 2;
            // 
            // tBoxAlbumArtist
            // 
            tBoxAlbumArtist.Location = new System.Drawing.Point(151, 62);
            tBoxAlbumArtist.Name = "tBoxAlbumArtist";
            tBoxAlbumArtist.Size = new System.Drawing.Size(347, 20);
            tBoxAlbumArtist.TabIndex = 1;
            // 
            // tBoxAlbum
            // 
            tBoxAlbum.Location = new System.Drawing.Point(151, 114);
            tBoxAlbum.Name = "tBoxAlbum";
            tBoxAlbum.Size = new System.Drawing.Size(347, 20);
            tBoxAlbum.TabIndex = 3;
            // 
            // tBoxYear
            // 
            tBoxYear.Location = new System.Drawing.Point(151, 140);
            tBoxYear.Name = "tBoxYear";
            tBoxYear.Size = new System.Drawing.Size(347, 20);
            tBoxYear.TabIndex = 4;
            // 
            // tBoxTrackNo
            // 
            tBoxTrackNo.Location = new System.Drawing.Point(151, 166);
            tBoxTrackNo.Name = "tBoxTrackNo";
            tBoxTrackNo.Size = new System.Drawing.Size(347, 20);
            tBoxTrackNo.TabIndex = 5;
            // 
            // tBoxGenre
            // 
            tBoxGenre.Location = new System.Drawing.Point(151, 192);
            tBoxGenre.Name = "tBoxGenre";
            tBoxGenre.Size = new System.Drawing.Size(347, 20);
            tBoxGenre.TabIndex = 6;
            // 
            // btnReset
            // 
            btnReset.Location = new System.Drawing.Point(342, 220);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(75, 23);
            btnReset.TabIndex = 15;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cBoxApplyToAll
            // 
            cBoxApplyToAll.AutoSize = true;
            cBoxApplyToAll.Location = new System.Drawing.Point(728, 224);
            cBoxApplyToAll.Name = "cBoxApplyToAll";
            cBoxApplyToAll.Size = new System.Drawing.Size(77, 17);
            cBoxApplyToAll.TabIndex = 17;
            cBoxApplyToAll.Text = "Apply to all";
            cBoxApplyToAll.UseVisualStyleBackColor = true;
            // 
            // listViewMP3s
            // 
            listViewMP3s.Location = new System.Drawing.Point(504, 35);
            listViewMP3s.MaximumSize = new System.Drawing.Size(382, 177);
            listViewMP3s.MinimumSize = new System.Drawing.Size(382, 177);
            listViewMP3s.Name = "listViewMP3s";
            listViewMP3s.Size = new System.Drawing.Size(382, 177);
            listViewMP3s.Sorting = System.Windows.Forms.SortOrder.Ascending;
            listViewMP3s.TabIndex = 19;
            listViewMP3s.UseCompatibleStateImageBehavior = false;
            listViewMP3s.View = System.Windows.Forms.View.List;
            listViewMP3s.SelectedIndexChanged += new System.EventHandler(this.listViewMP3s_SelectedIndexChanged);
            // 
            // cBoxTitle
            // 
            cBoxTitle.AutoSize = true;
            cBoxTitle.Location = new System.Drawing.Point(16, 37);
            cBoxTitle.Name = "cBoxTitle";
            cBoxTitle.Size = new System.Drawing.Size(49, 17);
            cBoxTitle.TabIndex = 7;
            cBoxTitle.Text = "Title:";
            cBoxTitle.UseVisualStyleBackColor = true;
            // 
            // cBoxAlbumArtist
            // 
            cBoxAlbumArtist.AutoSize = true;
            cBoxAlbumArtist.Location = new System.Drawing.Point(16, 65);
            cBoxAlbumArtist.Name = "cBoxAlbumArtist";
            cBoxAlbumArtist.Size = new System.Drawing.Size(83, 17);
            cBoxAlbumArtist.TabIndex = 8;
            cBoxAlbumArtist.Text = "Album artist:";
            cBoxAlbumArtist.UseVisualStyleBackColor = true;
            // 
            // cBoxContArtists
            // 
            cBoxContArtists.AutoSize = true;
            cBoxContArtists.Location = new System.Drawing.Point(16, 91);
            cBoxContArtists.Name = "cBoxContArtists";
            cBoxContArtists.Size = new System.Drawing.Size(115, 17);
            cBoxContArtists.TabIndex = 9;
            cBoxContArtists.Text = "Contributing artists:";
            cBoxContArtists.UseVisualStyleBackColor = true;
            // 
            // cBoxAlbum
            // 
            cBoxAlbum.AutoSize = true;
            cBoxAlbum.Location = new System.Drawing.Point(16, 117);
            cBoxAlbum.Name = "cBoxAlbum";
            cBoxAlbum.Size = new System.Drawing.Size(58, 17);
            cBoxAlbum.TabIndex = 10;
            cBoxAlbum.Text = "Album:";
            cBoxAlbum.UseVisualStyleBackColor = true;
            // 
            // cBoxYear
            // 
            cBoxYear.AutoSize = true;
            cBoxYear.Location = new System.Drawing.Point(16, 143);
            cBoxYear.Name = "cBoxYear";
            cBoxYear.Size = new System.Drawing.Size(51, 17);
            cBoxYear.TabIndex = 11;
            cBoxYear.Text = "Year:";
            cBoxYear.UseVisualStyleBackColor = true;
            // 
            // cBoxTrackNo
            // 
            cBoxTrackNo.AutoSize = true;
            cBoxTrackNo.Location = new System.Drawing.Point(16, 169);
            cBoxTrackNo.Name = "cBoxTrackNo";
            cBoxTrackNo.Size = new System.Drawing.Size(77, 17);
            cBoxTrackNo.TabIndex = 12;
            cBoxTrackNo.Text = "Track No.:";
            cBoxTrackNo.UseVisualStyleBackColor = true;
            // 
            // cBoxGenre
            // 
            cBoxGenre.AutoSize = true;
            cBoxGenre.Location = new System.Drawing.Point(16, 195);
            cBoxGenre.Name = "cBoxGenre";
            cBoxGenre.Size = new System.Drawing.Size(58, 17);
            cBoxGenre.TabIndex = 13;
            cBoxGenre.Text = "Genre:";
            cBoxGenre.UseVisualStyleBackColor = true;
            // 
            // cBoxSelectAll
            // 
            cBoxSelectAll.AutoSize = true;
            cBoxSelectAll.Location = new System.Drawing.Point(16, 224);
            cBoxSelectAll.Name = "cBoxSelectAll";
            cBoxSelectAll.Size = new System.Drawing.Size(70, 17);
            cBoxSelectAll.TabIndex = 14;
            cBoxSelectAll.Text = "Select All";
            cBoxSelectAll.UseVisualStyleBackColor = true;
            cBoxSelectAll.CheckedChanged += new System.EventHandler(this.cBoxSelectAll_CheckedChanged);
            // 
            // formMP3Boss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 253);
            this.Controls.Add(cBoxSelectAll);
            this.Controls.Add(cBoxGenre);
            this.Controls.Add(cBoxTrackNo);
            this.Controls.Add(cBoxYear);
            this.Controls.Add(cBoxAlbum);
            this.Controls.Add(cBoxContArtists);
            this.Controls.Add(cBoxAlbumArtist);
            this.Controls.Add(cBoxTitle);
            this.Controls.Add(listViewMP3s);
            this.Controls.Add(cBoxApplyToAll);
            this.Controls.Add(btnReset);
            this.Controls.Add(tBoxGenre);
            this.Controls.Add(tBoxTrackNo);
            this.Controls.Add(tBoxYear);
            this.Controls.Add(tBoxAlbum);
            this.Controls.Add(tBoxAlbumArtist);
            this.Controls.Add(tBoxContArtists);
            this.Controls.Add(tBoxTitle);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(914, 291);
            this.MinimumSize = new System.Drawing.Size(914, 291);
            this.Name = "formMP3Boss";
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
        public static System.Windows.Forms.TextBox tBoxTitle;
        public static System.Windows.Forms.TextBox tBoxContArtists;
        public static System.Windows.Forms.TextBox tBoxAlbumArtist;
        public static System.Windows.Forms.TextBox tBoxAlbum;
        public static System.Windows.Forms.TextBox tBoxYear;
        public static System.Windows.Forms.TextBox tBoxTrackNo;
        public static System.Windows.Forms.TextBox tBoxGenre;
        public static System.Windows.Forms.Button btnReset;
        public static System.Windows.Forms.CheckBox cBoxApplyToAll;
        private System.Windows.Forms.FolderBrowserDialog fBDialogLoadMP3s;
        public static System.Windows.Forms.ListView listViewMP3s;
        public static System.Windows.Forms.CheckBox cBoxTitle;
        public static System.Windows.Forms.CheckBox cBoxAlbumArtist;
        public static System.Windows.Forms.CheckBox cBoxContArtists;
        public static System.Windows.Forms.CheckBox cBoxAlbum;
        public static System.Windows.Forms.CheckBox cBoxYear;
        public static System.Windows.Forms.CheckBox cBoxTrackNo;
        internal static System.Windows.Forms.CheckBox cBoxGenre;
        internal static System.Windows.Forms.CheckBox cBoxSelectAll;
    }
}

