using System.Threading.Tasks;

namespace HBApp.Core.ParseStrategy
{
    public interface IParseStrategy
    {
        Task<string> Parse(string text);
    }
}
