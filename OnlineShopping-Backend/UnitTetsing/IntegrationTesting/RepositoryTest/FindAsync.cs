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
    public class FindAsync

    {
        private readonly ITestOutputHelper _testOutPutHelper;
        private Mock<IHostingEnvironment> _mockEnvironment;

        public FindAsync(ITestOutputHelper testOutPutHelper)
        {
            _testOutPutHelper = testOutPutHelper;
            _mockEnvironment = new Mock<IHostingEnvironment>();
            _mockEnvironment.Setup(m => m.EnvironmentName).Returns("Test");

        }

        [Fact]
        public async Task ShouldFindProductByGivenId()

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
                IList<Product> prodlist = await genericRepository.FindAsync(x=>x.catogeryId==1).ConfigureAwait(false);
                 Assert.Equal(2, prodlist.Count);
     

            }

        }


    }
}
