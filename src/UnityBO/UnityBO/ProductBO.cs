using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using UnityBO.DTO;
using UnityBO.Interfaces;
using UnityDAL;
using UnityDAL.Interfaces;

namespace UnityBO
{
    public class ProductBO : IProductBO
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IProductCategoryRepository _categoriesRepository;
        private readonly IProductSubcategoryRepository _subcategoriesRepository;

        public ProductBO(IProductsRepository productsRepository
                , IProductCategoryRepository categoriesRepository
                , IProductSubcategoryRepository subcategoriesRepository)
        {
            _productsRepository = productsRepository;
            _categoriesRepository = categoriesRepository;
            _subcategoriesRepository = subcategoriesRepository;

            InitMaps();
        }

        private void InitMaps()
        {
            Mapper.CreateMap<Product, ProductDTO>();
            Mapper.CreateMap<ProductCategory, ProductCategoryDTO>();
            Mapper.CreateMap<ProductSubcategory, ProductSubcategoryDTO>();
        }


        public IList<ProductDTO> GetAllProducts()
        {
            return new List<ProductDTO>(_productsRepository.Products.Select(elem => Mapper.Map<Product, ProductDTO>(elem)));
        }

        public ProductDTO Get(int productId)
        {
            return Mapper.Map<Product, ProductDTO>(_productsRepository.Products.FirstOrDefault(p=>p.ProductID == productId));
        }

        public bool Save(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public IList<ProductSubcategoryDTO> GetAllSubcategories()
        {
            return new List<ProductSubcategoryDTO>(
                _subcategoriesRepository
                .Subcategories
                .Select(elem => Mapper.Map<ProductSubcategory, ProductSubcategoryDTO>(elem)));
            
        }

        public IList<ProductCategoryDTO> GetAllCategories()
        {
            return new List<ProductCategoryDTO>(
                _categoriesRepository.Categories
                .Select(elem => Mapper.Map<ProductCategory, ProductCategoryDTO>(elem)));
         
        }

        public IList<ProductDTO> GetProductsBySubcategory(ProductSubcategoryDTO subcategory)
        {
            return new List<ProductDTO>(
                _productsRepository.Products
                .Where(p => p.ProductSubcategoryID == subcategory.ProductSubcategoryId)
                .Select(elem => Mapper.Map<Product, ProductDTO>(elem)));
            
        }

        public IList<ProductSubcategoryDTO> GetSubcategroiesByCategory(ProductCategoryDTO category)
        {
            return new List<ProductSubcategoryDTO>(
                _subcategoriesRepository.Subcategories
                .Where(s => s.ProductCategoryID == category.ProductCategoryId)
                .Select(elem => Mapper.Map<ProductSubcategory, ProductSubcategoryDTO>(elem)));
            
        }
    }
}
