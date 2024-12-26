using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartnersApi.Data
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Usuario1 { get; set; }
        public string Pass { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? PersonaId { get; set; }

        public virtual PersonaDto Persona { get; set; }
    }
}
