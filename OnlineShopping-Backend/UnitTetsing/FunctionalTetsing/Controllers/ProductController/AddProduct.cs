using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using OnlineShoppingServices.Common.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi;
using Xunit;
using System.Net.Http.Headers;

using Microsoft.Extensions.Configuration;
using OnlineShoppingServices.Controllers;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace UnitTetsing.FunctionalTetsing
{
   public  class AddProduct:IClassFixture<CustomWebApplicationFactory<Startup>>
    {
       /* private readonly string requestUri;
        public HttpClient Client { get; set; }
        public HttpClient unAuthorizedClient { get; set; }
        
        public AddProduct(CustomWebApplicationFactory<Startup> factory)
        {
            requestUri = "api/Product";
            var f = factory.WithWebHostBuilder(x => x.UseStartup<TestServerStartup>());
            Client = f.CreateClient();
          //  Client.BaseAddress = new Uri("https://localhost:44316/");

            unAuthorizedClient = factory.CreateClient();
        }

      /*  private async Task SetTokenAsync(HttpClient client)
        {
            var access_token=  MockJwtTokens.generateJwtToken(new UserModel() { UserName = "test", Password = "test" });

            client.SetBearerToken(access_token);
        }
        [Fact]
        public async Task ShouldAddProduct()
        {

        var Product = new ProductModel()
            {
                catogeryId = 1,
                ProductId = 12,
                ProductName = "test"
            };

             // HttpClient _client;
       // var token = MockJwtTokens.generateJwtToken(new UserModel() { UserName = "test", Password = "test" });
            
           // var response = await httpClient.SendAsync(url);
          //  Action act = () => response.EnsureSuccessStatusCode();
            //var token = await Authenticate(new UserModel() { UserId = 1, Password = "test" });
            StringContent content = new StringContent(JsonConvert.SerializeObject(Product), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(new Uri(string.Format(CultureInfo.InvariantCulture, requestUri, 3), UriKind.Relative), content).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ShouldAddProducta()
        {
            var Product = new ProductModel()
            {
                catogeryId = 1,
                ProductId = 12,
                ProductName = "test"
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(Product), Encoding.UTF8, "application/json");
            var response = await unAuthorizedClient.PostAsync(new Uri(string.Format(CultureInfo.InvariantCulture, requestUri, 3), UriKind.Relative), content).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }*/
    }
}
