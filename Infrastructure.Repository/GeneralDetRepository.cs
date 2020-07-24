using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Infrastructure.Repository
{
	public class GeneralDetRepository:IGeneralDetRepository
	{
		private readonly IConnectionFactory _connectionFactory;

		public GeneralDetRepository(IConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(GeneralDet generalDet)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spi_tbl_general_det";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_no_general_det", generalDet.no_general_det);
				parameters.Add("@pi_id_usuario_login", generalDet.id_usuario_creacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public ResponseQuery Update(GeneralDet generalDet)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spu_tbl_general_det";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_nu_general_cab", generalDet.nu_general_cab);
				parameters.Add("@pi_co_general_det", generalDet.co_general_det);
				parameters.Add("@pi_no_general_det", generalDet.no_general_det);
				parameters.Add("@pi_id_usuario_login", generalDet.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public ResponseQuery Delete(GeneralDet generalDet)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spd_tbl_general_det";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_nu_general_cab", generalDet.nu_general_cab);
				parameters.Add("@pi_co_general_det", generalDet.co_general_det);
				parameters.Add("@pi_id_usuario_login", generalDet.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public GeneralDet Get(int nu_general_cab,string co_general_det)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "sps_tbl_general_det";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_nu_general_cab", nu_general_cab);
				parameters.Add("@pi_co_general_det", co_general_det);
				parameters.Add("@pi_id_usuario_login", 0);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var generalDet = connection.QuerySingleOrDefault<GeneralDet>(query, param: parameters, commandType: CommandType.StoredProcedure);

				if (generalDet == null)
				{
					GeneralDet generalDetError = new GeneralDet();
					generalDetError.error_number = parameters.Get<int>("@po_error_number");
					generalDetError.error_message = parameters.Get<string>("@po_error_message");
				return generalDetError;
				}
				else
				{
				return generalDet;
				}
			}
		}
		public IEnumerable<GeneralDet> GetAll(GeneralDet generalDet)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spl_tbl_general_det";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_nu_general_cab", generalDet.nu_general_cab);
				parameters.Add("@pi_co_general_det", generalDet.co_general_det);
				parameters.Add("@pi_no_general_det", generalDet.no_general_det);
				parameters.Add("@pi_fl_inactivo", generalDet.fl_inactivo);
				parameters.Add("@pi_id_usuario_login", generalDet.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var generalDets = connection.Query<GeneralDet>(query, param: parameters, commandType: CommandType.StoredProcedure);
				var error_number = parameters.Get<int>("@po_error_number");
				var error_message = parameters.Get<string>("@po_error_message");

				return generalDets;
			}
		}
		#endregion

		#region Metodos Asincronos

		public async Task<ResponseQuery> InsertAsync(GeneralDet generalDet)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spi_tbl_general_det";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_no_general_det", generalDet.no_general_det);
				parameters.Add("@pi_id_usuario_login", generalDet.id_usuario_creacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<ResponseQuery> UpdateAsync(GeneralDet generalDet)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spu_tbl_general_det";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_nu_general_cab", generalDet.nu_general_cab);
				parameters.Add("@pi_co_general_det", generalDet.co_general_det);
				parameters.Add("@pi_no_general_det", generalDet.no_general_det);
				parameters.Add("@pi_id_usuario_login", generalDet.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<ResponseQuery> DeleteAsync(GeneralDet generalDet)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spd_tbl_general_det";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_nu_general_cab", generalDet.nu_general_cab);
				parameters.Add("@pi_co_general_det", generalDet.co_general_det);
				parameters.Add("@pi_id_usuario_login", generalDet.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<GeneralDet> GetAsync(int nu_general_cab,string co_general_det)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "sps_tbl_general_det";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_nu_general_cab", nu_general_cab);
				parameters.Add("@pi_co_general_det", co_general_det);
				parameters.Add("@pi_id_usuario_login", 0);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var generalDet = await connection.QuerySingleOrDefaultAsync<GeneralDet>(query, param: parameters, commandType: CommandType.StoredProcedure);

				if (generalDet == null)
				{
					GeneralDet generalDetError = new GeneralDet();
					generalDetError.error_number = parameters.Get<int>("@po_error_number");
					generalDetError.error_message = parameters.Get<string>("@po_error_message");
				return generalDetError;
				}
				else
				{
				return generalDet;
				}
			}
		}
		public async Task<IEnumerable<GeneralDet>> GetAllAsync(GeneralDet generalDet)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spl_tbl_general_det";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_nu_general_cab", generalDet.nu_general_cab);
				parameters.Add("@pi_co_general_det", generalDet.co_general_det);
				parameters.Add("@pi_no_general_det", generalDet.no_general_det);
				parameters.Add("@pi_fl_inactivo", generalDet.fl_inactivo);
				parameters.Add("@pi_id_usuario_login", generalDet.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var generalDets = await connection.QueryAsync<GeneralDet>(query, param: parameters, commandType: CommandType.StoredProcedure);
				var error_number = parameters.Get<int>("@po_error_number");
				var error_message = parameters.Get<string>("@po_error_message");

				return generalDets;
			}
		#endregion

		}

	}
}