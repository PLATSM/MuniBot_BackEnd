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
            CreateMap<Contribuyente, ContribuyenteDTO>().ReverseMap();

            //CreateMap<Contribuyente, ContribuyenteDTO>().ReverseMap()
            //    .ForMember(destino => destino.id_contribuyente, source => source.MapFrom(origen => origen.id_contribuyente))

        }
    }
}
