using System;
using Xunit;
using Moq;
using OnlineShoppingServices.Common.Interfaces;
using OnlineShoppingServices.Common.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using OnlineShoppingServices.Business;
using OnlineShoppingServices.Common.Helpers;
using Microsoft.Extensions.Options;
using OnlineShoppingServices.Common.Models;

namespace UnitTetsing
{
    public class ProductBusinessTest
    {
        Mock<IAsyncRepository<Product>> _repo;
        Mock<IUnitOfWork> _uow;

        public ProductBusinessTest()
        {
            _repo = new Mock<IAsyncRepository<Product>>();
            _uow = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task ShouldRetrieveAllProducts()
        {

            List<Product> prodList = new List<Product>()
            {
                new Product
                {
                    catogeryId=1,
                    ProductId=1,
                    ProductName="Anchor"
                },
                  new Product
                {
                    catogeryId=1,
                    ProductId=2,
                    ProductName="Highland"
                }
            };

            _repo.Setup(x => x.GetAllAsync()).ReturnsAsync(prodList);
            _uow.Setup(m => m.ProductRepository).Returns(_repo.Object);
            var productBusiness = new ProductBusiness(_uow.Object);
            List<ProductModel> products = await productBusiness.getAllProducts().ConfigureAwait(false);
            Assert.NotNull(products);
            Assert.IsAssignableFrom<List<ProductModel>>(products);
            Assert.Equal(2, products.Count);

        }
        [Fact]
        public async Task ShouldAddProduct()
        {

            var product = new ProductModel()
            {
                catogeryId = 1,
                ProductId = 1,
                ProductName = "Anchor"

            };

            var prod = new Product()
            {
                catogeryId = 1,
                ProductId = 1,
                ProductName = "Anchor"

            };

            _repo.Setup(x => x.AddAsync(prod)).ReturnsAsync(prod);
            await _repo.Object.AddAsync(prod);

            _uow.Setup(m => m.ProductRepository).Returns(_repo.Object);

            var productBusiness = new ProductBusiness(_uow.Object);
            var resultProduct = await productBusiness.addProduct(product).ConfigureAwait(false);
            Product resultProd;
            if (resultProduct != null)
            {
                resultProd = new Product()
                {
                    catogeryId = resultProduct.catogeryId,
                    ProductId = resultProduct.ProductId,
                    ProductName = resultProduct.ProductName
                };

                Assert.Equal(resultProd.ProductId, prod.ProductId);
                Assert.Equal(resultProd.catogeryId, prod.catogeryId);
                Assert.Equal(resultProd.ProductName, prod.ProductName);
                _repo.Verify(x => x.AddAsync(prod), Times.Once());
            }
        }

        [Fact]
        public async Task ShouldDeleteProduct()
        {
            var prod = new Product()
            {
                catogeryId = 1,
                ProductId = 1,
                ProductName = "Anchor"
            };

            var product = new ProductModel()
            {
                catogeryId = 1,
                ProductId = 1,
                ProductName = "Anchor"
            };

            var _repo = new Mock<IAsyncRepository<Product>>();

            _repo.Setup(x => x.DeleteAsync(prod));
            await _repo.Object.DeleteAsync(prod);
            _uow.Setup(m => m.ProductRepository).Returns(_repo.Object);
            var productBusiness = new ProductBusiness(_uow.Object);
            await productBusiness.deleteProduct(product).ConfigureAwait(false);

            _repo.Setup(x => x.SingleOrDefaultAsync(x => x.ProductId == 1));
            _repo.Object.SingleOrDefaultAsync(x => x.ProductId == 1).GetAwaiter().Equals(null);

            _repo.Verify(x => x.DeleteAsync(prod), Times.Once);

        }

        [Fact]
        public async Task ShouldUpdateProduct()
        {

            var product = new ProductModel()
            {
                catogeryId = 1,
                ProductId = 1,
                ProductName = "Anchor"

            };

            var prod = new Product()
            {
                catogeryId = 1,
                ProductId = 1,
                ProductName = "Test"

            };

            var prodToUpdate = new Product()
            {
                catogeryId = 1,
                ProductId = 1,
                ProductName = "TestNew"

            };
            _repo.Setup(x => x.AddAsync(prod)).ReturnsAsync(prod);
            await _repo.Object.AddAsync(prod);

            _repo.Setup(x => x.UpdateAsync(prod)).ReturnsAsync(prodToUpdate);
            await _repo.Object.UpdateAsync(prodToUpdate);
            _repo.Verify(x => x.UpdateAsync(prodToUpdate), Times.Once);


            _uow.Setup(m => m.ProductRepository).Returns(_repo.Object);

            var productBusiness = new ProductBusiness(_uow.Object);
            await productBusiness.updateProduct(product).ConfigureAwait(false);

            _repo.Setup(x => x.GetAsync(1)).ReturnsAsync(prodToUpdate);
            await _repo.Object.GetAsync(1);

            _repo.Object.GetAsync(1).GetAwaiter().GetResult().ProductName.Equals("TestNew");

        }


        [Fact]
        public async Task Get_Product_By_Id()
        {

            var prod = new Product()
            {
                catogeryId = 1,
                ProductId = 1,
                ProductName = "Test"

            };

            _repo.Setup(x => x.GetAsync(1)).ReturnsAsync(prod);
            await _repo.Object.GetAsync(1);
            _repo.Object.GetAsync(1).GetAwaiter().GetResult().ProductName.Equals("TestNew");
            _repo.Verify(x => x.GetAsync(prod.ProductId), Times.Once());

        }
    }
}
