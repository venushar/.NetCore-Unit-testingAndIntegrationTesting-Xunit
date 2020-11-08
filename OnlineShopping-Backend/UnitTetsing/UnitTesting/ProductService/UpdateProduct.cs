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
    public class UpdateProduct
    {

        private readonly Mock<IAsyncRepository<Product>> _repo;
        Mock<IUnitOfWork> _uow;

        public UpdateProduct()
        {
            _repo = new Mock<IAsyncRepository<Product>>();
            _uow = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task Should_Return__Exception_When_Product_IsNull()
        {
            _repo.Setup(x => x.UpdateAsync(null));
            await _repo.Object.UpdateAsync(null);

            _uow.Setup(m => m.ProductRepository).Returns(_repo.Object);

            var productBusiness = new ProductBusiness(_uow.Object);

            await Assert.ThrowsAsync<System.NullReferenceException>(async () => await productBusiness.updateProduct(null).ConfigureAwait(false)).ConfigureAwait(false);
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

            _repo.Setup(x => x.UpdateAsync(prodToUpdate)).ReturnsAsync(prodToUpdate);
            await _repo.Object.UpdateAsync(prodToUpdate);
            _repo.Verify(x => x.UpdateAsync(prodToUpdate), Times.Once);


            _uow.Setup(m => m.ProductRepository).Returns(_repo.Object);

            var productBusiness = new ProductBusiness(_uow.Object);
           var t= await productBusiness.updateProduct(product).ConfigureAwait(false);

          

        }

        [Fact]
        public async Task ShouldUpdateProduct_withNotExistingId()
        {

            var product = new ProductModel()
            {
                catogeryId = 11,
                ProductId = 11,
                ProductName = "Anchor"

            };

            var prod = new Product()
            {
                catogeryId = 1,
                ProductId = 22,
                ProductName = "Test"

            };

            var prodToUpdate = new Product()
            {
                catogeryId = 1,
                ProductId = 1,
                ProductName = "TestNew"
            };
         Mock<IAsyncRepository<Product>> _repo1 = new Mock<IAsyncRepository<Product>>();

            Mock<IUnitOfWork> _uow1 = new Mock<IUnitOfWork>();
          

        //  _repo.Setup(x => x.AddAsync(prod)).ReturnsAsync(prod);
        //  await _repo.Object.AddAsync(prod);

            _uow1.Setup(m => m.ProductRepository).Returns(_repo1.Object);

            var productBusiness = new ProductBusiness(_uow1.Object);
            var model = await productBusiness.updateProduct(product).ConfigureAwait(false);

           
        }




    }
}
