using System;
using System.Linq;
using UnityDAL.Interfaces;

namespace UnityDAL
{
    public class ProductsRepository: Repository<Product>, IProductsRepository
    {

        public ProductsRepository(IDataContextFactory dataContextFactory):base(dataContextFactory)
        {
            
        }

        public IQueryable<Product> Products
        {
            get { return All().AsQueryable(); }
        }

        public void SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}