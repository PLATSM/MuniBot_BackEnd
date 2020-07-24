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
	public class EstablecimientoCategoriaController:Controller
	{
		private readonly IEstablecimientoCategoriaApplication _establecimientoCategoriaApplication;
		private readonly AppSettings _appSettings;

		public EstablecimientoCategoriaController(IEstablecimientoCategoriaApplication establecimientoCategoriaApplication, IOptions<AppSettings> appSettings)
		{
			_establecimientoCategoriaApplication = establecimientoCategoriaApplication;
			_appSettings = appSettings.Value;
		}

		#region Metodos Sincronos

		[HttpPost("Insert")]
		public IActionResult Insert([FromBody]EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoCategoriaDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "establecimientoCategoriaDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _establecimientoCategoriaApplication.Insert(establecimientoCategoriaDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("Update")]
		public IActionResult Update([FromBody]EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoCategoriaDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "establecimientoCategoriaDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _establecimientoCategoriaApplication.Update(establecimientoCategoriaDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("Delete")]
		public IActionResult Delete([FromBody]EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoCategoriaDTO.co_establecimiento_clase == "")
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "co_establecimiento_clase tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}			if (establecimientoCategoriaDTO.co_establecimiento_subclase == "")
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "co_establecimiento_subclase tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}			if (establecimientoCategoriaDTO.co_establecimiento_categoria == "")
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "co_establecimiento_categoria tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _establecimientoCategoriaApplication.Delete(establecimientoCategoriaDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPost("Get")]
		public IActionResult Get([FromBody]EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			if (establecimientoCategoriaDTO.co_establecimiento_clase == "")
				return BadRequest();

			if (establecimientoCategoriaDTO.co_establecimiento_subclase == "")
				return BadRequest();

			if (establecimientoCategoriaDTO.co_establecimiento_categoria == "")
				return BadRequest();

			var response = _establecimientoCategoriaApplication.Get(establecimientoCategoriaDTO.co_establecimiento_clase, establecimientoCategoriaDTO.co_establecimiento_subclase, establecimientoCategoriaDTO.co_establecimiento_categoria);
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
		public IActionResult GetAll([FromBody]EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			var response = _establecimientoCategoriaApplication.GetAll(establecimientoCategoriaDTO);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}

		#endregion

		#region Metodos Asincronos

		[HttpPost("InsertAsync")]
		public async Task<IActionResult> InsertAsync([FromBody]EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoCategoriaDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "establecimientoCategoriaDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _establecimientoCategoriaApplication.InsertAsync(establecimientoCategoriaDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("UpdateAsync")]
		public async Task<IActionResult> UpdateAsync([FromBody]EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoCategoriaDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "establecimientoCategoriaDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _establecimientoCategoriaApplication.UpdateAsync(establecimientoCategoriaDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("DeleteAsync")]
		public async Task<IActionResult> DeleteAsync([FromBody]EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (establecimientoCategoriaDTO.co_establecimiento_clase == "")
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "co_establecimiento_clase tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}			if (establecimientoCategoriaDTO.co_establecimiento_subclase == "")
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "co_establecimiento_subclase tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}			if (establecimientoCategoriaDTO.co_establecimiento_categoria == "")
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "co_establecimiento_categoria tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _establecimientoCategoriaApplication.DeleteAsync(establecimientoCategoriaDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPost("GetAsync")]
		public async Task<IActionResult> GetAsync([FromBody]EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			if (establecimientoCategoriaDTO.co_establecimiento_clase == "")
				return BadRequest();

			if (establecimientoCategoriaDTO.co_establecimiento_subclase == "")
				return BadRequest();

			if (establecimientoCategoriaDTO.co_establecimiento_categoria == "")
				return BadRequest();

			var response = await _establecimientoCategoriaApplication.GetAsync(establecimientoCategoriaDTO.co_establecimiento_clase, establecimientoCategoriaDTO.co_establecimiento_subclase, establecimientoCategoriaDTO.co_establecimiento_categoria);
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
		public async Task<IActionResult> GetAllAsync([FromBody]EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			var response = await _establecimientoCategoriaApplication.GetAllAsync(establecimientoCategoriaDTO);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}
	}
	#endregion

}