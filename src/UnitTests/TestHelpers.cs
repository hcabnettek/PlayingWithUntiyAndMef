using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using UnityDAL;
using UnityDAL.Interfaces;

namespace UnityDemo.UnitTests
{
    public static class TestHelpers
    {
        public static void ShouldEqual<T>(this T actual, T expected)
        {
            Assert.AreEqual(expected, actual);
        }


        public static IProductsRepository MockProductsRepository(params Product[] prods)
        {
            var mockProductsRepos = new Mock<IProductsRepository>();
            mockProductsRepos.Setup(x => x.Products).Returns(prods.AsQueryable());
            return mockProductsRepos.Object;
        }
    }
}
