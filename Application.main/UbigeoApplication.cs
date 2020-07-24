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
	public class UbigeoApplication:IUbigeoApplication
	{
		private readonly IUbigeoDomain _ubigeoDomain;
		private readonly IMapper _mapper;
		private readonly IAppLogger<UbigeoApplication> _logger;

		public UbigeoApplication(IUbigeoDomain ubigeoDomain, IMapper mapper, IAppLogger<UbigeoApplication> logger)
		{
			_ubigeoDomain = ubigeoDomain;
			_mapper = mapper;
			_logger = logger;
		}

		#region Metodos Sincronos

		public Response<UbigeoDTO> Get(string co_ubigeo)
		{
			var response = new Response<UbigeoDTO>();
			try
			{
				var ubigeo = _ubigeoDomain.Get( co_ubigeo);
				response.Data = _mapper.Map<UbigeoDTO>(ubigeo);
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
		public Response<IEnumerable<UbigeoDTO>> GetAll(UbigeoDTO ubigeoDTO)
		{
			var response = new Response<IEnumerable<UbigeoDTO>>();
			try
			{
			var ubigeo = _mapper.Map<Ubigeo>(ubigeoDTO);
			var ubigeos = _ubigeoDomain.GetAll(ubigeo);
			response.Data = _mapper.Map<IEnumerable<UbigeoDTO>>(ubigeos);
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

		public async Task<Response<UbigeoDTO>> GetAsync(string co_ubigeo)
		{
			var response = new Response<UbigeoDTO>();
			try
			{
				var ubigeo = await _ubigeoDomain.GetAsync( co_ubigeo);
				response.Data = _mapper.Map<UbigeoDTO>(ubigeo);
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
		public async Task<Response<IEnumerable<UbigeoDTO>>> GetAllAsync(UbigeoDTO ubigeoDTO)
		{
			var response = new Response<IEnumerable<UbigeoDTO>>();
			try
			{
				var ubigeo = _mapper.Map<Ubigeo>(ubigeoDTO);
				var ubigeos = await _ubigeoDomain.GetAllAsync(ubigeo);
				response.Data = _mapper.Map<IEnumerable<UbigeoDTO>>(ubigeos);
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