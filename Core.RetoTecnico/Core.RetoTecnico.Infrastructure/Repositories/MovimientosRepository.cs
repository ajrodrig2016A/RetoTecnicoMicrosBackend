using Core.RetoTecnico.Application.Contracts.Persistence;
using Core.RetoTecnico.Domain.Entities;
using Core.RetoTecnico.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Infrastructure.Repositories
{
    public class MovimientosRepository : IMovimientosRepository
    {
        public readonly BancoContext _context;
        public CuentasRepository _cuentasRepository;
        public MovimientosRepository(BancoContext context)
        {
            _context = context;
            _cuentasRepository = new(_context);
        }

        public async Task ActualizarSaldoDisponibleCta(Movimientos movimiento)
        {
            decimal decSaldoCuenta, decSaldoMovimiento;

            //Cuentas objConsultaCuenta = new Cuentas()
            //{
            //    Id = movimiento.CuentaId
            //};

            try
            {
                //Consulta id del movimiento registrado
                var intIdMovimiento = await _context.Movimientos.Where(x => x.CuentaId == movimiento.CuentaId && x.Fecha == movimiento.Fecha && x.Saldo == movimiento.Saldo).Select(y => y.Id).FirstOrDefaultAsync(); 

                //Se consulta saldo de la cuenta antes de registrar el movimiento
                decSaldoCuenta = await _context.Cuentas.Where(a => a.Id == movimiento.CuentaId).Select(s => s.SaldoInicial).FirstOrDefaultAsync();

                //Se calcula saldo disponible del movimiento registrado
                decSaldoMovimiento = decSaldoCuenta + movimiento.Valor;

                Movimientos objUpdSaldoMovimiento = new()
                {
                    Id = intIdMovimiento,
                    Fecha = movimiento.Fecha,
                    Tipo = movimiento.Tipo,
                    Valor = movimiento.Valor,
                    Saldo = decSaldoMovimiento,
                    CuentaId = movimiento.CuentaId
                };
                //Se actualiza saldo final del movimiento
                await UpdateMovimiento(objUpdSaldoMovimiento);

                var queryCuenta = await _context.Cuentas.Include(u => u.Cliente).Where(x => x.Id == movimiento.CuentaId)
                    .Select(c => new Cuentas
                    {   ClienteId = c.ClienteId,  
                        Numero = c.Numero,
                        Tipo = c.Tipo
                    }).FirstOrDefaultAsync();
                    //await _context.Clientes.Include(a => a.Cuentas).Where(x => x.Cuentas.Contains(movimiento.CuentaId)).Select(c => c.Id).FirstOrDefaultAsync();

                Cuentas objUpdCuenta = new()
                {
                    Id = movimiento.CuentaId,
                    Numero = queryCuenta.Numero,
                    Tipo = queryCuenta.Tipo,
                    SaldoInicial = decSaldoMovimiento,
                    Estado = movimiento.Cuenta.Estado,
                    ClienteId = queryCuenta.ClienteId
                };
                //Se actualiza saldo disponible final de la cuenta
                await _cuentasRepository.UpdateCuenta(objUpdCuenta);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 

        }

        public async Task<decimal> AddMovimiento(Movimientos movimiento)
        {
            Movimientos objInsMovimiento = new()
            {
                Fecha = movimiento.Fecha,
                Tipo = movimiento.Tipo,
                Valor = movimiento.Valor,
                Saldo = movimiento.Saldo,
                CuentaId = movimiento.CuentaId
            };

            _context.Database.BeginTransaction();
            await _context.Movimientos.AddAsync(objInsMovimiento);
            await _context.SaveChangesAsync();
            await ActualizarSaldoDisponibleCta(movimiento);
            _context.Database.CommitTransaction();
            return objInsMovimiento.Valor;
        }

        public async Task<int> DeleteMovimiento(Movimientos movimiento)
        {
            var movimientoBorrado = await _context.Movimientos.FindAsync(movimiento.Id);
            _context.Movimientos.Remove(movimientoBorrado!);

            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteMovimiento(int id)
        {
            var movimientoBorrado = await _context.Movimientos.FindAsync(id);
            _context.Movimientos.Remove(movimientoBorrado!);

            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Movimientos>> GetAllMovimientos()
        {
            return await _context.Movimientos.ToListAsync();
        }

        public async Task<Movimientos> GetMovimientoById(int id)
        {
            return await _context.Movimientos.FindAsync(id);
        }

        public async Task<IEnumerable<EstadoCuenta>> ReporteEstadoCuenta(RequestEstadoCuenta requestEstadoCuenta)
        {
            IEnumerable<EstadoCuenta> result;
            List<EstadoCuenta> resultAux = new List<EstadoCuenta>();

            var collection = await _context.Movimientos.Include(a => a.Cuenta).Include(u => u.Cuenta.Cliente)
                .Where(x => x.Fecha >= requestEstadoCuenta.FechaInicio && x.Fecha <= requestEstadoCuenta.FechaFin && x.Cuenta.Cliente.Nombre.Contains(requestEstadoCuenta.NombreCliente)).Select
                (m => new Movimientos
                {
                    Fecha = m.Fecha,
                    Tipo = m.Tipo,
                    Valor = m.Valor,
                    Saldo = m.Saldo,
                    Cuenta = new Cuentas
                    {
                        Numero = m.Cuenta.Numero,
                        Tipo = m.Cuenta.Tipo,
                        SaldoInicial = m.Cuenta.SaldoInicial,
                        Estado = m.Cuenta.Estado,
                        Cliente = new Clientes
                        {
                            Nombre = m.Cuenta.Cliente.Nombre
                        }
                    }
                }).ToListAsync();

            foreach (var item in collection)
            {
                EstadoCuenta itemMovimiento = new()
                {
                    Fecha = item.Fecha,
                    Cliente = item.Cuenta.Cliente.Nombre,
                    NumeroCuenta = item.Cuenta.Numero,
                    Tipo = item.Cuenta.Tipo,
                    SaldoInicial = item.Cuenta.SaldoInicial,
                    Estado = item.Cuenta.Estado,
                    Movimiento = item.Valor, 
                    SaldoDisponible = item.Saldo,
                };

                resultAux.Add(itemMovimiento);
            }

            result = resultAux;
            return result;
        }

        public async Task<int> UpdateMovimiento(Movimientos movimiento)
        {
            Movimientos obUpdMovimiento = new()
            {
                Id = movimiento.Id,
                Fecha = movimiento.Fecha,
                Tipo = movimiento.Tipo,
                Valor = movimiento.Valor,
                Saldo = movimiento.Saldo,
                CuentaId = movimiento.CuentaId
            };

            var existsMovimiento = await _context.Movimientos.FindAsync(obUpdMovimiento.Id);
            existsMovimiento!.Fecha = obUpdMovimiento.Fecha;
            existsMovimiento.Tipo = obUpdMovimiento.Tipo;
            existsMovimiento.Valor = obUpdMovimiento.Valor;
            existsMovimiento.Saldo = obUpdMovimiento.Saldo;
            existsMovimiento.CuentaId = obUpdMovimiento.CuentaId;
            _context.Movimientos.Update(existsMovimiento);

            var result = await _context.SaveChangesAsync();
            return result;
        }

    }
}
