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
	public class EstablecimientoCategoriaApplication:IEstablecimientoCategoriaApplication
	{
		private readonly IEstablecimientoCategoriaDomain _establecimientoCategoriaDomain;
		private readonly IMapper _mapper;
		private readonly IAppLogger<EstablecimientoCategoriaApplication> _logger;

		public EstablecimientoCategoriaApplication(IEstablecimientoCategoriaDomain establecimientoCategoriaDomain, IMapper mapper, IAppLogger<EstablecimientoCategoriaApplication> logger)
		{
			_establecimientoCategoriaDomain = establecimientoCategoriaDomain;
			_mapper = mapper;
			_logger = logger;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoCategoria = _mapper.Map<EstablecimientoCategoria>(establecimientoCategoriaDTO);
				responseQuery = _establecimientoCategoriaDomain.Insert(establecimientoCategoria);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public ResponseQuery Update(EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoCategoria = _mapper.Map<EstablecimientoCategoria>(establecimientoCategoriaDTO);
				responseQuery = _establecimientoCategoriaDomain.Update(establecimientoCategoria);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public ResponseQuery Delete(EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoCategoria = _mapper.Map<EstablecimientoCategoria>(establecimientoCategoriaDTO);
				responseQuery = _establecimientoCategoriaDomain.Delete(establecimientoCategoria);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public Response<EstablecimientoCategoriaDTO> Get(string co_establecimiento_clase,string co_establecimiento_subclase,string co_establecimiento_categoria)
		{
			var response = new Response<EstablecimientoCategoriaDTO>();
			try
			{
				var establecimientoCategoria = _establecimientoCategoriaDomain.Get( co_establecimiento_clase, co_establecimiento_subclase, co_establecimiento_categoria);
				response.Data = _mapper.Map<EstablecimientoCategoriaDTO>(establecimientoCategoria);
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
		public Response<IEnumerable<EstablecimientoCategoriaDTO>> GetAll(EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			var response = new Response<IEnumerable<EstablecimientoCategoriaDTO>>();
			try
			{
			var establecimientoCategoria = _mapper.Map<EstablecimientoCategoria>(establecimientoCategoriaDTO);
			var establecimientoCategorias = _establecimientoCategoriaDomain.GetAll(establecimientoCategoria);
			response.Data = _mapper.Map<IEnumerable<EstablecimientoCategoriaDTO>>(establecimientoCategorias);
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

		public async Task<ResponseQuery> InsertAsync(EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoCategoria = _mapper.Map<EstablecimientoCategoria>(establecimientoCategoriaDTO);
				responseQuery = await _establecimientoCategoriaDomain.InsertAsync(establecimientoCategoria);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<ResponseQuery> UpdateAsync(EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoCategoria = _mapper.Map<EstablecimientoCategoria>(establecimientoCategoriaDTO);
				responseQuery = await _establecimientoCategoriaDomain.UpdateAsync(establecimientoCategoria);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<ResponseQuery> DeleteAsync(EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var establecimientoCategoria = _mapper.Map<EstablecimientoCategoria>(establecimientoCategoriaDTO);
				responseQuery = await _establecimientoCategoriaDomain.DeleteAsync(establecimientoCategoria);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<Response<EstablecimientoCategoriaDTO>> GetAsync(string co_establecimiento_clase,string co_establecimiento_subclase,string co_establecimiento_categoria)
		{
			var response = new Response<EstablecimientoCategoriaDTO>();
			try
			{
				var establecimientoCategoria = await _establecimientoCategoriaDomain.GetAsync( co_establecimiento_clase, co_establecimiento_subclase, co_establecimiento_categoria);
				response.Data = _mapper.Map<EstablecimientoCategoriaDTO>(establecimientoCategoria);
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
		public async Task<Response<IEnumerable<EstablecimientoCategoriaDTO>>> GetAllAsync(EstablecimientoCategoriaDTO establecimientoCategoriaDTO)
		{
			var response = new Response<IEnumerable<EstablecimientoCategoriaDTO>>();
			try
			{
				var establecimientoCategoria = _mapper.Map<EstablecimientoCategoria>(establecimientoCategoriaDTO);
				var establecimientoCategorias = await _establecimientoCategoriaDomain.GetAllAsync(establecimientoCategoria);
				response.Data = _mapper.Map<IEnumerable<EstablecimientoCategoriaDTO>>(establecimientoCategorias);
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