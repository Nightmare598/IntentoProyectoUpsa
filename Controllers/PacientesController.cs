using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntentoProyectoUpsa.Models;

namespace IntentoProyectoUpsa.Controllers
{
    [Route("api/Pacientes")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly PacienteContext _context;

        public PacientesController(PacienteContext context)
        {
            _context = context;
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            // return await _context.Pacientes.ToListAsync();
            return await _context.Pacientes.Include(u => u.Lecturas).ToListAsync();
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }

        // PUT: api/Pacientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, Paciente paciente)
        {
            if (id != paciente.idPaciente)
            {
                return BadRequest();
            }

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
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

        // POST: api/Pacientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
        {
            // paciente = _context.Pacientes.Include(m => m.Lecturas).Single(m => m.idPaciente == paciente.idPaciente);
            List<Lectura> lec = paciente.Lecturas.Where(x => x.pacId == paciente.idPaciente).ToList();
            paciente.Lecturas = lec;
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
           // var lec = new Lectura() { };
            
            /* var lectura = await _context.Pacientes
                              .Include(i => i.Lecturas)
                            .FirstOrDefaultAsync(i => i.idPaciente == paciente.idPaciente);*/

            
            return CreatedAtAction(nameof(GetPaciente), new { id = paciente.idPaciente }, paciente);
            
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PacienteExists(int id)
        {
            return _context.Pacientes.Any(e => e.idPaciente == id);
        }
    }
}
