using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Domain.Entities
{
    public class EstadoCuenta
    {
        public DateTime Fecha { get; set; }

        public String Cliente { get; set; } = null!;

        public String NumeroCuenta { get; set; } = null!;

        public String Tipo { get; set; } = null!;

        public decimal SaldoInicial { get; set; }

        public bool Estado { get; set; }

        public decimal Movimiento { get; set; }

        public decimal SaldoDisponible { get; set; }
    }
}
