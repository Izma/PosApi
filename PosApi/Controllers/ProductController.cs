using Microsoft.AspNetCore.Mvc;
using Data;
using Data.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace PosApi.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository product)
        {
            repository = product;
        }

        [HttpGet, ProducesResponseType(200, Type = typeof(string)), ProducesResponseType(404), Route("api/product")]
        public async Task<IActionResult> Get()
        {
            var result = await repository.GetProducts().ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404)]
        [Route("api/product/{productId}")]
        public async Task<IActionResult> Get(string productId)
        {
            var result = await repository.GetProducts().ConfigureAwait(false);
            return Ok(result.Where(p => p.ProductId == productId));
        }
    }
}