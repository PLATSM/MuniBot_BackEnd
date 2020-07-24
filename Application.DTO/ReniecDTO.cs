﻿using MuniBot_BackEnd.Domain.Entity;

namespace MuniBot_BackEnd.Application.DTO
{
    public class ReniecDTO : EntidadBase
    {
        public string nuDNI { get; set; }
        public string apPrimer { get; set; }
        public string apSegundo { get; set; }
        public string prenombres { get; set; }
        public string estadoCivil { get; set; }
        public string ubigeo { get; set; }
        public string direccion { get; set; }
        public string restriccion { get; set; }
    }
}
