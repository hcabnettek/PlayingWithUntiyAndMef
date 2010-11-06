using System;
using System.Linq;
using UnityDAL.Interfaces;

namespace UnityDAL
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {

        public ProductCategoryRepository(IDataContextFactory dataContextFactory)
            : base(dataContextFactory)
        {

        }

        public IQueryable<ProductCategory> Categories
        {
            get { return All().AsQueryable(); }
        }

        public void SaveCategory(ProductCategory category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(ProductCategory category)
        {
            throw new NotImplementedException();
        }
    }
}