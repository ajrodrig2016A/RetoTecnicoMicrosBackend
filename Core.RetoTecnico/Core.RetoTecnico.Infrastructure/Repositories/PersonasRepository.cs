using Core.RetoTecnico.Application.Contracts.Persistence;
using Core.RetoTecnico.Domain.Entities;
using Core.RetoTecnico.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Infrastructure.Repositories
{
    public class PersonasRepository : IPersonasRepository
    {
        public readonly BancoContext _context;

        public PersonasRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task<int> AddPersona(Personas persona)
        {
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
            return persona.Id;
        }

        public async Task<int> DeletePersona(Personas persona)
        {
            var existsPersona = await _context.Personas.FindAsync(persona.Id);
            if (existsPersona != null)
            {
                existsPersona.Nombre = persona.Nombre;
                existsPersona.Genero = persona.Genero;
                existsPersona.Edad = persona.Edad;
                existsPersona.Identificacion = persona.Identificacion;
                existsPersona.Direccion = persona.Direccion;
                existsPersona.Telefono = persona.Telefono;
                _context.Personas.Remove(existsPersona);
            }

            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<Personas> GetPersonaById(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task<int> UpdatePersona(Personas persona)
        {
            var existsPersona = await _context.Personas.FindAsync(persona.Id);
            if (existsPersona != null)
            {
                existsPersona.Nombre = persona.Nombre;
                existsPersona.Genero = persona.Genero;
                existsPersona.Edad = persona.Edad;
                existsPersona.Identificacion = persona.Identificacion;
                existsPersona.Direccion = persona.Direccion;
                existsPersona.Telefono = persona.Telefono;
                _context.Personas.Update(existsPersona);
            }

            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
