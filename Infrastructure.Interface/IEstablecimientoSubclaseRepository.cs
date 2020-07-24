using System.Collections.Generic;
using System.Threading.Tasks;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Infrastructure.Interface
{
	public interface IEstablecimientoSubclaseRepository
	{
		#region Metodos Sincronos

		ResponseQuery Insert(EstablecimientoSubclase establecimientoSubclase);
		ResponseQuery Update(EstablecimientoSubclase establecimientoSubclase);
		ResponseQuery Delete(EstablecimientoSubclase establecimientoSubclase);
		EstablecimientoSubclase Get(string co_establecimiento_clase,string co_establecimiento_subclase);
		IEnumerable<EstablecimientoSubclase> GetAll(EstablecimientoSubclase establecimientoSubclase);

		#endregion

		#region Metodos Sincronos

		Task<ResponseQuery> InsertAsync(EstablecimientoSubclase establecimientoSubclase);
		Task<ResponseQuery> UpdateAsync(EstablecimientoSubclase establecimientoSubclase);
		Task<ResponseQuery> DeleteAsync(EstablecimientoSubclase establecimientoSubclase);
		Task<EstablecimientoSubclase> GetAsync(string co_establecimiento_clase,string co_establecimiento_subclase);
		Task<IEnumerable<EstablecimientoSubclase>> GetAllAsync(EstablecimientoSubclase establecimientoSubclase);

		#endregion

	}
}