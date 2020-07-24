using System;

namespace MuniBot_BackEnd.Domain.Entity
{
	public class Ubigeo:EntidadBase
	{
		public string co_ubigeo { get; set; }
		public string no_departamento { get; set; }
		public string no_provincia { get; set; }
		public string no_distrito { get; set; }
		public string co_tipo { get; set; }

	}
}