using System.Threading.Tasks;
using System.Collections.Generic;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Domain.Interface;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Domain.Core
{
	public class UsuarioDomain:IUsuarioDomain
	{
		private readonly IUsuarioRepository _usuarioRepository;

		public UsuarioDomain(IUsuarioRepository usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;
		}

		#region Metodos Sincronos

		public ResponseQuery Insert(Usuario usuario)
		{
			return _usuarioRepository.Insert(usuario);
		}

		public ResponseQuery Update(Usuario usuario)
		{
			return _usuarioRepository.Update(usuario);
		}

		public ResponseQuery Delete(Usuario usuario)
		{
			return _usuarioRepository.Delete(usuario);
		}

		public Usuario Get(int id_usuario)
		{
			return _usuarioRepository.Get(id_usuario);
		}

		public IEnumerable<Usuario> GetAll(Usuario usuario)
		{
			return _usuarioRepository.GetAll(usuario);
		}

		#endregion


		#region Metodos Sincronos

		public async Task<ResponseQuery> InsertAsync(Usuario usuario)
		{
			return await _usuarioRepository.InsertAsync(usuario);
		}

		public async Task<ResponseQuery> UpdateAsync(Usuario usuario)
		{
			return await _usuarioRepository.UpdateAsync(usuario);
		}

		public async Task<ResponseQuery> DeleteAsync(Usuario usuario)
		{
			return await _usuarioRepository.DeleteAsync(usuario);
		}

		public async Task<Usuario> GetAsync(int id_usuario)
		{
			return await _usuarioRepository.GetAsync(id_usuario);
		}

		public async Task<IEnumerable<Usuario>> GetAllAsync(Usuario usuario)
		{
			return await _usuarioRepository.GetAllAsync(usuario);
		}

		#endregion

	}
}