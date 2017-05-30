using Autofac;
using MP3Boss.Common.Interfaces;
using MP3Boss.DataAccess.Files;
using MP3Boss.DataAccess.FileTags;
using MP3Boss.Logic.Directory;
using MP3Boss.Logic.FileTags;
using MP3Boss.ViewModels;

namespace MP3Boss.DependencyInjection
{
    /// <summary>
    /// Contains the methods used to Setup all the Dependency Injection
    /// </summary>
    public class DIContainerSetup
    {
        #region Members
        ContainerBuilder _builder;
        IContainer _container;
        #endregion

        public DIContainerSetup()
        {
            BuildDIContainer();
        }

        /// <summary>
        /// All the other projects, except WebApi, and their DI registrations that need to be done
        /// </summary>
        private void AddProjectsRegisterations()
        {
            //Only need one instance of these
            _builder.RegisterType<MainWindowViewModel>();
            _builder.RegisterType<TagViewModel>();
            _builder.RegisterType<FileTagManipulationLogic>()
                .As<IManipulateFileTagsLogic>();
            _builder.RegisterType<FileDirectoryManipulationLogic>()
                .As<IManipulateFileDirectoryLogic>();
            _builder.RegisterType<FileDirectoryDataAccess>()
                .As<IManipulateFileDirectoryDataAccess>();
            _builder.RegisterType<FileTagsDataAccess>()
                .As<IManipulateFileTagsDataAccess>();
        }

        /// <summary>
        /// Get registrations of all projects including WebApi
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public void BuildDIContainer()
        {
            _builder = new ContainerBuilder();
            AddProjectsRegisterations();

            _container =_builder.Build();
        }

        /// <summary>
        /// Resolves instances of a given type
        /// </summary>
        /// <typeparam name="T">Type to get an instance of</typeparam>
        /// <returns>Instance of given type</returns>
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
