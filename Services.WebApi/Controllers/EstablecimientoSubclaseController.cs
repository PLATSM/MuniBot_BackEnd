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
	public class EstablecimientoSubclaseController:Controller
	{
		private readonly IEstablecimientoSubclaseApplication _establecimientoSubclaseApplication;
		private readonly AppSettings _appSettings;

		public EstablecimientoSubclaseController(IEstablecimientoSubclaseApplication establecimientoSubclaseApplication, IOptions<AppSettings> appSettings)
		{
			_establecimientoSubclaseApplication = establecimientoSubclaseApplication;
			_appSettings = appSettings.Value;
		}

		#region Metodos Sincronos

		[HttpPost("Insert")]
		public IActionResult Insert([FromBody]EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoSubclaseDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "establecimientoSubclaseDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _establecimientoSubclaseApplication.Insert(establecimientoSubclaseDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("Update")]
		public IActionResult Update([FromBody]EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoSubclaseDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "establecimientoSubclaseDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _establecimientoSubclaseApplication.Update(establecimientoSubclaseDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("Delete")]
		public IActionResult Delete([FromBody]EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoSubclaseDTO.co_establecimiento_clase == "")
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "co_establecimiento_clase tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}			if (establecimientoSubclaseDTO.co_establecimiento_subclase == "")
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "co_establecimiento_subclase tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _establecimientoSubclaseApplication.Delete(establecimientoSubclaseDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPost("Get")]
		public IActionResult Get([FromBody]EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			if (establecimientoSubclaseDTO.co_establecimiento_clase == "")
				return BadRequest();

			if (establecimientoSubclaseDTO.co_establecimiento_subclase == "")
				return BadRequest();

			var response = _establecimientoSubclaseApplication.Get(establecimientoSubclaseDTO.co_establecimiento_clase, establecimientoSubclaseDTO.co_establecimiento_subclase);
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
		public IActionResult GetAll([FromBody]EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			var response = _establecimientoSubclaseApplication.GetAll(establecimientoSubclaseDTO);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}

		#endregion

		#region Metodos Asincronos

		[HttpPost("InsertAsync")]
		public async Task<IActionResult> InsertAsync([FromBody]EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoSubclaseDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "establecimientoSubclaseDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _establecimientoSubclaseApplication.InsertAsync(establecimientoSubclaseDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("UpdateAsync")]
		public async Task<IActionResult> UpdateAsync([FromBody]EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoSubclaseDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "establecimientoSubclaseDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _establecimientoSubclaseApplication.UpdateAsync(establecimientoSubclaseDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("DeleteAsync")]
		public async Task<IActionResult> DeleteAsync([FromBody]EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoSubclaseDTO.co_establecimiento_clase == "")
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "co_establecimiento_clase tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}			if (establecimientoSubclaseDTO.co_establecimiento_subclase == "")
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "co_establecimiento_subclase tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _establecimientoSubclaseApplication.DeleteAsync(establecimientoSubclaseDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPost("GetAsync")]
		public async Task<IActionResult> GetAsync([FromBody]EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			if (establecimientoSubclaseDTO.co_establecimiento_clase == "")
				return BadRequest();

			if (establecimientoSubclaseDTO.co_establecimiento_subclase == "")
				return BadRequest();

			var response = await _establecimientoSubclaseApplication.GetAsync(establecimientoSubclaseDTO.co_establecimiento_clase, establecimientoSubclaseDTO.co_establecimiento_subclase);
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
		public async Task<IActionResult> GetAllAsync([FromBody]EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			var response = await _establecimientoSubclaseApplication.GetAllAsync(establecimientoSubclaseDTO);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}
	}
	#endregion

}