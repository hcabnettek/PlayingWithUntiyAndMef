using System;
using System.ServiceModel;
using System.ServiceModel.Channels;


namespace UnitySilverlightApp.Services
{
    public abstract class BaseService<TClient, TChannel> : ClientBase<TChannel> where TClient : ClientBase<TChannel>, new()
                                                                                where TChannel : class
    {

        private const string BASE_SERVICE = "UnityServiceApp/{0}.svc";

        private static readonly string _baseUri;

        static BaseService()
        {
            _baseUri = System.Windows.Browser.HtmlPage.Document.DocumentUri.AbsoluteUri;
            int lastSlash = _baseUri.LastIndexOf("/");
            _baseUri = _baseUri.Substring(0, lastSlash + 2);
        }

        private readonly TClient _channel;

        protected BaseService()
        {
            if (_baseUri.Contains("http"))
            {
                BasicHttpBinding binding = new BasicHttpBinding{
                    Name = "SLBinding"
                    , MaxBufferSize = 650000
                    , MaxReceivedMessageSize = 650000
                };
                
                binding.Security.Mode = BasicHttpSecurityMode.None;

                //EndpointAddress endpoint = new EndpointAddress(string.Format("{0}{1}",
                //                                                             _baseUri, string.Format(BASE_SERVICE, typeof(TChannel).Name)));

                var ep = new EndpointAddress("http://stonecold/UnityServiceApp/ProductService.svc/sl");

                _channel = (TClient)Activator.CreateInstance(typeof(TClient), new object[] { binding, ep });
            }

            else
            {
                _channel = Activator.CreateInstance<TClient>();
            }
        }

        protected TClient _GetClientChannel()
        {
            return _channel;
        }
    }
}