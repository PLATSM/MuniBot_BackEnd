using System;
using AutoMapper;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Application.Interface;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Domain.Interface;
using MuniBot_BackEnd.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MuniBot_BackEnd.Application.Main
{
    public class ContribuyenteApplication : IContribuyenteApplication
    {
        private readonly IContribuyenteDomain _contribuyenteDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ContribuyenteApplication> _logger;

        public ContribuyenteApplication(IContribuyenteDomain contribuyenteDomain, IMapper mapper, IAppLogger<ContribuyenteApplication> logger)
        {
            _contribuyenteDomain = contribuyenteDomain;
            _mapper = mapper;
            _logger = logger;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(ContribuyenteDTO contribuyenteDTO)
        {
            var response = new Response<bool>();
            try
            {
                var contribuyente = _mapper.Map<Contribuyente>(contribuyenteDTO);
                response.Data = _contribuyenteDomain.Insert(contribuyente);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.error_message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.error_message = e.Message;
            }
            return response;
        }
        public Response<bool> Update(ContribuyenteDTO contribuyenteDTO)
        {
            var response = new Response<bool>();
            try
            {
                var contribuyente = _mapper.Map<Contribuyente>(contribuyenteDTO);
                response.Data = _contribuyenteDomain.Update(contribuyente);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.error_message = "Actualización Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.error_message = e.Message;
            }
            return response;
        }
        public Response<bool> Delete(ContribuyenteDTO contribuyenteDTO)
        {
            var response = new Response<bool>();
            try
            {
                var contribuyente = _mapper.Map<Contribuyente>(contribuyenteDTO);
                response.Data = _contribuyenteDomain.Delete(contribuyente);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.error_message = "Eliminación Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.error_message = e.Message;
            }
            return response;
        }

        public Response<ContribuyenteDTO> Get(int id_contribuyente)
        {
            var response = new Response<ContribuyenteDTO>();
            try
            {
                var contribuyente = _contribuyenteDomain.Get(id_contribuyente);
                response.Data = _mapper.Map<ContribuyenteDTO>(contribuyente);
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

        public Response<ContribuyenteDTO> GetLogin(string co_usuario, string no_contrasena)
        {
            var response = new Response<ContribuyenteDTO>();
            if (string.IsNullOrEmpty(co_usuario) || string.IsNullOrEmpty(no_contrasena))
            {
                response.error_message = "Parámetros no pueden ser vácios";
                return response;
            }
            
            try
            {
                var contribuyente = _contribuyenteDomain.GetLogin(co_usuario,no_contrasena);
                response.Data = _mapper.Map<ContribuyenteDTO>(contribuyente);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.error_message = "Autenticación Exitosa!!!";
                }
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.error_message = "Contribuyente no existe.";
            }
            catch (Exception e)
            {
                response.error_message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<ContribuyenteDTO>> GetAll(ContribuyenteDTO contribuyenteDTO)
        {
            var response = new Response<IEnumerable<ContribuyenteDTO>>();
            try
            {
                var contribuyente = _mapper.Map<Contribuyente>(contribuyenteDTO);
                var contribuyentes = _contribuyenteDomain.GetAll(contribuyente);
                response.Data = _mapper.Map<IEnumerable<ContribuyenteDTO>>(contribuyentes);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.error_message = "Consulta Exitosa!!!";
                    _logger.LogInformation("Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.error_message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        #endregion

        #region Métodos Asíncronos
        public async Task<ResponseQuery> InsertAsync(ContribuyenteDTO contribuyenteDTO)
        {
            ResponseQuery responseQuery = new ResponseQuery();
            try
            {
                var contribuyente = _mapper.Map<Contribuyente>(contribuyenteDTO);
                responseQuery = await _contribuyenteDomain.InsertAsync(contribuyente);
            }
            catch (Exception e)
            {
                responseQuery.error_number = -1;
                responseQuery.error_message = e.Message;
            }
            return responseQuery;
        }

        public async Task<ResponseQuery> UpdateAsync(ContribuyenteDTO contribuyenteDTO)
        {
            ResponseQuery responseQuery = new ResponseQuery();
            try
            {
                var contribuyente = _mapper.Map<Contribuyente>(contribuyenteDTO);
                responseQuery = await _contribuyenteDomain.UpdateAsync(contribuyente);
            }
            catch (Exception e)
            {
                responseQuery.error_number = -1;
                responseQuery.error_message = e.Message;
            }
            return responseQuery;
        }
        public async Task<ResponseQuery> DeleteAsync(ContribuyenteDTO contribuyenteDTO)
        {
            ResponseQuery responseQuery = new ResponseQuery();
            try
            {
                var contribuyente = _mapper.Map<Contribuyente>(contribuyenteDTO);
                responseQuery = await _contribuyenteDomain.DeleteAsync(contribuyente);
            }
            catch (Exception e)
            {
                responseQuery.error_number = -1;
                responseQuery.error_message = e.Message;
            }
            return responseQuery;
        }

        public async Task<Response<ContribuyenteDTO>> GetAsync(int id_contribuyente)
        {
            var response = new Response<ContribuyenteDTO>();

            try
            {
                var contribuyente = await _contribuyenteDomain.GetAsync(id_contribuyente);
                response.Data = _mapper.Map<ContribuyenteDTO>(contribuyente);
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

        public async Task<Response<ContribuyenteDTO>> GetLoginAsync(string co_documento_identidad, string nu_documento_identidad, string no_contrasena)
        {
            var response = new Response<ContribuyenteDTO>();

            if (string.IsNullOrEmpty(co_documento_identidad) || string.IsNullOrEmpty(nu_documento_identidad) || string.IsNullOrEmpty(no_contrasena))
            {
                response.error_number = -1;
                response.error_message = "Parámetros no pueden ser vácios";
                return response;
            }

            try
            {
                var contribuyente = await _contribuyenteDomain.GetLoginAsync(co_documento_identidad, nu_documento_identidad, no_contrasena);
                response.Data = _mapper.Map<ContribuyenteDTO>(contribuyente);
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


        public async Task<Response<IEnumerable<ContribuyenteDTO>>> GetAllAsync(ContribuyenteDTO contribuyenteDTO)
        {
            var response = new Response<IEnumerable<ContribuyenteDTO>>();
            try
            {
                var contribuyente = _mapper.Map<Contribuyente>(contribuyenteDTO);
                var contribuyentes = await _contribuyenteDomain.GetAllAsync(contribuyente);
                response.Data = _mapper.Map<IEnumerable<ContribuyenteDTO>>(contribuyentes);
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
