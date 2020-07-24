using System.Threading.Tasks;
using System.Collections.Generic;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Domain.Interface;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Domain.Core
{
	public class EstablecimientoSubclaseDomain:IEstablecimientoSubclaseDomain
	{
		private readonly IEstablecimientoSubclaseRepository _establecimientoSubclaseRepository;

		public EstablecimientoSubclaseDomain(IEstablecimientoSubclaseRepository establecimientoSubclaseRepository)
		{
			_establecimientoSubclaseRepository = establecimientoSubclaseRepository;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(EstablecimientoSubclase establecimientoSubclase)
		{
			return _establecimientoSubclaseRepository.Insert(establecimientoSubclase);
		}

		public ResponseQuery Update(EstablecimientoSubclase establecimientoSubclase)
		{
			return _establecimientoSubclaseRepository.Update(establecimientoSubclase);
		}

		public ResponseQuery Delete(EstablecimientoSubclase establecimientoSubclase)
		{
			return _establecimientoSubclaseRepository.Delete(establecimientoSubclase);
		}

		public EstablecimientoSubclase Get(string co_establecimiento_clase,string co_establecimiento_subclase)
		{
			return _establecimientoSubclaseRepository.Get(co_establecimiento_clase, co_establecimiento_subclase);
		}

		public IEnumerable<EstablecimientoSubclase> GetAll(EstablecimientoSubclase establecimientoSubclase)
		{
			return _establecimientoSubclaseRepository.GetAll(establecimientoSubclase);
		}

		#endregion


		#region Metodos Sincronos

		public async Task<ResponseQuery> InsertAsync(EstablecimientoSubclase establecimientoSubclase)
		{
			return await _establecimientoSubclaseRepository.InsertAsync(establecimientoSubclase);
		}

		public async Task<ResponseQuery> UpdateAsync(EstablecimientoSubclase establecimientoSubclase)
		{
			return await _establecimientoSubclaseRepository.UpdateAsync(establecimientoSubclase);
		}

		public async Task<ResponseQuery> DeleteAsync(EstablecimientoSubclase establecimientoSubclase)
		{
			return await _establecimientoSubclaseRepository.DeleteAsync(establecimientoSubclase);
		}

		public async Task<EstablecimientoSubclase> GetAsync(string co_establecimiento_clase,string co_establecimiento_subclase)
		{
			return await _establecimientoSubclaseRepository.GetAsync(co_establecimiento_clase, co_establecimiento_subclase);
		}

		public async Task<IEnumerable<EstablecimientoSubclase>> GetAllAsync(EstablecimientoSubclase establecimientoSubclase)
		{
			return await _establecimientoSubclaseRepository.GetAllAsync(establecimientoSubclase);
		}

		#endregion

	}
}