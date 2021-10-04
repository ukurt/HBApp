using HBApp.Core.Dto;
using HBApp.Core.Interfaces;
using HBApp.Core.ParseStrategy;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class IncreaseTimeExecutor : IExecutor
    {
        public async Task<BaseDto> Execute(BaseDto baseDto)
        {
            return (IncreaseTimeDto)baseDto;
        }
    }
}
