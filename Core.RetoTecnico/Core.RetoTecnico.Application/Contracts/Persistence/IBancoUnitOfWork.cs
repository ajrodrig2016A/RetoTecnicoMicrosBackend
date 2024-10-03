using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Contracts.Persistence
{
    public interface IBancoUnitOfWork : IDisposable
    {
        IClientesRepository ClientesRepository { get; }

        IPersonasRepository PersonasRepository { get; }

        ICuentasRepository CuentasRepository { get; }

        IMovimientosRepository MovimientosRepository { get; }
    }
}
