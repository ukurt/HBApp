using Ardalis.Result;
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

        public async Task<Result<Product>> AddProductAsync(string productCode, decimal price, int stock)
        {
            if (string.IsNullOrEmpty(productCode))
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(productCode),
                    ErrorMessage = $"{nameof(productCode)} is required."
                });
                return Result<Product>.Invalid(errors);
            }
            var product = new Product(productCode, price, stock);
            await _repository.AddAsync(product);

            return new Result<Product>(product);
        }

        public async Task<Result<Product>> GetProductByCodeAsync(string productCode)
        {
            if (string.IsNullOrEmpty(productCode))
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(productCode),
                    ErrorMessage = $"{nameof(productCode)} is required."
                });
                return Result<Product>.Invalid(errors);
            }

            var product = await _repository.GetAsync<Product>(p => p.ProductCode == productCode);
            return new Result<Product>(product);
        }

    }
}
