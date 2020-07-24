using System.Collections.Generic;
using System.Threading.Tasks;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Application.Interface
{
	public interface IEstablecimientoCategoriaApplication
	{
		#region Metodos Sincronos

		ResponseQuery Insert(EstablecimientoCategoriaDTO establecimientoCategoriaDTO);
		ResponseQuery Update(EstablecimientoCategoriaDTO establecimientoCategoriaDTO);
		ResponseQuery Delete(EstablecimientoCategoriaDTO establecimientoCategoriaDTO);
		Response<EstablecimientoCategoriaDTO> Get(string co_establecimiento_clase,string co_establecimiento_subclase,string co_establecimiento_categoria);
		Response<IEnumerable<EstablecimientoCategoriaDTO>> GetAll(EstablecimientoCategoriaDTO establecimientoCategoriaDTO);

		#endregion


		#region Metodos Sincronos

		Task<ResponseQuery> InsertAsync(EstablecimientoCategoriaDTO establecimientoCategoriaDTO);
		Task<ResponseQuery> UpdateAsync(EstablecimientoCategoriaDTO establecimientoCategoriaDTO);
		Task<ResponseQuery> DeleteAsync(EstablecimientoCategoriaDTO establecimientoCategoriaDTO);
		Task<Response<EstablecimientoCategoriaDTO>> GetAsync(string co_establecimiento_clase,string co_establecimiento_subclase,string co_establecimiento_categoria);
		Task<Response<IEnumerable<EstablecimientoCategoriaDTO>>> GetAllAsync(EstablecimientoCategoriaDTO establecimientoCategoriaDTO);

		#endregion

	}
}