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
        public DbSet<Lectura> Lecturas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
              modelBuilder.Entity<Paciente>().HasMany(p => p.Lecturas).WithOne(b => b.Paciente).HasForeignKey(p => p.idPaciente);
            //  modelBuilder.Entity<Lectura>().HasOne(p => p.Paciente).WithMany(b => b.Lecturas).HasForeignKey(p => p.idPaciente);
           // modelBuilder.Entity<Paciente>().HasMany(p => p.Lecturas).WithOne(b => b.Paciente);
        }
    }
}
