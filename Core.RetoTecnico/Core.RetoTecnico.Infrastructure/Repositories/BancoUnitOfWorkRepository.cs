using Core.RetoTecnico.Application.Contracts.Persistence;
using Core.RetoTecnico.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Infrastructure.Repositories
{
    public class BancoUnitOfWorkRepository : IBancoUnitOfWork
    {
        public readonly BancoContext _context;

        public BancoUnitOfWorkRepository(BancoContext context)
        {
            _context = context;
        }

        IClientesRepository _clientesRepository { get; set; }
        public IClientesRepository ClientesRepository => _clientesRepository ??= new ClientesRepository(_context);

        IPersonasRepository _personasRepository { get; set; }
        public IPersonasRepository PersonasRepository => _personasRepository ??= new PersonasRepository(_context);

        ICuentasRepository _cuentasRepository { get; set; }
        public ICuentasRepository CuentasRepository => _cuentasRepository ??= new CuentasRepository(_context);

        IMovimientosRepository _movimientosRepository { get; set; }
        public IMovimientosRepository MovimientosRepository => _movimientosRepository ??= new MovimientosRepository(_context);

        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
