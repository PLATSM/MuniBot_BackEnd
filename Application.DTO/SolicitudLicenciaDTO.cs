using System;
using MuniBot_BackEnd.Domain.Entity;

namespace MuniBot_BackEnd.Application.DTO
{
    public class SolicitudLicenciaDTO: EntidadBase
    {
		public int id_solicitud_licencia { get; set; }
		public int id_empresa { get; set; }
		public int id_contribuyente { get; set; }
		public string co_tipo_licencia { get; set; }
		public string no_comercial { get; set; }
		public string co_clase { get; set; }
		public string co_sub_clase { get; set; }
		public string co_categoria { get; set; }
		public string no_dirección { get; set; }
		public string nu_area { get; set; }
		public string no_imagen_croquis { get; set; }
		public string co_estado { get; set; }
		public string nu_resolucion { get; set; }
		public string fe_resolucion { get; set; }
		public int id_autorizador { get; set; }

		public string fe_proceso_ini { get; set; }
		public string fe_proceso_fin { get; set; }

	}
}
