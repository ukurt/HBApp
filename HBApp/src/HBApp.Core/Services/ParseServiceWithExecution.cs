using HBApp.Core.Constant;
using HBApp.Core.Dto;
using HBApp.Core.Helper;
using HBApp.Core.Interfaces;
using HBApp.Core.ParseStrategy;
using System.Linq;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public delegate IExecutor ExecutorResolver(string constValue);

    //dekorator
    public class ParseServiceWithExecution : IParseService
    {
        private readonly IParseService _innerParseService;

        private IExecutor _executor = null;

        private ExecutorResolver _executorResolver { get; set; }

        public ParseServiceWithExecution(IParseService innerParseService, ExecutorResolver executorResolver)
        {
            _innerParseService = innerParseService;
            _executorResolver = executorResolver;
        }

        //parse ve execute işlemi icin kullanılacak
        public async Task<BaseDto> Parse(string text)
        {
            //Gelen text den olabildiğince tokenları doldur, eksikleri execute metodunda dolacak
            //ornegin get_campaign_info da Turnover yada Total Sales verisi gibi.
            var key = StringHelper.SplitAndGetFirst(text);

            if (!string.IsNullOrEmpty(key))
            {
                _executor = _executorResolver(key);

                var dto = await _innerParseService.Parse(text);

                return await _executor.Execute(dto);
            }

            return null;
        }
    }
}
