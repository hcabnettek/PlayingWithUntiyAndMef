using NUnit.Framework;
using UnityBO;
using UnityDAL;

namespace UnityDemo.UnitTests
{
	[TestFixture]
	public class ProductBO_Tests
	{
		[Test]
		public void Product_Count_Should_Equal_5()
		{
            var mockRepository = TestHelpers.MockProductsRepository(new[]{
			                                                                new Product { ProductID = 1, Name = "Bob's Boxes", DaysToManufacture = 2, ListPrice = 15.21m, Class = "Stationairy"}
                                                                            ,  new Product { ProductID = 2, Name = "Tom's Tacks", DaysToManufacture = 2, ListPrice = 12.21m, Class = "Stationairy" }
                                                                            ,  new Product { ProductID = 3, Name = "Will's Wrenches", DaysToManufacture = 2, ListPrice = 6.21m, Class = "Tools"}
                                                                            ,  new Product { ProductID = 4, Name = "Hank's Hammers", DaysToManufacture = 2, ListPrice = 15.49m, Class = "Tools"}
                                                                            ,  new Product { ProductID = 5, Name = "Paul's Pencils", DaysToManufacture = 2, ListPrice = 4.52m, Class = "Stationairy"}
                                                                            });


		    var productsBO = new ProductBO(mockRepository, null, null);

            productsBO.GetAllProducts().Count.ShouldEqual(5);
		}


        [Test]
        public void Product_Price_Should_Equal_1549()
        {
            var mockRepository = TestHelpers.MockProductsRepository(new[]{
			                                                                new Product { ProductID = 1, Name = "Bob's Boxes", DaysToManufacture = 2, ListPrice = 15.21m, Class = "Stationairy"}
                                                                            ,  new Product { ProductID = 2, Name = "Tom's Tacks", DaysToManufacture = 2, ListPrice = 12.21m, Class = "Stationairy" }
                                                                            ,  new Product { ProductID = 3, Name = "Will's Wrenches", DaysToManufacture = 2, ListPrice = 6.21m, Class = "Tools"}
                                                                            ,  new Product { ProductID = 4, Name = "Hank's Hammers", DaysToManufacture = 2, ListPrice = 15.49m, Class = "Tools"}
                                                                            ,  new Product { ProductID = 5, Name = "Paul's Pencils", DaysToManufacture = 2, ListPrice = 4.52m, Class = "Stationairy"}
                                                                            });


          
        }
	}
}

