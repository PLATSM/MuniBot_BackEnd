using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using MuniBot_BackEnd.Transversal.Common;
using MuniBot_BackEnd.Domain.Entity;

namespace MuniBot_BackEnd.Infrastructure.Interface
{
    public interface ISolicitudLicenciaRepository
    {
        #region Métodos Síncronos

        bool Insert(SolicitudLicencia solicitudLicencia);
        bool Update(SolicitudLicencia solicitudLicencia);
        bool Delete(SolicitudLicencia solicitudLicencia);

        SolicitudLicencia Get(int id_solicitudLicencia);
        IEnumerable<SolicitudLicencia> GetAll(SolicitudLicencia solicitudLicencia);
        #endregion

        #region Métodos Asíncronos
        Task<ResponseQuery> InsertAsync(SolicitudLicencia solicitudLicencia);
        Task<ResponseQuery> UpdateAsync(SolicitudLicencia solicitudLicencia);
        Task<ResponseQuery> DeleteAsync(SolicitudLicencia solicitudLicencia);
        Task<SolicitudLicencia> GetAsync(int id_solicitudLicencia);
        Task<IEnumerable<SolicitudLicencia>> GetAllAsync(SolicitudLicencia solicitudLicencia);
        #endregion
    }
}
