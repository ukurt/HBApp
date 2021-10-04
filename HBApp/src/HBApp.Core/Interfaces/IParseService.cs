using HBApp.Core.Dto;
using System.Threading.Tasks;

namespace HBApp.Core.Interfaces
{
    public interface IParseService
    {
        Task<BaseDto> Parse(string text);
    }
}
