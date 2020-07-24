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
	public class EstablecimientoSubclaseApplication:IEstablecimientoSubclaseApplication
	{
		private readonly IEstablecimientoSubclaseDomain _establecimientoSubclaseDomain;
		private readonly IMapper _mapper;
		private readonly IAppLogger<EstablecimientoSubclaseApplication> _logger;

		public EstablecimientoSubclaseApplication(IEstablecimientoSubclaseDomain establecimientoSubclaseDomain, IMapper mapper, IAppLogger<EstablecimientoSubclaseApplication> logger)
		{
			_establecimientoSubclaseDomain = establecimientoSubclaseDomain;
			_mapper = mapper;
			_logger = logger;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoSubclase = _mapper.Map<EstablecimientoSubclase>(establecimientoSubclaseDTO);
				responseQuery = _establecimientoSubclaseDomain.Insert(establecimientoSubclase);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public ResponseQuery Update(EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoSubclase = _mapper.Map<EstablecimientoSubclase>(establecimientoSubclaseDTO);
				responseQuery = _establecimientoSubclaseDomain.Update(establecimientoSubclase);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public ResponseQuery Delete(EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoSubclase = _mapper.Map<EstablecimientoSubclase>(establecimientoSubclaseDTO);
				responseQuery = _establecimientoSubclaseDomain.Delete(establecimientoSubclase);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public Response<EstablecimientoSubclaseDTO> Get(string co_establecimiento_clase,string co_establecimiento_subclase)
		{
			var response = new Response<EstablecimientoSubclaseDTO>();
			try
			{
				var establecimientoSubclase = _establecimientoSubclaseDomain.Get( co_establecimiento_clase, co_establecimiento_subclase);
				response.Data = _mapper.Map<EstablecimientoSubclaseDTO>(establecimientoSubclase);
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
		public Response<IEnumerable<EstablecimientoSubclaseDTO>> GetAll(EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			var response = new Response<IEnumerable<EstablecimientoSubclaseDTO>>();
			try
			{
			var establecimientoSubclase = _mapper.Map<EstablecimientoSubclase>(establecimientoSubclaseDTO);
			var establecimientoSubclases = _establecimientoSubclaseDomain.GetAll(establecimientoSubclase);
			response.Data = _mapper.Map<IEnumerable<EstablecimientoSubclaseDTO>>(establecimientoSubclases);
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

		public async Task<ResponseQuery> InsertAsync(EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoSubclase = _mapper.Map<EstablecimientoSubclase>(establecimientoSubclaseDTO);
				responseQuery = await _establecimientoSubclaseDomain.InsertAsync(establecimientoSubclase);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<ResponseQuery> UpdateAsync(EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoSubclase = _mapper.Map<EstablecimientoSubclase>(establecimientoSubclaseDTO);
				responseQuery = await _establecimientoSubclaseDomain.UpdateAsync(establecimientoSubclase);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<ResponseQuery> DeleteAsync(EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoSubclase = _mapper.Map<EstablecimientoSubclase>(establecimientoSubclaseDTO);
				responseQuery = await _establecimientoSubclaseDomain.DeleteAsync(establecimientoSubclase);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<Response<EstablecimientoSubclaseDTO>> GetAsync(string co_establecimiento_clase,string co_establecimiento_subclase)
		{
			var response = new Response<EstablecimientoSubclaseDTO>();
			try
			{
				var establecimientoSubclase = await _establecimientoSubclaseDomain.GetAsync( co_establecimiento_clase, co_establecimiento_subclase);
				response.Data = _mapper.Map<EstablecimientoSubclaseDTO>(establecimientoSubclase);
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
		public async Task<Response<IEnumerable<EstablecimientoSubclaseDTO>>> GetAllAsync(EstablecimientoSubclaseDTO establecimientoSubclaseDTO)
		{
			var response = new Response<IEnumerable<EstablecimientoSubclaseDTO>>();
			try
			{
				var establecimientoSubclase = _mapper.Map<EstablecimientoSubclase>(establecimientoSubclaseDTO);
				var establecimientoSubclases = await _establecimientoSubclaseDomain.GetAllAsync(establecimientoSubclase);
				response.Data = _mapper.Map<IEnumerable<EstablecimientoSubclaseDTO>>(establecimientoSubclases);
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