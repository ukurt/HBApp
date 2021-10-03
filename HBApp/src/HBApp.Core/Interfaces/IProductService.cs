using Ardalis.Result;
using System.Threading.Tasks;

namespace HBApp.Core.Interfaces
{
    public interface IProductService
    {
        Task<Result<Product>> AddProductAsync(string productCode, decimal price, int stock);
        Task<Result<Product>> GetProductByCodeAsync(string productCode);

    }
}
