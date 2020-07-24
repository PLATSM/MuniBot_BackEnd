using System.Threading.Tasks;
using System.Collections.Generic;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Domain.Interface;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Domain.Core
{
	public class EstablecimientoClaseDomain:IEstablecimientoClaseDomain
	{
		private readonly IEstablecimientoClaseRepository _establecimientoClaseRepository;

		public EstablecimientoClaseDomain(IEstablecimientoClaseRepository establecimientoClaseRepository)
		{
			_establecimientoClaseRepository = establecimientoClaseRepository;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(EstablecimientoClase establecimientoClase)
		{
			return _establecimientoClaseRepository.Insert(establecimientoClase);
		}

		public ResponseQuery Update(EstablecimientoClase establecimientoClase)
		{
			return _establecimientoClaseRepository.Update(establecimientoClase);
		}

		public ResponseQuery Delete(EstablecimientoClase establecimientoClase)
		{
			return _establecimientoClaseRepository.Delete(establecimientoClase);
		}

		public EstablecimientoClase Get(string co_establecimiento_clase)
		{
			return _establecimientoClaseRepository.Get(co_establecimiento_clase);
		}

		public IEnumerable<EstablecimientoClase> GetAll(EstablecimientoClase establecimientoClase)
		{
			return _establecimientoClaseRepository.GetAll(establecimientoClase);
		}

		#endregion


		#region Metodos Sincronos

		public async Task<ResponseQuery> InsertAsync(EstablecimientoClase establecimientoClase)
		{
			return await _establecimientoClaseRepository.InsertAsync(establecimientoClase);
		}

		public async Task<ResponseQuery> UpdateAsync(EstablecimientoClase establecimientoClase)
		{
			return await _establecimientoClaseRepository.UpdateAsync(establecimientoClase);
		}

		public async Task<ResponseQuery> DeleteAsync(EstablecimientoClase establecimientoClase)
		{
			return await _establecimientoClaseRepository.DeleteAsync(establecimientoClase);
		}

		public async Task<EstablecimientoClase> GetAsync(string co_establecimiento_clase)
		{
			return await _establecimientoClaseRepository.GetAsync(co_establecimiento_clase);
		}

		public async Task<IEnumerable<EstablecimientoClase>> GetAllAsync(EstablecimientoClase establecimientoClase)
		{
			return await _establecimientoClaseRepository.GetAllAsync(establecimientoClase);
		}

		#endregion

	}
}