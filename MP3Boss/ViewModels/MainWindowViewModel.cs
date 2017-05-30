using MP3Boss.Common.Commands;
using MP3Boss.Common.Interfaces;
using MP3Boss.Models.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MP3Boss.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Members
        IManipulateFileDirectoryLogic _manipulateFileDirectory;
        FilePathPair _selectedFilePathPair;

        bool _applyToAll;
        bool _autoNext;
        #endregion

        #region Properties

        public TagViewModel TagViewModel { get; }
        public FilePathPair SelectedFilePathPair { get { return _selectedFilePathPair; } set { _selectedFilePathPair = value; OnPropertyChanged(); FileSelected(); } }
        public ObservableCollection<FilePathPair> AudioFilesList { get; }
        public string StatusLabel { get; set; }
        public string AudioFilesCount { get; set; }
        public string FilePathLabel { get; set; }

        public int CurrentIndex { get; set; }
        public int Format { get; set; }

        public bool ApplyToAll
        {
            get { return _applyToAll; }
            set
            {
                _applyToAll = value;
                if (value)
                    AutoNext = false;
                OnPropertyChanged();
            }
        }
        public bool AutoNext
        {
            get { return _autoNext; }
            set
            {
                _autoNext = value;
                if (value)
                    ApplyToAll = false;
                OnPropertyChanged();
            }
        }

        #region Commands
        public ICommand SelectAllCommand { get; }
        public ICommand ResetAllCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand HowToCommand { get; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #endregion

        #region Constructor Methods
        public MainWindowViewModel(TagViewModel tagViewModel, IManipulateFileDirectoryLogic manipulateFileDirectory)
        {
            AudioFilesList = new ObservableCollection<FilePathPair>();
            TagViewModel = tagViewModel;
            _manipulateFileDirectory = manipulateFileDirectory;
            SaveCommand = new CommandHandler((o) =>
            {
                if (ApplyToAll)
                    SaveAll();
                else
                    SaveLoaded(AutoNext);

                //Refresh TagViewModel for the currently selected file
                //This makes sure the TagViewModel works with the current file path,
                //as this file path could change after a save
                TagViewModel.Load(SelectedFilePathPair.FilePath);
            });
        }
        #endregion

        #region Methods
        private void SaveLoaded(bool autoNext = false)
        {
            TagViewModel.Save();
            FilePathPair renamedFilePathPair = _manipulateFileDirectory.Rename(SelectedFilePathPair.FilePath, TagViewModel, Format);

            //Set properties of SelectedFilePathPair property so that it fires PropertyChanged event on the object it is assigned
            //Otherwise assigning the returned object from the Rename method to the SelectedFilePathPair property will not allow item in the
            //ListView to be updated, as it is a new object which isn't in the List
            SelectedFilePathPair.FilePath = renamedFilePathPair.FilePath;
            SelectedFilePathPair.DisplayText = renamedFilePathPair.DisplayText;

            if (autoNext)
                SelectedFilePathPair = GetNextElement(SelectedFilePathPair, AudioFilesList);
        }

        T GetNextElement<T>(T item, IList<T> list)
        {
            int itemIndex = list.IndexOf(item);
            if (itemIndex == list.Count - 1)
                return list[0];
            else if (itemIndex < list.Count && itemIndex > -1)
                return list[itemIndex + 1];
            else
                return default(T);
        }

        private void SaveAll()
        {
            foreach (FilePathPair filePathPair in AudioFilesList)
            {
                SelectedFilePathPair = filePathPair;
                TagViewModel.Load(filePathPair.FilePath);
                SaveLoaded();
            }
        }
        #endregion

        #region Event Handlers
        //private void ListViewAudioFiles_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
        //        e.Effects = DragDropEffects.All;
        //    else
        //        e.Effects = DragDropEffects.None;
        //}

        public void AudioFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] dropedFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            FillFileList(dropedFiles);
        }

        private void FillFileList(string[] dropedFiles)
        {
            MessageBoxResult subDirectorySelection = default(MessageBoxResult);
            if (dropedFiles.Length > 0)
                subDirectorySelection = MessageBox.Show("Include subdirectories?", "Please select...", MessageBoxButton.YesNo);

            foreach (FilePathPair filePath in _manipulateFileDirectory.GetFiles(dropedFiles, subDirectorySelection == MessageBoxResult.Yes))
                AudioFilesList.Add(filePath);

            AudioFilesCount = AudioFilesList.Count.ToString();
            SelectedFilePathPair = AudioFilesList[0];
            TagViewModel.Load(SelectedFilePathPair.FilePath);
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
            //ApplyToAllCheckBoxes(cBoxSelectAll.IsChecked.Value);
        }

        public void FileSelected()
        {
            TagViewModel.Load(SelectedFilePathPair.FilePath);
            //if (containsItems)
            //{
            //    BindingObject.StatusLabel = "";
            //    ClearFormAttributes();

            //    BindingObject.CurrentIndex = listViewAudioFiles.SelectedIndex;

            //    FormManagerObject.SetFormAttributes(BindingObject.CurrentIndex);
            //}
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //ClearFormAttributes();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            //if (containsItems)
            //    FormManagerObject.SetFormAttributes(BindingObject.CurrentIndex);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //if (containsItems)
            //    FormManagerObject.SaveToFile(cBoxApplyToAll.IsChecked.Value, cBoxAutoNext.IsChecked.Value);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //FormManagerObject.RefreshListView();
        }

        private void cBoxApplyToAll_CheckedChanged(object sender, RoutedEventArgs e)
        {
            //if (cBoxApplyToAll.IsChecked.Value)
            //{
            //    cBoxAutoNext.IsEnabled = false;
            //    cBoxAutoNext.IsChecked = false;
            //}
            //else
            //    cBoxAutoNext.IsEnabled = true;
        }

        private void btnSearchAndReplace_Click(object sender, RoutedEventArgs e)
        {
            //SearchAndReplaceWindow searchForm = new SearchAndReplaceWindow(FormManagerObject);
            //searchForm.Show();
        }

        private void btnCheckFormMsg_Click(object sender, RoutedEventArgs e)
        {
            //IVerify verify = ObjectFactory.GetVerifier();
            //verify.checkFormMessage(true);
        }

        private void btnSuggest_Click(object sender, RoutedEventArgs e)
        {
            //FormManagerObject.ManageSuggestions();
        }
        private void btnSuggest_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            //FormManagerObject.CheckDBFileAndSave(true);
        }

        bool isSuccessful = true;
        private void btnAddToDB_Click(object sender, RoutedEventArgs e)
        {
            //if (containsItems)
            //{
            //    isSuccessful = FormManagerObject.ManageAdditionsToDB();
            //    if (isSuccessful)
            //        BindingObject.StatusLabel = "Done.";
            //}
        }

        private void btnAddToDB_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            //for (int i = 0; (i < listViewAudioFiles.Items.Count) && isSuccessful; i++)
            //    isSuccessful = FormManagerObject.ManageAdditionsToDB();

            //if (isSuccessful)
            //    BindingObject.StatusLabel = "Done.";
        }

        private void ComboBoxFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //BindingObject.Format = comboBoxFormat.SelectedIndex;
        }

        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion
    }
}
