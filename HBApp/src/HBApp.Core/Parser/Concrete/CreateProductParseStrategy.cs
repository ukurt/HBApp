using HBApp.Core.Dto;
using HBApp.Core.ParseStrategy;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class CreateProductParseStrategy : IParseStrategy
    {
        public async Task<BaseDto> Parse(string text)
        {
            text = text.Trim();

            var pattern = @"create_product" +
                @"(?<whitespace>\s*)|" +
                @"(?<variable>[a-zA-Z_$][a-zA-Z0-9_$]*)|" +
                 @"(?<integer>[0-9]+)|" +
                @"(?<invalid>[^\s]+)";


            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.ExplicitCapture);

            CreateProductDto createProductDto = new();

            //Eger create_product icin verilen pattern e uymuyorsa patlat!
            if (matches.Count != 4)
            {
                throw new Exception("Check your pattern");
            }

            int i = 0;

            //Tokenlarda gez ve uygunluğuna ve sırasına göre değerleri al
            foreach (Match m in matches)
            {
                var variable = m.Groups["variable"].Value;

                if (!string.IsNullOrEmpty(variable))
                {
                    createProductDto.ProductCode = variable;
                }

                var price_stock = m.Groups["integer"].Value;

                if (!string.IsNullOrEmpty(price_stock))
                {
                    if (i == 2)
                    {
                        createProductDto.Price = Convert.ToInt32(price_stock);
                    }
                    if (i == 3)
                    {
                        createProductDto.Stock = Convert.ToInt32(price_stock);
                    }
                }

                i++;
            }

            return await Task.FromResult(createProductDto);
        }

    }
}
