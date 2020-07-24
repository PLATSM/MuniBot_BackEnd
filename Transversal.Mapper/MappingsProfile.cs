using System;
using AutoMapper;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Application.DTO;

namespace MuniBot_BackEnd.Transversal.Mapper
{
    public class MappingsProfile:Profile
    {
        public MappingsProfile()
        {
            CreateMap<Ubigeo, UbigeoDTO>().ReverseMap();
            CreateMap<Contribuyente, ContribuyenteDTO>().ReverseMap();
            CreateMap<SolicitudLicencia, SolicitudLicenciaDTO>().ReverseMap();
            CreateMap<DataJson, DataJsonDTO>().ReverseMap();
            CreateMap<GeneralDet, GeneralDetDTO>().ReverseMap();
            CreateMap<EstablecimientoClase, EstablecimientoClaseDTO>().ReverseMap();
            CreateMap<EstablecimientoSubclase, EstablecimientoSubclaseDTO>().ReverseMap();
            CreateMap<EstablecimientoCategoria, EstablecimientoCategoriaDTO>().ReverseMap();
            CreateMap<Reniec, ReniecDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();

            //CreateMap<Contribuyente, ContribuyenteDTO>().ReverseMap()
            //    .ForMember(destino => destino.id_contribuyente, source => source.MapFrom(origen => origen.id_contribuyente))

        }
    }
}
