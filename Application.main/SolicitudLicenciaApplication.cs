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
    public class SolicitudLicenciaApplication : ISolicitudLicenciaApplication
    {
        private readonly ISolicitudLicenciaDomain _solicitudLicenciaDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<SolicitudLicenciaApplication> _logger;

        public SolicitudLicenciaApplication(ISolicitudLicenciaDomain solicitudLicenciaDomain, IMapper mapper, IAppLogger<SolicitudLicenciaApplication> logger)
        {
            _solicitudLicenciaDomain = solicitudLicenciaDomain;
            _mapper = mapper;
            _logger = logger;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            var response = new Response<bool>();
            try
            {
                var solicitudLicencia = _mapper.Map<SolicitudLicencia>(solicitudLicenciaDTO);
                response.Data = _solicitudLicenciaDomain.Insert(solicitudLicencia);
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
        public Response<bool> Update(SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            var response = new Response<bool>();
            try
            {
                var solicitudLicencia = _mapper.Map<SolicitudLicencia>(solicitudLicenciaDTO);
                response.Data = _solicitudLicenciaDomain.Update(solicitudLicencia);
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
        public Response<bool> Delete(SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            var response = new Response<bool>();
            try
            {
                var solicitudLicencia = _mapper.Map<SolicitudLicencia>(solicitudLicenciaDTO);
                response.Data = _solicitudLicenciaDomain.Delete(solicitudLicencia);
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

        public Response<SolicitudLicenciaDTO> Get(int id_solicitudLicencia)
        {
            var response = new Response<SolicitudLicenciaDTO>();
            try
            {
                var solicitudLicencia = _solicitudLicenciaDomain.Get(id_solicitudLicencia);
                response.Data = _mapper.Map<SolicitudLicenciaDTO>(solicitudLicencia);
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

        public Response<IEnumerable<SolicitudLicenciaDTO>> GetAll(SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            var response = new Response<IEnumerable<SolicitudLicenciaDTO>>();
            try
            {
                var solicitudLicencia = _mapper.Map<SolicitudLicencia>(solicitudLicenciaDTO);
                var solicitudLicencias = _solicitudLicenciaDomain.GetAll(solicitudLicencia);
                response.Data = _mapper.Map<IEnumerable<SolicitudLicenciaDTO>>(solicitudLicencias);
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
        public async Task<ResponseQuery> InsertAsync(SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            ResponseQuery responseQuery = new ResponseQuery();
            try
            {
                var solicitudLicencia = _mapper.Map<SolicitudLicencia>(solicitudLicenciaDTO);
                responseQuery = await _solicitudLicenciaDomain.InsertAsync(solicitudLicencia);
            }
            catch (Exception e)
            {
                responseQuery.error_number = -1;
                responseQuery.error_message = e.Message;
            }
            return responseQuery;
        }

        public async Task<ResponseQuery> UpdateAsync(SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            ResponseQuery responseQuery = new ResponseQuery();
            try
            {
                var solicitudLicencia = _mapper.Map<SolicitudLicencia>(solicitudLicenciaDTO);
                responseQuery = await _solicitudLicenciaDomain.UpdateAsync(solicitudLicencia);
            }
            catch (Exception e)
            {
                responseQuery.error_number = -1;
                responseQuery.error_message = e.Message;
            }
            return responseQuery;
        }
        public async Task<ResponseQuery> DeleteAsync(SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            ResponseQuery responseQuery = new ResponseQuery();
            try
            {
                var solicitudLicencia = _mapper.Map<SolicitudLicencia>(solicitudLicenciaDTO);
                responseQuery = await _solicitudLicenciaDomain.DeleteAsync(solicitudLicencia);
            }
            catch (Exception e)
            {
                responseQuery.error_number = -1;
                responseQuery.error_message = e.Message;
            }
            return responseQuery;
        }

        public async Task<Response<SolicitudLicenciaDTO>> GetAsync(int id_solicitudLicencia, int id_contribuyente, string nu_solicitud_licencia)
        {
            var response = new Response<SolicitudLicenciaDTO>();

            try
            {
                var solicitudLicencia = await _solicitudLicenciaDomain.GetAsync(id_solicitudLicencia, id_contribuyente, nu_solicitud_licencia);
                response.Data = _mapper.Map<SolicitudLicenciaDTO>(solicitudLicencia);
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

        public async Task<Response<IEnumerable<SolicitudLicenciaDTO>>> GetAllAsync(SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            var response = new Response<IEnumerable<SolicitudLicenciaDTO>>();
            try
            {
                var solicitudLicencia = _mapper.Map<SolicitudLicencia>(solicitudLicenciaDTO);
                var solicitudLicencias = await _solicitudLicenciaDomain.GetAllAsync(solicitudLicencia);
                response.Data = _mapper.Map<IEnumerable<SolicitudLicenciaDTO>>(solicitudLicencias);
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
