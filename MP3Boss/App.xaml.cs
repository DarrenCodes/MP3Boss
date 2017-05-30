using MP3Boss.DependencyInjection;
using MP3Boss.ViewModels;
using MP3Boss.Views;
using System.Windows;

namespace MP3Boss
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var container = new DIContainerSetup();
            var viewModel = container.Resolve<MainWindowViewModel>();
            var window = new MainWindow { DataContext = viewModel };
            window.Show();
        }
    }
}
