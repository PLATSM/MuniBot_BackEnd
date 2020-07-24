using System.Collections.Generic;
using System.Threading.Tasks;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Domain.Interface
{
	public interface IUbigeoDomain
	{
		#region Metodos Sincronos

		Ubigeo Get(string co_ubigeo);
		IEnumerable<Ubigeo> GetAll(Ubigeo ubigeo);

		#endregion

		#region Metodos Sincronos

		Task<Ubigeo> GetAsync(string co_ubigeo);
		Task<IEnumerable<Ubigeo>> GetAllAsync(Ubigeo ubigeo);

		#endregion

	}
}