using System;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MuniBot_BackEnd.Infrastructure.Repository
{
    public class ContribuyenteRepository:IContribuyenteRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ContribuyenteRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Métodos Síncronos        

        public bool Insert(Contribuyente contribuyente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spi_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_empresa", contribuyente.id_empresa);
                parameters.Add("@pi_co_tipo_persona", contribuyente.co_tipo_persona);
                parameters.Add("@pi_co_documento_identidad", contribuyente.co_documento_identidad);
                parameters.Add("@pi_nu_documento_identidad", contribuyente.nu_documento_identidad);
                parameters.Add("@pi_no_nombres", contribuyente.no_nombres);
                parameters.Add("@pi_no_apellido_paterno", contribuyente.no_apellido_paterno);
                parameters.Add("@pi_no_apellido_materno", contribuyente.no_apellido_materno);
                parameters.Add("@pi_no_razon_social", contribuyente.no_razon_social);
                parameters.Add("@pi_no_correo_electronico", contribuyente.no_correo_electronico);
                parameters.Add("@pi_no_contrasena", contribuyente.no_contrasena);
                parameters.Add("@pi_id_usuario_login", contribuyente.id_usuario_creacion);
                parameters.Add("@po_id_contribuyente", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                var id_contribuyente = parameters.Get<int>("@po_id_contribuyente");
                var error_number = parameters.Get<int>("@po_error_number");
                var error_message = parameters.Get<string>("@po_error_message");

                return error_number >= 0;
            }
        }

        public bool Update(Contribuyente contribuyente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spu_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_contribuyente", contribuyente.id_contribuyente);
                parameters.Add("@pi_id_empresa", contribuyente.id_empresa);
                parameters.Add("@pi_co_tipo_persona", contribuyente.co_tipo_persona);
                parameters.Add("@pi_co_documento_identidad", contribuyente.co_documento_identidad);
                parameters.Add("@pi_nu_documento_identidad", contribuyente.nu_documento_identidad);
                parameters.Add("@pi_no_nombres", contribuyente.no_nombres);
                parameters.Add("@pi_no_apellido_paterno", contribuyente.no_apellido_paterno);
                parameters.Add("@pi_no_apellido_materno", contribuyente.no_apellido_materno);
                parameters.Add("@pi_no_razon_social", contribuyente.no_razon_social);
                parameters.Add("@pi_no_correo_electronico", contribuyente.no_correo_electronico);
                parameters.Add("@pi_id_usuario_login", contribuyente.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                var error_number = parameters.Get<int>("@po_error_number");
                var error_message = parameters.Get<string>("@po_error_message");

                return error_number >= 0;
            }
        }

        public bool Delete(Contribuyente contribuyente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spd_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_contribuyente", contribuyente.id_contribuyente);
                parameters.Add("@pi_id_usuario_login", contribuyente.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                var error_number = parameters.Get<int>("@po_error_number");
                var error_message = parameters.Get<string>("@po_error_message");

                return error_number >= 0;
            }
        }

        public Contribuyente Get(int id_contribuyente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sps_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_contribuyente", id_contribuyente);
                parameters.Add("@pi_id_usuario_login", 0);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var contribuyente = connection.QuerySingleOrDefault<Contribuyente>(query, param: parameters, commandType: CommandType.StoredProcedure);

                if (contribuyente == null)
                {
                    Contribuyente contribuyenteError = new Contribuyente();
                    contribuyenteError.error_number = parameters.Get<int>("@po_error_number");
                    contribuyenteError.error_message = parameters.Get<string>("@po_error_message");
                    return contribuyenteError;
                }
                else
                {
                    return contribuyente;
                }
            }
        }

        public Contribuyente GetLogin(string co_usuario, string no_contrasena)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sps_mae_contribuyente_login";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_co_usuario", co_usuario);
                parameters.Add("@pi_no_contrasena", no_contrasena);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var contribuyente = connection.QuerySingle<Contribuyente>(query, param: parameters, commandType: CommandType.StoredProcedure);

                if (contribuyente == null)
                {
                    Contribuyente contribuyenteError = new Contribuyente();
                    contribuyenteError.error_number = parameters.Get<int>("@po_error_number");
                    contribuyenteError.error_message = parameters.Get<string>("@po_error_message");
                    return contribuyenteError;
                }
                else
                {
                    return contribuyente;
                }
            }
        }

        public IEnumerable<Contribuyente> GetAll(Contribuyente contribuyente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spl_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_contribuyente", contribuyente.id_contribuyente);
                parameters.Add("@pi_id_empresa", contribuyente.id_empresa);
                parameters.Add("@pi_co_tipo_persona", contribuyente.co_tipo_persona);
                parameters.Add("@pi_co_documento_identidad", contribuyente.co_documento_identidad);
                parameters.Add("@pi_nu_documento_identidad", contribuyente.nu_documento_identidad);
                parameters.Add("@pi_no_nombres", contribuyente.no_nombres);
                parameters.Add("@pi_no_apellido_paterno", contribuyente.no_apellido_paterno);
                parameters.Add("@pi_no_apellido_materno", contribuyente.no_apellido_materno);
                parameters.Add("@pi_no_razon_social", contribuyente.no_razon_social);
                parameters.Add("@pi_fl_inactivo", contribuyente.fl_inactivo);
                parameters.Add("@pi_id_usuario_login", contribuyente.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var contribuyentes = connection.Query<Contribuyente>(query, param: parameters, commandType: CommandType.StoredProcedure);
                var error_number = parameters.Get<int>("@po_error_number");
                var error_message = parameters.Get<string>("@po_error_message");

                return contribuyentes;
            }
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Contribuyente contribuyente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spi_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_empresa", contribuyente.id_empresa);
                parameters.Add("@pi_co_tipo_persona", contribuyente.co_tipo_persona);
                parameters.Add("@pi_co_documento_identidad", contribuyente.co_documento_identidad);
                parameters.Add("@pi_nu_documento_identidad", contribuyente.nu_documento_identidad);
                parameters.Add("@pi_no_nombres", contribuyente.no_nombres);
                parameters.Add("@pi_no_apellido_paterno", contribuyente.no_apellido_paterno);
                parameters.Add("@pi_no_apellido_materno", contribuyente.no_apellido_materno);
                parameters.Add("@pi_no_razon_social", contribuyente.no_razon_social);
                parameters.Add("@pi_no_correo_electronico", contribuyente.no_correo_electronico);
                parameters.Add("@pi_no_contrasena", contribuyente.no_contrasena);
                parameters.Add("@pi_id_usuario_login", contribuyente.id_usuario_creacion);
                parameters.Add("@po_id_contribuyente", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                var id_contribuyente = parameters.Get<int>("@po_id_contribuyente");
                var error_number = parameters.Get<int>("@po_error_number");
                var error_message = parameters.Get<string>("@po_error_message");

                return error_number >= 0;
            }
        }

        public async Task<bool> UpdateAsync(Contribuyente contribuyente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spu_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_contribuyente", contribuyente.id_contribuyente);
                parameters.Add("@pi_id_empresa", contribuyente.id_empresa);
                parameters.Add("@pi_co_tipo_persona", contribuyente.co_tipo_persona);
                parameters.Add("@pi_co_documento_identidad", contribuyente.co_documento_identidad);
                parameters.Add("@pi_nu_documento_identidad", contribuyente.nu_documento_identidad);
                parameters.Add("@pi_no_nombres", contribuyente.no_nombres);
                parameters.Add("@pi_no_apellido_paterno", contribuyente.no_apellido_paterno);
                parameters.Add("@pi_no_apellido_materno", contribuyente.no_apellido_materno);
                parameters.Add("@pi_no_razon_social", contribuyente.no_razon_social);
                parameters.Add("@pi_no_correo_electronico", contribuyente.no_correo_electronico);
                parameters.Add("@pi_id_usuario_login", contribuyente.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                var error_number = parameters.Get<int>("@po_error_number");
                var error_message = parameters.Get<string>("@po_error_message");

                return error_number >= 0;
            }
        }

        public async Task<bool> DeleteAsync(Contribuyente contribuyente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spd_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_contribuyente", contribuyente.id_contribuyente);
                parameters.Add("@pi_id_usuario_login", contribuyente.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                var error_number = parameters.Get<int>("@po_error_number");
                var error_message = parameters.Get<string>("@po_error_message");

                return error_number >= 0;
            }
        }

        public async Task<Contribuyente> GetAsync(int id_contribuyente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sps_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_contribuyente", id_contribuyente);
                parameters.Add("@pi_id_usuario_login", 0);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var contribuyente = await connection.QuerySingleOrDefaultAsync<Contribuyente>(query, param: parameters, commandType: CommandType.StoredProcedure);

                if (contribuyente == null)
                {
                    Contribuyente contribuyenteError = new Contribuyente();
                    contribuyenteError.error_number = parameters.Get<int>("@po_error_number");
                    contribuyenteError.error_message = parameters.Get<string>("@po_error_message");
                    return contribuyenteError;
                }
                else
                {
                    return contribuyente;
                }
            }
        }

        public async Task<Contribuyente> GetLoginAsync(string co_usuario, string no_contrasena)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sps_mae_contribuyente_login";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_co_usuario", co_usuario);
                parameters.Add("@pi_no_contrasena", no_contrasena);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var contribuyente = await connection.QuerySingleOrDefaultAsync<Contribuyente>(query, param: parameters, commandType: CommandType.StoredProcedure);

                if (contribuyente == null)
                {
                    Contribuyente contribuyenteError = new Contribuyente();
                    contribuyenteError.error_number = parameters.Get<int>("@po_error_number");
                    contribuyenteError.error_message = parameters.Get<string>("@po_error_message");
                    return contribuyenteError;
                }
                else
                {
                    return contribuyente;
                }
            }
        }

        public async Task<IEnumerable<Contribuyente>> GetAllAsync(Contribuyente contribuyente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spl_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_contribuyente", contribuyente.id_contribuyente);
                parameters.Add("@pi_id_empresa", contribuyente.id_empresa);
                parameters.Add("@pi_co_tipo_persona", contribuyente.co_tipo_persona);
                parameters.Add("@pi_co_documento_identidad", contribuyente.co_documento_identidad);
                parameters.Add("@pi_nu_documento_identidad", contribuyente.nu_documento_identidad);
                parameters.Add("@pi_no_nombres", contribuyente.no_nombres);
                parameters.Add("@pi_no_apellido_paterno", contribuyente.no_apellido_paterno);
                parameters.Add("@pi_no_apellido_materno", contribuyente.no_apellido_materno);
                parameters.Add("@pi_no_razon_social", contribuyente.no_razon_social);
                parameters.Add("@pi_fl_inactivo",contribuyente.fl_inactivo);
                parameters.Add("@pi_id_usuario_login", contribuyente.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var contribuyentes = await connection.QueryAsync<Contribuyente>(query, param: parameters, commandType: CommandType.StoredProcedure);
                var error_number = parameters.Get<int>("@po_error_number");
                var error_message = parameters.Get<string>("@po_error_message");

                return contribuyentes;
            }
        }

        #endregion
    }
}
