using System.Linq;

namespace UnityDAL.Interfaces
{
    public interface IProductSubcategoryRepository : IRepository<ProductSubcategory>
    {
        IQueryable<ProductSubcategory> Subcategories { get; }
        void SaveSubcategory(ProductSubcategory subcategory);
        void DeleteSubcategory(ProductSubcategory subcategory);
    }
}