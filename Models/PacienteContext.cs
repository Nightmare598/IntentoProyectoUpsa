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
            //var lect = new Lectura();
            modelBuilder.Entity<Paciente>().HasMany(p => p.Lecturas).WithOne(b => b.Paciente).HasForeignKey(p => p.pacId);
            // modelBuilder.Entity<Paciente>().HasMany(p => p.Lecturas).WithOne(s => s.Paciente).HasForeignKey(x => x.idPaciente).IsRequired();
            // modelBuilder.Entity<Paciente>().HasMany<Lectura>(s => s.Lecturas).WithOne(e => e.Paciente).HasForeignKey(r => r.idPaciente).IsRequired();
            // modelBuilder.Entity<Paciente>().HasMany(paciente => paciente.Lecturas);
            //  modelBuilder.Entity<Lectura>().HasOne(p => p.Paciente).WithMany(b => b.Lecturas).HasForeignKey(p => p.idPaciente);
            // modelBuilder.Entity<Paciente>().HasMany(p => p.Lecturas).WithOne(b => b.Paciente);
            // modelBuilder.Entity<Paciente>().HasMany(e => e.Lecturas).WithOne(g => g.Paciente).HasForeignKey("pacId");
            
        }
    }
}
