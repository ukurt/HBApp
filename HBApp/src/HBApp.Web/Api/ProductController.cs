using HBApp.Core.Interfaces;
using HBApp.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HBApp.Web.Api
{
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet("{productCode}")]
        public async Task<IActionResult> GetByCode(string productCode)
        {
            var productResult = await _productService.GetProductByCodeAsync(productCode);

            var result = new ProductDTO
            {
                Id = productResult.Value.Id,
                Price = productResult.Value.Price,
                ProductCode = productResult.Value.ProductCode,
                Stock = productResult.Value.Stock
            };

            return Ok(result);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO request)
        {
            var productResult = await _productService.AddProductAsync(request.ProductCode, request.Price, request.Stock);

            var result = new ProductDTO
            {
                Id = productResult.Value.Id,
                ProductCode = productResult.Value.ProductCode
            };

            return Ok(result);
        }
    }
}
