using System;
using System.Collections.Generic;
using System.Text;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Transversal.Common;
using System.Threading.Tasks;

namespace MuniBot_BackEnd.Application.Interface
{
    public interface IContribuyenteApplication
    {
        #region Métodos Síncronos

        Response<bool> Insert(ContribuyenteDTO contribuyenteDTO);
        Response<bool> Update(ContribuyenteDTO contribuyenteDTO);
        Response<bool> Delete(ContribuyenteDTO contribuyenteDTO);

        Response<ContribuyenteDTO> Get(int id_contribuyente);
        Response<ContribuyenteDTO> GetLogin(string co_usuario, string no_contrasena);
        Response<IEnumerable<ContribuyenteDTO>> GetAll(ContribuyenteDTO contribuyenteDTO);

        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(ContribuyenteDTO contribuyenteDTO);
        Task<Response<bool>> UpdateAsync(ContribuyenteDTO contribuyenteDTO);
        Task<Response<bool>> DeleteAsync(ContribuyenteDTO contribuyenteDTO);

        Task<Response<ContribuyenteDTO>> GetAsync(int id_contribuyenteDTO);
        Task<Response<ContribuyenteDTO>> GetLoginAsync(string co_usuario, string no_contrasena);
        Task<Response<IEnumerable<ContribuyenteDTO>>> GetAllAsync(ContribuyenteDTO contribuyenteDTO);
        #endregion

    }
}
