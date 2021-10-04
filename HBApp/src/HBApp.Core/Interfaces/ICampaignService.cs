using HBApp.Core.Dto;
using System.Threading.Tasks;

namespace HBApp.Core.Interfaces
{
    public interface ICampaignService
    {
        Task<Campaign> AddCampaignAsync(CreateCampaignDto campaignDto);
}
}
