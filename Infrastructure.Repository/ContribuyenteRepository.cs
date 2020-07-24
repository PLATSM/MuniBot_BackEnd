using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

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

        public ResponseQuery Insert(Contribuyente contribuyente)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spi_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_empresa", contribuyente.id_empresa);
                parameters.Add("@pi_co_documento_identidad", contribuyente.co_documento_identidad);
                parameters.Add("@pi_nu_documento_identidad", contribuyente.nu_documento_identidad);
                parameters.Add("@pi_no_nombres", contribuyente.no_nombres);
                parameters.Add("@pi_no_apellido_paterno", contribuyente.no_apellido_paterno);
                parameters.Add("@pi_no_apellido_materno", contribuyente.no_apellido_materno);
                parameters.Add("@pi_fe_nacimiento", contribuyente.fe_nacimiento);
                parameters.Add("@pi_co_sexo", contribuyente.co_sexo);
                parameters.Add("@pi_no_razon_social", contribuyente.no_razon_social);
                parameters.Add("@pi_no_representante_legal", contribuyente.no_representante_legal);
                parameters.Add("@pi_nu_telefono", contribuyente.nu_telefono);
                parameters.Add("@pi_no_direccion", contribuyente.no_direccion);
                parameters.Add("@pi_no_correo_electronico", contribuyente.no_correo_electronico);
                parameters.Add("@pi_no_contrasena", contribuyente.no_contrasena);
                parameters.Add("@pi_no_contrasena_sha256", contribuyente.no_contrasena_sha256);
                parameters.Add("@pi_foto", contribuyente.foto);
                parameters.Add("@pi_id_usuario_login", contribuyente.id_usuario_creacion);
                parameters.Add("@po_id_contribuyente", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                responseQuery.id_identity = parameters.Get<int>("@po_id_contribuyente");
                responseQuery.error_number = parameters.Get<int>("@po_error_number");
                responseQuery.error_message = parameters.Get<string>("@po_error_message");

                return responseQuery;
            }
        }
        public ResponseQuery Update(Contribuyente contribuyente)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spu_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_contribuyente", contribuyente.id_contribuyente);
                parameters.Add("@pi_id_empresa", contribuyente.id_empresa);
                parameters.Add("@pi_co_documento_identidad", contribuyente.co_documento_identidad);
                parameters.Add("@pi_nu_documento_identidad", contribuyente.nu_documento_identidad);
                parameters.Add("@pi_no_nombres", contribuyente.no_nombres);
                parameters.Add("@pi_no_apellido_paterno", contribuyente.no_apellido_paterno);
                parameters.Add("@pi_no_apellido_materno", contribuyente.no_apellido_materno);
                parameters.Add("@pi_fe_nacimiento", contribuyente.fe_nacimiento);
                parameters.Add("@pi_co_sexo", contribuyente.co_sexo);
                parameters.Add("@pi_no_razon_social", contribuyente.no_razon_social);
                parameters.Add("@pi_no_representante_legal", contribuyente.no_representante_legal);
                parameters.Add("@pi_nu_telefono", contribuyente.nu_telefono);
                parameters.Add("@pi_no_direccion", contribuyente.no_direccion);
                parameters.Add("@pi_no_correo_electronico", contribuyente.no_correo_electronico);
                parameters.Add("@pi_id_usuario_login", contribuyente.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                responseQuery.error_number = parameters.Get<int>("@po_error_number");
                responseQuery.error_message = parameters.Get<string>("@po_error_message");

                return responseQuery;
            }
        }
        public ResponseQuery Delete(Contribuyente contribuyente)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spd_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_contribuyente", contribuyente.id_contribuyente);
                parameters.Add("@pi_id_usuario_login", contribuyente.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                responseQuery.error_number = parameters.Get<int>("@po_error_number");
                responseQuery.error_message = parameters.Get<string>("@po_error_message");

                return responseQuery;
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
        public Contribuyente GetLogin(int id_empresa, string co_documento_identidad, string nu_documento_identidad, string no_contrasena)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sps_mae_contribuyente_login";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_empresa", id_empresa);
                parameters.Add("@pi_co_documento_identidad", co_documento_identidad);
                parameters.Add("@pi_nu_documento_identidad", nu_documento_identidad);
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
                parameters.Add("@pi_no_representante_legal", contribuyente.no_representante_legal);
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

        public async Task<ResponseQuery> InsertAsync(Contribuyente contribuyente)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spi_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_empresa", contribuyente.id_empresa);
                parameters.Add("@pi_co_documento_identidad", contribuyente.co_documento_identidad);
                parameters.Add("@pi_nu_documento_identidad", contribuyente.nu_documento_identidad);
                parameters.Add("@pi_no_nombres", contribuyente.no_nombres);
                parameters.Add("@pi_no_apellido_paterno", contribuyente.no_apellido_paterno);
                parameters.Add("@pi_no_apellido_materno", contribuyente.no_apellido_materno);
                parameters.Add("@pi_fe_nacimiento", contribuyente.fe_nacimiento);
                parameters.Add("@pi_co_sexo", contribuyente.co_sexo);
                parameters.Add("@pi_no_razon_social", contribuyente.no_razon_social);
                parameters.Add("@pi_no_representante_legal", contribuyente.no_representante_legal);
                parameters.Add("@pi_nu_telefono", contribuyente.nu_telefono);
                parameters.Add("@pi_no_direccion", contribuyente.no_direccion);
                parameters.Add("@pi_no_correo_electronico", contribuyente.no_correo_electronico);
                parameters.Add("@pi_no_contrasena", contribuyente.no_contrasena);
                parameters.Add("@pi_no_contrasena_sha256", contribuyente.no_contrasena_sha256);
                parameters.Add("@pi_foto", contribuyente.foto);
                parameters.Add("@pi_id_usuario_login", contribuyente.id_usuario_creacion);
                parameters.Add("@po_id_contribuyente", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

                responseQuery.id_identity = parameters.Get<int>("@po_id_contribuyente");
                responseQuery.error_number = parameters.Get<int>("@po_error_number");
                responseQuery.error_message = parameters.Get<string>("@po_error_message");

                return responseQuery;
            }
        }
        public async Task<ResponseQuery> UpdateAsync(Contribuyente contribuyente)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spu_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_contribuyente", contribuyente.id_contribuyente);
                parameters.Add("@pi_id_empresa", contribuyente.id_empresa);
                parameters.Add("@pi_co_documento_identidad", contribuyente.co_documento_identidad);
                parameters.Add("@pi_nu_documento_identidad", contribuyente.nu_documento_identidad);
                parameters.Add("@pi_no_nombres", contribuyente.no_nombres);
                parameters.Add("@pi_no_apellido_paterno", contribuyente.no_apellido_paterno);
                parameters.Add("@pi_no_apellido_materno", contribuyente.no_apellido_materno);
                parameters.Add("@pi_fe_nacimiento", contribuyente.fe_nacimiento);
                parameters.Add("@pi_co_sexo", contribuyente.co_sexo);
                parameters.Add("@pi_no_razon_social", contribuyente.no_razon_social);
                parameters.Add("@pi_no_representante_legal", contribuyente.no_representante_legal);
                parameters.Add("@pi_nu_telefono", contribuyente.nu_telefono);
                parameters.Add("@pi_no_direccion", contribuyente.no_direccion);
                parameters.Add("@pi_no_correo_electronico", contribuyente.no_correo_electronico);
                parameters.Add("@pi_id_usuario_login", contribuyente.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                responseQuery.error_number = parameters.Get<int>("@po_error_number");
                responseQuery.error_message = parameters.Get<string>("@po_error_message");

                return responseQuery;
            }
        }
        public async Task<ResponseQuery> DeleteAsync(Contribuyente contribuyente)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spd_mae_contribuyente";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_contribuyente", contribuyente.id_contribuyente);
                parameters.Add("@pi_id_usuario_login", contribuyente.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                responseQuery.error_number = parameters.Get<int>("@po_error_number");
                responseQuery.error_message = parameters.Get<string>("@po_error_message");

                return responseQuery;
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
        public async Task<DataJson> GetJsonAsync(int id_contribuyente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sps_mae_contribuyente_json";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_contribuyente", id_contribuyente);
                parameters.Add("@pi_id_usuario_login", 0);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var dataJson = await connection.QuerySingleOrDefaultAsync<DataJson>(query, param: parameters, commandType: CommandType.StoredProcedure);

                if (dataJson == null)
                {
                    DataJson dataJsonError = new DataJson();
                    dataJsonError.error_number = parameters.Get<int>("@po_error_number");
                    dataJsonError.error_message = parameters.Get<string>("@po_error_message");
                    return dataJsonError;
                }
                else
                {
                    return dataJson;
                }
            }
        }
        public async Task<Contribuyente> GetLoginAsync(int id_empresa, string co_documento_identidad, string nu_documento_identidad, string no_contrasena)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sps_mae_contribuyente_login";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_empresa", id_empresa);
                parameters.Add("@pi_co_documento_identidad", co_documento_identidad);
                parameters.Add("@pi_nu_documento_identidad", nu_documento_identidad);
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
                parameters.Add("@pi_no_representante_legal", contribuyente.no_representante_legal);
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
