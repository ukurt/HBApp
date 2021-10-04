using HBApp.Core.Dto;
using HBApp.Core.Interfaces;
using HBApp.Core.ParseStrategy;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class CreateOrderExecutor : IExecutor
    {
        IOrderService _orderService;
        public CreateOrderExecutor(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<BaseDto> Execute(BaseDto baseDto)
        {
            var dtoToExecute = (CreateOrderDto)baseDto;
            await _orderService.CreateOrderAsync(dtoToExecute);
            return dtoToExecute;
        }
    }
}
