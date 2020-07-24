using System.Collections.Generic;
using System.Threading.Tasks;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Domain.Interface
{
	public interface IUsuarioDomain
	{
		#region Metodos Sincronos

		ResponseQuery Insert(Usuario usuario);
		ResponseQuery Update(Usuario usuario);
		ResponseQuery Delete(Usuario usuario);
		Usuario Get(int id_usuario);
		IEnumerable<Usuario> GetAll(Usuario usuario);

		#endregion

		#region Metodos Sincronos

		Task<ResponseQuery> InsertAsync(Usuario usuario);
		Task<ResponseQuery> UpdateAsync(Usuario usuario);
		Task<ResponseQuery> DeleteAsync(Usuario usuario);
		Task<Usuario> GetAsync(int id_usuario);
		Task<IEnumerable<Usuario>> GetAllAsync(Usuario usuario);

		#endregion

	}
}