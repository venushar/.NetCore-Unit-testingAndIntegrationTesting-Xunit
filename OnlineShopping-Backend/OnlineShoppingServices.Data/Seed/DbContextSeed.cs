using OnlineShoppingServices.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingServices.Data.Seed
{
    public static class DbContextSeed
    {
        public static async Task SeedAsync(ShoppingDBContext context)
        {

            await SeedProducts(context).ConfigureAwait(false);
        }

        private static async Task SeedProducts(ShoppingDBContext context)
        {
            if (!context.Products.Any())
            {
                context.AddRange(ProductSeed.PopulateProductList());
                await context.SaveChangesAsync().ConfigureAwait(false);
                {
                }
            }
        }
    }
}
