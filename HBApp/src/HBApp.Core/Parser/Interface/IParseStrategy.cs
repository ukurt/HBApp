using HBApp.Core.Dto;
using System.Threading.Tasks;

namespace HBApp.Core.ParseStrategy
{
    public interface IParseStrategy
    {
        Task<BaseDto> Parse(string text);
    }
}
