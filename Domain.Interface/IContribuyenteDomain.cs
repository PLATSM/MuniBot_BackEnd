﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Domain.Interface
{
    public interface IContribuyenteDomain
    {
        #region Métodos Síncronos

        bool Insert(Contribuyente contribuyente);
        bool Update(Contribuyente contribuyente);
        bool Delete(Contribuyente contribuyente);

        Contribuyente Get(int id_contribuyente);
        IEnumerable<Contribuyente> GetAll(Contribuyente contribuyente);
        Contribuyente GetLogin(string co_usuario, string no_contrasena);

        #endregion

        #region Métodos Asíncronos
        Task<ResponseQuery> InsertAsync(Contribuyente contribuyente);
        Task<ResponseQuery> UpdateAsync(Contribuyente contribuyente);
        Task<ResponseQuery> DeleteAsync(Contribuyente contribuyente);

        Task<Contribuyente> GetAsync(int id_contribuyente);
        Task<IEnumerable<Contribuyente>> GetAllAsync(Contribuyente contribuyente);
        Task<Contribuyente> GetLoginAsync(string co_documento_identidad, string nu_documento_identidad, string no_contrasena);
        #endregion
    }
}
