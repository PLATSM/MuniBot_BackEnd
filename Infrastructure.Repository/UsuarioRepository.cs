using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Infrastructure.Repository
{
	public class UsuarioRepository:IUsuarioRepository
	{
		private readonly IConnectionFactory _connectionFactory;

		public UsuarioRepository(IConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(Usuario usuario)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spi_mae_usuario";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_id_perfil", usuario.id_perfil);
				parameters.Add("@pi_co_usuario", usuario.co_usuario);
				parameters.Add("@pi_no_apellido_paterno", usuario.no_apellido_paterno);
				parameters.Add("@pi_no_apellido_materno", usuario.no_apellido_materno);
				parameters.Add("@pi_no_nombres", usuario.no_nombres);
				parameters.Add("@pi_no_correo_electronico", usuario.no_correo_electronico);
				parameters.Add("@pi_no_contrasena", usuario.no_contrasena);
				parameters.Add("@pi_no_contrasena_sha256", usuario.no_contrasena_sha256);
				parameters.Add("@pi_id_usuario_login", usuario.id_usuario_creacion);
				parameters.Add("@po_id_usuario", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public ResponseQuery Update(Usuario usuario)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spu_mae_usuario";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_id_usuario", usuario.id_usuario);
				parameters.Add("@pi_id_perfil", usuario.id_perfil);
				parameters.Add("@pi_co_usuario", usuario.co_usuario);
				parameters.Add("@pi_no_apellido_paterno", usuario.no_apellido_paterno);
				parameters.Add("@pi_no_apellido_materno", usuario.no_apellido_materno);
				parameters.Add("@pi_no_nombres", usuario.no_nombres);
				parameters.Add("@pi_no_correo_electronico", usuario.no_correo_electronico);
				parameters.Add("@pi_id_usuario_login", usuario.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public ResponseQuery Delete(Usuario usuario)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spd_mae_usuario";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_id_usuario", usuario.id_usuario);
				parameters.Add("@pi_id_usuario_login", usuario.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public Usuario Get(int id_usuario)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "sps_mae_usuario";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_id_usuario", id_usuario);
				parameters.Add("@pi_id_usuario_login", 0);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var usuario = connection.QuerySingleOrDefault<Usuario>(query, param: parameters, commandType: CommandType.StoredProcedure);

				if (usuario == null)
				{
					Usuario usuarioError = new Usuario();
					usuarioError.error_number = parameters.Get<int>("@po_error_number");
					usuarioError.error_message = parameters.Get<string>("@po_error_message");
				return usuarioError;
				}
				else
				{
				return usuario;
				}
			}
		}
		public IEnumerable<Usuario> GetAll(Usuario usuario)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spl_mae_usuario";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_id_usuario", usuario.id_usuario);
				parameters.Add("@pi_id_perfil", usuario.id_perfil);
				parameters.Add("@pi_co_usuario", usuario.co_usuario);
				parameters.Add("@pi_no_apellido_paterno", usuario.no_apellido_paterno);
				parameters.Add("@pi_no_apellido_materno", usuario.no_apellido_materno);
				parameters.Add("@pi_no_nombres", usuario.no_nombres);
				parameters.Add("@pi_fl_inactivo", usuario.fl_inactivo);
				parameters.Add("@pi_id_usuario_login", usuario.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var usuarios = connection.Query<Usuario>(query, param: parameters, commandType: CommandType.StoredProcedure);
				var error_number = parameters.Get<int>("@po_error_number");
				var error_message = parameters.Get<string>("@po_error_message");

				return usuarios;
			}
		}
		#endregion

		#region Metodos Asincronos

		public async Task<ResponseQuery> InsertAsync(Usuario usuario)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spi_mae_usuario";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_id_perfil", usuario.id_perfil);
				parameters.Add("@pi_co_usuario", usuario.co_usuario);
				parameters.Add("@pi_no_apellido_paterno", usuario.no_apellido_paterno);
				parameters.Add("@pi_no_apellido_materno", usuario.no_apellido_materno);
				parameters.Add("@pi_no_nombres", usuario.no_nombres);
				parameters.Add("@pi_no_correo_electronico", usuario.no_correo_electronico);
				parameters.Add("@pi_no_contrasena", usuario.no_contrasena);
				parameters.Add("@pi_no_contrasena_sha256", usuario.no_contrasena_sha256);
				parameters.Add("@pi_id_usuario_login", usuario.id_usuario_creacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<ResponseQuery> UpdateAsync(Usuario usuario)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spu_mae_usuario";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_id_usuario", usuario.id_usuario);
				parameters.Add("@pi_id_perfil", usuario.id_perfil);
				parameters.Add("@pi_co_usuario", usuario.co_usuario);
				parameters.Add("@pi_no_apellido_paterno", usuario.no_apellido_paterno);
				parameters.Add("@pi_no_apellido_materno", usuario.no_apellido_materno);
				parameters.Add("@pi_no_nombres", usuario.no_nombres);
				parameters.Add("@pi_no_correo_electronico", usuario.no_correo_electronico);
				parameters.Add("@pi_id_usuario_login", usuario.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<ResponseQuery> DeleteAsync(Usuario usuario)
		{
			ResponseQuery responseQuery = new ResponseQuery();

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spd_mae_usuario";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_id_usuario", usuario.id_usuario);
				parameters.Add("@pi_id_usuario_login", usuario.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
				responseQuery.error_number = parameters.Get<int>("@po_error_number");
				responseQuery.error_message = parameters.Get<string>("@po_error_message");

				return responseQuery;
			}
		}
		public async Task<Usuario> GetAsync(int id_usuario)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "sps_mae_usuario";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_id_usuario", id_usuario);
				parameters.Add("@pi_id_usuario_login", 0);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var usuario = await connection.QuerySingleOrDefaultAsync<Usuario>(query, param: parameters, commandType: CommandType.StoredProcedure);

				if (usuario == null)
				{
					Usuario usuarioError = new Usuario();
					usuarioError.error_number = parameters.Get<int>("@po_error_number");
					usuarioError.error_message = parameters.Get<string>("@po_error_message");
				return usuarioError;
				}
				else
				{
				return usuario;
				}
			}
		}
		public async Task<IEnumerable<Usuario>> GetAllAsync(Usuario usuario)
		{
			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "spl_mae_usuario";
				var parameters = new DynamicParameters();
				parameters.Add("@pi_id_usuario", usuario.id_usuario);
				parameters.Add("@pi_id_perfil", usuario.id_perfil);
				parameters.Add("@pi_co_usuario", usuario.co_usuario);
				parameters.Add("@pi_no_apellido_paterno", usuario.no_apellido_paterno);
				parameters.Add("@pi_no_apellido_materno", usuario.no_apellido_materno);
				parameters.Add("@pi_no_nombres", usuario.no_nombres);
				parameters.Add("@pi_fl_inactivo", usuario.fl_inactivo);
				parameters.Add("@pi_id_usuario_login", usuario.id_usuario_modificacion);
				parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
				parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

				var usuarios = await connection.QueryAsync<Usuario>(query, param: parameters, commandType: CommandType.StoredProcedure);
				var error_number = parameters.Get<int>("@po_error_number");
				var error_message = parameters.Get<string>("@po_error_message");

				return usuarios;
			}
		#endregion

		}

	}
}