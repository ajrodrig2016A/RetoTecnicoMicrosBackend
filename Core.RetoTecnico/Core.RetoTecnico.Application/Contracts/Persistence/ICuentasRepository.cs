using Core.RetoTecnico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Contracts.Persistence
{
    public interface ICuentasRepository
    {
        Task<Cuentas> GetCuentaById(int id);

        Task<IEnumerable<Cuentas>> GetAllCuentas();

        Task<string> AddCuenta(Cuentas cuenta);

        Task<int> UpdateCuenta(Cuentas cuenta);

        Task<int> DeleteCuenta(int id);

        Task<int> DeleteCuenta(Cuentas cuenta);
    }
}
