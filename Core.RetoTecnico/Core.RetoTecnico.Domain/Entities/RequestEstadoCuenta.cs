using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Domain.Entities
{
    public class RequestEstadoCuenta
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public String NombreCliente { get; set; } = null!;
    }
}
