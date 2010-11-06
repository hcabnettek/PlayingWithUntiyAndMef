using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;
using UnityDemo.Core;

namespace Core.WCF
{
    public class UnityInstanceProvider: IInstanceProvider
    {
        private readonly Type _serviceType;
        private readonly IUnityContainer _container;

        public UnityInstanceProvider(Type serviceType)
        {
            _serviceType = serviceType;
            _container = UnityWrapper.Create().Container;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            var instance = _container.Resolve(_serviceType);

            return instance;
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            
        }
    }
}