using Ardalis.Result;
using System.Threading.Tasks;

namespace HBApp.Core.Interfaces
{
    public interface IOrderService
    {
        Task<Result<Order>> CreateOrderAsync(string productCode, int quantiy);
    }
}
