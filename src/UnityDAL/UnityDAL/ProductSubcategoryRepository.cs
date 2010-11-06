using System;
using System.Linq;
using UnityDAL.Interfaces;

namespace UnityDAL
{
    public class ProductSubcategoryRepository : Repository<ProductSubcategory>, IProductSubcategoryRepository
    {

        public ProductSubcategoryRepository(IDataContextFactory dataContextFactory)
            : base(dataContextFactory)
        {

        }

        public IQueryable<ProductSubcategory> Subcategories
        {
            get { return All().AsQueryable(); }
        }

        public void SaveSubcategory(ProductSubcategory subcategory)
        {
            throw new NotImplementedException();
        }

        public void DeleteSubcategory(ProductSubcategory subcategory)
        {
            throw new NotImplementedException();
        }
    }
}