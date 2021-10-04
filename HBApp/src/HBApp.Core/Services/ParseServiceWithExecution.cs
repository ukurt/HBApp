using HBApp.Core.Constant;
using HBApp.Core.Dto;
using HBApp.Core.Interfaces;
using HBApp.Core.ParseStrategy;
using System.Linq;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    //parse servisinde default davranışını bozmamak icin dekorator kullanıldı.
    public class ParseServiceWithExecution : IParseService
    {
        private readonly IParseService _innerParseService;

        //Set Executor eklenip onun execute edilmesi sağlanabilir.
        private readonly BaseExecutor _baseExecutor;

        public ParseServiceWithExecution(IParseService innerParseService)
        {
            _innerParseService = innerParseService;
        }

        //parse ve execute işlemi icin kullanılacak
        public async Task<BaseDto> Parse(string text)
        {
            var result = await  _innerParseService.Parse(text);
            await _baseExecutor.Execute(result);
            return result;
        }
    }
}
