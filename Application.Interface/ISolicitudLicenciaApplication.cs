using System;
using System.Collections.Generic;
using System.Text;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Transversal.Common;
using System.Threading.Tasks;

namespace MuniBot_BackEnd.Application.Interface
{
    public interface ISolicitudLicenciaApplication
    {
        #region Métodos Síncronos

        Response<bool> Insert(SolicitudLicenciaDTO solicitudLicenciaDTO);
        Response<bool> Update(SolicitudLicenciaDTO solicitudLicenciaDTO);
        Response<bool> Delete(SolicitudLicenciaDTO solicitudLicenciaDTO);

        Response<SolicitudLicenciaDTO> Get(int id_solicitudLicencia);
        Response<IEnumerable<SolicitudLicenciaDTO>> GetAll(SolicitudLicenciaDTO solicitudLicenciaDTO);

        #endregion

        #region Métodos Asíncronos
        Task<ResponseQuery> InsertAsync(SolicitudLicenciaDTO solicitudLicenciaDTO);
        Task<ResponseQuery> UpdateAsync(SolicitudLicenciaDTO solicitudLicenciaDTO);
        Task<ResponseQuery> DeleteAsync(SolicitudLicenciaDTO solicitudLicenciaDTO);

        Task<Response<SolicitudLicenciaDTO>> GetAsync(int id_solicitudLicenciaDTO);
        Task<Response<IEnumerable<SolicitudLicenciaDTO>>> GetAllAsync(SolicitudLicenciaDTO solicitudLicenciaDTO);
        #endregion

    }
}
