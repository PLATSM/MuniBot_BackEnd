using System;
using MuniBot_BackEnd.Domain.Entity;

namespace MuniBot_BackEnd.Application.DTO
{
	public class EstablecimientoClaseDTO:EntidadBase
	{
		public string co_establecimiento_clase { get; set; }
		public string no_establecimiento_clase { get; set; }

	}
}