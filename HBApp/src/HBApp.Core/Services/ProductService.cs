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

        public async Task<Product> AddProductAsync(string productCode, decimal price, int stock)
        {
            var product = new Product(productCode, price, stock);
            await _repository.AddAsync(product);
            return product;
        }

        public async Task<Product> GetProductByCodeAsync(string productCode)
        {
            var product = await _repository.GetAsync<Product>(p => p.ProductCode == productCode);
            return product;
        }

    }
}
