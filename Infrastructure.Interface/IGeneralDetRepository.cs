using System.Collections.Generic;
using System.Threading.Tasks;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Infrastructure.Interface
{
	public interface IGeneralDetRepository
	{
		#region Metodos Sincronos

		ResponseQuery Insert(GeneralDet generalDet);
		ResponseQuery Update(GeneralDet generalDet);
		ResponseQuery Delete(GeneralDet generalDet);
		GeneralDet Get(int nu_general_cab,string co_general_det);
		IEnumerable<GeneralDet> GetAll(GeneralDet generalDet);

		#endregion

		#region Metodos Sincronos

		Task<ResponseQuery> InsertAsync(GeneralDet generalDet);
		Task<ResponseQuery> UpdateAsync(GeneralDet generalDet);
		Task<ResponseQuery> DeleteAsync(GeneralDet generalDet);
		Task<GeneralDet> GetAsync(int nu_general_cab,string co_general_det);
		Task<IEnumerable<GeneralDet>> GetAllAsync(GeneralDet generalDet);

		#endregion

	}
}