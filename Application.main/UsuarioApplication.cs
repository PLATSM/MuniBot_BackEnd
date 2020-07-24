using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Application.Interface;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Domain.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Application.Main
{
	public class UsuarioApplication:IUsuarioApplication
	{
		private readonly IUsuarioDomain _usuarioDomain;
		private readonly IMapper _mapper;
		private readonly IAppLogger<UsuarioApplication> _logger;

		public UsuarioApplication(IUsuarioDomain usuarioDomain, IMapper mapper, IAppLogger<UsuarioApplication> logger)
		{
			_usuarioDomain = usuarioDomain;
			_mapper = mapper;
			_logger = logger;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(UsuarioDTO usuarioDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var usuario = _mapper.Map<Usuario>(usuarioDTO);
				responseQuery = _usuarioDomain.Insert(usuario);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public ResponseQuery Update(UsuarioDTO usuarioDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var usuario = _mapper.Map<Usuario>(usuarioDTO);
				responseQuery = _usuarioDomain.Update(usuario);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public ResponseQuery Delete(UsuarioDTO usuarioDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var usuario = _mapper.Map<Usuario>(usuarioDTO);
				responseQuery = _usuarioDomain.Delete(usuario);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public Response<UsuarioDTO> Get(int id_usuario)
		{
			var response = new Response<UsuarioDTO>();
			try
			{
				var usuario = _usuarioDomain.Get( id_usuario);
				response.Data = _mapper.Map<UsuarioDTO>(usuario);
				if (response.Data != null)
				{
					response.IsSuccess = true;
					response.error_number = response.Data.error_number;
					response.error_message = response.Data.error_message;
				}
				else
				{
					response.IsSuccess = false;
					response.error_number = -1;
					response.error_message = "Ha ocurrido un error.";
				}
			}
			catch (Exception e)
			{
				response.IsSuccess = false;
				response.error_number = -1;
				response.error_message = e.Message;
			}
			return response;
		}
		public Response<IEnumerable<UsuarioDTO>> GetAll(UsuarioDTO usuarioDTO)
		{
			var response = new Response<IEnumerable<UsuarioDTO>>();
			try
			{
			var usuario = _mapper.Map<Usuario>(usuarioDTO);
			var usuarios = _usuarioDomain.GetAll(usuario);
			response.Data = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
			if (response.Data != null)
				{
				response.IsSuccess = true;
				response.error_message = "Consulta Exitosa!!!";
				}
			}
			catch (Exception e)
			{
				response.error_message = e.Message;
			}
			return response;
		}

		#endregion

		#region Metodos Asincronos

		public async Task<ResponseQuery> InsertAsync(UsuarioDTO usuarioDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var usuario = _mapper.Map<Usuario>(usuarioDTO);
				responseQuery = await _usuarioDomain.InsertAsync(usuario);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<ResponseQuery> UpdateAsync(UsuarioDTO usuarioDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var usuario = _mapper.Map<Usuario>(usuarioDTO);
				responseQuery = await _usuarioDomain.UpdateAsync(usuario);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<ResponseQuery> DeleteAsync(UsuarioDTO usuarioDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var usuario = _mapper.Map<Usuario>(usuarioDTO);
				responseQuery = await _usuarioDomain.DeleteAsync(usuario);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<Response<UsuarioDTO>> GetAsync(int id_usuario)
		{
			var response = new Response<UsuarioDTO>();
			try
			{
				var usuario = await _usuarioDomain.GetAsync( id_usuario);
				response.Data = _mapper.Map<UsuarioDTO>(usuario);
				if (response.Data != null)
				{
					response.IsSuccess = true;
					response.error_number = response.Data.error_number;
					response.error_message = response.Data.error_message;
				}
				else
				{
					response.IsSuccess = false;
					response.error_number = -1;
					response.error_message = "Ha ocurrido un error.";
				}
			}
			catch (Exception e)
			{
				response.IsSuccess = false;
				response.error_number = -1;
				response.error_message = e.Message;
			}
			return response;
		}
		public async Task<Response<IEnumerable<UsuarioDTO>>> GetAllAsync(UsuarioDTO usuarioDTO)
		{
			var response = new Response<IEnumerable<UsuarioDTO>>();
			try
			{
				var usuario = _mapper.Map<Usuario>(usuarioDTO);
				var usuarios = await _usuarioDomain.GetAllAsync(usuario);
				response.Data = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
				if (response.Data != null)
				{
					response.IsSuccess = true;
					response.error_message = "Consulta Exitosa!!!";
				}
			}
			catch (Exception e)
			{
				response.error_message = e.Message;
			}
			return response;
		}

		#endregion

	}
}