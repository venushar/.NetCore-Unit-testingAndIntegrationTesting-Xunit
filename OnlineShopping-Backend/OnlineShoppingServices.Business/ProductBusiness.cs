
using Microsoft.Extensions.Options;
using OnlineShoppingServices.Common.Entities;
using OnlineShoppingServices.Common.Helpers;
using OnlineShoppingServices.Common.Interfaces;
using OnlineShoppingServices.Common.Models;
using OnlineShoppingServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingServices.Business
{
    public class ProductBusiness : IProductBusiness
    {

        private readonly IUnitOfWork _UoW;
     
        public ProductBusiness(IUnitOfWork UoW)
        {
            _UoW = UoW; 
         
        }

        public async Task<ProductModel> getProductById(int id)
        {
           var p =  await _UoW.ProductRepository.GetAsync(id).ConfigureAwait(false);
            return  new ProductModel { catogeryId = p.catogeryId, ProductId = p.ProductId, ProductName = p.ProductName };
        }


            //get all
            public async Task<List<ProductModel>> getAllProducts()
        {
            var result = await _UoW.ProductRepository.GetAllAsync().ConfigureAwait(false);
           // var TheListOfObjectsB = TheListObjectsA.Select(a => new ObjectB() { Prop1 = a.Prop1, Prop2 = a.Prop2 }).ToList();
            return result.Select(p => new ProductModel() { catogeryId=p.catogeryId,ProductId=p.ProductId,ProductName=p.ProductName}).ToList();
        }

        //delete
        public async Task deleteProduct(ProductModel productModel)
        {

            Product pro = new Product()
            {
                ProductId = productModel.ProductId,
                catogeryId = productModel.catogeryId,
                ProductName = productModel.ProductName

            };
            await _UoW.ProductRepository.DeleteAsync(pro).ConfigureAwait(false);
            
        }

        //update
        public async Task<ProductModel> updateProduct(ProductModel productModel)
        {

            Product pro = new Product()
            {
                ProductId = productModel.ProductId,
                catogeryId = productModel.catogeryId,
                ProductName = productModel.ProductName

            };
            await _UoW.ProductRepository.UpdateAsync(pro).ConfigureAwait(false);
            return productModel;

        }

        //update
        public async Task<ProductModel> addProduct(ProductModel productModel)
        {

            Product pro = new Product()
            {
                ProductId = productModel.ProductId,
                catogeryId = productModel.catogeryId,
                ProductName = productModel.ProductName

            };
            await _UoW.ProductRepository.AddAsync(pro).ConfigureAwait(false);
           return productModel;

        }
    }
}