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
    public class SolicitudLicenciaRepository:ISolicitudLicenciaRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public SolicitudLicenciaRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Métodos Síncronos        

        public bool Insert(SolicitudLicencia solicitudLicencia)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spi_tbl_solicitud_licencia";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_empresa", solicitudLicencia.id_empresa);
                parameters.Add("@pi_id_contribuyente", solicitudLicencia.id_contribuyente);
                parameters.Add("@pi_co_tipo_licencia", solicitudLicencia.co_tipo_licencia);
                parameters.Add("@pi_no_comercial", solicitudLicencia.no_comercial);
                parameters.Add("@pi_co_clase", solicitudLicencia.co_clase);
                parameters.Add("@pi_co_sub_clase", solicitudLicencia.co_sub_clase);
                parameters.Add("@pi_co_categoria", solicitudLicencia.co_categoria);
                parameters.Add("@pi_no_dirección", solicitudLicencia.no_dirección);
                parameters.Add("@pi_nu_area", solicitudLicencia.nu_area);
                parameters.Add("@pi_no_imagen_croquis", solicitudLicencia.no_imagen_croquis);
                parameters.Add("@pi_id_usuario_login", solicitudLicencia.id_usuario_creacion);
                parameters.Add("@po_id_solicitud_licencia", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                var id_solicitudLicencia = parameters.Get<int>("@po_id_solicitud_licencia");
                var error_number = parameters.Get<int>("@po_error_number");
                var error_message = parameters.Get<string>("@po_error_message");

                return error_number >= 0;
            }
        }

        public bool Update(SolicitudLicencia solicitudLicencia)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spu_tbl_solicitud_licencia";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_solicitud_licencia", solicitudLicencia.id_solicitud_licencia);
                parameters.Add("@pi_id_empresa", solicitudLicencia.id_empresa);
                parameters.Add("@pi_id_contribuyente", solicitudLicencia.id_contribuyente);
                parameters.Add("@pi_co_tipo_licencia", solicitudLicencia.co_tipo_licencia);
                parameters.Add("@pi_no_comercial", solicitudLicencia.no_comercial);
                parameters.Add("@pi_co_clase", solicitudLicencia.co_clase);
                parameters.Add("@pi_co_sub_clase", solicitudLicencia.co_sub_clase);
                parameters.Add("@pi_co_categoria", solicitudLicencia.co_categoria);
                parameters.Add("@pi_no_dirección", solicitudLicencia.no_dirección);
                parameters.Add("@pi_nu_area", solicitudLicencia.nu_area);
                parameters.Add("@pi_no_imagen_croquis", solicitudLicencia.no_imagen_croquis);
                parameters.Add("@pi_id_usuario_login", solicitudLicencia.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                var error_number = parameters.Get<int>("@po_error_number");
                var error_message = parameters.Get<string>("@po_error_message");

                return error_number >= 0;
            }
        }

        public bool Delete(SolicitudLicencia solicitudLicencia)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spd_tbl_solicitud_licencia";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_solicitud_licencia", solicitudLicencia.id_solicitud_licencia);
                parameters.Add("@pi_id_usuario_login", solicitudLicencia.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                var error_number = parameters.Get<int>("@po_error_number");
                var error_message = parameters.Get<string>("@po_error_message");

                return error_number >= 0;
            }
        }

        public SolicitudLicencia Get(int id_solicitudLicencia)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sps_tbl_solicitud_licencia";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_solicitud_licencia", id_solicitudLicencia);
                parameters.Add("@pi_id_usuario_login", 0);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var solicitudLicencia = connection.QuerySingleOrDefault<SolicitudLicencia>(query, param: parameters, commandType: CommandType.StoredProcedure);

                if (solicitudLicencia == null)
                {
                    SolicitudLicencia solicitudLicenciaError = new SolicitudLicencia();
                    solicitudLicenciaError.error_number = parameters.Get<int>("@po_error_number");
                    solicitudLicenciaError.error_message = parameters.Get<string>("@po_error_message");
                    return solicitudLicenciaError;
                }
                else
                {
                    return solicitudLicencia;
                }
            }
        }

        public IEnumerable<SolicitudLicencia> GetAll(SolicitudLicencia solicitudLicencia)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spl_tbl_solicitud_licencia";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_solicitud_licencia", solicitudLicencia.id_solicitud_licencia);
                parameters.Add("@pi_id_empresa", solicitudLicencia.id_empresa);
                parameters.Add("@pi_id_contribuyente", solicitudLicencia.id_contribuyente);
                parameters.Add("@pi_fe_proceso_ini", solicitudLicencia.fe_proceso_ini);
                parameters.Add("@pi_fe_proceso_fin", solicitudLicencia.fe_proceso_fin);
                parameters.Add("@pi_co_tipo_licencia", solicitudLicencia.co_tipo_licencia);
                parameters.Add("@pi_va_no_comercial", solicitudLicencia.no_comercial);
                parameters.Add("@pi_co_clase", solicitudLicencia.co_clase);
                parameters.Add("@pi_co_sub_clase", solicitudLicencia.co_sub_clase);
                parameters.Add("@pi_co_categoria", solicitudLicencia.co_categoria);
                parameters.Add("@pi_co_estado", solicitudLicencia.co_estado);
                parameters.Add("@pi_id_usuario_login", solicitudLicencia.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var solicitudLicencias = connection.Query<SolicitudLicencia>(query, param: parameters, commandType: CommandType.StoredProcedure);
                var error_number = parameters.Get<int>("@po_error_number");
                var error_message = parameters.Get<string>("@po_error_message");

                return solicitudLicencias;
            }
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<ResponseQuery> InsertAsync(SolicitudLicencia solicitudLicencia)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spi_tbl_solicitud_licencia";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_empresa", solicitudLicencia.id_empresa);
                parameters.Add("@pi_id_contribuyente", solicitudLicencia.id_contribuyente);
                parameters.Add("@pi_co_tipo_licencia", solicitudLicencia.co_tipo_licencia);
                parameters.Add("@pi_no_comercial", solicitudLicencia.no_comercial);
                parameters.Add("@pi_co_clase", solicitudLicencia.co_clase);
                parameters.Add("@pi_co_sub_clase", solicitudLicencia.co_sub_clase);
                parameters.Add("@pi_co_categoria", solicitudLicencia.co_categoria);
                parameters.Add("@pi_no_dirección", solicitudLicencia.no_dirección);
                parameters.Add("@pi_nu_area", solicitudLicencia.nu_area);
                parameters.Add("@pi_no_imagen_croquis", solicitudLicencia.no_imagen_croquis);
                parameters.Add("@pi_id_usuario_login", solicitudLicencia.id_usuario_creacion);
                parameters.Add("@po_id_solicitud_licencia", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

                responseQuery.id_identity = parameters.Get<int>("@po_id_solicitud_licencia");
                responseQuery.error_number = parameters.Get<int>("@po_error_number");
                responseQuery.error_message = parameters.Get<string>("@po_error_message");

                return responseQuery;
            }
        }

        public async Task<ResponseQuery> UpdateAsync(SolicitudLicencia solicitudLicencia)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spu_tbl_solicitud_licencia";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_solicitud_licencia", solicitudLicencia.id_solicitud_licencia);
                parameters.Add("@pi_id_empresa", solicitudLicencia.id_empresa);
                parameters.Add("@pi_id_contribuyente", solicitudLicencia.id_contribuyente);
                parameters.Add("@pi_co_tipo_licencia", solicitudLicencia.co_tipo_licencia);
                parameters.Add("@pi_no_comercial", solicitudLicencia.no_comercial);
                parameters.Add("@pi_co_clase", solicitudLicencia.co_clase);
                parameters.Add("@pi_co_sub_clase", solicitudLicencia.co_sub_clase);
                parameters.Add("@pi_co_categoria", solicitudLicencia.co_categoria);
                parameters.Add("@pi_no_dirección", solicitudLicencia.no_dirección);
                parameters.Add("@pi_nu_area", solicitudLicencia.nu_area);
                parameters.Add("@pi_no_imagen_croquis", solicitudLicencia.no_imagen_croquis);
                parameters.Add("@pi_id_usuario_login", solicitudLicencia.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                responseQuery.error_number = parameters.Get<int>("@po_error_number");
                responseQuery.error_message = parameters.Get<string>("@po_error_message");

                return responseQuery;
            }
        }

        public async Task<ResponseQuery> DeleteAsync(SolicitudLicencia solicitudLicencia)
        {
            ResponseQuery responseQuery = new ResponseQuery();

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spd_tbl_solicitud_licencia";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_solicitud_licencia", solicitudLicencia.id_solicitud_licencia);
                parameters.Add("@pi_id_usuario_login", solicitudLicencia.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                responseQuery.error_number = parameters.Get<int>("@po_error_number");
                responseQuery.error_message = parameters.Get<string>("@po_error_message");

                return responseQuery;
            }
        }

        public async Task<SolicitudLicencia> GetAsync(int id_solicitudLicencia)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sps_tbl_solicitud_licencia";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_solicitud_licencia", id_solicitudLicencia);
                parameters.Add("@pi_id_usuario_login", 0);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var solicitudLicencia = await connection.QuerySingleOrDefaultAsync<SolicitudLicencia>(query, param: parameters, commandType: CommandType.StoredProcedure);

                if (solicitudLicencia == null)
                {
                    SolicitudLicencia solicitudLicenciaError = new SolicitudLicencia();
                    solicitudLicenciaError.error_number = parameters.Get<int>("@po_error_number");
                    solicitudLicenciaError.error_message = parameters.Get<string>("@po_error_message");
                    return solicitudLicenciaError;
                }
                else
                {
                    return solicitudLicencia;
                }
            }
        }

        public async Task<IEnumerable<SolicitudLicencia>> GetAllAsync(SolicitudLicencia solicitudLicencia)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "spl_tbl_solicitud_licencia";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_id_solicitud_licencia", solicitudLicencia.id_solicitud_licencia);
                parameters.Add("@pi_id_empresa", solicitudLicencia.id_empresa);
                parameters.Add("@pi_id_contribuyente", solicitudLicencia.id_contribuyente);
                parameters.Add("@pi_fe_proceso_ini", solicitudLicencia.fe_proceso_ini);
                parameters.Add("@pi_fe_proceso_fin", solicitudLicencia.fe_proceso_fin);
                parameters.Add("@pi_co_tipo_licencia", solicitudLicencia.co_tipo_licencia);
                parameters.Add("@pi_va_no_comercial", solicitudLicencia.no_comercial);
                parameters.Add("@pi_co_clase", solicitudLicencia.co_clase);
                parameters.Add("@pi_co_sub_clase", solicitudLicencia.co_sub_clase);
                parameters.Add("@pi_co_categoria", solicitudLicencia.co_categoria);
                parameters.Add("@pi_co_estado", solicitudLicencia.co_estado);
                parameters.Add("@pi_id_usuario_login", solicitudLicencia.id_usuario_modificacion);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var solicitudLicencias = await connection.QueryAsync<SolicitudLicencia>(query, param: parameters, commandType: CommandType.StoredProcedure);
                var error_number = parameters.Get<int>("@po_error_number");
                var error_message = parameters.Get<string>("@po_error_message");

                return solicitudLicencias;
            }
        }

        #endregion
    }
}
