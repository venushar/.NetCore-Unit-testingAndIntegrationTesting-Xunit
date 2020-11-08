using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingServices.Common.Interfaces;
using OnlineShoppingServices.Common.Models;

namespace OnlineShoppingServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private IProductBusiness _productService; 
        public ProductController(IProductBusiness productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {                    
            List< ProductModel> productsList=  await _productService.getAllProducts();
            return Ok(productsList);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody] ProductModel productModel)
        {
            if(productModel is null) { return BadRequest(); }
            await _productService.addProduct(productModel);
                return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModel productModel)
        {
            if (productModel is null) { return BadRequest(); }
            await _productService.updateProduct(productModel);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] ProductModel productModel)
        {
            if (productModel is null) { return BadRequest(); }
            await _productService.deleteProduct(productModel);
            return Ok();
        }
    }
}
