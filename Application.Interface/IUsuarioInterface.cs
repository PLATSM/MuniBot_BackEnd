using System.Collections.Generic;
using System.Threading.Tasks;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Application.Interface
{
	public interface IUsuarioApplication
	{
		#region Metodos Sincronos

		ResponseQuery Insert(UsuarioDTO usuarioDTO);
		ResponseQuery Update(UsuarioDTO usuarioDTO);
		ResponseQuery Delete(UsuarioDTO usuarioDTO);
		Response<UsuarioDTO> Get(int id_usuario);
		Response<IEnumerable<UsuarioDTO>> GetAll(UsuarioDTO usuarioDTO);

		#endregion


		#region Metodos Sincronos

		Task<ResponseQuery> InsertAsync(UsuarioDTO usuarioDTO);
		Task<ResponseQuery> UpdateAsync(UsuarioDTO usuarioDTO);
		Task<ResponseQuery> DeleteAsync(UsuarioDTO usuarioDTO);
		Task<Response<UsuarioDTO>> GetAsync(int id_usuario);
		Task<Response<IEnumerable<UsuarioDTO>>> GetAllAsync(UsuarioDTO usuarioDTO);

		#endregion

	}
}