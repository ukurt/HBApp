using Ardalis.Result;
using System.Threading.Tasks;

namespace HBApp.Core.Interfaces
{
    public interface ICampaignService
    {
        Task<Result<Campaign>> AddCampaignAsync(string name, string productCode, int duration, int priceManipulation, int targetSaleCount);
}
}
