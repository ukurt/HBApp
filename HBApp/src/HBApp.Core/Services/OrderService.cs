using HBApp.Core.Dto;
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

        public async Task<Order> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var order = new Order(createOrderDto.ProductCode, createOrderDto.Quantity, createOrderDto.CampaignCode, createOrderDto.UnitPrice);
            await _repository.AddAsync(order);
            return order;
        }
    }
}
