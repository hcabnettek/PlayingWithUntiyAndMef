using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace UnityWebApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();

            
        }

        private void BindGrid()
        {
            var proxy = GetClient();
            productGrid.DataSource = proxy.GetProducts();
            productGrid.DataBind();
        }


        private IProductService GetClient()
        {
            Binding binding = new BasicHttpBinding("SilverlightBinding");
            var ep = new EndpointAddress("http://stonecold/UnityServiceApp/ProductService.svc/sl");
            return new ProductServiceClient(binding, ep);
        }
    }
}
