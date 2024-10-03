using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Domain.Entities
{
    public abstract class Personas
    {
        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Ingrese los nombres")]
        [MaxLength(200)]
        public string Nombre { get; set; } = null!;

        //Genero de la persona (M, F)
        public char Genero { get; set; }

        //Edad de la persona
        public int Edad { get; set; }

        //[Required(ErrorMessage = "Ingrese un número de identificación válido")]
        [MaxLength(20)]
        public string Identificacion { get; set; } = null!;

        [DataType(DataType.MultilineText)]
        [MaxLength(255)]
        public string Direccion { get; set; } = null!;

        //[Required(ErrorMessage = "Ingrese un número telefónico")]
        [MaxLength(50)]
        public string Telefono { get; set; } = null!;
    }
}
