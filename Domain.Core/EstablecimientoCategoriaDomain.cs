using System.Threading.Tasks;
using System.Collections.Generic;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Domain.Interface;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Domain.Core
{
	public class EstablecimientoCategoriaDomain:IEstablecimientoCategoriaDomain
	{
		private readonly IEstablecimientoCategoriaRepository _establecimientoCategoriaRepository;

		public EstablecimientoCategoriaDomain(IEstablecimientoCategoriaRepository establecimientoCategoriaRepository)
		{
			_establecimientoCategoriaRepository = establecimientoCategoriaRepository;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(EstablecimientoCategoria establecimientoCategoria)
		{
			return _establecimientoCategoriaRepository.Insert(establecimientoCategoria);
		}

		public ResponseQuery Update(EstablecimientoCategoria establecimientoCategoria)
		{
			return _establecimientoCategoriaRepository.Update(establecimientoCategoria);
		}

		public ResponseQuery Delete(EstablecimientoCategoria establecimientoCategoria)
		{
			return _establecimientoCategoriaRepository.Delete(establecimientoCategoria);
		}

		public EstablecimientoCategoria Get(string co_establecimiento_clase,string co_establecimiento_subclase,string co_establecimiento_categoria)
		{
			return _establecimientoCategoriaRepository.Get(co_establecimiento_clase, co_establecimiento_subclase, co_establecimiento_categoria);
		}

		public IEnumerable<EstablecimientoCategoria> GetAll(EstablecimientoCategoria establecimientoCategoria)
		{
			return _establecimientoCategoriaRepository.GetAll(establecimientoCategoria);
		}

		#endregion


		#region Metodos Sincronos

		public async Task<ResponseQuery> InsertAsync(EstablecimientoCategoria establecimientoCategoria)
		{
			return await _establecimientoCategoriaRepository.InsertAsync(establecimientoCategoria);
		}

		public async Task<ResponseQuery> UpdateAsync(EstablecimientoCategoria establecimientoCategoria)
		{
			return await _establecimientoCategoriaRepository.UpdateAsync(establecimientoCategoria);
		}

		public async Task<ResponseQuery> DeleteAsync(EstablecimientoCategoria establecimientoCategoria)
		{
			return await _establecimientoCategoriaRepository.DeleteAsync(establecimientoCategoria);
		}

		public async Task<EstablecimientoCategoria> GetAsync(string co_establecimiento_clase,string co_establecimiento_subclase,string co_establecimiento_categoria)
		{
			return await _establecimientoCategoriaRepository.GetAsync(co_establecimiento_clase, co_establecimiento_subclase, co_establecimiento_categoria);
		}

		public async Task<IEnumerable<EstablecimientoCategoria>> GetAllAsync(EstablecimientoCategoria establecimientoCategoria)
		{
			return await _establecimientoCategoriaRepository.GetAllAsync(establecimientoCategoria);
		}

		#endregion

	}
}