using HBApp.Core.Constant;
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
            //Aggregate islemlerde sqlite Sum,Avg gibi fonksiyonları kullandırmıyor. Mecbur bu sekilde yaptım.
            var orders = _repository.GetAll<Order>(o => o.CampaignCode == campaignCode).ToList();
            decimal total = 0;
            orders.ForEach(o => total += o.UnitPrice);
            return total / orders.Count();
        }

        public int GetTotalSales(string campaignCode)
        {
            var orders = _repository.GetAll<Order>(o => o.CampaignCode == campaignCode).ToList();
            int total = 0;
            orders.ForEach(o => total += o.Quantity);
            return total;
        }

        public int GetTotalTurnover(string campaignCode)
        {
            var orders = _repository.GetAll<Order>(o => o.CampaignCode == campaignCode && o.Status == OperationContants.OrderStatusCancel).ToList();
            int total = 0;
            orders.ForEach(o => total += o.Quantity);
            return total;
        }
    }
}
