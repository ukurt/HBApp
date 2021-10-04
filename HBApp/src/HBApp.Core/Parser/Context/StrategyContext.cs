using HBApp.Core.Dto;
using System.Threading.Tasks;

namespace HBApp.Core.ParseStrategy
{
    public class StrategyContext
    {
        private IParseStrategy _parseStrategy;

        public void SetStrategy(IParseStrategy parseStrategy)
        {
            _parseStrategy = parseStrategy;
        }

        public async Task<BaseDto> Execute(string text)
        {
            return await _parseStrategy.Parse(text);
        }
    }
}
