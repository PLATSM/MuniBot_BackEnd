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
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController:Controller
	{
		private readonly IUsuarioApplication _usuarioApplication;
		private readonly AppSettings _appSettings;

		public UsuarioController(IUsuarioApplication usuarioApplication, IOptions<AppSettings> appSettings)
		{
			_usuarioApplication = usuarioApplication;
			_appSettings = appSettings.Value;
		}

		#region Metodos Sincronos

		[HttpPost("Insert")]
		public IActionResult Insert([FromBody]UsuarioDTO usuarioDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (usuarioDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "usuarioDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _usuarioApplication.Insert(usuarioDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("Update")]
		public IActionResult Update([FromBody]UsuarioDTO usuarioDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (usuarioDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "usuarioDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _usuarioApplication.Update(usuarioDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("Delete")]
		public IActionResult Delete([FromBody]UsuarioDTO usuarioDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (usuarioDTO.id_usuario == 0)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "id_usuario tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = _usuarioApplication.Delete(usuarioDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPost("Get")]
		public IActionResult Get([FromBody]UsuarioDTO usuarioDTO)
		{
			if (usuarioDTO.id_usuario == 0)
				return BadRequest();

			var response = _usuarioApplication.Get(usuarioDTO.id_usuario);
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
		public IActionResult GetAll([FromBody]UsuarioDTO usuarioDTO)
		{
			var response = _usuarioApplication.GetAll(usuarioDTO);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}

		#endregion

		#region Metodos Asincronos

		[HttpPost("InsertAsync")]
		public async Task<IActionResult> InsertAsync([FromBody]UsuarioDTO usuarioDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (usuarioDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "usuarioDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _usuarioApplication.InsertAsync(usuarioDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("UpdateAsync")]
		public async Task<IActionResult> UpdateAsync([FromBody]UsuarioDTO usuarioDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (usuarioDTO == null)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "usuarioDTO no puede ser nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _usuarioApplication.UpdateAsync(usuarioDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPut("DeleteAsync")]
		public async Task<IActionResult> DeleteAsync([FromBody]UsuarioDTO usuarioDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			if (usuarioDTO.id_usuario == 0)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = "id_usuario tiene un valor errado o nulo.";
				return BadRequest(responseQuery);
			}

			responseQuery = await _usuarioApplication.DeleteAsync(usuarioDTO);
			if (responseQuery.error_number == 0)
				return Ok(responseQuery);

			return BadRequest(responseQuery);
			}

		[HttpPost("GetAsync")]
		public async Task<IActionResult> GetAsync([FromBody]UsuarioDTO usuarioDTO)
		{
			if (usuarioDTO.id_usuario == 0)
				return BadRequest();

			var response = await _usuarioApplication.GetAsync(usuarioDTO.id_usuario);
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
		public async Task<IActionResult> GetAllAsync([FromBody]UsuarioDTO usuarioDTO)
		{
			var response = await _usuarioApplication.GetAllAsync(usuarioDTO);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}
	}
	#endregion

}