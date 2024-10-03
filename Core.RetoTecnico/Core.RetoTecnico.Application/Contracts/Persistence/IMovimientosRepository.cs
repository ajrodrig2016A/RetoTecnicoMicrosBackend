using Core.RetoTecnico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Contracts.Persistence
{
    public interface IMovimientosRepository
    {
        Task<Movimientos> GetMovimientoById(int id);

        Task<IEnumerable<Movimientos>> GetAllMovimientos();

        Task<decimal> AddMovimiento(Movimientos movimiento);

        Task<int> UpdateMovimiento(Movimientos movimiento);

        Task<int> DeleteMovimiento(int id);

        Task<int> DeleteMovimiento(Movimientos movimiento);

        Task ActualizarSaldoDisponibleCta(Movimientos movimiento);

        Task<IEnumerable<EstadoCuenta>> ReporteEstadoCuenta(RequestEstadoCuenta requestEstadoCuenta);
    }
}
