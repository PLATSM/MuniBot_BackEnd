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
	public class GeneralDetController:Controller
	{
		private readonly IGeneralDetApplication _generalDetApplication;
		private readonly AppSettings _appSettings;

		public GeneralDetController(IGeneralDetApplication generalDetApplication, IOptions<AppSettings> appSettings)
		{
			_generalDetApplication = generalDetApplication;
			_appSettings = appSettings.Value;
		}

		#region Metodos Sincronos

		[HttpPost("Insert")]
		public IActionResult Insert([FromBody]GeneralDetDTO generalDetDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (generalDetDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "generalDetDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _generalDetApplication.Insert(generalDetDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("Update")]
		public IActionResult Update([FromBody]GeneralDetDTO generalDetDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (generalDetDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "generalDetDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _generalDetApplication.Update(generalDetDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("Delete")]
		public IActionResult Delete([FromBody]GeneralDetDTO generalDetDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (generalDetDTO.nu_general_cab == 0)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "nu_general_cab tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}			if (generalDetDTO.co_general_det == "")
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "co_general_det tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _generalDetApplication.Delete(generalDetDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPost("Get")]
		public IActionResult Get([FromBody]GeneralDetDTO generalDetDTO)
		{
			if (generalDetDTO.nu_general_cab == 0)
				return BadRequest();

			if (generalDetDTO.co_general_det == "")
				return BadRequest();

			var response = _generalDetApplication.Get(generalDetDTO.nu_general_cab, generalDetDTO.co_general_det);
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
		public IActionResult GetAll([FromBody]GeneralDetDTO generalDetDTO)
		{
			var response = _generalDetApplication.GetAll(generalDetDTO);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}

		#endregion

		#region Metodos Asincronos

		[HttpPost("InsertAsync")]
		public async Task<IActionResult> InsertAsync([FromBody]GeneralDetDTO generalDetDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (generalDetDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "generalDetDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _generalDetApplication.InsertAsync(generalDetDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("UpdateAsync")]
		public async Task<IActionResult> UpdateAsync([FromBody]GeneralDetDTO generalDetDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (generalDetDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "generalDetDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _generalDetApplication.UpdateAsync(generalDetDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("DeleteAsync")]
		public async Task<IActionResult> DeleteAsync([FromBody]GeneralDetDTO generalDetDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (generalDetDTO.nu_general_cab == 0)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "nu_general_cab tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}			if (generalDetDTO.co_general_det == "")
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "co_general_det tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _generalDetApplication.DeleteAsync(generalDetDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPost("GetAsync")]
		public async Task<IActionResult> GetAsync([FromBody]GeneralDetDTO generalDetDTO)
		{
			if (generalDetDTO.nu_general_cab == 0)
				return BadRequest();

			if (generalDetDTO.co_general_det == "")
				return BadRequest();

			var response = await _generalDetApplication.GetAsync(generalDetDTO.nu_general_cab, generalDetDTO.co_general_det);
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
		public async Task<IActionResult> GetAllAsync([FromBody]GeneralDetDTO generalDetDTO)
		{
			var response = await _generalDetApplication.GetAllAsync(generalDetDTO);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}
	}
	#endregion

}