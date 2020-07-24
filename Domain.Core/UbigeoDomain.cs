using System.Threading.Tasks;
using System.Collections.Generic;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Domain.Interface;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Domain.Core
{
	public class UbigeoDomain:IUbigeoDomain
	{
		private readonly IUbigeoRepository _ubigeoRepository;

		public UbigeoDomain(IUbigeoRepository ubigeoRepository)
		{
			_ubigeoRepository = ubigeoRepository;
		}

		#region Metodos Sincronos

		public Ubigeo Get(string co_ubigeo)
		{
			return _ubigeoRepository.Get(co_ubigeo);
		}

		public IEnumerable<Ubigeo> GetAll(Ubigeo ubigeo)
		{
			return _ubigeoRepository.GetAll(ubigeo);
		}

		#endregion


		#region Metodos Sincronos

		public async Task<Ubigeo> GetAsync(string co_ubigeo)
		{
			return await _ubigeoRepository.GetAsync(co_ubigeo);
		}

		public async Task<IEnumerable<Ubigeo>> GetAllAsync(Ubigeo ubigeo)
		{
			return await _ubigeoRepository.GetAllAsync(ubigeo);
		}

		#endregion

	}
}