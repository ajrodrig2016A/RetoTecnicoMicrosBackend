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
    public class ClientesRepository : IClientesRepository
    {
        public readonly BancoContext _context;

        public ClientesRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task<string> AddCliente(Clientes cliente)
        {
            Clientes objInsCliente = new()
            {
                Nombre = cliente.Nombre,
                Genero = cliente.Genero,
                Edad = cliente.Edad,
                Identificacion = cliente.Identificacion,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Contrasenia = cliente.Contrasenia,
                Estado = cliente.Estado
            };

            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente.Identificacion;
        }

        public async Task<int> DeleteCliente(int id)
        {
            var clienteBorrado = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clienteBorrado!);

            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<int> DeleteCliente(Clientes cliente)
        {
            var clienteBorrado = await _context.Clientes.FindAsync(cliente.Id);
            _context.Clientes.Remove(clienteBorrado!);

            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<Clientes>> GetAllClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Clientes> GetClienteById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<int> UpdateCliente(Clientes cliente)
        {
            Clientes objUpdCliente = new()
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Genero = cliente.Genero,
                Edad = cliente.Edad,
                Identificacion = cliente.Identificacion,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Contrasenia = cliente.Contrasenia,
                Estado = cliente.Estado
            };

            var existsCliente = await _context.Clientes.FindAsync(objUpdCliente.Id);
            existsCliente!.Nombre = objUpdCliente.Nombre;
            existsCliente.Genero = objUpdCliente.Genero;
            existsCliente.Edad = objUpdCliente.Edad;
            existsCliente.Identificacion = objUpdCliente.Identificacion;
            existsCliente.Direccion = objUpdCliente.Direccion;
            existsCliente.Telefono = objUpdCliente.Telefono;
            existsCliente.Contrasenia = objUpdCliente.Contrasenia;
            existsCliente.Estado = objUpdCliente.Estado;
            _context.Clientes.Update(existsCliente);

            await _context.SaveChangesAsync();
            return cliente.Id;
        }
    }
}
