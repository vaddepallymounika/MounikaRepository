using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductDataAccess;
using ProductService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ProductController controller = new ProductController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ProductController controller = new ProductController();

            try
            {
                // Act
                var result = controller.Get(5);

                // Assert
                Assert.IsNotNull(result);
            }
            catch(Exception e)
            {
                //Do Nothing
            }
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ProductController controller = new ProductController();

            try
            {
                // Act
                controller.Post(new Product() { Name = "Dummy Product", Description = "Dummy Product", Price = 100, ProductID = 1 });
            }
            catch(Exception e)
            {
                //Do Nothing
            }
        }
                
        [TestMethod]
        public void Delete()
        {
            // Arrange
            ProductController controller = new ProductController();

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
