using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBApp.Core.Dto
{
    public class IncreaseTimeDto : BaseDto
    {
        public string Time { get; set; }

        public override string ToString()
        {
            return $"Time is {Time}";
        }

    }
}
