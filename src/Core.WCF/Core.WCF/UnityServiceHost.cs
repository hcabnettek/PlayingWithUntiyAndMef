using System;
using System.ServiceModel;

namespace Core.WCF
{
    public class UnityServiceHost:ServiceHost
    {
        public UnityServiceHost()
        {
            
        }

        public UnityServiceHost(Type serviceType, params Uri[] baseAddresses):base(serviceType, baseAddresses)
        {
           
           
        }

        protected override void OnOpening()
        {
            Description.Behaviors.Add(new UnityServiceBehavior());
            base.OnOpening();
        }
    }
}