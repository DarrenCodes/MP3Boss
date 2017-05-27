using Autofac;
using MP3Boss.ViewModels;

namespace MP3Boss
{
    class ViewModelLocator
    {
        private static IContainer Container { get; set; }

        public MainWindowViewModel MainWindowViewModel { get { return Container.Resolve<MainWindowViewModel>(); } }

        public ViewModelLocator()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<MainWindowViewModel>();
            builder.RegisterType<FileViewModel>();
            builder.RegisterType<TagViewModel>();
            
            Container = builder.Build();
        }
    }
}
