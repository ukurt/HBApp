using HBApp.Core.Dto;
using HBApp.Core.Interfaces;
using HBApp.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly IRepository<Campaign> _repository;

        public CampaignService(IRepository<Campaign> repository)
        {
            _repository = repository;
        }

        public async Task AddCampaignAsync(CreateCampaignDto campaignDto)
        {
            var campaign = new Campaign(campaignDto.Name, campaignDto.ProductCode, campaignDto.Duration,
                campaignDto.PriceManipulationLimit, campaignDto.TargetSaleCount);
            await _repository.AddAsync(campaign);
        }

        public async Task<Campaign> GetActiveCampaignForThisProduct(string productCode)
        {
            var campaing = await _repository.GetAsync<Campaign>(c => c.Name == productCode && c.Status == 1);
            return campaing;
        }

        public async Task<Campaign> GetCampaignAsync(string campaignName)
        {
            var campaing = await _repository.GetAsync<Campaign>(c => c.Name == campaignName);
            return campaing;
        }

        public async Task ChangeCampaignStatus(Campaign campaign, int status)
        {
            campaign.Status = status;
            await _repository.UpdateAsycn(campaign);
        }
    }
}
