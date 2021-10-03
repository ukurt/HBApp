using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBApp.Core.ParseStrategy
{
    public interface IParseStrategy
    {
        Task<string> Parse(string text);
    }
}
