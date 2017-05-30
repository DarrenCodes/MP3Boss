using MP3Boss.Source.GUI.Backend;
using MP3Boss.Source.Validation;
using MP3Boss.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace MP3Boss.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //BindingObject = ObjectFactory.GetBindingObject();
            //DataContext = BindingObject;
            //FormManagerObject = ObjectFactory.GetFormManager(BindingObject);
            //EnableWindowElements(false);
        }

        #region Other helper methods
        private void ApplyToAllCheckBoxes(bool checkAll)
        {
            //Action<ToggleButton> check = (setting) => setting.IsChecked = checkAll;

            //check(cBoxTitle);
            //check(cBoxTitle);
            //check(cBoxAlbumArtist);
            //check(cBoxContArtists);
            //check(cBoxAlbum);
            //check(cBoxYear);
            //check(cBoxTrackNo);
            //check(cBoxGenres);
        }

        public void EnableWindowElements(bool directoryIsSet)
        {
            //Action<UIElement> enable = (setting) => setting.IsEnabled = directoryIsSet;

            //enable(cBoxTitle);
            //enable(cBoxAlbumArtist);
            //enable(cBoxContArtists);
            //enable(cBoxAlbum);
            //enable(cBoxYear);
            //enable(cBoxTrackNo);
            //enable(cBoxGenres);
            //enable(cBoxSelectAll);

            //enable(comboBoxTitle);
            //enable(comboBoxAlbumArtist);
            //enable(comboBoxContArtists);
            //enable(comboBoxAlbum);
            //enable(comboBoxYear);
            //enable(comboBoxTrackNo);
            //enable(comboBoxGenre);

            //enable(btnReset);
            //enable(btnClear);
            //enable(btnRefresh);
            //enable(btnSave);

            //enable(btnSearchReplace);
            //enable(btnCheckFormMsg);

            //enable(comboBoxFormat);

            //enable(cBoxApplyToAll);
            //enable(cBoxAutoNext);

            //enable(btnSuggest);
            //enable(btnAddToDB);
        }

        public void ClearFormAttributes()
        {
            //Action<ToggleButton, ObservableCollection<string>> clear = (checkbox, collection) =>
            //{
            //    if (checkbox.IsChecked != true)
            //    {
            //        collection.Clear();
            //    }
            //};

            //clear(cBoxTitle, BindingObject.Title);
            //clear(cBoxAlbumArtist, BindingObject.Artist);
            //clear(cBoxContArtists, BindingObject.ContributingArtists);
            //clear(cBoxAlbum, BindingObject.Album);
            //clear(cBoxYear, BindingObject.Year);
            //clear(cBoxTrackNo, BindingObject.TrackNo);
            //clear(cBoxGenres, BindingObject.Genre);
        }

        public void ResetForm()
        {
            //ClearFormAttributes();
            //BindingObject.FilePathLabel = "";
            //BindingObject.StatusLabel = "";
            //BindingObject.AudioFilesCountLabel = "";
            //BindingObject.FullPathAudioFilesList = null;
            //cBoxSelectAll.IsChecked = false;
            //cBoxApplyToAll.IsChecked = false;
            //cBoxAutoNext.IsChecked = false;
            //tagArtPictureBox.Source = null;
            //FormManagerObject.Reset();
        }
        #endregion

        #region Event Handlers
        //private void listViewAudioFiles_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
        //        e.Effects = DragDropEffects.All;
        //    else
        //        e.Effects = DragDropEffects.None;
        //}

        //private void listViewAudioFiles_DragDrop(object sender, DragEventArgs e)
        //{
        //    string[] dropedFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
        //    FormManagerObject.FillFileList(dropedFiles);
        //    BindingObject.AudioFilesCountLabel = listViewAudioFiles.Items.Count.ToString();
        //    EnableWindowElements(true);
        //}

        //private void ResetAllMenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    ResetForm();
        //}

        //private void CloseMenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    Close();
        //}

        //private void HowToMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show(
        //        "Drag & drop files and/or folders onto the big white box (list view component) to get started." +
        //    "\n\n" +
        //    "Select the item you want to work on by clicking on the item in the list view component." +
        //    "\n" +
        //    "Set all tags to the same value by ticking the checkbox next to the corresponding textbox." +
        //    "\n" +
        //    "Click on the S button to open the Search & Replace window." +
        //    "\n" +
        //    "Click on the C button to change the preselected options in the Check Form Message window." +
        //    "\n\n" +
        //    "Enjoy!",
        //        "Welcome",
        //        MessageBoxButton.OK,
        //        MessageBoxImage.Information);
        //}

        //private void cBoxSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
        //{
        //    ApplyToAllCheckBoxes(cBoxSelectAll.IsChecked.Value);
        //}

        //private void listViewAudioFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (listViewAudioFiles.Items.Count != 0)
        //    {
        //        BindingObject.StatusLabel = "";
        //        ClearFormAttributes();

        //        BindingObject.CurrentIndex = listViewAudioFiles.SelectedIndex;

        //        FormManagerObject.SetFormAttributes(BindingObject.CurrentIndex);
        //    }
        //}

        //private void btnClear_Click(object sender, RoutedEventArgs e)
        //{
        //    ClearFormAttributes();
        //}

        //private void btnReset_Click(object sender, RoutedEventArgs e)
        //{
        //    if (BindingObject.FullPathAudioFilesList.Count > 0)
        //        FormManagerObject.SetFormAttributes(BindingObject.CurrentIndex);
        //}

        //private void btnSave_Click(object sender, RoutedEventArgs e)
        //{
        //    if (BindingObject.FullPathAudioFilesList.Count > 0)
        //    {
        //        FormManagerObject.SaveToFile(cBoxApplyToAll.IsChecked.Value, cBoxAutoNext.IsChecked.Value);
        //    }
        //}

        //private void btnRefresh_Click(object sender, RoutedEventArgs e)
        //{
        //    FormManagerObject.RefreshListView();
        //}

        //private void cBoxApplyToAll_CheckedChanged(object sender, RoutedEventArgs e)
        //{
        //    if (cBoxApplyToAll.IsChecked.Value)
        //    {
        //        cBoxAutoNext.IsEnabled = false;
        //        cBoxAutoNext.IsChecked = false;
        //    }
        //    else
        //        cBoxAutoNext.IsEnabled = true;
        //}

        //private void btnSearchAndReplace_Click(object sender, RoutedEventArgs e)
        //{
        //    SearchAndReplaceWindow searchForm = new SearchAndReplaceWindow(FormManagerObject);
        //    searchForm.Show();
        //}

        //private void btnCheckFormMsg_Click(object sender, RoutedEventArgs e)
        //{
        //    IVerify verify = ObjectFactory.GetVerifier();
        //    verify.checkFormMessage(true);
        //}

        //private void btnSuggest_Click(object sender, RoutedEventArgs e)
        //{
        //    FormManagerObject.ManageSuggestions();
        //}
        //private void btnSuggest_DoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    FormManagerObject.CheckDBFileAndSave(true);
        //}

        //bool isSuccessful = true;
        //private void btnAddToDB_Click(object sender, RoutedEventArgs e)
        //{
        //    isSuccessful = FormManagerObject.ManageAdditionsToDB();
        //    if (isSuccessful)
        //        BindingObject.StatusLabel = "Done.";
        //}

        //private void btnAddToDB_DoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    for (int i = 0; (i < listViewAudioFiles.Items.Count) && isSuccessful; i++)
        //        isSuccessful = FormManagerObject.ManageAdditionsToDB();

        //    if (isSuccessful)
        //        BindingObject.StatusLabel = "Done.";
        //}
        #endregion
    }
}
