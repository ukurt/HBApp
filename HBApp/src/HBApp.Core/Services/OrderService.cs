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

        public async Task<Order> CreateOrderAsync(string productCode, int quantiy)
        {
            var order = new Order(productCode, quantiy);
            await _repository.AddAsync(order);
            return order;
        }
    }
}
