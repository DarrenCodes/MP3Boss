using MP3Boss.Source.GUI.Backend;
using System.Windows;

namespace MP3Boss.Source.GUI
{
    public partial class SearchAndReplaceWindow : Window
    {
        IFormManager manageForm;
        public SearchAndReplaceWindow(IFormManager manager)
        {
            InitializeComponent();
            manageForm = manager;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            manageForm.SearchAndReplace(tBoxFind.Text, tBoxReplace.Text, cBoxSearchAll.IsChecked.Value);
            Close();
        }
    }
}
