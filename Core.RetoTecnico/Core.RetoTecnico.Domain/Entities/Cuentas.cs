using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Domain.Entities
{
    public class Cuentas
    {
        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Ingrese un número de cuenta")]
        [MaxLength(100)]
        public string Numero { get; set; } = null!;

        //[Required(ErrorMessage = "Ingrese un tipo de cuenta: Ahorros / Corriente")]
        [MaxLength(64)]
        public string Tipo { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal SaldoInicial { get; set; }

        public bool Estado { get; set; }

        public int ClienteId { get; set; }

        public virtual Clientes Cliente { get; set; } = null!;

        public virtual ICollection<Movimientos> Movimientos { get; set; }
    }
}
