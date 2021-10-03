using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void Execute(string text)
        {
            _parseStrategy.Parse(text);
        }
    }
}
