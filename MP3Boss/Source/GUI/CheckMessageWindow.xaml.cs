using System.Windows;

namespace MP3Boss.Source.GUI
{
    public partial class CheckMessageWindow : Window
    {
        public CheckMessageWindow()
        {
            InitializeComponent();
        }
        
        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            msgBoxResult = "Yes";
            Close();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            msgBoxResult = "Continue";
            Close();
        }

        private void btnSkip_Click(object sender, RoutedEventArgs e)
        {
            msgBoxResult = "Skip";
            Close();
        }

        private static string msgBoxResult = null;
        public string MsgBoxResult
        {
            get { return msgBoxResult; }
        }

        private static bool applyToAll = false;
        public bool ApplyToAll
        {
            get { return applyToAll; }
            set { applyToAll = value; }
        }
    }
}
