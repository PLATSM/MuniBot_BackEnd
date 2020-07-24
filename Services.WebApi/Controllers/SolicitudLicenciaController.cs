using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Application.Interface;
using MuniBot_BackEnd.Transversal.Common;
using Services.WebApi.Helpers;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudLicenciaController : Controller
    {
        private readonly ISolicitudLicenciaApplication _solicitudLicenciaApplication;
        private readonly AppSettings _appSettings;

        public SolicitudLicenciaController(ISolicitudLicenciaApplication solicitudLicenciaApplication, IOptions<AppSettings> appSettings)
        {
            _solicitudLicenciaApplication = solicitudLicenciaApplication;
            _appSettings = appSettings.Value;
        }

        #region "Métodos Sincronos"

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody]SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            if (solicitudLicenciaDTO == null)
                return BadRequest();
            var response = _solicitudLicenciaApplication.Insert(solicitudLicenciaDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.error_message);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody]SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            if (solicitudLicenciaDTO == null)
                return BadRequest();
            var response = _solicitudLicenciaApplication.Update(solicitudLicenciaDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.error_message);
        }

        [HttpPut("Delete")]
        public IActionResult Delete([FromBody]SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            if (solicitudLicenciaDTO.id_solicitud_licencia == 0)
                return BadRequest();
            var response = _solicitudLicenciaApplication.Delete(solicitudLicenciaDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.error_message);
        }

        [HttpPost("Get")]
        public IActionResult Get([FromBody]SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            if (solicitudLicenciaDTO.id_solicitud_licencia == 0)
                return BadRequest();
            var response = _solicitudLicenciaApplication.Get(solicitudLicenciaDTO.id_solicitud_licencia);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.error_message);
        }

        [HttpPost("GetAll")]
        public IActionResult GetAll([FromBody]SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            var response = _solicitudLicenciaApplication.GetAll(solicitudLicenciaDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.error_message);
        }
        #endregion

        #region "Métodos Asincronos"

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody]SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            if (solicitudLicenciaDTO == null)
            {
                responseQuery.error_number = -1;
                responseQuery.error_message = "solicitudLicenciaDTO no puede ser nulo.";
                return BadRequest(responseQuery);
            }

            responseQuery = await _solicitudLicenciaApplication.InsertAsync(solicitudLicenciaDTO);
            if (responseQuery.error_number == 0)
                return Ok(responseQuery);

            return BadRequest(responseQuery);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody]SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            if (solicitudLicenciaDTO == null)
            {
                responseQuery.error_number = -1;
                responseQuery.error_message = "solicitudLicenciaDTO no puede ser nulo.";
                return BadRequest(responseQuery);
            }

            responseQuery = await _solicitudLicenciaApplication.UpdateAsync(solicitudLicenciaDTO);
            if (responseQuery.error_number == 0)
                return Ok(responseQuery);

            return BadRequest(responseQuery);
        }

        [HttpPut("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync([FromBody]SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            if (solicitudLicenciaDTO.id_solicitud_licencia == 0)
            {
                responseQuery.error_number = -1;
                responseQuery.error_message = "id_solicitud_licencia no puede ser cero";
                return BadRequest(responseQuery);
            }

            responseQuery = await _solicitudLicenciaApplication.DeleteAsync(solicitudLicenciaDTO);
            if (responseQuery.error_number == 0)
                return Ok(responseQuery);

            return BadRequest(responseQuery);
        }

        [HttpPost("GetAsync")]
        public async Task<IActionResult> GetAsync(SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            if 
            (
                solicitudLicenciaDTO.id_solicitud_licencia == 0 &&
                solicitudLicenciaDTO.id_contribuyente == 0 &&
                string.IsNullOrEmpty(solicitudLicenciaDTO.nu_solicitud_licencia)
            ) 
                return BadRequest(); 

            var response = await _solicitudLicenciaApplication.GetAsync(solicitudLicenciaDTO.id_solicitud_licencia, solicitudLicenciaDTO.id_contribuyente, solicitudLicenciaDTO.nu_solicitud_licencia);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPost("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync([FromBody]SolicitudLicenciaDTO solicitudLicenciaDTO)
        {
            var response = await _solicitudLicenciaApplication.GetAllAsync(solicitudLicenciaDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.error_message);
        }

    }
    #endregion
}