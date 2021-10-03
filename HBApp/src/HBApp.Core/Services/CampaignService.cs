using Ardalis.Result;
using HBApp.Core.Interfaces;
using HBApp.Core.ParseStrategy;
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

        public async Task<Result<Campaign>> AddCampaignAsync(string name, string productCode, int duration, int priceManipulation, int targetSaleCount)
        {
            if (string.IsNullOrEmpty(name))
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(name),
                    ErrorMessage = $"{nameof(name)} is required."
                });
                return Result<Campaign>.Invalid(errors);
            }

            var campaign = new Campaign(name,productCode,duration,priceManipulation,targetSaleCount);
            await _repository.AddAsync(campaign);

            return new Result<Campaign>(campaign);
        }

    }
}
