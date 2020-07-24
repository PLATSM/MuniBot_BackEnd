using AutoMapper;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Application.Interface;
using MuniBot_BackEnd.Domain.Interface;
using MuniBot_BackEnd.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuniBot_BackEnd.Application.Main
{
    public class ReniecApplication: IReniecApplication
    {
        private readonly IReniecDomain _reniecDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ReniecApplication> _logger;

        public ReniecApplication(IReniecDomain reniecDomain, IMapper mapper, IAppLogger<ReniecApplication> logger)
        {
            _reniecDomain = reniecDomain;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<Response<ReniecDTO>> GetAsync(string nuDNI)
        {
            var response = new Response<ReniecDTO>();

            try
            {
                var reniec = await _reniecDomain.GetAsync(nuDNI);
                response.Data = _mapper.Map<ReniecDTO>(reniec);
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

    }
}
