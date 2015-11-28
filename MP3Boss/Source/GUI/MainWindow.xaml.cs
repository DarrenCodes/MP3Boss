using MP3Boss.Source.DataStructures;
using MP3Boss.Source.GUI.Backend;
using MP3Boss.Source.Objects;
using MP3Boss.Source.Validation;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace MP3Boss.Source.GUI
{
    public partial class MainWindow : Window
    {
        IFormManager manageForm;
        IWindowProperties formPropertiesObject;

        public MainWindow()
        {
            formPropertiesObject = ObjectFactory.GetBindingObject();
            InitializeComponent();
            DataContext = formPropertiesObject;
            manageForm = ObjectFactory.GetFormManager(formPropertiesObject);
            EnableWindowElements(false);
        }

        #region Other helper methods
        private void ApplyToAllCheckBoxes(bool checkAll)
        {
            Action<ToggleButton> check = (setting) => setting.IsChecked = checkAll;

            check(cBoxTitle);
            check(cBoxTitle);
            check(cBoxAlbumArtist);
            check(cBoxContArtists);
            check(cBoxAlbum);
            check(cBoxYear);
            check(cBoxTrackNo);
            check(cBoxGenres);
        }

        public void EnableWindowElements(bool directoryIsSet)
        {
            Action<UIElement> enable = (setting) => setting.IsEnabled = directoryIsSet;

            enable(cBoxTitle);
            enable(cBoxAlbumArtist);
            enable(cBoxContArtists);
            enable(cBoxAlbum);
            enable(cBoxYear);
            enable(cBoxTrackNo);
            enable(cBoxGenres);
            enable(cBoxSelectAll);

            enable(comboBoxTitle);
            enable(comboBoxAlbumArtist);
            enable(comboBoxContArtists);
            enable(comboBoxAlbum);
            enable(comboBoxYear);
            enable(comboBoxTrackNo);
            enable(comboBoxGenre);

            enable(btnReset);
            enable(btnClear);
            enable(btnRefresh);
            enable(btnSave);

            enable(btnSearchReplace);
            enable(btnCheckFormMsg);

            enable(comboBoxFormat);

            enable(cBoxApplyToAll);
            enable(cBoxAutoNext);

            enable(btnSuggest);
            enable(btnAddToDB);
        }

        public void ClearFormAttributes()
        {
            Action<ToggleButton, Collection<string>> clear = (checkbox, collection) =>
            {
                if (checkbox.IsChecked != true)
                {
                    collection.Clear();
                }
            };

            clear(cBoxTitle, formPropertiesObject.Title);
            clear(cBoxAlbumArtist, formPropertiesObject.Artist);
            clear(cBoxContArtists, formPropertiesObject.ContributingArtists);
            clear(cBoxAlbum, formPropertiesObject.Album);
            clear(cBoxYear, formPropertiesObject.Year);
            clear(cBoxTrackNo, formPropertiesObject.TrackNo);
            clear(cBoxGenres, formPropertiesObject.Genre);
        }

        public void ResetForm()
        {
            ClearFormAttributes();
            formPropertiesObject.FilePathLabel = "";
            formPropertiesObject.StatusLabel = "";
            formPropertiesObject.AudioFilesCountLabel = "";
            formPropertiesObject.ListViewAudioFiles = new ObservableCollection<string>();
            cBoxSelectAll.IsChecked = false;
            cBoxApplyToAll.IsChecked = false;
            cBoxAutoNext.IsChecked = false;
            tagArtPictureBox.Source = null;
            manageForm.Reset();
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
            manageForm.FillFileList(dropedFiles);
            formPropertiesObject.AudioFilesCountLabel = listViewAudioFiles.Items.Count.ToString();
            EnableWindowElements(true);
        }

        private void ResetAllMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ResetForm();
        }

        private void CloseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
            if (listViewAudioFiles.Items.Count != 0)
            {
                formPropertiesObject.StatusLabel = "";
                ClearFormAttributes();

                formPropertiesObject.CurrentIndex = listViewAudioFiles.SelectedIndex;

                manageForm.SetFormAttributes(formPropertiesObject.CurrentIndex);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFormAttributes();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            if (formPropertiesObject.ListViewAudioFiles.Count > 0)
                manageForm.SetFormAttributes(formPropertiesObject.CurrentIndex);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (formPropertiesObject.ListViewAudioFiles.Count > 0)
            {
                manageForm.SaveToFile(cBoxApplyToAll.IsChecked.Value, cBoxAutoNext.IsChecked.Value);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            manageForm.RefreshListView();
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
            SearchAndReplaceWindow searchForm = new SearchAndReplaceWindow(manageForm);
            searchForm.Show();
        }

        private void btnCheckFormMsg_Click(object sender, RoutedEventArgs e)
        {
            IVerify verify = ObjectFactory.GetVerifier();
            verify.checkFormMessage(true);
        }

        private void btnSuggest_Click(object sender, RoutedEventArgs e)
        {
            manageForm.ManageSuggestions();
        }
        private void btnSuggest_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            manageForm.CheckDBFileAndSave(true);
        }

        bool isSuccessful = true;
        private void btnAddToDB_Click(object sender, RoutedEventArgs e)
        {
            isSuccessful = manageForm.ManageAdditionsToDB();
            if (isSuccessful)
                formPropertiesObject.StatusLabel = "Done.";
        }

        private void btnAddToDB_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; (i < listViewAudioFiles.Items.Count) && isSuccessful; i++)
                isSuccessful = manageForm.ManageAdditionsToDB();

            if (isSuccessful)
                formPropertiesObject.StatusLabel = "Done.";
        }
        #endregion
    }
}
