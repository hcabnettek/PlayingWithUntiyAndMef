using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Core.WCF
{
    public class UnityServiceBehavior:IServiceBehavior{

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
           
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach(ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers )
            {
                ChannelDispatcher cd = cdb as ChannelDispatcher;
                if(cd != null)
                {
                    foreach (EndpointDispatcher endpoint in cd.Endpoints)
                    {
                        endpoint.DispatchRuntime.InstanceProvider =
                            new UnityInstanceProvider(serviceDescription.ServiceType);
                    }
                }
            }
        }
    }
}