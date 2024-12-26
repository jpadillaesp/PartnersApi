using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartnersApi.Data
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Email { get; set; }
        public string TipoIdentificacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string NumeroIdentificacionCompleto { get; set; }
        public string NombreCompleto { get; set; }

        public virtual List<UsuarioDto> Usuarios { get; set; }
    }
}
