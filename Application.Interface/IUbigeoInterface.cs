using System.Collections.Generic;
using System.Threading.Tasks;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Application.Interface
{
	public interface IUbigeoApplication
	{
		#region Metodos Sincronos

		Response<UbigeoDTO> Get(string co_ubigeo);
		Response<IEnumerable<UbigeoDTO>> GetAll(UbigeoDTO ubigeoDTO);

		#endregion


		#region Metodos Sincronos

		Task<Response<UbigeoDTO>> GetAsync(string co_ubigeo);
		Task<Response<IEnumerable<UbigeoDTO>>> GetAllAsync(UbigeoDTO ubigeoDTO);

		#endregion

	}
}