using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows;
using UnitySilverlightApp.ProductService;
using UnitySilverlightApp.Services;
using UnitySilverlightLib;
using UnitySilverlightLib.ViewModels;

namespace UnitySilverlightApp
{
    [Export]
    public partial class MainPage
    {
       
        [RegionType(TargetView = ViewType.Preferences)]
        public UIElement QueryExport
        {
            get { return QueryRegion; }
        }

        [RegionType(TargetView = ViewType.Shape)]
        public UIElement ShapesExport
        {
            get { return ShapeRegion; }
        }

        [Import]
        public MainViewModel ViewModel { get; set; }

        //private IList<ProductDTO> _products;
        public MainPage()
        {
            InitializeComponent();
            Init();
          
        }

        private void Init()
        {
            ProductServiceClientHelper proxy = new ProductServiceClientHelper();
            //proxy.ProductServiceCompleted += ProductLoaded;
            //proxy.ProductListServiceCompleted += ProductsLoaded;

            proxy.CategoriesListCompleted += CategoriesLoaded;
            //proxy.SubcategoriesListCompleted += SubcategoriesLoaded;

            proxy.GetCategories();
            //proxy.GetProducts();
        }

        private void SubcategoriesLoaded(object sender, ServiceCompleteArgs<List<ProductSubcategoryDTO>> e)
        {
            if (e.Error == null)
            {
                if (ViewModel != null)
                {
                    //ViewModel.Products = e.Entity;

                    
                }
            }
            else
            {
                HandleError(e.Error);
            }
        }

        private void ProductsBySubcategoryLoaded(object sender, ServiceCompleteArgs<List<ProductDTO>> e)
        {
            if (e.Error == null)
            {
                if (ViewModel != null)
                {
                    var products = e.Entity;
                 
                }
            }
            else
            {
                HandleError(e.Error);
            }
        }

        private void SubcategoriesByCategoryLoaded(object sender, ServiceCompleteArgs<List<ProductSubcategoryDTO>> e)
        {
            if (e.Error == null)
            {
                if (ViewModel != null)
                {
                    var subcategories = e.Entity;
                    var subcategory = subcategories[0];
                    var proxy = new ProductServiceClientHelper();

                    proxy.ProductsBySubcategoryCompleted += ProductsBySubcategoryLoaded;
                    proxy.GetProductsBySubcategory(subcategory);



                }
            }
            else
            {
                HandleError(e.Error);
            }
        }

        private void CategoriesLoaded(object sender, ServiceCompleteArgs<List<ProductCategoryDTO>> e)
        {
            if (e.Error == null)
            {
                var categories = e.Entity;
                var category = categories[0];
                var proxy = new ProductServiceClientHelper();

                proxy.SubcategoriesByCategoryCompleted += SubcategoriesByCategoryLoaded;
                proxy.GetSubCategoriesByCategory(category);

                if (ViewModel != null)
                {
                    //ViewModel.Products = e.Entity;


                }
            }
            else
            {
                HandleError(e.Error);
            }
        }

        private void ProductLoaded(object sender, ServiceCompleteArgs<ProductDTO> e)
        {
            //if(e.Error == null)
            //{
            //    ProductNum.Text = e.Entity.ProductNumber;
            //}
            //else
            //{
            //    HandleError(e.Error);
            //}
        }

        private void HandleError(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        private void ProductsLoaded(object sender, ServiceCompleteArgs<List<ProductDTO>> e)
        {
            if (e.Error == null)
            {
                if(ViewModel != null)
                {
                    var prods = new List<object>(e.Entity.Count);
                    e.Entity.ForEach(p => prods.Add(new {Id = p.ProductId,
                                                         ProductNo = p.ProductNumber ?? string.Empty,
                                                         ProductName = p.Name ?? string.Empty}));

                    //ViewModel.Products = e.Entity;
                    
                    
                }
            }
            else
            {
                HandleError(e.Error);
            }
        }
    }
}
