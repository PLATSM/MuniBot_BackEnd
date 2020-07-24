using System;
using MuniBot_BackEnd.Domain.Entity;

namespace MuniBot_BackEnd.Application.DTO
{
	public class GeneralDetDTO:EntidadBase
	{
		public int nu_general_cab { get; set; }
		public string co_general_det { get; set; }
		public string no_general_det { get; set; }

	}
}