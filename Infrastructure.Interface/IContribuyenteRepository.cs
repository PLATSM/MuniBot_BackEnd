using System;
using System.Collections.Generic;
using System.Text;
using MuniBot_BackEnd.Domain.Entity;
using System.Threading.Tasks;

namespace MuniBot_BackEnd.Infrastructure.Interface
{
    public interface IContribuyenteRepository
    {
        #region Métodos Síncronos

        bool Insert(Contribuyente contribuyente);
        bool Update(Contribuyente contribuyente);
        bool Delete(Contribuyente contribuyente);

        Contribuyente Get(int id_Contribuyente);
        IEnumerable<Contribuyente> GetAll(Contribuyente contribuyente);
        Contribuyente GetLogin(string co_usuario, string no_contrasena);
        #endregion

        #region Métodos Asíncronos
        Task<bool> InsertAsync(Contribuyente contribuyente);
        Task<bool> UpdateAsync(Contribuyente contribuyente);
        Task<bool> DeleteAsync(Contribuyente contribuyente);

        Task<Contribuyente> GetAsync(int id_contribuyente);
        Task<IEnumerable<Contribuyente>> GetAllAsync(Contribuyente contribuyente);
        Task<Contribuyente> GetLoginAsync(string co_usuario, string no_contrasena);
        #endregion
    }
}
