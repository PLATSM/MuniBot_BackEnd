using System;
using MuniBot_BackEnd.Domain.Entity;

namespace MuniBot_BackEnd.Application.DTO
{
	public class UsuarioDTO:EntidadBase
	{
		public int id_usuario { get; set; }
		public int id_perfil { get; set; }
		public string co_usuario { get; set; }
		public string no_apellido_paterno { get; set; }
		public string no_apellido_materno { get; set; }
		public string no_nombres { get; set; }
		public string no_correo_electronico { get; set; }
		public string no_contrasena { get; set; }
		public string no_contrasena_sha256 { get; set; }
		public string fl_resetear_pwd { get; set; }
		public string fl_bloqueado { get; set; }
		public DateTime fe_bloqueado { get; set; }
		public int qt_login_intentos { get; set; }
		public DateTime fe_cambio_contrasena { get; set; }

	}
}