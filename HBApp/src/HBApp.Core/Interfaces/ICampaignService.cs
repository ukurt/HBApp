using HBApp.Core.Dto;
using System.Threading.Tasks;

namespace HBApp.Core.Interfaces
{
    public interface ICampaignService
    {
        Task AddCampaignAsync(CreateCampaignDto campaignDto);
        Task<GetCampaignInfoDto> GetCampaignInfoAsync(GetCampaignInfoDto campaignInfoDto);

    }
}
