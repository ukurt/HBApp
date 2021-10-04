using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBApp.Core.Helper
{
    public static class StringHelper
    {
        public static string SplitAndGetFirst(string text)
        {
            var splitted = text.Split(" ");
            if (splitted != null && splitted.Any())
            {
                return splitted[0];
            }

            return null;
        }
    }
}
