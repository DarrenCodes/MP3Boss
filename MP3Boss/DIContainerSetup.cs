using Autofac;
using MP3Boss.BLL.Directory;
using MP3Boss.Common.Interfaces;
using MP3Boss.DAL.Files;
using MP3Boss.DAL.FileTags;
using MP3Boss.Source.File;
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
            _builder.RegisterType<FileTagManipulation>()
                .As<IManipulateFileTagsBLL>();
            _builder.RegisterType<FileDirectoryManipulation>()
                .As<IManipulateFileDirectoryBLL>();
            _builder.RegisterType<FileDirectoryDAL>()
                .As<IManipulateFileDirectoryDAL>();
            _builder.RegisterType<FileTagsDAL>()
                .As<IManipulateFileTagsDAL>();
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
