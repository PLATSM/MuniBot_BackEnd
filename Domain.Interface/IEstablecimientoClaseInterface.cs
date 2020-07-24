using System.Collections.Generic;
using System.Threading.Tasks;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Domain.Interface
{
	public interface IEstablecimientoClaseDomain
	{
		#region Metodos Sincronos

		ResponseQuery Insert(EstablecimientoClase establecimientoClase);
		ResponseQuery Update(EstablecimientoClase establecimientoClase);
		ResponseQuery Delete(EstablecimientoClase establecimientoClase);
		EstablecimientoClase Get(string co_establecimiento_clase);
		IEnumerable<EstablecimientoClase> GetAll(EstablecimientoClase establecimientoClase);

		#endregion

		#region Metodos Sincronos

		Task<ResponseQuery> InsertAsync(EstablecimientoClase establecimientoClase);
		Task<ResponseQuery> UpdateAsync(EstablecimientoClase establecimientoClase);
		Task<ResponseQuery> DeleteAsync(EstablecimientoClase establecimientoClase);
		Task<EstablecimientoClase> GetAsync(string co_establecimiento_clase);
		Task<IEnumerable<EstablecimientoClase>> GetAllAsync(EstablecimientoClase establecimientoClase);

		#endregion

	}
}