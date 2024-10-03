using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Domain.Entities
{
    public class Clientes : Personas
    {
        [Key]
        public new int Id { get; set; }

        [MaxLength(255)]
        public string Contrasenia { get; set; } = null!;

        public bool Estado { get; set; }

        public virtual ICollection<Cuentas> Cuentas { get; set; } = null!;
    }
}
