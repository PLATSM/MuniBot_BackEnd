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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyenteController : Controller
    {
        private readonly IContribuyenteApplication _contribuyenteApplication;
        private readonly AppSettings _appSettings;

        public ContribuyenteController(IContribuyenteApplication contribuyenteApplication, IOptions<AppSettings> appSettings)
        {
            _contribuyenteApplication = contribuyenteApplication;
            _appSettings = appSettings.Value;
        }

        #region "Métodos Sincronos"

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            if (contribuyenteDTO == null)
                return BadRequest();
            var response = _contribuyenteApplication.Insert(contribuyenteDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.error_message);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            if (contribuyenteDTO == null)
                return BadRequest();
            var response = _contribuyenteApplication.Update(contribuyenteDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.error_message);
        }

        [HttpPut("Delete")]
        public IActionResult Delete([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            if (contribuyenteDTO.id_contribuyente == 0)
                return BadRequest();
            var response = _contribuyenteApplication.Delete(contribuyenteDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.error_message);
        }

        [HttpPost("Get")]
        public IActionResult Get([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            if (contribuyenteDTO.id_contribuyente == 0)
                return BadRequest();
            var response = _contribuyenteApplication.Get(contribuyenteDTO.id_contribuyente);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.error_message);
        }

        [AllowAnonymous]
        [HttpPost("GetLogin")]
        public IActionResult GetLogin(ContribuyenteDTO contribuyenteDTO)
        {
            var response = _contribuyenteApplication.GetLogin(contribuyenteDTO.co_usuario, contribuyenteDTO.no_contrasena);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                    return NotFound(response.error_message);
            }
            return BadRequest(response.error_message);
        }

        [HttpPost("GetAll")]
        public IActionResult GetAll([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            var response = _contribuyenteApplication.GetAll(contribuyenteDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.error_message);
        }
        #endregion

        #region "Métodos Asincronos"

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            if (contribuyenteDTO == null)
            {
                responseQuery.error_number = -1;
                responseQuery.error_message = "contribuyenteDTO no puede ser nulo.";
                return BadRequest(responseQuery);
            }

            responseQuery = await _contribuyenteApplication.InsertAsync(contribuyenteDTO);
            if (responseQuery.error_number == 0)
                return Ok(responseQuery);

            return BadRequest(responseQuery);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            if (contribuyenteDTO == null)
            {
                responseQuery.error_number = -1;
                responseQuery.error_message = "contribuyenteDTO no puede ser nulo.";
                return BadRequest(responseQuery);
            }

            responseQuery = await _contribuyenteApplication.UpdateAsync(contribuyenteDTO);
            if (responseQuery.error_number == 0)
                return Ok(responseQuery);

            return BadRequest(responseQuery);
        }

        [HttpPut("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            if (contribuyenteDTO.id_contribuyente == 0)
            {
                responseQuery.error_number = -1;
                responseQuery.error_message = "id_contribuyente no puede ser cero";
                return BadRequest(responseQuery);
            }

            responseQuery = await _contribuyenteApplication.DeleteAsync(contribuyenteDTO);
            if (responseQuery.error_number == 0)
                return Ok(responseQuery);

            return BadRequest(responseQuery);
        }

        [HttpPost("GetAsync")]
        public async Task<IActionResult> GetAsync(ContribuyenteDTO contribuyenteDTO)
        {
            if (contribuyenteDTO.id_contribuyente == 0)
                return BadRequest(); 

            var response = await _contribuyenteApplication.GetAsync(contribuyenteDTO.id_contribuyente);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [AllowAnonymous]
        [HttpPost("GetLoginAsync")]
        public async Task<IActionResult> GetLoginAsync([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            var response = await _contribuyenteApplication.GetLoginAsync(contribuyenteDTO.co_documento_identidad, contribuyenteDTO.nu_documento_identidad, contribuyenteDTO.no_contrasena);
            if (response.IsSuccess)
            {
                if (response.Data.error_number == 0)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                    return NotFound(response);
            }
            return BadRequest(response);
        }

        [HttpPost("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            var response = await _contribuyenteApplication.GetAllAsync(contribuyenteDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.error_message);
        }

        private string BuildToken(Response<ContribuyenteDTO> contribuyenteDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, contribuyenteDto.Data.co_usuario.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            // Generar el token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

    }
    #endregion
}