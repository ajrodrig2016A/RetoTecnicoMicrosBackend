using Core.RetoTecnico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Contracts.Persistence
{
    public interface IClientesRepository
    {
        Task<Clientes> GetClienteById(int id);

        Task<IEnumerable<Clientes>> GetAllClientes();

        Task<string> AddCliente(Clientes cliente);

        Task<int> UpdateCliente(Clientes cliente);

        Task<int> DeleteCliente(int id);

        Task<int> DeleteCliente(Clientes cliente);


    }
}
