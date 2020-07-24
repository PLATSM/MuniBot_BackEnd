using System.Collections.Generic;
using System.Threading.Tasks;
using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Application.Interface
{
	public interface IGeneralDetApplication
	{
		#region Metodos Sincronos

		ResponseQuery Insert(GeneralDetDTO generalDetDTO);
		ResponseQuery Update(GeneralDetDTO generalDetDTO);
		ResponseQuery Delete(GeneralDetDTO generalDetDTO);
		Response<GeneralDetDTO> Get(int nu_general_cab,string co_general_det);
		Response<IEnumerable<GeneralDetDTO>> GetAll(GeneralDetDTO generalDetDTO);

		#endregion


		#region Metodos Sincronos

		Task<ResponseQuery> InsertAsync(GeneralDetDTO generalDetDTO);
		Task<ResponseQuery> UpdateAsync(GeneralDetDTO generalDetDTO);
		Task<ResponseQuery> DeleteAsync(GeneralDetDTO generalDetDTO);
		Task<Response<GeneralDetDTO>> GetAsync(int nu_general_cab,string co_general_det);
		Task<Response<IEnumerable<GeneralDetDTO>>> GetAllAsync(GeneralDetDTO generalDetDTO);

		#endregion

	}
}