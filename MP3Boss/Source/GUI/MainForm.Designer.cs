namespace MP3Boss.Source.GUI
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
            this.btnSuggest = new System.Windows.Forms.Button();
            this.comboBoxGenre = new System.Windows.Forms.ComboBox();
            this.cBoxGenres = new System.Windows.Forms.CheckBox();
            this.comboBoxTrackNo = new System.Windows.Forms.ComboBox();
            this.cBoxTrackNo = new System.Windows.Forms.CheckBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.cBoxYear = new System.Windows.Forms.CheckBox();
            this.comboBoxAlbum = new System.Windows.Forms.ComboBox();
            this.cBoxAlbum = new System.Windows.Forms.CheckBox();
            this.comboBoxContArtists = new System.Windows.Forms.ComboBox();
            this.cBoxContArtists = new System.Windows.Forms.CheckBox();
            this.comboBoxAlbumArtist = new System.Windows.Forms.ComboBox();
            this.cBoxAlbumArtist = new System.Windows.Forms.CheckBox();
            this.comboBoxTitle = new System.Windows.Forms.ComboBox();
            this.cBoxTitle = new System.Windows.Forms.CheckBox();
            this.tagEditAndDisplayTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.resetAndSuggestTabelPanel = new System.Windows.Forms.TableLayoutPanel();
            this.saveAndFormatTabelPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.extraButtonsPanel = new System.Windows.Forms.Panel();
            this.fileSpecificDisplayTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.tagArtPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.tagEditAndDisplayTablePanel.SuspendLayout();
            this.resetAndSuggestTabelPanel.SuspendLayout();
            this.saveAndFormatTabelPanel.SuspendLayout();
            this.mainTablePanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.extraButtonsPanel.SuspendLayout();
            this.fileSpecificDisplayTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagArtPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(372, 3);
            this.btnSave.MinimumSize = new System.Drawing.Size(76, 22);
            this.btnSave.Name = "btnSave";
            this.saveAndFormatTabelPanel.SetRowSpan(this.btnSave, 2);
            this.btnSave.Size = new System.Drawing.Size(103, 42);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClear.Location = new System.Drawing.Point(288, 3);
            this.btnClear.MinimumSize = new System.Drawing.Size(0, 22);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(66, 22);
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
            this.menuStrip.Size = new System.Drawing.Size(1089, 24);
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
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReset.Location = new System.Drawing.Point(216, 3);
            this.btnReset.MinimumSize = new System.Drawing.Size(0, 22);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(66, 22);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cBoxApplyToAll
            // 
            this.cBoxApplyToAll.AutoSize = true;
            this.cBoxApplyToAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cBoxApplyToAll.Location = new System.Drawing.Point(286, 3);
            this.cBoxApplyToAll.MinimumSize = new System.Drawing.Size(76, 22);
            this.cBoxApplyToAll.Name = "cBoxApplyToAll";
            this.cBoxApplyToAll.Size = new System.Drawing.Size(80, 22);
            this.cBoxApplyToAll.TabIndex = 20;
            this.cBoxApplyToAll.Text = "Apply to All";
            this.cBoxApplyToAll.UseVisualStyleBackColor = true;
            this.cBoxApplyToAll.CheckedChanged += new System.EventHandler(this.cBoxApplyToAll_CheckedChanged);
            // 
            // listViewAudioFiles
            // 
            this.listViewAudioFiles.AllowDrop = true;
            this.listViewAudioFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAudioFiles.Location = new System.Drawing.Point(3, 3);
            this.listViewAudioFiles.Name = "listViewAudioFiles";
            this.listViewAudioFiles.Size = new System.Drawing.Size(616, 445);
            this.listViewAudioFiles.TabIndex = 23;
            this.listViewAudioFiles.UseCompatibleStateImageBehavior = false;
            this.listViewAudioFiles.View = System.Windows.Forms.View.List;
            this.listViewAudioFiles.SelectedIndexChanged += new System.EventHandler(this.listViewAudioFiles_SelectedIndexChanged);
            this.listViewAudioFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewAudioFiles_DragDrop);
            this.listViewAudioFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewAudioFiles_DragEnter);
            // 
            // cBoxSelectAll
            // 
            this.cBoxSelectAll.AutoSize = true;
            this.cBoxSelectAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cBoxSelectAll.Location = new System.Drawing.Point(3, 5);
            this.cBoxSelectAll.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.cBoxSelectAll.Name = "cBoxSelectAll";
            this.cBoxSelectAll.Size = new System.Drawing.Size(79, 17);
            this.cBoxSelectAll.TabIndex = 15;
            this.cBoxSelectAll.Text = "Select All";
            this.cBoxSelectAll.UseVisualStyleBackColor = true;
            this.cBoxSelectAll.CheckedChanged += new System.EventHandler(this.cBoxSelectAll_CheckedChanged);
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.Items.AddRange(new object[] {
            "None",
            "1: #. Title - Artist",
            "2: #. Artist - Title",
            "3: Artist - Title",
            "4: #. Title",
            "5: Title - Artist"});
            this.comboBoxFormat.Location = new System.Drawing.Point(167, 3);
            this.comboBoxFormat.MinimumSize = new System.Drawing.Size(76, 0);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(113, 21);
            this.comboBoxFormat.TabIndex = 18;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFormat.Location = new System.Drawing.Point(111, 3);
            this.lblFormat.Margin = new System.Windows.Forms.Padding(3);
            this.lblFormat.MinimumSize = new System.Drawing.Size(40, 21);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(50, 21);
            this.lblFormat.TabIndex = 22;
            this.lblFormat.Text = "Format:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRefresh.Location = new System.Drawing.Point(3, 27);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(0, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(102, 22);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblStatus.Location = new System.Drawing.Point(88, 6);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(122, 13);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "Status:";
            // 
            // cBoxAutoNext
            // 
            this.cBoxAutoNext.AutoSize = true;
            this.cBoxAutoNext.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cBoxAutoNext.Location = new System.Drawing.Point(286, 27);
            this.cBoxAutoNext.MinimumSize = new System.Drawing.Size(76, 22);
            this.cBoxAutoNext.Name = "cBoxAutoNext";
            this.cBoxAutoNext.Size = new System.Drawing.Size(80, 22);
            this.cBoxAutoNext.TabIndex = 21;
            this.cBoxAutoNext.Text = "Auto Next";
            this.cBoxAutoNext.UseVisualStyleBackColor = true;
            // 
            // btnSearchReplace
            // 
            this.btnSearchReplace.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSearchReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchReplace.Location = new System.Drawing.Point(0, 33);
            this.btnSearchReplace.Name = "btnSearchReplace";
            this.btnSearchReplace.Size = new System.Drawing.Size(16, 33);
            this.btnSearchReplace.TabIndex = 25;
            this.btnSearchReplace.Text = "S";
            this.btnSearchReplace.UseVisualStyleBackColor = true;
            this.btnSearchReplace.Click += new System.EventHandler(this.btnSearchReplace_Click);
            // 
            // lblItemsCount
            // 
            this.lblItemsCount.AutoSize = true;
            this.lblItemsCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblItemsCount.ForeColor = System.Drawing.Color.Green;
            this.lblItemsCount.Location = new System.Drawing.Point(3, 3);
            this.lblItemsCount.Margin = new System.Windows.Forms.Padding(3);
            this.lblItemsCount.MinimumSize = new System.Drawing.Size(76, 21);
            this.lblItemsCount.Name = "lblItemsCount";
            this.lblItemsCount.Size = new System.Drawing.Size(102, 21);
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
            this.btnCheckFormMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCheckFormMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckFormMsg.Location = new System.Drawing.Point(0, 0);
            this.btnCheckFormMsg.Name = "btnCheckFormMsg";
            this.btnCheckFormMsg.Size = new System.Drawing.Size(16, 33);
            this.btnCheckFormMsg.TabIndex = 28;
            this.btnCheckFormMsg.Text = "C";
            this.btnCheckFormMsg.UseVisualStyleBackColor = true;
            this.btnCheckFormMsg.Click += new System.EventHandler(this.btnCheckFormMsg_Click);
            // 
            // btnSuggest
            // 
            this.btnSuggest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSuggest.Location = new System.Drawing.Point(360, 3);
            this.btnSuggest.MinimumSize = new System.Drawing.Size(0, 22);
            this.btnSuggest.Name = "btnSuggest";
            this.btnSuggest.Size = new System.Drawing.Size(70, 22);
            this.btnSuggest.TabIndex = 36;
            this.btnSuggest.Text = "Suggest...";
            this.btnSuggest.UseVisualStyleBackColor = true;
            this.btnSuggest.Click += new System.EventHandler(this.btnSuggest_Click);
            this.btnSuggest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSuggest_Hold);
            this.btnSuggest.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnSuggest_Release);
            // 
            // comboBoxGenre
            // 
            this.comboBoxGenre.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxGenre.FormattingEnabled = true;
            this.comboBoxGenre.Location = new System.Drawing.Point(130, 181);
            this.comboBoxGenre.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(300, 21);
            this.comboBoxGenre.TabIndex = 33;
            // 
            // cBoxGenres
            // 
            this.cBoxGenres.AutoSize = true;
            this.cBoxGenres.Dock = System.Windows.Forms.DockStyle.Top;
            this.cBoxGenres.Location = new System.Drawing.Point(3, 184);
            this.cBoxGenres.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cBoxGenres.Name = "cBoxGenres";
            this.cBoxGenres.Size = new System.Drawing.Size(121, 17);
            this.cBoxGenres.TabIndex = 13;
            this.cBoxGenres.Text = "Genre(s):";
            this.cBoxGenres.UseVisualStyleBackColor = true;
            // 
            // comboBoxTrackNo
            // 
            this.comboBoxTrackNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxTrackNo.FormattingEnabled = true;
            this.comboBoxTrackNo.Location = new System.Drawing.Point(130, 152);
            this.comboBoxTrackNo.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.comboBoxTrackNo.Name = "comboBoxTrackNo";
            this.comboBoxTrackNo.Size = new System.Drawing.Size(300, 21);
            this.comboBoxTrackNo.TabIndex = 32;
            // 
            // cBoxTrackNo
            // 
            this.cBoxTrackNo.AutoSize = true;
            this.cBoxTrackNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.cBoxTrackNo.Location = new System.Drawing.Point(3, 155);
            this.cBoxTrackNo.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cBoxTrackNo.Name = "cBoxTrackNo";
            this.cBoxTrackNo.Size = new System.Drawing.Size(121, 16);
            this.cBoxTrackNo.TabIndex = 11;
            this.cBoxTrackNo.Text = "Track No.:";
            this.cBoxTrackNo.UseVisualStyleBackColor = true;
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(130, 123);
            this.comboBoxYear.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(300, 21);
            this.comboBoxYear.TabIndex = 31;
            // 
            // cBoxYear
            // 
            this.cBoxYear.AutoSize = true;
            this.cBoxYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.cBoxYear.Location = new System.Drawing.Point(3, 126);
            this.cBoxYear.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cBoxYear.Name = "cBoxYear";
            this.cBoxYear.Size = new System.Drawing.Size(121, 16);
            this.cBoxYear.TabIndex = 9;
            this.cBoxYear.Text = "Year:";
            this.cBoxYear.UseVisualStyleBackColor = true;
            // 
            // comboBoxAlbum
            // 
            this.comboBoxAlbum.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxAlbum.FormattingEnabled = true;
            this.comboBoxAlbum.Location = new System.Drawing.Point(130, 94);
            this.comboBoxAlbum.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.comboBoxAlbum.Name = "comboBoxAlbum";
            this.comboBoxAlbum.Size = new System.Drawing.Size(300, 21);
            this.comboBoxAlbum.TabIndex = 30;
            // 
            // cBoxAlbum
            // 
            this.cBoxAlbum.AutoSize = true;
            this.cBoxAlbum.Dock = System.Windows.Forms.DockStyle.Top;
            this.cBoxAlbum.Location = new System.Drawing.Point(3, 97);
            this.cBoxAlbum.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cBoxAlbum.Name = "cBoxAlbum";
            this.cBoxAlbum.Size = new System.Drawing.Size(121, 16);
            this.cBoxAlbum.TabIndex = 7;
            this.cBoxAlbum.Text = "Album:";
            this.cBoxAlbum.UseVisualStyleBackColor = true;
            // 
            // comboBoxContArtists
            // 
            this.comboBoxContArtists.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxContArtists.FormattingEnabled = true;
            this.comboBoxContArtists.Location = new System.Drawing.Point(130, 65);
            this.comboBoxContArtists.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.comboBoxContArtists.Name = "comboBoxContArtists";
            this.comboBoxContArtists.Size = new System.Drawing.Size(300, 21);
            this.comboBoxContArtists.TabIndex = 34;
            // 
            // cBoxContArtists
            // 
            this.cBoxContArtists.AutoSize = true;
            this.cBoxContArtists.Dock = System.Windows.Forms.DockStyle.Top;
            this.cBoxContArtists.Location = new System.Drawing.Point(3, 68);
            this.cBoxContArtists.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cBoxContArtists.Name = "cBoxContArtists";
            this.cBoxContArtists.Size = new System.Drawing.Size(121, 16);
            this.cBoxContArtists.TabIndex = 5;
            this.cBoxContArtists.Text = "Contributing artist(s):";
            this.cBoxContArtists.UseVisualStyleBackColor = true;
            // 
            // comboBoxAlbumArtist
            // 
            this.comboBoxAlbumArtist.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxAlbumArtist.FormattingEnabled = true;
            this.comboBoxAlbumArtist.Location = new System.Drawing.Point(130, 36);
            this.comboBoxAlbumArtist.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.comboBoxAlbumArtist.Name = "comboBoxAlbumArtist";
            this.comboBoxAlbumArtist.Size = new System.Drawing.Size(300, 21);
            this.comboBoxAlbumArtist.TabIndex = 35;
            // 
            // cBoxAlbumArtist
            // 
            this.cBoxAlbumArtist.AutoSize = true;
            this.cBoxAlbumArtist.Dock = System.Windows.Forms.DockStyle.Top;
            this.cBoxAlbumArtist.Location = new System.Drawing.Point(3, 39);
            this.cBoxAlbumArtist.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cBoxAlbumArtist.Name = "cBoxAlbumArtist";
            this.cBoxAlbumArtist.Size = new System.Drawing.Size(121, 16);
            this.cBoxAlbumArtist.TabIndex = 3;
            this.cBoxAlbumArtist.Text = "Album artist:";
            this.cBoxAlbumArtist.UseVisualStyleBackColor = true;
            // 
            // comboBoxTitle
            // 
            this.comboBoxTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxTitle.FormattingEnabled = true;
            this.comboBoxTitle.Location = new System.Drawing.Point(130, 7);
            this.comboBoxTitle.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.comboBoxTitle.Name = "comboBoxTitle";
            this.comboBoxTitle.Size = new System.Drawing.Size(300, 21);
            this.comboBoxTitle.TabIndex = 29;
            // 
            // cBoxTitle
            // 
            this.cBoxTitle.AutoSize = true;
            this.cBoxTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cBoxTitle.Location = new System.Drawing.Point(3, 10);
            this.cBoxTitle.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cBoxTitle.Name = "cBoxTitle";
            this.cBoxTitle.Size = new System.Drawing.Size(121, 16);
            this.cBoxTitle.TabIndex = 1;
            this.cBoxTitle.Text = "Title:";
            this.cBoxTitle.UseVisualStyleBackColor = true;
            // 
            // tagEditAndDisplayTablePanel
            // 
            this.tagEditAndDisplayTablePanel.AutoScroll = true;
            this.tagEditAndDisplayTablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tagEditAndDisplayTablePanel.ColumnCount = 2;
            this.tagEditAndDisplayTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tagEditAndDisplayTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tagEditAndDisplayTablePanel.Controls.Add(this.comboBoxTitle, 1, 0);
            this.tagEditAndDisplayTablePanel.Controls.Add(this.cBoxAlbumArtist, 0, 1);
            this.tagEditAndDisplayTablePanel.Controls.Add(this.cBoxTitle, 0, 0);
            this.tagEditAndDisplayTablePanel.Controls.Add(this.comboBoxAlbumArtist, 1, 1);
            this.tagEditAndDisplayTablePanel.Controls.Add(this.comboBoxContArtists, 1, 2);
            this.tagEditAndDisplayTablePanel.Controls.Add(this.cBoxContArtists, 0, 2);
            this.tagEditAndDisplayTablePanel.Controls.Add(this.comboBoxAlbum, 1, 3);
            this.tagEditAndDisplayTablePanel.Controls.Add(this.comboBoxYear, 1, 4);
            this.tagEditAndDisplayTablePanel.Controls.Add(this.comboBoxGenre, 1, 6);
            this.tagEditAndDisplayTablePanel.Controls.Add(this.comboBoxTrackNo, 1, 5);
            this.tagEditAndDisplayTablePanel.Controls.Add(this.cBoxAlbum, 0, 3);
            this.tagEditAndDisplayTablePanel.Controls.Add(this.cBoxGenres, 0, 6);
            this.tagEditAndDisplayTablePanel.Controls.Add(this.cBoxTrackNo, 0, 5);
            this.tagEditAndDisplayTablePanel.Controls.Add(this.cBoxYear, 0, 4);
            this.tagEditAndDisplayTablePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tagEditAndDisplayTablePanel.Location = new System.Drawing.Point(3, 3);
            this.tagEditAndDisplayTablePanel.Name = "tagEditAndDisplayTablePanel";
            this.tagEditAndDisplayTablePanel.RowCount = 7;
            this.tagEditAndDisplayTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tagEditAndDisplayTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tagEditAndDisplayTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tagEditAndDisplayTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tagEditAndDisplayTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tagEditAndDisplayTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tagEditAndDisplayTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tagEditAndDisplayTablePanel.Size = new System.Drawing.Size(433, 205);
            this.tagEditAndDisplayTablePanel.TabIndex = 37;
            // 
            // resetAndSuggestTabelPanel
            // 
            this.resetAndSuggestTabelPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetAndSuggestTabelPanel.ColumnCount = 5;
            this.resetAndSuggestTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.80198F));
            this.resetAndSuggestTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.70297F));
            this.resetAndSuggestTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.83168F));
            this.resetAndSuggestTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.83168F));
            this.resetAndSuggestTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.83168F));
            this.resetAndSuggestTabelPanel.Controls.Add(this.btnReset, 2, 0);
            this.resetAndSuggestTabelPanel.Controls.Add(this.btnClear, 3, 0);
            this.resetAndSuggestTabelPanel.Controls.Add(this.btnSuggest, 4, 0);
            this.resetAndSuggestTabelPanel.Controls.Add(this.lblStatus, 1, 0);
            this.resetAndSuggestTabelPanel.Controls.Add(this.cBoxSelectAll, 0, 0);
            this.resetAndSuggestTabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.resetAndSuggestTabelPanel.Location = new System.Drawing.Point(3, 214);
            this.resetAndSuggestTabelPanel.Name = "resetAndSuggestTabelPanel";
            this.resetAndSuggestTabelPanel.RowCount = 1;
            this.resetAndSuggestTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.resetAndSuggestTabelPanel.Size = new System.Drawing.Size(433, 27);
            this.resetAndSuggestTabelPanel.TabIndex = 38;
            // 
            // saveAndFormatTabelPanel
            // 
            this.saveAndFormatTabelPanel.AutoScroll = true;
            this.saveAndFormatTabelPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveAndFormatTabelPanel.ColumnCount = 5;
            this.saveAndFormatTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.7907F));
            this.saveAndFormatTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.90476F));
            this.saveAndFormatTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.saveAndFormatTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.11377F));
            this.saveAndFormatTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.60479F));
            this.saveAndFormatTabelPanel.Controls.Add(this.lblItemsCount, 0, 0);
            this.saveAndFormatTabelPanel.Controls.Add(this.lblFormat, 1, 0);
            this.saveAndFormatTabelPanel.Controls.Add(this.comboBoxFormat, 2, 0);
            this.saveAndFormatTabelPanel.Controls.Add(this.btnSave, 4, 0);
            this.saveAndFormatTabelPanel.Controls.Add(this.cBoxAutoNext, 3, 1);
            this.saveAndFormatTabelPanel.Controls.Add(this.btnRefresh, 0, 1);
            this.saveAndFormatTabelPanel.Controls.Add(this.cBoxApplyToAll, 3, 0);
            this.saveAndFormatTabelPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.saveAndFormatTabelPanel.Location = new System.Drawing.Point(141, 454);
            this.saveAndFormatTabelPanel.MaximumSize = new System.Drawing.Size(500, 55);
            this.saveAndFormatTabelPanel.MinimumSize = new System.Drawing.Size(0, 48);
            this.saveAndFormatTabelPanel.Name = "saveAndFormatTabelPanel";
            this.saveAndFormatTabelPanel.RowCount = 2;
            this.saveAndFormatTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.02041F));
            this.saveAndFormatTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.97959F));
            this.saveAndFormatTabelPanel.Size = new System.Drawing.Size(478, 48);
            this.saveAndFormatTabelPanel.TabIndex = 39;
            // 
            // mainTablePanel
            // 
            this.mainTablePanel.AutoScroll = true;
            this.mainTablePanel.ColumnCount = 3;
            this.mainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.64111F));
            this.mainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.35889F));
            this.mainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.mainTablePanel.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.mainTablePanel.Controls.Add(this.extraButtonsPanel, 2, 0);
            this.mainTablePanel.Controls.Add(this.fileSpecificDisplayTablePanel, 0, 0);
            this.mainTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTablePanel.Location = new System.Drawing.Point(0, 24);
            this.mainTablePanel.Name = "mainTablePanel";
            this.mainTablePanel.RowCount = 1;
            this.mainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.mainTablePanel.Size = new System.Drawing.Size(1089, 511);
            this.mainTablePanel.TabIndex = 40;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.listViewAudioFiles, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.saveAndFormatTabelPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(448, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(622, 505);
            this.tableLayoutPanel1.TabIndex = 41;
            // 
            // extraButtonsPanel
            // 
            this.extraButtonsPanel.Controls.Add(this.btnSearchReplace);
            this.extraButtonsPanel.Controls.Add(this.btnCheckFormMsg);
            this.extraButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extraButtonsPanel.Location = new System.Drawing.Point(1070, 5);
            this.extraButtonsPanel.Margin = new System.Windows.Forms.Padding(0, 5, 3, 0);
            this.extraButtonsPanel.Name = "extraButtonsPanel";
            this.extraButtonsPanel.Size = new System.Drawing.Size(16, 506);
            this.extraButtonsPanel.TabIndex = 41;
            // 
            // fileSpecificDisplayTablePanel
            // 
            this.fileSpecificDisplayTablePanel.ColumnCount = 1;
            this.fileSpecificDisplayTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fileSpecificDisplayTablePanel.Controls.Add(this.resetAndSuggestTabelPanel, 0, 1);
            this.fileSpecificDisplayTablePanel.Controls.Add(this.tagEditAndDisplayTablePanel, 0, 0);
            this.fileSpecificDisplayTablePanel.Controls.Add(this.tagArtPictureBox, 0, 2);
            this.fileSpecificDisplayTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileSpecificDisplayTablePanel.Location = new System.Drawing.Point(3, 3);
            this.fileSpecificDisplayTablePanel.Name = "fileSpecificDisplayTablePanel";
            this.fileSpecificDisplayTablePanel.RowCount = 3;
            this.fileSpecificDisplayTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.fileSpecificDisplayTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.fileSpecificDisplayTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fileSpecificDisplayTablePanel.Size = new System.Drawing.Size(439, 505);
            this.fileSpecificDisplayTablePanel.TabIndex = 41;
            // 
            // tagArtPictureBox
            // 
            this.tagArtPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tagArtPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tagArtPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagArtPictureBox.Location = new System.Drawing.Point(3, 248);
            this.tagArtPictureBox.Name = "tagArtPictureBox";
            this.tagArtPictureBox.Size = new System.Drawing.Size(433, 254);
            this.tagArtPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tagArtPictureBox.TabIndex = 39;
            this.tagArtPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1089, 535);
            this.Controls.Add(this.mainTablePanel);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(740, 328);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MP3Boss";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tagEditAndDisplayTablePanel.ResumeLayout(false);
            this.tagEditAndDisplayTablePanel.PerformLayout();
            this.resetAndSuggestTabelPanel.ResumeLayout(false);
            this.resetAndSuggestTabelPanel.PerformLayout();
            this.saveAndFormatTabelPanel.ResumeLayout(false);
            this.saveAndFormatTabelPanel.PerformLayout();
            this.mainTablePanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.extraButtonsPanel.ResumeLayout(false);
            this.fileSpecificDisplayTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tagArtPictureBox)).EndInit();
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
        private System.Windows.Forms.Button btnSuggest;
        private System.Windows.Forms.ComboBox comboBoxGenre;
        private System.Windows.Forms.CheckBox cBoxGenres;
        private System.Windows.Forms.ComboBox comboBoxTrackNo;
        private System.Windows.Forms.CheckBox cBoxTrackNo;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.CheckBox cBoxYear;
        private System.Windows.Forms.ComboBox comboBoxAlbum;
        private System.Windows.Forms.CheckBox cBoxAlbum;
        private System.Windows.Forms.ComboBox comboBoxContArtists;
        private System.Windows.Forms.CheckBox cBoxContArtists;
        private System.Windows.Forms.ComboBox comboBoxAlbumArtist;
        private System.Windows.Forms.CheckBox cBoxAlbumArtist;
        private System.Windows.Forms.ComboBox comboBoxTitle;
        private System.Windows.Forms.CheckBox cBoxTitle;
        private System.Windows.Forms.TableLayoutPanel tagEditAndDisplayTablePanel;
        private System.Windows.Forms.TableLayoutPanel resetAndSuggestTabelPanel;
        private System.Windows.Forms.TableLayoutPanel saveAndFormatTabelPanel;
        private System.Windows.Forms.TableLayoutPanel mainTablePanel;
        private System.Windows.Forms.TableLayoutPanel fileSpecificDisplayTablePanel;
        private System.Windows.Forms.PictureBox tagArtPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel extraButtonsPanel;
    }
}

