using System.ComponentModel.DataAnnotations;

namespace IntentoProyectoUpsa.Models
{
    public class Paciente
    {
        [Key]
        public long idPaciente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
