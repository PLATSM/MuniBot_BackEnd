using System;

namespace MuniBot_BackEnd.Domain.Entity
{
	public class EstablecimientoCategoria:EntidadBase
	{
		public string co_establecimiento_clase { get; set; }
		public string co_establecimiento_subclase { get; set; }
		public string co_establecimiento_categoria { get; set; }
		public string no_establecimiento_categoria { get; set; }

	}
}