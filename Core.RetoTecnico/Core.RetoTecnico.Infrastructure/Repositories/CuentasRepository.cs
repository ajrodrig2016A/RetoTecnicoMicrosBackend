using Core.RetoTecnico.Application.Contracts.Persistence;
using Core.RetoTecnico.Domain.Entities;
using Core.RetoTecnico.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Core.RetoTecnico.Infrastructure.Repositories
{
    public class CuentasRepository : ICuentasRepository
    {
        public readonly BancoContext _context;

        public CuentasRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task<string> AddCuenta(Cuentas cuenta)
        {
            Cuentas objInsCuenta = new()
            {
                  Numero = cuenta.Numero,
                  Tipo = cuenta.Tipo,
                  SaldoInicial = cuenta.SaldoInicial,
                  Estado = cuenta.Estado,
                  ClienteId = cuenta.ClienteId
            };

            await _context.Cuentas.AddAsync(objInsCuenta);
            await _context.SaveChangesAsync();
            return objInsCuenta.Numero;
        }

        public async Task<int> DeleteCuenta(Cuentas cuenta)
        {            
            var cuentaBorrado = await _context.Cuentas.FindAsync(cuenta.Id);
            _context.Cuentas.Remove(cuentaBorrado!);

            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteCuenta(int id)
        {
            var cuentaBorrado = await _context.Cuentas.FindAsync(id);
            _context.Cuentas.Remove(cuentaBorrado!);

            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Cuentas>> GetAllCuentas()
        {
            return await _context.Cuentas.ToListAsync();
        }

        public async Task<Cuentas> GetCuentaById(int id)
        {
            return await _context.Cuentas.FindAsync(id);
        }

        public async Task<int> UpdateCuenta(Cuentas cuenta)
        {
            Cuentas objUpdCuenta = new()
            {
                Id = cuenta.Id,
                Numero = cuenta.Numero,
                Tipo = cuenta.Tipo,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = cuenta.Estado,
                ClienteId = cuenta.ClienteId
            };

            var existsCuenta = await _context.Cuentas.FindAsync(objUpdCuenta.Id);
            existsCuenta!.Numero = objUpdCuenta.Numero;
            existsCuenta.Tipo = objUpdCuenta.Tipo;
            existsCuenta.SaldoInicial = objUpdCuenta.SaldoInicial;
            existsCuenta.Estado = objUpdCuenta.Estado;
            existsCuenta.ClienteId = objUpdCuenta.ClienteId;
            _context.Cuentas.Update(existsCuenta);

            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
