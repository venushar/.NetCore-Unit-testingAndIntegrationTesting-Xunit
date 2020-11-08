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

namespace UnitTetsing.ProductService
{
  public  class AddProduct
    {

     private readonly Mock<IAsyncRepository<Product>> _repo;
        Mock<IUnitOfWork> _uow;

        public AddProduct()
        {
            _repo = new Mock<IAsyncRepository<Product>>();
            _uow = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task Should_Return__Exception_When_Product_IsNull()
        {
             _repo.Setup(x => x.AddAsync(null));
            await _repo.Object.AddAsync(null);

            _uow.Setup(m => m.ProductRepository).Returns(_repo.Object);

            var productBusiness = new ProductBusiness(_uow.Object);
          
            await Assert.ThrowsAsync<System.NullReferenceException>(async () => await productBusiness.addProduct(null).ConfigureAwait(false)).ConfigureAwait(false);
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
    }
}
