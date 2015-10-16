namespace MP3Boss
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReset = new System.Windows.Forms.Button();
            this.cBoxApplyToAll = new System.Windows.Forms.CheckBox();
            this.listViewAudioFiles = new System.Windows.Forms.ListView();
            this.cBoxTitle = new System.Windows.Forms.CheckBox();
            this.cBoxAlbumArtist = new System.Windows.Forms.CheckBox();
            this.cBoxContArtists = new System.Windows.Forms.CheckBox();
            this.cBoxAlbum = new System.Windows.Forms.CheckBox();
            this.cBoxYear = new System.Windows.Forms.CheckBox();
            this.cBoxTrackNo = new System.Windows.Forms.CheckBox();
            this.cBoxGenres = new System.Windows.Forms.CheckBox();
            this.cBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cBoxAutoNext = new System.Windows.Forms.CheckBox();
            this.btnSearchReplace = new System.Windows.Forms.Button();
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnCheckFormMsg = new System.Windows.Forms.Button();
            this.comboBoxTitle = new System.Windows.Forms.ComboBox();
            this.comboBoxAlbum = new System.Windows.Forms.ComboBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.comboBoxTrackNo = new System.Windows.Forms.ComboBox();
            this.comboBoxGenre = new System.Windows.Forms.ComboBox();
            this.comboBoxContArtists = new System.Windows.Forms.ComboBox();
            this.comboBoxAlbumArtist = new System.Windows.Forms.ComboBox();
            this.btnSuggest = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(807, 213);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(333, 220);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.helpMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(904, 24);
            this.menuStrip.TabIndex = 2;
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetAllMenuItem,
            this.closeMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // resetAllMenuItem
            // 
            this.resetAllMenuItem.Name = "resetAllMenuItem";
            this.resetAllMenuItem.Size = new System.Drawing.Size(128, 22);
            this.resetAllMenuItem.Text = "Reset All...";
            this.resetAllMenuItem.Click += new System.EventHandler(this.resetAllMenuItem_Click);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(128, 22);
            this.closeMenuItem.Text = "Close...";
            this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpMenuItem.Text = "Help";
            // 
            // howToMenuItem
            // 
            this.howToMenuItem.Name = "howToMenuItem";
            this.howToMenuItem.Size = new System.Drawing.Size(122, 22);
            this.howToMenuItem.Text = "How to...";
            this.howToMenuItem.Click += new System.EventHandler(this.howToMenuItem_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(252, 220);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cBoxApplyToAll
            // 
            this.cBoxApplyToAll.AutoSize = true;
            this.cBoxApplyToAll.Location = new System.Drawing.Point(728, 208);
            this.cBoxApplyToAll.Name = "cBoxApplyToAll";
            this.cBoxApplyToAll.Size = new System.Drawing.Size(78, 17);
            this.cBoxApplyToAll.TabIndex = 20;
            this.cBoxApplyToAll.Text = "Apply to All";
            this.cBoxApplyToAll.UseVisualStyleBackColor = true;
            this.cBoxApplyToAll.CheckedChanged += new System.EventHandler(this.cBoxApplyToAll_CheckedChanged);
            // 
            // listViewAudioFiles
            // 
            this.listViewAudioFiles.AllowDrop = true;
            this.listViewAudioFiles.Location = new System.Drawing.Point(504, 35);
            this.listViewAudioFiles.MaximumSize = new System.Drawing.Size(500, 600);
            this.listViewAudioFiles.MinimumSize = new System.Drawing.Size(382, 100);
            this.listViewAudioFiles.Name = "listViewAudioFiles";
            this.listViewAudioFiles.Size = new System.Drawing.Size(382, 167);
            this.listViewAudioFiles.TabIndex = 23;
            this.listViewAudioFiles.UseCompatibleStateImageBehavior = false;
            this.listViewAudioFiles.View = System.Windows.Forms.View.List;
            this.listViewAudioFiles.SelectedIndexChanged += new System.EventHandler(this.listViewAudioFiles_SelectedIndexChanged);
            this.listViewAudioFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewAudioFiles_DragDrop);
            this.listViewAudioFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewAudioFiles_DragEnter);
            // 
            // cBoxTitle
            // 
            this.cBoxTitle.AutoSize = true;
            this.cBoxTitle.Location = new System.Drawing.Point(16, 37);
            this.cBoxTitle.Name = "cBoxTitle";
            this.cBoxTitle.Size = new System.Drawing.Size(49, 17);
            this.cBoxTitle.TabIndex = 1;
            this.cBoxTitle.Text = "Title:";
            this.cBoxTitle.UseVisualStyleBackColor = true;
            // 
            // cBoxAlbumArtist
            // 
            this.cBoxAlbumArtist.AutoSize = true;
            this.cBoxAlbumArtist.Location = new System.Drawing.Point(16, 65);
            this.cBoxAlbumArtist.Name = "cBoxAlbumArtist";
            this.cBoxAlbumArtist.Size = new System.Drawing.Size(83, 17);
            this.cBoxAlbumArtist.TabIndex = 3;
            this.cBoxAlbumArtist.Text = "Album artist:";
            this.cBoxAlbumArtist.UseVisualStyleBackColor = true;
            // 
            // cBoxContArtists
            // 
            this.cBoxContArtists.AutoSize = true;
            this.cBoxContArtists.Location = new System.Drawing.Point(16, 91);
            this.cBoxContArtists.Name = "cBoxContArtists";
            this.cBoxContArtists.Size = new System.Drawing.Size(121, 17);
            this.cBoxContArtists.TabIndex = 5;
            this.cBoxContArtists.Text = "Contributing artist(s):";
            this.cBoxContArtists.UseVisualStyleBackColor = true;
            // 
            // cBoxAlbum
            // 
            this.cBoxAlbum.AutoSize = true;
            this.cBoxAlbum.Location = new System.Drawing.Point(16, 117);
            this.cBoxAlbum.Name = "cBoxAlbum";
            this.cBoxAlbum.Size = new System.Drawing.Size(58, 17);
            this.cBoxAlbum.TabIndex = 7;
            this.cBoxAlbum.Text = "Album:";
            this.cBoxAlbum.UseVisualStyleBackColor = true;
            // 
            // cBoxYear
            // 
            this.cBoxYear.AutoSize = true;
            this.cBoxYear.Location = new System.Drawing.Point(16, 143);
            this.cBoxYear.Name = "cBoxYear";
            this.cBoxYear.Size = new System.Drawing.Size(51, 17);
            this.cBoxYear.TabIndex = 9;
            this.cBoxYear.Text = "Year:";
            this.cBoxYear.UseVisualStyleBackColor = true;
            // 
            // cBoxTrackNo
            // 
            this.cBoxTrackNo.AutoSize = true;
            this.cBoxTrackNo.Location = new System.Drawing.Point(16, 169);
            this.cBoxTrackNo.Name = "cBoxTrackNo";
            this.cBoxTrackNo.Size = new System.Drawing.Size(77, 17);
            this.cBoxTrackNo.TabIndex = 11;
            this.cBoxTrackNo.Text = "Track No.:";
            this.cBoxTrackNo.UseVisualStyleBackColor = true;
            // 
            // cBoxGenres
            // 
            this.cBoxGenres.AutoSize = true;
            this.cBoxGenres.Location = new System.Drawing.Point(16, 195);
            this.cBoxGenres.Name = "cBoxGenres";
            this.cBoxGenres.Size = new System.Drawing.Size(69, 17);
            this.cBoxGenres.TabIndex = 13;
            this.cBoxGenres.Text = "Genre(s):";
            this.cBoxGenres.UseVisualStyleBackColor = true;
            // 
            // cBoxSelectAll
            // 
            this.cBoxSelectAll.AutoSize = true;
            this.cBoxSelectAll.Location = new System.Drawing.Point(16, 224);
            this.cBoxSelectAll.Name = "cBoxSelectAll";
            this.cBoxSelectAll.Size = new System.Drawing.Size(70, 17);
            this.cBoxSelectAll.TabIndex = 15;
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
            this.comboBoxFormat.Location = new System.Drawing.Point(630, 215);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(92, 21);
            this.comboBoxFormat.TabIndex = 18;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(582, 218);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(42, 13);
            this.lblFormat.TabIndex = 22;
            this.lblFormat.Text = "Format:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(504, 227);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblStatus.Location = new System.Drawing.Point(148, 225);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "Status:";
            // 
            // cBoxAutoNext
            // 
            this.cBoxAutoNext.AutoSize = true;
            this.cBoxAutoNext.Location = new System.Drawing.Point(728, 231);
            this.cBoxAutoNext.Name = "cBoxAutoNext";
            this.cBoxAutoNext.Size = new System.Drawing.Size(73, 17);
            this.cBoxAutoNext.TabIndex = 21;
            this.cBoxAutoNext.Text = "Auto Next";
            this.cBoxAutoNext.UseVisualStyleBackColor = true;
            // 
            // btnSearchReplace
            // 
            this.btnSearchReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchReplace.Location = new System.Drawing.Point(888, 34);
            this.btnSearchReplace.Name = "btnSearchReplace";
            this.btnSearchReplace.Size = new System.Drawing.Size(14, 33);
            this.btnSearchReplace.TabIndex = 25;
            this.btnSearchReplace.Text = "S";
            this.btnSearchReplace.UseVisualStyleBackColor = true;
            this.btnSearchReplace.Click += new System.EventHandler(this.btnSearchReplace_Click);
            // 
            // lblItemsCount
            // 
            this.lblItemsCount.AutoSize = true;
            this.lblItemsCount.ForeColor = System.Drawing.Color.Green;
            this.lblItemsCount.Location = new System.Drawing.Point(504, 208);
            this.lblItemsCount.Name = "lblItemsCount";
            this.lblItemsCount.Size = new System.Drawing.Size(38, 13);
            this.lblItemsCount.TabIndex = 26;
            this.lblItemsCount.Text = "Count:";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblFileName.Location = new System.Drawing.Point(148, 9);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(63, 13);
            this.lblFileName.TabIndex = 27;
            this.lblFileName.Text = "Current File:";
            // 
            // btnCheckFormMsg
            // 
            this.btnCheckFormMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckFormMsg.Location = new System.Drawing.Point(888, 73);
            this.btnCheckFormMsg.Name = "btnCheckFormMsg";
            this.btnCheckFormMsg.Size = new System.Drawing.Size(14, 33);
            this.btnCheckFormMsg.TabIndex = 28;
            this.btnCheckFormMsg.Text = "C";
            this.btnCheckFormMsg.UseVisualStyleBackColor = true;
            this.btnCheckFormMsg.Click += new System.EventHandler(this.btnCheckFormMsg_Click);
            // 
            // comboBoxTitle
            // 
            this.comboBoxTitle.FormattingEnabled = true;
            this.comboBoxTitle.Location = new System.Drawing.Point(151, 35);
            this.comboBoxTitle.Name = "comboBoxTitle";
            this.comboBoxTitle.Size = new System.Drawing.Size(347, 21);
            this.comboBoxTitle.TabIndex = 29;
            // 
            // comboBoxAlbum
            // 
            this.comboBoxAlbum.FormattingEnabled = true;
            this.comboBoxAlbum.Location = new System.Drawing.Point(151, 115);
            this.comboBoxAlbum.Name = "comboBoxAlbum";
            this.comboBoxAlbum.Size = new System.Drawing.Size(347, 21);
            this.comboBoxAlbum.TabIndex = 30;
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(151, 141);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(347, 21);
            this.comboBoxYear.TabIndex = 31;
            // 
            // comboBoxTrackNo
            // 
            this.comboBoxTrackNo.FormattingEnabled = true;
            this.comboBoxTrackNo.Location = new System.Drawing.Point(151, 167);
            this.comboBoxTrackNo.Name = "comboBoxTrackNo";
            this.comboBoxTrackNo.Size = new System.Drawing.Size(347, 21);
            this.comboBoxTrackNo.TabIndex = 32;
            // 
            // comboBoxGenre
            // 
            this.comboBoxGenre.FormattingEnabled = true;
            this.comboBoxGenre.Location = new System.Drawing.Point(151, 193);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(347, 21);
            this.comboBoxGenre.TabIndex = 33;
            // 
            // comboBoxContArtists
            // 
            this.comboBoxContArtists.FormattingEnabled = true;
            this.comboBoxContArtists.Location = new System.Drawing.Point(151, 89);
            this.comboBoxContArtists.Name = "comboBoxContArtists";
            this.comboBoxContArtists.Size = new System.Drawing.Size(347, 21);
            this.comboBoxContArtists.TabIndex = 34;
            // 
            // comboBoxAlbumArtist
            // 
            this.comboBoxAlbumArtist.FormattingEnabled = true;
            this.comboBoxAlbumArtist.Location = new System.Drawing.Point(151, 63);
            this.comboBoxAlbumArtist.Name = "comboBoxAlbumArtist";
            this.comboBoxAlbumArtist.Size = new System.Drawing.Size(347, 21);
            this.comboBoxAlbumArtist.TabIndex = 35;
            // 
            // btnSuggest
            // 
            this.btnSuggest.Location = new System.Drawing.Point(423, 220);
            this.btnSuggest.Name = "btnSuggest";
            this.btnSuggest.Size = new System.Drawing.Size(75, 23);
            this.btnSuggest.TabIndex = 36;
            this.btnSuggest.Text = "Suggest...";
            this.btnSuggest.UseVisualStyleBackColor = true;
            this.btnSuggest.Click += new System.EventHandler(this.btnSuggest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 253);
            this.Controls.Add(this.btnSuggest);
            this.Controls.Add(this.comboBoxAlbumArtist);
            this.Controls.Add(this.comboBoxContArtists);
            this.Controls.Add(this.comboBoxGenre);
            this.Controls.Add(this.comboBoxTrackNo);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.comboBoxAlbum);
            this.Controls.Add(this.comboBoxTitle);
            this.Controls.Add(this.btnCheckFormMsg);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lblItemsCount);
            this.Controls.Add(this.btnSearchReplace);
            this.Controls.Add(this.cBoxAutoNext);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.comboBoxFormat);
            this.Controls.Add(this.cBoxSelectAll);
            this.Controls.Add(this.cBoxGenres);
            this.Controls.Add(this.cBoxTrackNo);
            this.Controls.Add(this.cBoxYear);
            this.Controls.Add(this.cBoxAlbum);
            this.Controls.Add(this.cBoxContArtists);
            this.Controls.Add(this.cBoxAlbumArtist);
            this.Controls.Add(this.cBoxTitle);
            this.Controls.Add(this.listViewAudioFiles);
            this.Controls.Add(this.cBoxApplyToAll);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(920, 291);
            this.MinimumSize = new System.Drawing.Size(920, 291);
            this.Name = "MainForm";
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
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox cBoxApplyToAll;
        internal System.Windows.Forms.ListView listViewAudioFiles;
        private System.Windows.Forms.CheckBox cBoxTitle;
        private System.Windows.Forms.CheckBox cBoxAlbumArtist;
        private System.Windows.Forms.CheckBox cBoxContArtists;
        private System.Windows.Forms.CheckBox cBoxAlbum;
        private System.Windows.Forms.CheckBox cBoxYear;
        private System.Windows.Forms.CheckBox cBoxTrackNo;
        private System.Windows.Forms.CheckBox cBoxGenres;
        private System.Windows.Forms.CheckBox cBoxSelectAll;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.Label lblFormat;
        internal System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox cBoxAutoNext;
        private System.Windows.Forms.Button btnSearchReplace;
        private System.Windows.Forms.Label lblItemsCount;
        private System.Windows.Forms.ToolStripMenuItem resetAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnCheckFormMsg;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToMenuItem;
        private System.Windows.Forms.ComboBox comboBoxTitle;
        private System.Windows.Forms.ComboBox comboBoxAlbum;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.ComboBox comboBoxTrackNo;
        private System.Windows.Forms.ComboBox comboBoxGenre;
        private System.Windows.Forms.ComboBox comboBoxContArtists;
        private System.Windows.Forms.ComboBox comboBoxAlbumArtist;
        private System.Windows.Forms.Button btnSuggest;
    }
}

