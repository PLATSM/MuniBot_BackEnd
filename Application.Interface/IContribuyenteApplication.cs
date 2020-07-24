using System.Collections.Generic;
using System.Threading.Tasks;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Application.Interface
{
    public interface IContribuyenteApplication
    {
        #region Métodos Síncronos

        ResponseQuery Insert(ContribuyenteDTO contribuyenteDTO);
        ResponseQuery Update(ContribuyenteDTO contribuyenteDTO);
        ResponseQuery Delete(ContribuyenteDTO contribuyenteDTO);
        Response<ContribuyenteDTO> Get(int id_contribuyente);
        Response<ContribuyenteDTO> GetLogin(int id_empresa, string co_documento_identidad, string  nu_documento_identidad, string no_contrasena);
        Response<IEnumerable<ContribuyenteDTO>> GetAll(ContribuyenteDTO contribuyenteDTO);

        #endregion

        #region Métodos Asíncronos
        Task<ResponseQuery> InsertAsync(ContribuyenteDTO contribuyenteDTO);
        Task<ResponseQuery> UpdateAsync(ContribuyenteDTO contribuyenteDTO);
        Task<ResponseQuery> DeleteAsync(ContribuyenteDTO contribuyenteDTO);
        Task<Response<ContribuyenteDTO>> GetAsync(int id_contribuyente);
        Task<Response<DataJsonDTO>> GetJsonAsync(int id_contribuyente);
        Task<Response<ContribuyenteDTO>> GetLoginAsync(int id_empresa, string co_documento_identidad, string nu_documento_identidad, string no_contrasena);
        Task<Response<IEnumerable<ContribuyenteDTO>>> GetAllAsync(ContribuyenteDTO contribuyenteDTO);

        #endregion

    }
}
