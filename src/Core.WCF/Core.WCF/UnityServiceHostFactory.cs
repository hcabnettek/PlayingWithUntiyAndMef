using System;
using System.ServiceModel.Activation;
using UnityDemo.Core;

namespace Core.WCF
{
    public class UnityServiceHostFactory:ServiceHostFactory
    {
        public UnityServiceHostFactory()
        {
            UnityWrapper.Create();
        }

        protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new UnityServiceHost(serviceType, baseAddresses);
        }
    }
}
