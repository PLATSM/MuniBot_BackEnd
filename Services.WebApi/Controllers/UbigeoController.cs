using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Services.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Application.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace Services.WebApi.Controllers
{
	//[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UbigeoController:Controller
	{
		private readonly IUbigeoApplication _ubigeoApplication;
		private readonly AppSettings _appSettings;

		public UbigeoController(IUbigeoApplication ubigeoApplication, IOptions<AppSettings> appSettings)
		{
			_ubigeoApplication = ubigeoApplication;
			_appSettings = appSettings.Value;
		}

		#region Metodos Sincronos

		[HttpPost("Get")]
		public IActionResult Get([FromBody]UbigeoDTO ubigeoDTO)
		{
			if (ubigeoDTO.co_ubigeo == "")
				return BadRequest();

			var response = _ubigeoApplication.Get(ubigeoDTO.co_ubigeo);
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

		[HttpPost("GetAll")]
		public IActionResult GetAll([FromBody]UbigeoDTO ubigeoDTO)
		{
			var response = _ubigeoApplication.GetAll(ubigeoDTO);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}

		#endregion

		#region Metodos Asincronos

		[HttpPost("GetAsync")]
		public async Task<IActionResult> GetAsync([FromBody]UbigeoDTO ubigeoDTO)
		{
			if (ubigeoDTO.co_ubigeo == "")
				return BadRequest();

			var response = await _ubigeoApplication.GetAsync(ubigeoDTO.co_ubigeo);
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

		[HttpPost("GetAllAsync")]
		public async Task<IActionResult> GetAllAsync([FromBody]UbigeoDTO ubigeoDTO)
		{
			var response = await _ubigeoApplication.GetAllAsync(ubigeoDTO);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}
	}
	#endregion

}