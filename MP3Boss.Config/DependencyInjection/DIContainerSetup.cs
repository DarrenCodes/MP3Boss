using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP3Boss.Config.DependencyInjection
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
            _builder = new ContainerBuilder();
        }
        
        /// <summary>
        /// All the other projects, except WebApi, and their DI registrations that need to be done
        /// </summary>
        private void AddProjectsRegisterations()
        {
            //Only need one instance of these
            _builder.RegisterType<MainWindowViewModel>()
                .As<IDALObjectFactory>()
                .SingleInstance();
        }

        /// <summary>
        /// Get registrations of all projects including WebApi
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public IContainer GetDIContainer()
        {
            AddProjectsRegisterations();

            return _builder.Build();
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
