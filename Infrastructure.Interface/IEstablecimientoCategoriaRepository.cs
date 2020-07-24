using System.Collections.Generic;
using System.Threading.Tasks;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Infrastructure.Interface
{
	public interface IEstablecimientoCategoriaRepository
	{
		#region Metodos Sincronos

		ResponseQuery Insert(EstablecimientoCategoria establecimientoCategoria);
		ResponseQuery Update(EstablecimientoCategoria establecimientoCategoria);
		ResponseQuery Delete(EstablecimientoCategoria establecimientoCategoria);
		EstablecimientoCategoria Get(string co_establecimiento_clase,string co_establecimiento_subclase,string co_establecimiento_categoria);
		IEnumerable<EstablecimientoCategoria> GetAll(EstablecimientoCategoria establecimientoCategoria);

		#endregion

		#region Metodos Sincronos

		Task<ResponseQuery> InsertAsync(EstablecimientoCategoria establecimientoCategoria);
		Task<ResponseQuery> UpdateAsync(EstablecimientoCategoria establecimientoCategoria);
		Task<ResponseQuery> DeleteAsync(EstablecimientoCategoria establecimientoCategoria);
		Task<EstablecimientoCategoria> GetAsync(string co_establecimiento_clase,string co_establecimiento_subclase,string co_establecimiento_categoria);
		Task<IEnumerable<EstablecimientoCategoria>> GetAllAsync(EstablecimientoCategoria establecimientoCategoria);

		#endregion

	}
}