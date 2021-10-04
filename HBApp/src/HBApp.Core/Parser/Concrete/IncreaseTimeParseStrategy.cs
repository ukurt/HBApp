using HBApp.Core.Constant;
using HBApp.Core.Dto;
using HBApp.Core.ParseStrategy;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class IncreaseTimeParseStrategy : IParseStrategy
    {
        public async Task<BaseDto> Parse(string text)
        {
            text = text.Trim();

            var pattern = OperationContants.IncreaseTime + OperationContants.Pattern;

            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.ExplicitCapture);

            IncreaseTimeDto increaseTimeDto = new();

            int i = 0;

            //Tokenlarda gez ve uygunluğuna ve sırasına göre değerleri al
            foreach (Match m in matches)
            {
                var intValue = m.Groups["integer"].Value;

                if (!string.IsNullOrEmpty(intValue))
                {
                    Singleton.Instance.SimulateDate = Singleton.Instance.SimulateDate.AddHours(Convert.ToInt32(intValue));
                    var formattedDate = $"{Singleton.Instance.SimulateDate:hh:mm}";
                    increaseTimeDto.Time = formattedDate;
                }

                i++;
            }

            return await Task.FromResult(increaseTimeDto);
        }
    }
}
