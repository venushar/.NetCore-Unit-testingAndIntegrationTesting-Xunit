using Microsoft.Extensions.Options;
using OnlineShoppingServices.Business;
using OnlineShoppingServices.Common.Entities;
using OnlineShoppingServices.Common.Helpers;
using OnlineShoppingServices.Common.Interfaces;
using OnlineShoppingServices.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace FunctionalTestingMsTestInMemory
{
    class GetAllProducts
{
        IProductBusiness _productsBusiness;
        IUnitOfWork _unitOfWork;
        IAsyncRepository<Product> _genericRepository;
        IOptions<AppSettings> appSetting;


        GetAllProducts()
        {
           // _genericRepository = new GenericRepository<Product>();

            //_unitOfWork = new UnitOfWork();
           // _productsBusiness = new ProductBusiness(new )
        }

        public async Task HttpClient_Should_Get_OKStatus_From_Products_Using_InMemory_Hosting()
        {


        }

        /*  var config = new HttpConfiguration();
        //configure web api
        config.MapHttpAttributeRoutes();

            using (var server = new HttpServer(config)) {

                var client = new HttpClient(server);

        string url = "http://localhost/api/product/hello/";

        var request = new HttpRequestMessage
        {
            RequestUri = new Uri("api/GetAllProducts/"),
            Method = HttpMethod.Get
        };

        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await client.SendAsync(request)) {
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                }
}
        }*/




}
}
