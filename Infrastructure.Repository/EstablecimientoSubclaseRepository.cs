using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Infrastructure.Repository
{
	public class EstablecimientoSubclaseRepository:IEstablecimientoSubclaseRepository
	{
		private readonly IConnectionFactory _connectionFactory;

		public EstablecimientoSubclaseRepository(IConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(EstablecimientoSubclase establecimientoSubclase)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spi_tbl_establecimiento_subclase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_no_establecimiento_subclase", establecimientoSubclase.no_establecimiento_subclase);
				parameters.Add("@pi_id_usuario_login", establecimientoSubclase.id_usuario_creacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public ResponseQuery Update(EstablecimientoSubclase establecimientoSubclase)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spu_tbl_establecimiento_subclase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoSubclase.co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", establecimientoSubclase.co_establecimiento_subclase);
				parameters.Add("@pi_no_establecimiento_subclase", establecimientoSubclase.no_establecimiento_subclase);
				parameters.Add("@pi_id_usuario_login", establecimientoSubclase.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public ResponseQuery Delete(EstablecimientoSubclase establecimientoSubclase)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spd_tbl_establecimiento_subclase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoSubclase.co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", establecimientoSubclase.co_establecimiento_subclase);
				parameters.Add("@pi_id_usuario_login", establecimientoSubclase.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public EstablecimientoSubclase Get(string co_establecimiento_clase,string co_establecimiento_subclase)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "sps_tbl_establecimiento_subclase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", co_establecimiento_subclase);
				parameters.Add("@pi_id_usuario_login", 0);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var establecimientoSubclase = connection.QuerySingleOrDefault<EstablecimientoSubclase>(query, param: parameters, commandType: CommandType.StoredProcedure);

				if (establecimientoSubclase == null)
				{
					EstablecimientoSubclase establecimientoSubclaseError = new EstablecimientoSubclase();
					establecimientoSubclaseError.error_number = parameters.Get<int>("@po_error_number");
					establecimientoSubclaseError.error_message = parameters.Get<string>("@po_error_message");
				return establecimientoSubclaseError;
				}
				else
				{
				return establecimientoSubclase;
				}
			}
		}
		public IEnumerable<EstablecimientoSubclase> GetAll(EstablecimientoSubclase establecimientoSubclase)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spl_tbl_establecimiento_subclase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoSubclase.co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", establecimientoSubclase.co_establecimiento_subclase);
				parameters.Add("@pi_no_establecimiento_subclase", establecimientoSubclase.no_establecimiento_subclase);
				parameters.Add("@pi_fl_inactivo", establecimientoSubclase.fl_inactivo);
				parameters.Add("@pi_id_usuario_login", establecimientoSubclase.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var establecimientoSubclases = connection.Query<EstablecimientoSubclase>(query, param: parameters, commandType: CommandType.StoredProcedure);
				var error_number = parameters.Get<int>("@po_error_number");
				var error_message = parameters.Get<string>("@po_error_message");

				return establecimientoSubclases;
			}
		}
		#endregion

		#region Metodos Asincronos

		public async Task<ResponseQuery> InsertAsync(EstablecimientoSubclase establecimientoSubclase)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spi_tbl_establecimiento_subclase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_no_establecimiento_subclase", establecimientoSubclase.no_establecimiento_subclase);
				parameters.Add("@pi_id_usuario_login", establecimientoSubclase.id_usuario_creacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<ResponseQuery> UpdateAsync(EstablecimientoSubclase establecimientoSubclase)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spu_tbl_establecimiento_subclase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoSubclase.co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", establecimientoSubclase.co_establecimiento_subclase);
				parameters.Add("@pi_no_establecimiento_subclase", establecimientoSubclase.no_establecimiento_subclase);
				parameters.Add("@pi_id_usuario_login", establecimientoSubclase.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<ResponseQuery> DeleteAsync(EstablecimientoSubclase establecimientoSubclase)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spd_tbl_establecimiento_subclase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoSubclase.co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", establecimientoSubclase.co_establecimiento_subclase);
				parameters.Add("@pi_id_usuario_login", establecimientoSubclase.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<EstablecimientoSubclase> GetAsync(string co_establecimiento_clase,string co_establecimiento_subclase)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "sps_tbl_establecimiento_subclase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", co_establecimiento_subclase);
				parameters.Add("@pi_id_usuario_login", 0);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var establecimientoSubclase = await connection.QuerySingleOrDefaultAsync<EstablecimientoSubclase>(query, param: parameters, commandType: CommandType.StoredProcedure);

				if (establecimientoSubclase == null)
				{
					EstablecimientoSubclase establecimientoSubclaseError = new EstablecimientoSubclase();
					establecimientoSubclaseError.error_number = parameters.Get<int>("@po_error_number");
					establecimientoSubclaseError.error_message = parameters.Get<string>("@po_error_message");
				return establecimientoSubclaseError;
				}
				else
				{
				return establecimientoSubclase;
				}
			}
		}
		public async Task<IEnumerable<EstablecimientoSubclase>> GetAllAsync(EstablecimientoSubclase establecimientoSubclase)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spl_tbl_establecimiento_subclase";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoSubclase.co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", establecimientoSubclase.co_establecimiento_subclase);
				parameters.Add("@pi_no_establecimiento_subclase", establecimientoSubclase.no_establecimiento_subclase);
				parameters.Add("@pi_fl_inactivo", establecimientoSubclase.fl_inactivo);
				parameters.Add("@pi_id_usuario_login", establecimientoSubclase.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var establecimientoSubclases = await connection.QueryAsync<EstablecimientoSubclase>(query, param: parameters, commandType: CommandType.StoredProcedure);
				var error_number = parameters.Get<int>("@po_error_number");
				var error_message = parameters.Get<string>("@po_error_message");

				return establecimientoSubclases;
			}
		#endregion

		}

	}
}