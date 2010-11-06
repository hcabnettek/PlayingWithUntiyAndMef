using System;
using System.Collections.Generic;
using System.ServiceModel;
using UnityBO.DTO;

namespace UnityDemo.UnityDemoConsole
{
	class HelloWorld
	{
		[STAThread]
		static void Main(string[] args)
		{

		    var proxy = GetClient();

		    var categories = new List<ProductCategoryDTO>(proxy.GetCategories());
            var subcats = new List<ProductSubcategoryDTO>(proxy.GetSubcategories());

		    var sc = subcats[2];
            var products = new List<ProductDTO>(proxy.GetProductsBySubcategory(sc));


            
		}

        private static IProductService GetClient()
        {
            var ep = new EndpointAddress("http://stonecold/UnityServiceApp/ProductService.svc/sl");
            return new ProductServiceClient("SilverlightBinding", ep);
        }
	}
}

