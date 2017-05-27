using MP3Boss.Source.File;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MP3Boss.Source.ViewModels
{
    class MainWindowViewModel
    {
        #region Properties
        public BitmapImage TagArt { get; set; }
        public ObservableCollection<string> ListViewAudioFilesList { get; }
        public List<string> FullPathAudioFilesList { get; }
        public string StatusLabel { get; set; }
        public string AudioFilesCountLabel { get; set; }
        public string FilePathLabel { get; set; }
        public FileTagsViewModel FileTags { get; set; }

        public int CurrentIndex { get; set; }
        public int Format { get; set; }

        #region Locked Status
        public bool SelectAll { get; set; }

        public bool CheckBoxTitle { get; set; }
        public bool CheckBoxArtist { get; set; }
        public bool CheckBoxContributingArtists { get; set; }
        public bool CheckBoxAlbum { get; set; }
        public bool CheckBoxYear { get; set; }
        public bool CheckBoxTrackNo { get; set; }
        public bool CheckBoxGenre { get; set; }
        #endregion

        #region Text Boxes
        public string MyProperty { get; set; }
        #endregion

        public bool ApplyToAll { get; set; }
        public bool AutoNext { get; set; }

        #region Commands
        public ICommand SelectAllCommand { get; }
        public ICommand ResetAllCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand HowToCommand { get; }
        public ICommand SelectSongCommand { get; }
        #endregion

        #region Events
        public event DragEventHandler FilesAdded;
        #endregion
        #endregion

        #region Constructor Methods
        public MainWindowViewModel()
        {
            FilesAdded += listViewAudioFiles_DragEnter;
            FilesAdded += listViewAudioFiles_DragDrop;

            FullPathAudioFilesList = new List<string>();
            ListViewAudioFilesList = new ObservableCollection<string>();
        }
        #endregion

        #region Methods
        private void ApplyToAllCheckBoxes(bool checkAll)
        {
            CheckBoxTitle = checkAll;
            CheckBoxArtist = checkAll;
            CheckBoxContributingArtists = checkAll;
            CheckBoxAlbum = checkAll;
            CheckBoxYear = checkAll;
            CheckBoxTrackNo = checkAll;
            CheckBoxGenre = checkAll;
        }
        #endregion

        #region Event Handlers
        private void listViewAudioFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.All;
            else
                e.Effects = DragDropEffects.None;
        }

        private void listViewAudioFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] dropedFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            FillFileList(dropedFiles);

            AudioFilesCountLabel = ListViewAudioFilesList.Count.ToString();
        }

        private void FillFileList(string[] dropedFiles)
        {
            FullPathAudioFilesList.AddRange(AudioFile.GetAudioFiles(dropedFiles));

            foreach (string filePath in FullPathAudioFilesList)
                ListViewAudioFilesList.Add(System.IO.Path.GetFileName(filePath));

            string path = FullPathAudioFilesList[0];
            SetFormAttributes(path);
        }

        private void HowToMenu_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Drag & drop files and/or folders onto the big white box (list view component) to get started." +
            "\n\n" +
            "Select the item you want to work on by clicking on the item in the list view component." +
            "\n" +
            "Set all tags to the same value by ticking the checkbox next to the corresponding textbox." +
            "\n" +
            "Click on the S button to open the Search & Replace window." +
            "\n" +
            "Click on the C button to change the preselected options in the Check Form Message window." +
            "\n\n" +
            "Enjoy!",
                "Welcome",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void cBoxSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
        {
            ApplyToAllCheckBoxes(cBoxSelectAll.IsChecked.Value);
        }

        private void listViewAudioFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (containsItems)
            {
                BindingObject.StatusLabel = "";
                ClearFormAttributes();

                BindingObject.CurrentIndex = listViewAudioFiles.SelectedIndex;

                FormManagerObject.SetFormAttributes(BindingObject.CurrentIndex);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFormAttributes();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            if (containsItems)
                FormManagerObject.SetFormAttributes(BindingObject.CurrentIndex);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (containsItems)
                FormManagerObject.SaveToFile(cBoxApplyToAll.IsChecked.Value, cBoxAutoNext.IsChecked.Value);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            FormManagerObject.RefreshListView();
        }

        private void cBoxApplyToAll_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (cBoxApplyToAll.IsChecked.Value)
            {
                cBoxAutoNext.IsEnabled = false;
                cBoxAutoNext.IsChecked = false;
            }
            else
                cBoxAutoNext.IsEnabled = true;
        }

        private void btnSearchAndReplace_Click(object sender, RoutedEventArgs e)
        {
            SearchAndReplaceWindow searchForm = new SearchAndReplaceWindow(FormManagerObject);
            searchForm.Show();
        }

        private void btnCheckFormMsg_Click(object sender, RoutedEventArgs e)
        {
            IVerify verify = ObjectFactory.GetVerifier();
            verify.checkFormMessage(true);
        }

        private void btnSuggest_Click(object sender, RoutedEventArgs e)
        {
            FormManagerObject.ManageSuggestions();
        }
        private void btnSuggest_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            FormManagerObject.CheckDBFileAndSave(true);
        }

        bool isSuccessful = true;
        private void btnAddToDB_Click(object sender, RoutedEventArgs e)
        {
            if (containsItems)
            {
                isSuccessful = FormManagerObject.ManageAdditionsToDB();
                if (isSuccessful)
                    BindingObject.StatusLabel = "Done.";
            }
        }

        private void btnAddToDB_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; (i < listViewAudioFiles.Items.Count) && isSuccessful; i++)
                isSuccessful = FormManagerObject.ManageAdditionsToDB();

            if (isSuccessful)
                BindingObject.StatusLabel = "Done.";
        }

        private void ComboBoxFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindingObject.Format = comboBoxFormat.SelectedIndex;
        }
        #endregion
    }
}
