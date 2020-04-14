using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Application.Interface;
using MuniBot_BackEnd.Transversal.Common;
using Services.WebApi.Helpers;
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

            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            if (contribuyenteDTO == null)
                return BadRequest();
            var response = _contribuyenteApplication.Update(contribuyenteDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Delete")]
        public IActionResult Delete([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            if (contribuyenteDTO.id_contribuyente == 0)
                return BadRequest();
            var response = _contribuyenteApplication.Delete(contribuyenteDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        //[HttpGet("Get")]
        [HttpPost("Get")]
        public IActionResult Get([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            if (contribuyenteDTO.id_contribuyente == 0)
                return BadRequest();
            var response = _contribuyenteApplication.Get(contribuyenteDTO.id_contribuyente);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
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
                    return NotFound(response.Message);
            }
            return BadRequest(response.Message);
        }

        //[HttpGet("GetAll")]
        [HttpPost("GetAll")]
        public IActionResult GetAll([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            var response = _contribuyenteApplication.GetAll(contribuyenteDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

        #region "Métodos Asincronos"

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            if (contribuyenteDTO == null)
                return BadRequest();
            var response = await _contribuyenteApplication.InsertAsync(contribuyenteDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            if (contribuyenteDTO == null)
                return BadRequest();
            var response = await _contribuyenteApplication.UpdateAsync(contribuyenteDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            if (contribuyenteDTO.id_contribuyente == 0)
                return BadRequest();
            var response = await _contribuyenteApplication.DeleteAsync(contribuyenteDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        //[HttpGet("GetAsync")]
        [HttpPost("GetAsync")]
        public async Task<IActionResult> GetAsync([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            if (contribuyenteDTO.id_contribuyente == 0)
                return BadRequest();
            var response = await _contribuyenteApplication.GetAsync(contribuyenteDTO.id_contribuyente);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [AllowAnonymous]
        [HttpPost("GetLoginAsync")]
        public async Task<IActionResult> GetLoginAsync([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            var response = await _contribuyenteApplication.GetLoginAsync(contribuyenteDTO.co_usuario, contribuyenteDTO.no_contrasena);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                    return NotFound(response.Message);
            }
            return BadRequest(response.Message);
        }

        //[HttpGet("GetAllAsync")]
        [HttpPost("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync([FromBody]ContribuyenteDTO contribuyenteDTO)
        {
            var response = await _contribuyenteApplication.GetAllAsync(contribuyenteDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
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
                Expires = DateTime.UtcNow.AddMinutes(1),
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