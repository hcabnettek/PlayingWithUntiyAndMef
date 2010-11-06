using System.Linq;

namespace UnityDAL.Interfaces
{
    public interface IProductsRepository:IRepository<Product>
    {
        IQueryable<Product> Products { get; }
        void SaveProduct(Product product);
        void DeleteProduct(Product product);
    }
}