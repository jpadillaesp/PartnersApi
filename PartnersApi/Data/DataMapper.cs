using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PartnersApi.Models;

namespace PartnersApi.Data
{
    public class DataMapper
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                //config.CreateMap<Persona, PersonaDto>();
                //.ForMember(x => x.Usuarios, o => o.Ignore())
                //.ReverseMap();

                //config.CreateMap<Usuario, UsuarioDto>();
                //.ForMember(x => x.Persona, o => o.Ignore())
                //.ReverseMap();
                config.CreateMap<Persona, PersonaDto>()
                .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"{src.Nombres} {src.Apellidos}"))
                .ForMember(dest => dest.NumeroIdentificacionCompleto, opt => opt.MapFrom(src => $"{src.TipoIdentificacion}-{src.NumeroIdentificacion}"))
                .ForMember(dest => dest.Usuarios, opt => opt.MapFrom(src => src.Usuarios));

                // Mapeo de Usuario a UsuarioDto
                config.CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.Usuario1, opt => opt.MapFrom(src => src.Usuario1)) // Mapea el nombre de usuario
                .ForMember(dest => dest.Pass, opt => opt.Ignore()) // Excluye la contraseña                                                                   
                .ForMember(dest => dest.Persona, opt => opt.MapFrom(src => src.Persona)); // Mapea la relación con Persona


            });
        }
    }
}
