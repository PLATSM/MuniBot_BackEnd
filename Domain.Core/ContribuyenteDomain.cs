using System.Threading.Tasks;
using System.Collections.Generic;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Domain.Interface;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Domain.Core
{
    public class ContribuyenteDomain:IContribuyenteDomain
    {
        private readonly IContribuyenteRepository _contribuyenteRepository;

        public ContribuyenteDomain(IContribuyenteRepository contribuyenteRepository)
        {
            _contribuyenteRepository = contribuyenteRepository;
        }
        #region Métodos Sincronos

        public ResponseQuery Insert(Contribuyente contribuyente)
        {
            return _contribuyenteRepository.Insert(contribuyente);
        }

        public ResponseQuery Update(Contribuyente contribuyente)
        {
            return _contribuyenteRepository.Update(contribuyente);
        }

        public ResponseQuery Delete(Contribuyente contribuyente)
        {
            return _contribuyenteRepository.Delete(contribuyente);
        }

        public Contribuyente Get(int id_contribuyente)
        {
            return _contribuyenteRepository.Get(id_contribuyente);
        }

        public Contribuyente GetLogin(int id_empresa, string co_documento_identidad, string nu_documento_identidad, string no_contrasena)
        {
            return _contribuyenteRepository.GetLogin(id_empresa, co_documento_identidad, nu_documento_identidad, no_contrasena);
        }

        public IEnumerable<Contribuyente> GetAll(Contribuyente contribuyente)
        {
            return _contribuyenteRepository.GetAll(contribuyente);
        }

        #endregion

        #region Métodos Asincronos

        public async Task<ResponseQuery> InsertAsync(Contribuyente contribuyente)
        {
            return await _contribuyenteRepository.InsertAsync(contribuyente);
        }

        public async Task<ResponseQuery> UpdateAsync(Contribuyente contribuyente)
        {
            return await _contribuyenteRepository.UpdateAsync(contribuyente);
        }

        public async Task<ResponseQuery> DeleteAsync(Contribuyente contribuyente)
        {
            return await _contribuyenteRepository.DeleteAsync(contribuyente);
        }

        public async Task<Contribuyente> GetAsync(int id_contribuyente)
        {
            return await _contribuyenteRepository.GetAsync(id_contribuyente);
        }
        public async Task<DataJson> GetJsonAsync(int id_contribuyente)
        {
            return await _contribuyenteRepository.GetJsonAsync(id_contribuyente);
        }
        public async Task<Contribuyente> GetLoginAsync(int id_empresa, string co_documento_identidad, string nu_documento_identidad, string no_contrasena)
        {
            return await _contribuyenteRepository.GetLoginAsync(id_empresa, co_documento_identidad, nu_documento_identidad, no_contrasena);
        }

        public async Task<IEnumerable<Contribuyente>> GetAllAsync(Contribuyente contribuyente)
        {
            return await _contribuyenteRepository.GetAllAsync(contribuyente);
        }

        #endregion


    }
}
