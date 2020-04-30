using System;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Domain.Interface;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

using System.Threading.Tasks;
using System.Collections.Generic;

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

        public bool Insert(Contribuyente contribuyente)
        {
            return _contribuyenteRepository.Insert(contribuyente);
        }

        public bool Update(Contribuyente contribuyente)
        {
            return _contribuyenteRepository.Update(contribuyente);
        }

        public bool Delete(Contribuyente contribuyente)
        {
            return _contribuyenteRepository.Delete(contribuyente);
        }

        public Contribuyente Get(int id_contribuyente)
        {
            return _contribuyenteRepository.Get(id_contribuyente);
        }

        public Contribuyente GetLogin(string co_usuario, string no_contrasena)
        {
            return _contribuyenteRepository.GetLogin(co_usuario, no_contrasena);
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

        public async Task<Contribuyente> GetLoginAsync(string co_documento_identidad, string nu_documento_identidad, string no_contrasena)
        {
            return await _contribuyenteRepository.GetLoginAsync(co_documento_identidad, nu_documento_identidad, no_contrasena);
        }

        public async Task<IEnumerable<Contribuyente>> GetAllAsync(Contribuyente contribuyente)
        {
            return await _contribuyenteRepository.GetAllAsync(contribuyente);
        }

        #endregion


    }
}
