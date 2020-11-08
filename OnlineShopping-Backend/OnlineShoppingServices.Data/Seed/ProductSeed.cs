using OnlineShoppingServices.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingServices.Data.Seed
{
   internal static  class ProductSeed
    {
        internal static IEnumerable<Product> PopulateProductList()
        {
            return new List<Product>()
            {
                 addNewProduct(1,1,"AnchorMilkPowder"),
                 addNewProduct(1,2,"HighlandMilkPowder")
            };
        }

        public static Product  addNewProduct(int catogeryId,int productId,string productName)
        {
            return new Product()
            {
                catogeryId = catogeryId,
                ProductId = productId,
                ProductName = productName
            };
        }
    }
}
