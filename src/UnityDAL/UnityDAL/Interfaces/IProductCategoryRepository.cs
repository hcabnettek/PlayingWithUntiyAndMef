using System.Linq;

namespace UnityDAL.Interfaces
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        IQueryable<ProductCategory> Categories { get; }
        void SaveCategory(ProductCategory category);
        void DeleteCategory(ProductCategory category);
    }
}