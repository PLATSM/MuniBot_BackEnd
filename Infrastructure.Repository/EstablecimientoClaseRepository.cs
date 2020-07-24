using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Infrastructure.Repository
{
	public class EstablecimientoClaseRepository:IEstablecimientoClaseRepository
	{
		private readonly IConnectionFactory _connectionFactory;

		public EstablecimientoClaseRepository(IConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(EstablecimientoClase establecimientoClase)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spi_tbl_establecimiento_clase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_no_establecimiento_clase", establecimientoClase.no_establecimiento_clase);
				parameters.Add("@pi_id_usuario_login", establecimientoClase.id_usuario_creacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public ResponseQuery Update(EstablecimientoClase establecimientoClase)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spu_tbl_establecimiento_clase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoClase.co_establecimiento_clase);
				parameters.Add("@pi_no_establecimiento_clase", establecimientoClase.no_establecimiento_clase);
				parameters.Add("@pi_id_usuario_login", establecimientoClase.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public ResponseQuery Delete(EstablecimientoClase establecimientoClase)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spd_tbl_establecimiento_clase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoClase.co_establecimiento_clase);
				parameters.Add("@pi_id_usuario_login", establecimientoClase.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public EstablecimientoClase Get(string co_establecimiento_clase)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "sps_tbl_establecimiento_clase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", co_establecimiento_clase);
				parameters.Add("@pi_id_usuario_login", 0);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var establecimientoClase = connection.QuerySingleOrDefault<EstablecimientoClase>(query, param: parameters, commandType: CommandType.StoredProcedure);

				if (establecimientoClase == null)
				{
					EstablecimientoClase establecimientoClaseError = new EstablecimientoClase();
					establecimientoClaseError.error_number = parameters.Get<int>("@po_error_number");
					establecimientoClaseError.error_message = parameters.Get<string>("@po_error_message");
				return establecimientoClaseError;
				}
				else
				{
				return establecimientoClase;
				}
			}
		}
		public IEnumerable<EstablecimientoClase> GetAll(EstablecimientoClase establecimientoClase)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spl_tbl_establecimiento_clase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoClase.co_establecimiento_clase);
				parameters.Add("@pi_no_establecimiento_clase", establecimientoClase.no_establecimiento_clase);
				parameters.Add("@pi_fl_inactivo", establecimientoClase.fl_inactivo);
				parameters.Add("@pi_id_usuario_login", establecimientoClase.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var establecimientoClases = connection.Query<EstablecimientoClase>(query, param: parameters, commandType: CommandType.StoredProcedure);
				var error_number = parameters.Get<int>("@po_error_number");
				var error_message = parameters.Get<string>("@po_error_message");

				return establecimientoClases;
			}
		}
		#endregion

		#region Metodos Asincronos

		public async Task<ResponseQuery> InsertAsync(EstablecimientoClase establecimientoClase)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spi_tbl_establecimiento_clase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_no_establecimiento_clase", establecimientoClase.no_establecimiento_clase);
				parameters.Add("@pi_id_usuario_login", establecimientoClase.id_usuario_creacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<ResponseQuery> UpdateAsync(EstablecimientoClase establecimientoClase)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spu_tbl_establecimiento_clase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoClase.co_establecimiento_clase);
				parameters.Add("@pi_no_establecimiento_clase", establecimientoClase.no_establecimiento_clase);
				parameters.Add("@pi_id_usuario_login", establecimientoClase.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<ResponseQuery> DeleteAsync(EstablecimientoClase establecimientoClase)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spd_tbl_establecimiento_clase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoClase.co_establecimiento_clase);
				parameters.Add("@pi_id_usuario_login", establecimientoClase.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<EstablecimientoClase> GetAsync(string co_establecimiento_clase)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "sps_tbl_establecimiento_clase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", co_establecimiento_clase);
				parameters.Add("@pi_id_usuario_login", 0);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var establecimientoClase = await connection.QuerySingleOrDefaultAsync<EstablecimientoClase>(query, param: parameters, commandType: CommandType.StoredProcedure);

				if (establecimientoClase == null)
				{
					EstablecimientoClase establecimientoClaseError = new EstablecimientoClase();
					establecimientoClaseError.error_number = parameters.Get<int>("@po_error_number");
					establecimientoClaseError.error_message = parameters.Get<string>("@po_error_message");
				return establecimientoClaseError;
				}
				else
				{
				return establecimientoClase;
				}
			}
		}
		public async Task<IEnumerable<EstablecimientoClase>> GetAllAsync(EstablecimientoClase establecimientoClase)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spl_tbl_establecimiento_clase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoClase.co_establecimiento_clase);
				parameters.Add("@pi_no_establecimiento_clase", establecimientoClase.no_establecimiento_clase);
				parameters.Add("@pi_fl_inactivo", establecimientoClase.fl_inactivo);
				parameters.Add("@pi_id_usuario_login", establecimientoClase.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var establecimientoClases = await connection.QueryAsync<EstablecimientoClase>(query, param: parameters, commandType: CommandType.StoredProcedure);
				var error_number = parameters.Get<int>("@po_error_number");
				var error_message = parameters.Get<string>("@po_error_message");

				return establecimientoClases;
			}
		#endregion

		}

	}
}