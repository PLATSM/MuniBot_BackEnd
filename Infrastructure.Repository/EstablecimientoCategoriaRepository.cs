using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Infrastructure.Repository
{
	public class EstablecimientoCategoriaRepository:IEstablecimientoCategoriaRepository
	{
		private readonly IConnectionFactory _connectionFactory;

		public EstablecimientoCategoriaRepository(IConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(EstablecimientoCategoria establecimientoCategoria)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spi_tbl_establecimiento_categoria";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_no_establecimiento_categoria", establecimientoCategoria.no_establecimiento_categoria);
				parameters.Add("@pi_id_usuario_login", establecimientoCategoria.id_usuario_creacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public ResponseQuery Update(EstablecimientoCategoria establecimientoCategoria)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spu_tbl_establecimiento_categoria";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoCategoria.co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", establecimientoCategoria.co_establecimiento_subclase);
				parameters.Add("@pi_co_establecimiento_categoria", establecimientoCategoria.co_establecimiento_categoria);
				parameters.Add("@pi_no_establecimiento_categoria", establecimientoCategoria.no_establecimiento_categoria);
				parameters.Add("@pi_id_usuario_login", establecimientoCategoria.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public ResponseQuery Delete(EstablecimientoCategoria establecimientoCategoria)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spd_tbl_establecimiento_categoria";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoCategoria.co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", establecimientoCategoria.co_establecimiento_subclase);
				parameters.Add("@pi_co_establecimiento_categoria", establecimientoCategoria.co_establecimiento_categoria);
				parameters.Add("@pi_id_usuario_login", establecimientoCategoria.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public EstablecimientoCategoria Get(string co_establecimiento_clase,string co_establecimiento_subclase,string co_establecimiento_categoria)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "sps_tbl_establecimiento_categoria";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", co_establecimiento_subclase);
				parameters.Add("@pi_co_establecimiento_categoria", co_establecimiento_categoria);
				parameters.Add("@pi_id_usuario_login", 0);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var establecimientoCategoria = connection.QuerySingleOrDefault<EstablecimientoCategoria>(query, param: parameters, commandType: CommandType.StoredProcedure);

				if (establecimientoCategoria == null)
				{
					EstablecimientoCategoria establecimientoCategoriaError = new EstablecimientoCategoria();
					establecimientoCategoriaError.error_number = parameters.Get<int>("@po_error_number");
					establecimientoCategoriaError.error_message = parameters.Get<string>("@po_error_message");
				return establecimientoCategoriaError;
				}
				else
				{
				return establecimientoCategoria;
				}
			}
		}
		public IEnumerable<EstablecimientoCategoria> GetAll(EstablecimientoCategoria establecimientoCategoria)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spl_tbl_establecimiento_categoria";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoCategoria.co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", establecimientoCategoria.co_establecimiento_subclase);
				parameters.Add("@pi_co_establecimiento_categoria", establecimientoCategoria.co_establecimiento_categoria);
				parameters.Add("@pi_no_establecimiento_categoria", establecimientoCategoria.no_establecimiento_categoria);
				parameters.Add("@pi_fl_inactivo", establecimientoCategoria.fl_inactivo);
				parameters.Add("@pi_id_usuario_login", establecimientoCategoria.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var establecimientoCategorias = connection.Query<EstablecimientoCategoria>(query, param: parameters, commandType: CommandType.StoredProcedure);
				var error_number = parameters.Get<int>("@po_error_number");
				var error_message = parameters.Get<string>("@po_error_message");

				return establecimientoCategorias;
			}
		}
		#endregion

		#region Metodos Asincronos

		public async Task<ResponseQuery> InsertAsync(EstablecimientoCategoria establecimientoCategoria)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spi_tbl_establecimiento_categoria";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_no_establecimiento_categoria", establecimientoCategoria.no_establecimiento_categoria);
				parameters.Add("@pi_id_usuario_login", establecimientoCategoria.id_usuario_creacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<ResponseQuery> UpdateAsync(EstablecimientoCategoria establecimientoCategoria)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spu_tbl_establecimiento_categoria";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoCategoria.co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", establecimientoCategoria.co_establecimiento_subclase);
				parameters.Add("@pi_co_establecimiento_categoria", establecimientoCategoria.co_establecimiento_categoria);
				parameters.Add("@pi_no_establecimiento_categoria", establecimientoCategoria.no_establecimiento_categoria);
				parameters.Add("@pi_id_usuario_login", establecimientoCategoria.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<ResponseQuery> DeleteAsync(EstablecimientoCategoria establecimientoCategoria)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spd_tbl_establecimiento_categoria";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoCategoria.co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", establecimientoCategoria.co_establecimiento_subclase);
				parameters.Add("@pi_co_establecimiento_categoria", establecimientoCategoria.co_establecimiento_categoria);
				parameters.Add("@pi_id_usuario_login", establecimientoCategoria.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<EstablecimientoCategoria> GetAsync(string co_establecimiento_clase,string co_establecimiento_subclase,string co_establecimiento_categoria)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "sps_tbl_establecimiento_categoria";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", co_establecimiento_subclase);
				parameters.Add("@pi_co_establecimiento_categoria", co_establecimiento_categoria);
				parameters.Add("@pi_id_usuario_login", 0);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var establecimientoCategoria = await connection.QuerySingleOrDefaultAsync<EstablecimientoCategoria>(query, param: parameters, commandType: CommandType.StoredProcedure);

				if (establecimientoCategoria == null)
				{
					EstablecimientoCategoria establecimientoCategoriaError = new EstablecimientoCategoria();
					establecimientoCategoriaError.error_number = parameters.Get<int>("@po_error_number");
					establecimientoCategoriaError.error_message = parameters.Get<string>("@po_error_message");
				return establecimientoCategoriaError;
				}
				else
				{
				return establecimientoCategoria;
				}
			}
		}
		public async Task<IEnumerable<EstablecimientoCategoria>> GetAllAsync(EstablecimientoCategoria establecimientoCategoria)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spl_tbl_establecimiento_categoria";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_co_establecimiento_clase", establecimientoCategoria.co_establecimiento_clase);
				parameters.Add("@pi_co_establecimiento_subclase", establecimientoCategoria.co_establecimiento_subclase);
				parameters.Add("@pi_co_establecimiento_categoria", establecimientoCategoria.co_establecimiento_categoria);
				parameters.Add("@pi_no_establecimiento_categoria", establecimientoCategoria.no_establecimiento_categoria);
				parameters.Add("@pi_fl_inactivo", establecimientoCategoria.fl_inactivo);
				parameters.Add("@pi_id_usuario_login", establecimientoCategoria.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var establecimientoCategorias = await connection.QueryAsync<EstablecimientoCategoria>(query, param: parameters, commandType: CommandType.StoredProcedure);
				var error_number = parameters.Get<int>("@po_error_number");
				var error_message = parameters.Get<string>("@po_error_message");

				return establecimientoCategorias;
			}
		#endregion

		}

	}
}