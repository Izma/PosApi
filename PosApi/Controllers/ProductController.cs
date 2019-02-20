using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosApi.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;

        /// <summary>
        /// Product constructors method
        /// </summary>
        /// <param name="product"></param>
        public ProductController(IProductRepository product)
        {
            repository = product;
        }

        /// <summary>
        /// Get product list
        /// </summary>
        /// <returns></returns>        
        [HttpGet, ProducesResponseType(200, Type = typeof(IList<ProductModel>)), ProducesResponseType(404), Route("api/product")]
        public async Task<IActionResult> Get()
        {
            var result = await repository.GetProducts().ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="productId">productId</param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ProductModel))]
        [ProducesResponseType(404)]
        [Route("api/product/{productId}")]
        public async Task<IActionResult> Get(string productId)
        {
            var result = await repository.GetProducts().ConfigureAwait(false);
            return Ok(result.Where(p => p.ProductId == productId));
        }

        /// <summary>
        /// Delete a product by id
        /// </summary>
        /// <param name="productId">string</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(404)]
        [Route("api/product/{productId}")]
        public IActionResult Delete(string productId)
        {
            return Ok(productId);
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>int</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(404)]
        [Route("api/product")]
        public async Task<IActionResult> Add(ProductModel product)
        {
            var rowsAffected = await repository.CreateProduct(product).ConfigureAwait(false);
            if (rowsAffected > 0)
            {
                return Ok(new
                {
                    Saved = true
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Update a new product
        /// </summary>
        /// <param name="productId">productId</param>
        /// <param name="product">Model</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(404)]
        [Route("api/product/{productId}")]
        public IActionResult Update(string productId, ProductModel product)
        {
            throw new NotImplementedException();
        }

    }
}