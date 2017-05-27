using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MP3Boss.ViewModels
{
    class MainWindowViewModel
    {
        #region Properties

        public TagViewModel TagViewModel { get; }
        
        public ObservableCollection<string> ListViewAudioFilesList { get; }
        public List<string> FullPathAudioFilesList { get; }
        public string StatusLabel { get; set; }
        public string AudioFilesCountLabel { get; set; }
        public string FilePathLabel { get; set; }

        public int CurrentIndex { get; set; }
        public int Format { get; set; }
        
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
        public MainWindowViewModel(TagViewModel tagViewModel)
        {
            FilesAdded += ListViewAudioFiles_DragEnter;
            FilesAdded += ListViewAudioFiles_DragDrop;

            FullPathAudioFilesList = new List<string>();
            ListViewAudioFilesList = new ObservableCollection<string>();
        }
        #endregion

        #region Methods
        public void SaveToFile(bool applyToAll, bool autoNext)
        {
            int i = CurrentIndex;
            bool firstSave = true;
            IAudioFile file = ObjectFactory.GetAudioFileManager();
            int loopEnd = 0;
            int originalIndex = 0;
            string originalPath = "";

            int listLength = formPropertiesObject.FullPathAudioFilesList.Count;
            string filePath = "";

            if (listLength > 0)
            {
                string userDecision = null;

                originalIndex = i;

                if (applyToAll == true)
                    loopEnd = listLength;
                else
                    loopEnd = i + 1;

                #region Try to save
                try
                {
                    #region Save Changes
                    for (; i < loopEnd; i++)
                    {
                        filePath = formPropertiesObject.FullPathAudioFilesList[i];

                        if (firstSave == false)
                            this.SetFormAttributes(filePath);

                        if (userDecision != "Continue")
                            userDecision = this.FormChecker(formPropertiesObject);

                        bool isAllowedToSave = (userDecision == null || userDecision == "Continue");

                        if (listLength != 0 && isAllowedToSave)
                        {
                            originalPath = filePath;

                            file.Write(filePath, formPropertiesObject);
                            filePath = file.Rename(filePath, formPropertiesObject);
                            formPropertiesObject.ListViewAudioFilesList[i] = System.IO.Path.GetFileName(filePath);
                            formPropertiesObject.FullPathAudioFilesList[i] = filePath;
                            firstSave = false;

                            if (applyToAll == true && originalIndex != 0 && i == (listLength - 1))
                            {
                                i = -1;
                                loopEnd = originalIndex;
                            }
                        }
                        else if (userDecision == "Yes")
                        {
                            firstSave = true;
                            formPropertiesObject.CurrentIndex = i;
                            break;
                        }
                        else if (userDecision == "Skip")
                            firstSave = false;

                        if (applyToAll == true)
                            firstSave = false;

                        formPropertiesObject.StatusLabel = "Done.";
                    }

                    if (i >= formPropertiesObject.FullPathAudioFilesList.Count)
                    {
                        formPropertiesObject.CurrentIndex = 0;
                        this.SetFormAttributes(0);
                    }
                    #endregion

                    #region Go to next file
                    if ((autoNext == true || userDecision == "Skip") && i < listLength)
                    {
                        this.SetFormAttributes(formPropertiesObject.FullPathAudioFilesList[i]);
                        ++formPropertiesObject.CurrentIndex;
                    }
                    #endregion
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("The file was not found.", "Warning!");
                }
                catch (IOException ex)
                {
                    MessageBox.Show("An unexpected error occured while trying to save the changes made.", "Warning!");
                    ErrorLogging.Logger(ex.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occured. Sorry.", "Warning!");
                    ErrorLogging.Logger(ex.ToString());
                }
                #endregion
            }
        }
        #endregion

        #region Event Handlers
        private void ListViewAudioFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.All;
            else
                e.Effects = DragDropEffects.None;
        }

        private void ListViewAudioFiles_DragDrop(object sender, DragEventArgs e)
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

        /*            MessageBoxResult subDirectorySelection = default(MessageBoxResult);
            if (folders.Count > 0)
                subDirectorySelection = MessageBox.Show("Include subdirectories?", "Please select...", MessageBoxButton.YesNo);*/
    }
}
