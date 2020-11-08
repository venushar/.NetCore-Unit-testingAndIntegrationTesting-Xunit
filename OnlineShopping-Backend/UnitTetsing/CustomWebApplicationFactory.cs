using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using OnlineShoppingServices.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShoppingServices.Data.Seed;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace UnitTetsing
{
    public class CustomWebApplicationFactory<TStartup>
     : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override async void ConfigureWebHost(IWebHostBuilder builder)
        {

            ClientOptions.BaseAddress = new Uri("https://localhost:44316/");

            builder.UseEnvironment("Test");            

            builder.UseUrls("https://localhost:44316/");

            builder.ConfigureServices(services =>

            {

                // Create a new service provider.

                var serviceProvider = new ServiceCollection()

                    .AddEntityFrameworkInMemoryDatabase()

                    .BuildServiceProvider();


                // Add a database context(ApplicationDbContext) using an in-memory

                // database for testing.

                services.AddDbContext<ShoppingDBContext>(options =>

                {

                    options.UseInMemoryDatabase("InMemoryDbForTesting");

                    options.UseInternalServiceProvider(serviceProvider);

                });



                // Build the service provider.

                var sp = services.BuildServiceProvider();

                services.Configure<ClientConfigurationModel>(new ConfigurationBuilder().Build());



                // Create a scope to obtain a reference to the database

                using (var scope = sp.CreateScope())

                {

                    var scopedServices = scope.ServiceProvider;

                    var db = scopedServices.GetRequiredService<ShoppingDBContext>();



                    // Ensure the database is created.

                    db.Database.EnsureCreated();



                    // Seed the database with test data.

                    DbContextSeed.SeedAsync(db).Wait();

                }

            });



        }

       
    }
}
