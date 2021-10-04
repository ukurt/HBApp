using HBApp.Core.Constant;
using HBApp.Core.Dto;
using HBApp.Core.Interfaces;
using HBApp.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Linq;
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
                campaignDto.PriceManipulationLimit, campaignDto.TargetSaleCount, campaignDto.ProductPrice);
            await _repository.AddAsync(campaign);
        }

        public async Task<Campaign> GetActiveCampaignForThisProduct(string productCode)
        {
            var campaing = await _repository.GetAsync<Campaign>(c => c.ProductCode == productCode && c.Status == OperationContants.CampaignStatusActive);
            return campaing;
        }
        public IQueryable<Campaign> GetActiveCampaigns()
        {
            var campaings = _repository.GetAll<Campaign>(c => c.Status == OperationContants.CampaignStatusActive);
            return campaings;
        }

        public async Task<Campaign> GetCampaignAsync(string campaignName)
        {
            var campaing = await _repository.GetAsync<Campaign>(c => c.Name == campaignName);
            return campaing;
        }

        public async Task ChangeCampaignStatus(Campaign campaign, int status)
        {
            campaign.Status = status;
            await _repository.UpdateAsycn(campaign, campaign.Id);
        }

        public async Task UpdateCampaingAsync(Campaign campaign)
        {
            await _repository.UpdateAsycn(campaign, campaign.Id);
        }
    }
}
