using HBApp.Core.Constant;
using HBApp.Core.Dto;
using HBApp.Core.ParseStrategy;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class CreateCampaignParseStrategy : IParseStrategy
    {
        public async Task<BaseDto> Parse(string text)
        {
            text = text.Trim();

            var pattern = OperationContants.CreateCampaign + OperationContants.Pattern;

            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.ExplicitCapture);

            CreateCampaignDto createCampaignDto = new();

            //Eger create_campaign icin verilen pattern e uymuyorsa patlat!

            Validate(matches.Count);

            int i = 0;

            //Tokenlarda gez ve uygunluğuna ve sırasına göre değerleri al
            foreach (Match m in matches)
            {
                var variable = m.Groups["variable"].Value;

                if (!string.IsNullOrEmpty(variable))
                {
                    if (i == 1)
                        createCampaignDto.Name = variable;
                    if (i == 2)
                        createCampaignDto.ProductCode = variable;
                }

                var intVariables = m.Groups["integer"].Value;

                if (!string.IsNullOrEmpty(intVariables))
                {
                    if (i == 3)
                        createCampaignDto.Duration = Convert.ToInt32(intVariables);

                    if (i == 4)
                        createCampaignDto.PriceManipulationLimit = Convert.ToInt32(intVariables);

                    if (i == 5)
                        createCampaignDto.TargetSaleCount = Convert.ToInt32(intVariables);
                }

                i++;
            }

            return await Task.FromResult(createCampaignDto);
        }

        public void Validate(int count)
        {
            if (count != 6)
                throw new Exception("CheckPattern");
        }
    }
}
