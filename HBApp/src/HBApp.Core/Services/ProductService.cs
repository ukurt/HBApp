using HBApp.Core.Dto;
using HBApp.Core.Interfaces;
using HBApp.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Product> AddProductAsync(CreateProductDto createProductDto)
        {
            var product = new Product(createProductDto.ProductCode, createProductDto.Price, createProductDto.Stock);
            await _repository.AddAsync(product);
            return product;
        }

        public async Task<Product> GetProductByCodeAsync(string productCode)
        {
            var product = await _repository.GetAsync<Product>(p => p.ProductCode == productCode);
            return product;
        }

        public async Task<Product> IncreaseStockAsync(string productCode,int quantity)
        {
            var product = await _repository.GetAsync<Product>(p => p.ProductCode == productCode);
            product.Stock -= quantity;
            await _repository.UpdateAsycn(product, product.Id);
            return product;
        }
    }
}
