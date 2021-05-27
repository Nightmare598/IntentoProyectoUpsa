using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace IntentoProyectoUpsa.Models
{
    public class Paciente
    {
        [Key]
        public int idPaciente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public virtual List<Lectura> Lecturas { get; set; } 

        public Paciente()
        {
            Lecturas = new List<Lectura>();
        }
       
    }

    public class Lectura
    {
        [Key]
        public int idLectura { get; set; }
        public DateTime Fecha { get; set; }
        public int RitmoCardiaco { get; set; }
        public int SaturacionOxigeno { get; set; }
        public int pacId { get; set; }
        [ForeignKey("pacId")]
       /* [JsonIgnore]
        [BindProperty]*/
        public virtual Paciente Paciente { get; set; }
    }

}
