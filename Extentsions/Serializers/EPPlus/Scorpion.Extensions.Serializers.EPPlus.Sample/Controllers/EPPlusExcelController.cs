﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scorpion.Extensions.Serializers.Abstractions;
using Scorpion.Extensions.Serializers.EPPlus.Sample.Models;

namespace Scorpion.Extensions.Serializers.EPPlus.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EPPlusExcelController : ControllerBase
    {
        private readonly IExcelSerializer _excelSerializer;

        public EPPlusExcelController(IExcelSerializer excelSerializer)
        {
            _excelSerializer = excelSerializer;
        }

        [HttpPut("ToList")]
        public IActionResult ToList(IFormFile file)
        {
            if (file.Length > 0)
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();

                    return Ok(_excelSerializer.ExcelToList<ExcelModel>(fileBytes));
                }

            return Ok();
        }

        [HttpGet("ToExcel")]
        public IActionResult ToExcel([FromQuery] List<string> model)
        {
            if (model == null || !model.Any()) return Ok();

            var services = model.Select(s => new ExcelModel() { Title = s }).ToList();

            var result = _excelSerializer.ListToExcelByteArray(services);

            return File(result, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "services.xlsx");
        }
    }
}
