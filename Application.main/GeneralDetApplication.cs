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
	public class GeneralDetApplication:IGeneralDetApplication
	{
		private readonly IGeneralDetDomain _generalDetDomain;
		private readonly IMapper _mapper;
		private readonly IAppLogger<GeneralDetApplication> _logger;

		public GeneralDetApplication(IGeneralDetDomain generalDetDomain, IMapper mapper, IAppLogger<GeneralDetApplication> logger)
		{
			_generalDetDomain = generalDetDomain;
			_mapper = mapper;
			_logger = logger;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(GeneralDetDTO generalDetDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var generalDet = _mapper.Map<GeneralDet>(generalDetDTO);
				responseQuery = _generalDetDomain.Insert(generalDet);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public ResponseQuery Update(GeneralDetDTO generalDetDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var generalDet = _mapper.Map<GeneralDet>(generalDetDTO);
				responseQuery = _generalDetDomain.Update(generalDet);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public ResponseQuery Delete(GeneralDetDTO generalDetDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var generalDet = _mapper.Map<GeneralDet>(generalDetDTO);
				responseQuery = _generalDetDomain.Delete(generalDet);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public Response<GeneralDetDTO> Get(int nu_general_cab,string co_general_det)
		{
			var response = new Response<GeneralDetDTO>();
			try
			{
				var generalDet = _generalDetDomain.Get( nu_general_cab, co_general_det);
				response.Data = _mapper.Map<GeneralDetDTO>(generalDet);
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
		public Response<IEnumerable<GeneralDetDTO>> GetAll(GeneralDetDTO generalDetDTO)
		{
			var response = new Response<IEnumerable<GeneralDetDTO>>();
			try
			{
			var generalDet = _mapper.Map<GeneralDet>(generalDetDTO);
			var generalDets = _generalDetDomain.GetAll(generalDet);
			response.Data = _mapper.Map<IEnumerable<GeneralDetDTO>>(generalDets);
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

		public async Task<ResponseQuery> InsertAsync(GeneralDetDTO generalDetDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var generalDet = _mapper.Map<GeneralDet>(generalDetDTO);
				responseQuery = await _generalDetDomain.InsertAsync(generalDet);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<ResponseQuery> UpdateAsync(GeneralDetDTO generalDetDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var generalDet = _mapper.Map<GeneralDet>(generalDetDTO);
				responseQuery = await _generalDetDomain.UpdateAsync(generalDet);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<ResponseQuery> DeleteAsync(GeneralDetDTO generalDetDTO)
		{
			ResponseQuery responseQuery = new ResponseQuery();
			try
			{
				var generalDet = _mapper.Map<GeneralDet>(generalDetDTO);
				responseQuery = await _generalDetDomain.DeleteAsync(generalDet);
			}
			catch (Exception e)
			{
				responseQuery.error_number = -1;
				responseQuery.error_message = e.Message;
			}
			return responseQuery;
		}
		public async Task<Response<GeneralDetDTO>> GetAsync(int nu_general_cab,string co_general_det)
		{
			var response = new Response<GeneralDetDTO>();
			try
			{
				var generalDet = await _generalDetDomain.GetAsync( nu_general_cab, co_general_det);
				response.Data = _mapper.Map<GeneralDetDTO>(generalDet);
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
		public async Task<Response<IEnumerable<GeneralDetDTO>>> GetAllAsync(GeneralDetDTO generalDetDTO)
		{
			var response = new Response<IEnumerable<GeneralDetDTO>>();
			try
			{
				var generalDet = _mapper.Map<GeneralDet>(generalDetDTO);
				var generalDets = await _generalDetDomain.GetAllAsync(generalDet);
				response.Data = _mapper.Map<IEnumerable<GeneralDetDTO>>(generalDets);
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