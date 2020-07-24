using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Infrastructure.Repository
{
	public class UbigeoRepository:IUbigeoRepository
	{
		private readonly IConnectionFactory _connectionFactory;

		public UbigeoRepository(IConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		#region Metodos Sincronos

		public Ubigeo Get(string co_ubigeo)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "sps_mae_ubigeo";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_ubigeo", co_ubigeo);
				parameters.Add("@pi_id_usuario_login", 0);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var ubigeo = connection.QuerySingleOrDefault<Ubigeo>(query, param: parameters, commandType: CommandType.StoredProcedure);

				if (ubigeo == null)
				{
					Ubigeo ubigeoError = new Ubigeo();
					ubigeoError.error_number = parameters.Get<int>("@po_error_number");
					ubigeoError.error_message = parameters.Get<string>("@po_error_message");
				return ubigeoError;
				}
				else
				{
				return ubigeo;
				}
			}
		}
		public IEnumerable<Ubigeo> GetAll(Ubigeo ubigeo)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spl_mae_ubigeo";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_tipo", ubigeo.co_tipo);
				parameters.Add("@pi_co_ubigeo", ubigeo.co_ubigeo);
				parameters.Add("@pi_id_usuario_login", ubigeo.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var ubigeos = connection.Query<Ubigeo>(query, param: parameters, commandType: CommandType.StoredProcedure);
				var error_number = parameters.Get<int>("@po_error_number");
				var error_message = parameters.Get<string>("@po_error_message");

				return ubigeos;
			}
		}
		#endregion

		#region Metodos Asincronos

		public async Task<Ubigeo> GetAsync(string co_ubigeo)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "sps_mae_ubigeo";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_ubigeo", co_ubigeo);
				parameters.Add("@pi_id_usuario_login", 0);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var ubigeo = await connection.QuerySingleOrDefaultAsync<Ubigeo>(query, param: parameters, commandType: CommandType.StoredProcedure);

				if (ubigeo == null)
				{
					Ubigeo ubigeoError = new Ubigeo();
					ubigeoError.error_number = parameters.Get<int>("@po_error_number");
					ubigeoError.error_message = parameters.Get<string>("@po_error_message");
				return ubigeoError;
				}
				else
				{
				return ubigeo;
				}
			}
		}
		public async Task<IEnumerable<Ubigeo>> GetAllAsync(Ubigeo ubigeo)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spl_mae_ubigeo";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_tipo", ubigeo.co_tipo);
				parameters.Add("@pi_co_ubigeo", ubigeo.co_ubigeo);
				parameters.Add("@pi_id_usuario_login", ubigeo.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var ubigeos = await connection.QueryAsync<Ubigeo>(query, param: parameters, commandType: CommandType.StoredProcedure);
				var error_number = parameters.Get<int>("@po_error_number");
				var error_message = parameters.Get<string>("@po_error_message");

				return ubigeos;
			}
		#endregion

		}

	}
}