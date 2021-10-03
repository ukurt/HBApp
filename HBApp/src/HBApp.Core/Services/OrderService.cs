using Ardalis.Result;
using HBApp.Core.Interfaces;
using HBApp.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repository;

        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Result<Order>> CreateOrderAsync(string productCode, int quantiy)
        {
            if (string.IsNullOrEmpty(productCode))
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(productCode),
                    ErrorMessage = $"{nameof(productCode)} is required."
                });
                return Result<Order>.Invalid(errors);
            }
            var order = new Order(productCode, quantiy);
            await _repository.AddAsync(order);

            return new Result<Order>(order);
        }
    }
}
