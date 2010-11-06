using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using UnitySilverlightApp.ProductService;

namespace UnitySilverlightApp.Services
{
    public class ProductServiceClientHelper : BaseService<ProductServiceClient, IProductService>
    {
        public event EventHandler<ServiceCompleteArgs<ProductDTO>> ProductServiceCompleted;
        public event EventHandler<ServiceCompleteArgs<List<ProductDTO>>> ProductListServiceCompleted;
        public event EventHandler<ServiceCompleteArgs<List<ProductCategoryDTO>>> CategoriesListCompleted;
        public event EventHandler<ServiceCompleteArgs<List<ProductSubcategoryDTO>>> SubcategoriesListCompleted;
        public event EventHandler<ServiceCompleteArgs<List<ProductDTO>>> ProductsBySubcategoryCompleted;
        public event EventHandler<ServiceCompleteArgs<List<ProductSubcategoryDTO>>> SubcategoriesByCategoryCompleted;


        public ProductServiceClientHelper()
        {
            _GetClientChannel().GetProductCompleted += _GetProductCompleted;
            _GetClientChannel().GetProductsCompleted += _GetProductsCompleted;
            _GetClientChannel().GetCategoriesCompleted += _GetCategoriesCompleted;
            _GetClientChannel().GetSubcategoriesCompleted += _GetSubcategoriesCompleted;
            _GetClientChannel().GetSubcategoriesByCategoryCompleted += _GetSubcategoriesByCategoryCompleted;
            _GetClientChannel().GetProductsBySubcategoryCompleted += _GetProductsBySubcategoryCompleted;
        }

       


        public void GetProduct(int productId)
        {
            _GetClientChannel().GetProductAsync(productId);
        }


        public void GetProducts()
        {
            _GetClientChannel().GetProductsAsync();
        }

        public void GetCategories()
        {
            _GetClientChannel().GetCategoriesAsync();
        }


        public void GetSubCategories()
        {
            _GetClientChannel().GetSubcategoriesAsync();
        }


        public void GetSubCategoriesByCategory(ProductCategoryDTO category)
        {
            _GetClientChannel().GetSubcategoriesByCategoryAsync(category);
        }


        public void GetProductsBySubcategory(ProductSubcategoryDTO subcat)
        {
            _GetClientChannel().GetProductsBySubcategoryAsync(subcat);
        }



        private void _GetProductsCompleted(object sender, GetProductsCompletedEventArgs e)
        {
            if (ProductListServiceCompleted != null)
            {
                var result = e.Error == null ? e.Result : new List<ProductDTO> {new ProductDTO {ProductId = -1}};
                ProductListServiceCompleted(this, new ServiceCompleteArgs<List<ProductDTO>>(result, e.Error));
            }
        }

        private void _GetProductCompleted(object sender, GetProductCompletedEventArgs e)
        {
            if(ProductServiceCompleted != null)
            {
                ProductDTO result = e.Error == null ? e.Result : new ProductDTO{ProductId = -1};
                ProductServiceCompleted(this, new ServiceCompleteArgs<ProductDTO>(result, e.Error));
            }
        }

        private void _GetSubcategoriesCompleted(object sender, GetSubcategoriesCompletedEventArgs e)
        {
            if (SubcategoriesListCompleted != null)
            {
                var result = e.Error == null ? e.Result : new List<ProductSubcategoryDTO> { new ProductSubcategoryDTO{ ProductSubcategoryId = -1} };
                SubcategoriesListCompleted(this, new ServiceCompleteArgs<List<ProductSubcategoryDTO>>(result, e.Error));
            }
        }

        private void _GetCategoriesCompleted(object sender, GetCategoriesCompletedEventArgs e)
        {
            if (CategoriesListCompleted != null)
            {
                var result = e.Error == null ? e.Result : new List<ProductCategoryDTO> { new ProductCategoryDTO { ProductCategoryId = -1 } };
                CategoriesListCompleted(this, new ServiceCompleteArgs<List<ProductCategoryDTO>>(result, e.Error));
            }
        }

        private void _GetProductsBySubcategoryCompleted(object sender, GetProductsBySubcategoryCompletedEventArgs e)
        {
            if (ProductsBySubcategoryCompleted != null)
            {
                var result = e.Error == null ? e.Result : new List<ProductDTO> { new ProductDTO { ProductId = -1 } };
                ProductsBySubcategoryCompleted(this, new ServiceCompleteArgs<List<ProductDTO>>(result, e.Error));
            }
        }

        private void _GetSubcategoriesByCategoryCompleted(object sender, GetSubcategoriesByCategoryCompletedEventArgs e)
        {
            if (SubcategoriesByCategoryCompleted != null)
            {
                var result = e.Error == null ? e.Result : new List<ProductSubcategoryDTO> { new ProductSubcategoryDTO { ProductSubcategoryId = -1 } };
                SubcategoriesByCategoryCompleted(this, new ServiceCompleteArgs<List<ProductSubcategoryDTO>>(result, e.Error));
            }
        }

    }
}