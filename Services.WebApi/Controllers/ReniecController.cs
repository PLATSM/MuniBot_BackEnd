using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Application.Interface;
using Services.WebApi.Helpers;

namespace Services.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReniecController : ControllerBase
    {
        private readonly IReniecApplication _reniecApplication;
        private readonly AppSettings _appSettings;

        public ReniecController(IReniecApplication reniecApplication,IOptions<AppSettings> appSettings)
        {
            _reniecApplication = reniecApplication;
            _appSettings = appSettings.Value;
        }

        [HttpPost("GetAsync")]
        public async Task<IActionResult> GetAsync([FromBody]ReniecDTO reniecDTO)
        {
            if (string.IsNullOrEmpty(reniecDTO.nuDNI))
                return BadRequest();

            var response = await _reniecApplication.GetAsync(reniecDTO.nuDNI);
            if (response.IsSuccess)
            {
                if (response.Data.error_number == 0)
                {
                    return Ok(response);
                }
                else
                    return NotFound(response);
            }
            return BadRequest(response);
        }

    }
}