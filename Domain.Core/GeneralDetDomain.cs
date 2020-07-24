using System.Threading.Tasks;
using System.Collections.Generic;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Domain.Interface;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Domain.Core
{
	public class GeneralDetDomain:IGeneralDetDomain
	{
		private readonly IGeneralDetRepository _generalDetRepository;

		public GeneralDetDomain(IGeneralDetRepository generalDetRepository)
		{
			_generalDetRepository = generalDetRepository;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(GeneralDet generalDet)
		{
			return _generalDetRepository.Insert(generalDet);
		}

		public ResponseQuery Update(GeneralDet generalDet)
		{
			return _generalDetRepository.Update(generalDet);
		}

		public ResponseQuery Delete(GeneralDet generalDet)
		{
			return _generalDetRepository.Delete(generalDet);
		}

		public GeneralDet Get(int nu_general_cab,string co_general_det)
		{
			return _generalDetRepository.Get(nu_general_cab, co_general_det);
		}

		public IEnumerable<GeneralDet> GetAll(GeneralDet generalDet)
		{
			return _generalDetRepository.GetAll(generalDet);
		}

		#endregion


		#region Metodos Sincronos

		public async Task<ResponseQuery> InsertAsync(GeneralDet generalDet)
		{
			return await _generalDetRepository.InsertAsync(generalDet);
		}

		public async Task<ResponseQuery> UpdateAsync(GeneralDet generalDet)
		{
			return await _generalDetRepository.UpdateAsync(generalDet);
		}

		public async Task<ResponseQuery> DeleteAsync(GeneralDet generalDet)
		{
			return await _generalDetRepository.DeleteAsync(generalDet);
		}

		public async Task<GeneralDet> GetAsync(int nu_general_cab,string co_general_det)
		{
			return await _generalDetRepository.GetAsync(nu_general_cab, co_general_det);
		}

		public async Task<IEnumerable<GeneralDet>> GetAllAsync(GeneralDet generalDet)
		{
			return await _generalDetRepository.GetAllAsync(generalDet);
		}

		#endregion

	}
}