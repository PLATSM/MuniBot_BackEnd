using System.Collections.Generic;
using System.Threading.Tasks;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Application.Interface
{
	public interface IEstablecimientoClaseApplication
	{
		#region Metodos Sincronos

		ResponseQuery Insert(EstablecimientoClaseDTO establecimientoClaseDTO);
		ResponseQuery Update(EstablecimientoClaseDTO establecimientoClaseDTO);
		ResponseQuery Delete(EstablecimientoClaseDTO establecimientoClaseDTO);
		Response<EstablecimientoClaseDTO> Get(string co_establecimiento_clase);
		Response<IEnumerable<EstablecimientoClaseDTO>> GetAll(EstablecimientoClaseDTO establecimientoClaseDTO);

		#endregion


		#region Metodos Sincronos

		Task<ResponseQuery> InsertAsync(EstablecimientoClaseDTO establecimientoClaseDTO);
		Task<ResponseQuery> UpdateAsync(EstablecimientoClaseDTO establecimientoClaseDTO);
		Task<ResponseQuery> DeleteAsync(EstablecimientoClaseDTO establecimientoClaseDTO);
		Task<Response<EstablecimientoClaseDTO>> GetAsync(string co_establecimiento_clase);
		Task<Response<IEnumerable<EstablecimientoClaseDTO>>> GetAllAsync(EstablecimientoClaseDTO establecimientoClaseDTO);

		#endregion

	}
}