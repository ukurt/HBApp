using HBApp.Core.Constant;
using HBApp.Core.Dto;
using HBApp.Core.ParseStrategy;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    /// <summary>
    /// Burada bir abstract class yardımıyla kod tekrarından kaçınabilirdik ama zaman kalmadı.
    /// </summary>
    public class CreateOrderParseStrategy : IParseStrategy
    {
        public async Task<BaseDto> Parse(string text)
        {
            text = text.Trim();

            var pattern = OperationContants.CreateOrder + OperationContants.Pattern;

            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.ExplicitCapture);

            CreateOrderDto createOrderDto = new();

            int i = 0;

            //Tokenlarda gez ve uygunluğuna ve sırasına göre değerleri al
            foreach (Match m in matches)
            {
                var variable = m.Groups["variable"].Value;

                if (!string.IsNullOrEmpty(variable))
                {
                    createOrderDto.ProductCode = variable;
                }

                var intVariables = m.Groups["integer"].Value;

                if (!string.IsNullOrEmpty(intVariables))
                {
                    createOrderDto.Quantity = Convert.ToInt32(intVariables);
                }

                i++;
            }

            return await Task.FromResult(createOrderDto);
        }
    }
}
