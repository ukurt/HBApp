using HBApp.Core;
using HBApp.Core.Helper;
using HBApp.Core.Interfaces;
using HBApp.Core.ParseStrategy;
using HBApp.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBApp.Web.Api
{
    public class ExecController : BaseApiController
    {
        IParseService _parseService;
        public ExecController(IParseService parseService)
        {
            _parseService = parseService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile formFile)
        {
            Singleton.Instance.SimulateDate = DateTime.MinValue;

            var stringBuilder = new StringBuilder();
            using (var stream = new StreamReader(formFile.OpenReadStream()))
            {
                while (!stream.EndOfStream)
                {
                    var text = await stream.ReadLineAsync();
                    var result = await _parseService.Parse(text);
                    var syntax = result.ToString();
                    stringBuilder.AppendLine(syntax);
                }
            }

            return Ok(stringBuilder.ToString());
        }
    }
}
