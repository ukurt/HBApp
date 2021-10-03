using System.Threading.Tasks;

namespace HBApp.Core.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string productCode, int quantiy);
    }
}
