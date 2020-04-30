using System;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Domain.Interface;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

using System.Threading.Tasks;
using System.Collections.Generic;

namespace MuniBot_BackEnd.Domain.Core
{
    public class SolicitudLicenciaDomain:ISolicitudLicenciaDomain
    {
        private readonly ISolicitudLicenciaRepository _solicitudLicenciaRepository;

        public SolicitudLicenciaDomain(ISolicitudLicenciaRepository solicitudLicenciaRepository)
        {
            _solicitudLicenciaRepository = solicitudLicenciaRepository;
        }
        #region Métodos Sincronos

        public bool Insert(SolicitudLicencia solicitudLicencia)
        {
            return _solicitudLicenciaRepository.Insert(solicitudLicencia);
        }

        public bool Update(SolicitudLicencia solicitudLicencia)
        {
            return _solicitudLicenciaRepository.Update(solicitudLicencia);
        }

        public bool Delete(SolicitudLicencia solicitudLicencia)
        {
            return _solicitudLicenciaRepository.Delete(solicitudLicencia);
        }

        public SolicitudLicencia Get(int id_solicitudLicencia)
        {
            return _solicitudLicenciaRepository.Get(id_solicitudLicencia);
        }

        public IEnumerable<SolicitudLicencia> GetAll(SolicitudLicencia solicitudLicencia)
        {
            return _solicitudLicenciaRepository.GetAll(solicitudLicencia);
        }

        #endregion

        #region Métodos Asincronos

        public async Task<ResponseQuery> InsertAsync(SolicitudLicencia solicitudLicencia)
        {
            return await _solicitudLicenciaRepository.InsertAsync(solicitudLicencia);
        }

        public async Task<ResponseQuery> UpdateAsync(SolicitudLicencia solicitudLicencia)
        {
            return await _solicitudLicenciaRepository.UpdateAsync(solicitudLicencia);
        }

        public async Task<ResponseQuery> DeleteAsync(SolicitudLicencia solicitudLicencia)
        {
            return await _solicitudLicenciaRepository.DeleteAsync(solicitudLicencia);
        }

        public async Task<SolicitudLicencia> GetAsync(int id_solicitudLicencia)
        {
            return await _solicitudLicenciaRepository.GetAsync(id_solicitudLicencia);
        }

        public async Task<IEnumerable<SolicitudLicencia>> GetAllAsync(SolicitudLicencia solicitudLicencia)
        {
            return await _solicitudLicenciaRepository.GetAllAsync(solicitudLicencia);
        }

        #endregion


    }
}
