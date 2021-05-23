using Microsoft.EntityFrameworkCore;

namespace IntentoProyectoUpsa.Models
{
    public class PacienteContext : DbContext
    {
        public PacienteContext(DbContextOptions<PacienteContext> options)
            : base(options) 
        { 
        }

        public DbSet<Paciente> Pacientes { get; set; }
    }
}
