using System.Collections.Generic;
using UnityBO.DTO;

namespace UnityBO.Interfaces
{
    public interface IProductBO
    {
        IList<ProductDTO> GetAllProducts();
        ProductDTO Get(int productId);
        bool Save(ProductDTO product);

        IList<ProductSubcategoryDTO> GetAllSubcategories();
        IList<ProductCategoryDTO> GetAllCategories();

        IList<ProductSubcategoryDTO> GetSubcategroiesByCategory(ProductCategoryDTO category);
        IList<ProductDTO> GetProductsBySubcategory(ProductSubcategoryDTO subcategory);
        
    }
}
