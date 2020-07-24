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
	public class EstablecimientoClaseController:Controller
	{
		private readonly IEstablecimientoClaseApplication _establecimientoClaseApplication;
		private readonly AppSettings _appSettings;

		public EstablecimientoClaseController(IEstablecimientoClaseApplication establecimientoClaseApplication, IOptions<AppSettings> appSettings)
		{
			_establecimientoClaseApplication = establecimientoClaseApplication;
			_appSettings = appSettings.Value;
		}

		#region Metodos Sincronos

		[HttpPost("Insert")]
		public IActionResult Insert([FromBody]EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoClaseDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "establecimientoClaseDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _establecimientoClaseApplication.Insert(establecimientoClaseDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("Update")]
		public IActionResult Update([FromBody]EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoClaseDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "establecimientoClaseDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _establecimientoClaseApplication.Update(establecimientoClaseDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("Delete")]
		public IActionResult Delete([FromBody]EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoClaseDTO.co_establecimiento_clase == "")
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "co_establecimiento_clase tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _establecimientoClaseApplication.Delete(establecimientoClaseDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPost("Get")]
		public IActionResult Get([FromBody]EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			if (establecimientoClaseDTO.co_establecimiento_clase == "")
				return BadRequest();

			var response = _establecimientoClaseApplication.Get(establecimientoClaseDTO.co_establecimiento_clase);
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
		public IActionResult GetAll([FromBody]EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			var response = _establecimientoClaseApplication.GetAll(establecimientoClaseDTO);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}

		#endregion

		#region Metodos Asincronos

		[HttpPost("InsertAsync")]
		public async Task<IActionResult> InsertAsync([FromBody]EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoClaseDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "establecimientoClaseDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _establecimientoClaseApplication.InsertAsync(establecimientoClaseDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("UpdateAsync")]
		public async Task<IActionResult> UpdateAsync([FromBody]EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoClaseDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "establecimientoClaseDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _establecimientoClaseApplication.UpdateAsync(establecimientoClaseDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("DeleteAsync")]
		public async Task<IActionResult> DeleteAsync([FromBody]EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoClaseDTO.co_establecimiento_clase == "")
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "co_establecimiento_clase tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _establecimientoClaseApplication.DeleteAsync(establecimientoClaseDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPost("GetAsync")]
		public async Task<IActionResult> GetAsync([FromBody]EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			if (establecimientoClaseDTO.co_establecimiento_clase == "")
				return BadRequest();

			var response = await _establecimientoClaseApplication.GetAsync(establecimientoClaseDTO.co_establecimiento_clase);
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
		public async Task<IActionResult> GetAllAsync([FromBody]EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			var response = await _establecimientoClaseApplication.GetAllAsync(establecimientoClaseDTO);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}
	}
	#endregion

}