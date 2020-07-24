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
	public class EstablecimientoClaseApplication:IEstablecimientoClaseApplication
	{
		private readonly IEstablecimientoClaseDomain _establecimientoClaseDomain;
		private readonly IMapper _mapper;
		private readonly IAppLogger<EstablecimientoClaseApplication> _logger;

		public EstablecimientoClaseApplication(IEstablecimientoClaseDomain establecimientoClaseDomain, IMapper mapper, IAppLogger<EstablecimientoClaseApplication> logger)
		{
			_establecimientoClaseDomain = establecimientoClaseDomain;
			_mapper = mapper;
			_logger = logger;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoClase = _mapper.Map<EstablecimientoClase>(establecimientoClaseDTO);
				responseQuery = _establecimientoClaseDomain.Insert(establecimientoClase);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public ResponseQuery Update(EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoClase = _mapper.Map<EstablecimientoClase>(establecimientoClaseDTO);
				responseQuery = _establecimientoClaseDomain.Update(establecimientoClase);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public ResponseQuery Delete(EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoClase = _mapper.Map<EstablecimientoClase>(establecimientoClaseDTO);
				responseQuery = _establecimientoClaseDomain.Delete(establecimientoClase);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public Response<EstablecimientoClaseDTO> Get(string co_establecimiento_clase)
		{
			var response = new Response<EstablecimientoClaseDTO>();
			try
			{
				var establecimientoClase = _establecimientoClaseDomain.Get( co_establecimiento_clase);
				response.Data = _mapper.Map<EstablecimientoClaseDTO>(establecimientoClase);
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
		public Response<IEnumerable<EstablecimientoClaseDTO>> GetAll(EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			var response = new Response<IEnumerable<EstablecimientoClaseDTO>>();
			try
			{
			var establecimientoClase = _mapper.Map<EstablecimientoClase>(establecimientoClaseDTO);
			var establecimientoClases = _establecimientoClaseDomain.GetAll(establecimientoClase);
			response.Data = _mapper.Map<IEnumerable<EstablecimientoClaseDTO>>(establecimientoClases);
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

		public async Task<ResponseQuery> InsertAsync(EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoClase = _mapper.Map<EstablecimientoClase>(establecimientoClaseDTO);
				responseQuery = await _establecimientoClaseDomain.InsertAsync(establecimientoClase);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<ResponseQuery> UpdateAsync(EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoClase = _mapper.Map<EstablecimientoClase>(establecimientoClaseDTO);
				responseQuery = await _establecimientoClaseDomain.UpdateAsync(establecimientoClase);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<ResponseQuery> DeleteAsync(EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoClase = _mapper.Map<EstablecimientoClase>(establecimientoClaseDTO);
				responseQuery = await _establecimientoClaseDomain.DeleteAsync(establecimientoClase);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<Response<EstablecimientoClaseDTO>> GetAsync(string co_establecimiento_clase)
		{
			var response = new Response<EstablecimientoClaseDTO>();
			try
			{
				var establecimientoClase = await _establecimientoClaseDomain.GetAsync( co_establecimiento_clase);
				response.Data = _mapper.Map<EstablecimientoClaseDTO>(establecimientoClase);
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
		public async Task<Response<IEnumerable<EstablecimientoClaseDTO>>> GetAllAsync(EstablecimientoClaseDTO establecimientoClaseDTO)
		{
			var response = new Response<IEnumerable<EstablecimientoClaseDTO>>();
			try
			{
				var establecimientoClase = _mapper.Map<EstablecimientoClase>(establecimientoClaseDTO);
				var establecimientoClases = await _establecimientoClaseDomain.GetAllAsync(establecimientoClase);
				response.Data = _mapper.Map<IEnumerable<EstablecimientoClaseDTO>>(establecimientoClases);
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