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
