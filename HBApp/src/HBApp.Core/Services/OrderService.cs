using HBApp.Core.Dto;
using HBApp.Core.Interfaces;
using HBApp.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

        public decimal GetAveragePriceForCampaign(string campaignCode)
        {
            return _repository.GetAll<Order>(o => o.CampaignCode == campaignCode).Average(o=>o.UnitPrice);
        }

        public int GetTotalSales(string campaignCode)
        {
            var orders = _repository.GetAll<Order>(o => o.CampaignCode == campaignCode);
            return orders.Count();
        }

        public int GetTotalTurnover(string campaignCode)
        {
            var orders = _repository.GetAll<Order>(o => o.CampaignCode == campaignCode && o.Status == 2);
            return orders.Count();
        }
    }
}
