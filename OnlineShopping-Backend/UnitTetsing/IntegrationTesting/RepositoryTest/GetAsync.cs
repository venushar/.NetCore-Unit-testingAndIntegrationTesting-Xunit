using EfCore.InMemoryHelpers;
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
    public class GetAsync

    {
        private readonly ITestOutputHelper _testOutPutHelper;
        private Mock<IHostingEnvironment> _mockEnvironment;

        public GetAsync(ITestOutputHelper testOutPutHelper)
        {
            _testOutPutHelper = testOutPutHelper;
            _mockEnvironment = new Mock<IHostingEnvironment>();
            _mockEnvironment.Setup(m => m.EnvironmentName).Returns("Test");

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task ShouldretrieveproductForTheGivenId(int id)

        {
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
                Product prod = await genericRepository.GetAsync(id).ConfigureAwait(false);
                Assert.NotNull(prod);
                Assert.Equal(id, prod.ProductId);

            }

        }


    }
}
