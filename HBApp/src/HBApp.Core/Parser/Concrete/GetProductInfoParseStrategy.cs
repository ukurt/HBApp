using HBApp.Core.Constant;
using HBApp.Core.Dto;
using HBApp.Core.ParseStrategy;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class GetProductInfoParseStrategy : IParseStrategy
    {
        public async Task<BaseDto> Parse(string text)
        {
            text = text.Trim();

            var pattern = OperationContants.GetProductInfo + OperationContants.Pattern;

            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.ExplicitCapture);

            GetProductInfo getProductInfo = new();

            int i = 0;

            //Tokenlarda gez ve uygunluğuna ve sırasına göre değerleri al
            foreach (Match m in matches)
            {
                var variable = m.Groups["variable"].Value;

                if (!string.IsNullOrEmpty(variable))
                {
                    getProductInfo.ProductCode = variable;
                }

                i++;
            }

            return await Task.FromResult(getProductInfo);
        }
    }
}
