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

        public ContribuyenteApplication(IContribuyenteDomain contribuyenteDomain, IMapper mapper)
        {
            _contribuyenteDomain = contribuyenteDomain;
            _mapper = mapper;
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
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
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
                    response.Message = "Actualización Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
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
                    response.Message = "Eliminación Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
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
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<ContribuyenteDTO> GetLogin(string co_usuario, string no_contrasena)
        {
            var response = new Response<ContribuyenteDTO>();
            if (string.IsNullOrEmpty(co_usuario) || string.IsNullOrEmpty(no_contrasena))
            {
                response.Message = "Parámetros no pueden ser vácios";
                return response;
            }
            
            try
            {
                var contribuyente = _contribuyenteDomain.GetLogin(co_usuario,no_contrasena);
                response.Data = _mapper.Map<ContribuyenteDTO>(contribuyente);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Autenticación Exitosa!!!";
                }
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Contribuyente no existe.";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
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
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        #endregion

        #region Métodos Asíncronos
        public async Task<Response<bool>> InsertAsync(ContribuyenteDTO contribuyenteDTO)
        {
            var response = new Response<bool>();
            try
            {
                var contribuyente = _mapper.Map<Contribuyente>(contribuyenteDTO);
                response.Data = await _contribuyenteDomain.InsertAsync(contribuyente);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(ContribuyenteDTO contribuyenteDTO)
        {
            var response = new Response<bool>();
            try
            {
                var contribuyente = _mapper.Map<Contribuyente>(contribuyenteDTO);
                response.Data = await _contribuyenteDomain.UpdateAsync(contribuyente);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(ContribuyenteDTO contribuyenteDTO)
        {
            var response = new Response<bool>();
            try
            {
                var contribuyente = _mapper.Map<Contribuyente>(contribuyenteDTO);
                response.Data = await _contribuyenteDomain.DeleteAsync(contribuyente);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
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
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<ContribuyenteDTO>> GetLoginAsync(string co_usuario, string no_contrasena)
        {
            var response = new Response<ContribuyenteDTO>();
            if (string.IsNullOrEmpty(co_usuario) || string.IsNullOrEmpty(no_contrasena))
            {
                response.Message = "Parámetros no pueden ser vácios";
                return response;
            }

            try
            {
                var contribuyente = await _contribuyenteDomain.GetLoginAsync(co_usuario, no_contrasena);
                response.Data = _mapper.Map<ContribuyenteDTO>(contribuyente);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Autenticación Exitosa!!!";
                }
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Contribuyente no existe.";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
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
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        #endregion
    }   
}
