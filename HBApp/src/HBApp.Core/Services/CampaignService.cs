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

        public async Task<Campaign> AddCampaignAsync(string name, string productCode, int duration, int priceManipulation, int targetSaleCount)
        {
            var campaign = new Campaign(name,productCode,duration,priceManipulation,targetSaleCount);
            await _repository.AddAsync(campaign);
            return campaign;
        }

    }
}
