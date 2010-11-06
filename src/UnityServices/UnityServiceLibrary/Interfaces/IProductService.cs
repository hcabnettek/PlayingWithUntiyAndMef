using System.Collections.Generic;
using System.ServiceModel;
using UnityBO.DTO;

namespace UnityServiceLibrary.Interfaces
{
    [ServiceContract(Namespace = "http://kettenba.ch")]
    public interface IProductService
    {
        [OperationContract]
        IList<ProductDTO> GetProducts();
        
        [OperationContract]
        ProductDTO GetProduct(int productId);

        [OperationContract]
        IList<ProductDTO> GetProductsBySubcategory(ProductSubcategoryDTO subcategory);

        [OperationContract]
        IList<ProductCategoryDTO> GetCategories();

        [OperationContract]
        IList<ProductSubcategoryDTO> GetSubcategories();

        [OperationContract]
        IList<ProductSubcategoryDTO> GetSubcategoriesByCategory(ProductCategoryDTO category);
   
    
    }
}