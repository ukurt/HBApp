using HBApp.Core.Dto;
using System.Threading.Tasks;

namespace HBApp.Core.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(CreateOrderDto createOrderDto);
        int GetTotalSales(string campaignCode);
        int GetTotalTurnover(string campaignCode);
        decimal GetAveragePriceForCampaign(string campaignCode);


    }
}
