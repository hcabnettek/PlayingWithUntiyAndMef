using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Microsoft.Practices.ServiceLocation;
using UnityBO.DTO;
using UnityBO.Interfaces;
using UnityServiceLibrary.Interfaces;

namespace UnityServiceLibrary.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed) ]
    [ServiceBehavior(Namespace = "http://kettenba.ch")]
    public class ProductService : IProductService
    {

        public ProductService(IProductBO productBo)
        {
            ProductBO = productBo;
        }

        private IProductBO ProductBO { get; set; }

        public IList<ProductDTO> GetProducts()
        {
            return ProductBO.GetAllProducts();
        }

        public ProductDTO GetProduct(int productId)
        {
            return ProductBO.Get(productId);
        }

        public IList<ProductDTO> GetProductsBySubcategory(ProductSubcategoryDTO subcategory)
        {
            return ProductBO.GetProductsBySubcategory(subcategory);
        }

        public IList<ProductCategoryDTO> GetCategories()
        {
            return ProductBO.GetAllCategories();
        }

        public IList<ProductSubcategoryDTO> GetSubcategories()
        {
            return ProductBO.GetAllSubcategories();
        }

        public IList<ProductSubcategoryDTO> GetSubcategoriesByCategory(ProductCategoryDTO category)
        {
            return ProductBO.GetSubcategroiesByCategory(category);
        }
    }
}