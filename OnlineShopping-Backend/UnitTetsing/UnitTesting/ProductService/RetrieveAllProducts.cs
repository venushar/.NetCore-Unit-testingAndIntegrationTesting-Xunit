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
  public  class RetrieveAllProducts
    {

     private readonly Mock<IAsyncRepository<Product>> _repo;
        Mock<IUnitOfWork> _uow;

        public RetrieveAllProducts()
        {
            _repo = new Mock<IAsyncRepository<Product>>();
            _uow = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task Should_Return__Exception_When_ItemsNotAvailable()
        {
            var productBusiness = new ProductBusiness(_uow.Object);
            _uow.Setup(m => m.ProductRepository).Returns(_repo.Object);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await productBusiness.getAllProducts().ConfigureAwait(false)).ConfigureAwait(false);
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
    }
}
