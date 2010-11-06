using System;
using System.Configuration;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;


namespace UnityDemo.Core
{
    public class UnityWrapper : IIoCBootstrap
    {
        private static IUnityContainer _container;

        public static UnityWrapper Create()
        {
            return new UnityWrapper();
        }

        public UnityWrapper()
        {
            if(_container == null)
            {
                Init();
            }
            
        }

        public IUnityContainer Container
        {
            get { return _container; }
        }


        public void Register<TIn, TOut>() where TOut:TIn
        {
            _container.RegisterType<TIn, TOut>();
        }


        public void Init()
        {
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = @"C:\workspace\new\UnityDemo-v1.0.0.1\src\Core\unity.config" };
            
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
            _container = new UnityContainer().LoadConfiguration(unitySection);
        }
    }
}
