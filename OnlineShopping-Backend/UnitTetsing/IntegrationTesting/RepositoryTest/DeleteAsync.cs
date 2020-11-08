using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using OnlineShoppingServices.Common.Entities;
using OnlineShoppingServices.Common.Models;
using OnlineShoppingServices.Data;
using OnlineShoppingServices.Data.Seed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace UnitTetsing.FunctionalTetsing.RepositoryTest
{
    public class DeleteAsync

    {
        private readonly ITestOutputHelper _testOutPutHelper;
        private Mock<IHostingEnvironment> _mockEnvironment;

        public DeleteAsync(ITestOutputHelper testOutPutHelper)
        {
            _testOutPutHelper = testOutPutHelper;
            _mockEnvironment = new Mock<IHostingEnvironment>();
            _mockEnvironment.Setup(m => m.EnvironmentName).Returns("Test");

        }

        [Fact]
        public async Task ShouldDeleteProduct()

        {
            Product productMock = new Product()
            {
                catogeryId = 1,
                ProductId = 11,
                ProductName = "KotmaleMilkPowder"
            };
            var services = new ServiceCollection().AddEntityFrameworkInMemoryDatabase();
            services.AddSingleton(_mockEnvironment.Object);
            services.AddDbContext<ShoppingDBContext>(options =>
            {
                options.UseInMemoryDatabase("TestDB");
            });

            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var shoppingDBContext = scopedServices.GetRequiredService<ShoppingDBContext>();
                DbContextSeed.SeedAsync(shoppingDBContext).Wait();
                var genericRepository = new GenericRepository<Product>(shoppingDBContext);
                var product = await genericRepository.AddAsync(productMock).ConfigureAwait(false);
                await genericRepository.DeleteAsync(productMock).ConfigureAwait(false);
                Assert.Null( await genericRepository.GetAsync(11).ConfigureAwait(false));
           

            }

        }


    }
}
