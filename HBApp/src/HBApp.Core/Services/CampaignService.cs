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

        public async Task<Campaign> AddCampaignAsync(CreateCampaignDto campaignDto)
        {
            var campaign = new Campaign(campaignDto.Name, campaignDto.ProductCode, campaignDto.Duration,
                campaignDto.PriceManipulationLimit, campaignDto.TargetSaleCount);
            await _repository.AddAsync(campaign);
            return campaign;
        }

    }
}
