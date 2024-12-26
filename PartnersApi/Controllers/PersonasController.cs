using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PartnersApi.Data;
using PartnersApi.Models;

namespace PartnersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly PartnersContext _context;

        public PersonasController(PartnersContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> GetPersonas()
        {

            var personas = await _context.Personas
                .Include(p => p.Usuarios)
                .Select(p => new PersonaDto
                {
                    Id = p.Id,
                    Nombres = p.Nombres,
                    Apellidos = p.Apellidos,
                    NumeroIdentificacion = p.NumeroIdentificacion,
                    Email = p.Email,
                    TipoIdentificacion = p.TipoIdentificacion,
                    FechaCreacion = p.FechaCreacion,
                    NumeroIdentificacionCompleto = $"{p.TipoIdentificacion} {p.NumeroIdentificacion}",
                    NombreCompleto = $"{p.Nombres} {p.Apellidos}",
                    Usuarios = p.Usuarios.Select(u => new UsuarioDto
                    {
                        Id = u.Id,
                        Usuario1 = u.Usuario1,
                        Pass = u.Pass,
                        FechaCreacion = u.FechaCreacion
                    }).ToList()
                })
                .ToListAsync();

            if (personas == null || personas.Count() < 1)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<IEnumerable<PersonaDto>>(personas));
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.Id }, persona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }
    }
}
