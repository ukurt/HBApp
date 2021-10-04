using HBApp.Core.Dto;
using System.Linq;
using System.Threading.Tasks;

namespace HBApp.Core.Interfaces
{
    public interface ICampaignService
    {
        Task AddCampaignAsync(CreateCampaignDto campaignDto);
        Task<Campaign> GetCampaignAsync(string campaignName);
        Task<Campaign> GetActiveCampaignForThisProduct(string productCode);
        Task ChangeCampaignStatus(Campaign campaign, int status);
        IQueryable<Campaign> GetActiveCampaigns();
        Task UpdateCampaingAsync(Campaign campaign);


    }
}
