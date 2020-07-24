using System.Collections.Generic;
using System.Threading.Tasks;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Application.Interface
{
	public interface IEstablecimientoSubclaseApplication
	{
		#region Metodos Sincronos

		ResponseQuery Insert(EstablecimientoSubclaseDTO establecimientoSubclaseDTO);
		ResponseQuery Update(EstablecimientoSubclaseDTO establecimientoSubclaseDTO);
		ResponseQuery Delete(EstablecimientoSubclaseDTO establecimientoSubclaseDTO);
		Response<EstablecimientoSubclaseDTO> Get(string co_establecimiento_clase,string co_establecimiento_subclase);
		Response<IEnumerable<EstablecimientoSubclaseDTO>> GetAll(EstablecimientoSubclaseDTO establecimientoSubclaseDTO);

		#endregion


		#region Metodos Sincronos

		Task<ResponseQuery> InsertAsync(EstablecimientoSubclaseDTO establecimientoSubclaseDTO);
		Task<ResponseQuery> UpdateAsync(EstablecimientoSubclaseDTO establecimientoSubclaseDTO);
		Task<ResponseQuery> DeleteAsync(EstablecimientoSubclaseDTO establecimientoSubclaseDTO);
		Task<Response<EstablecimientoSubclaseDTO>> GetAsync(string co_establecimiento_clase,string co_establecimiento_subclase);
		Task<Response<IEnumerable<EstablecimientoSubclaseDTO>>> GetAllAsync(EstablecimientoSubclaseDTO establecimientoSubclaseDTO);

		#endregion

	}
}