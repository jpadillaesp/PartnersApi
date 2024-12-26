using System;
using System.Collections.Generic;

#nullable disable

namespace PartnersApi.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Email { get; set; }
        public string TipoIdentificacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string NumeroIdentificacionCompleto { get; set; }
        public string NombreCompleto { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
