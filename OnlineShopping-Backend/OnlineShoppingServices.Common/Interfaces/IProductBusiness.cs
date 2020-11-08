using OnlineShoppingServices.Common.Entities;
using OnlineShoppingServices.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingServices.Common.Interfaces
{
    public interface IProductBusiness
    {
        Task<List<ProductModel>> getAllProducts();
        Task deleteProduct(ProductModel productModel);
        Task<ProductModel> updateProduct(ProductModel productModel);
        Task<ProductModel> addProduct(ProductModel productModel);

    }

}
