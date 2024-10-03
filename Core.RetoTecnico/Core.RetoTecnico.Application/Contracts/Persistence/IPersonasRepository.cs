using Core.RetoTecnico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Contracts.Persistence
{
    public interface IPersonasRepository
    {
        Task<Personas> GetPersonaById(int id);

        Task<int> AddPersona(Personas persona);

        Task<int> UpdatePersona(Personas persona);

        Task<int> DeletePersona(Personas persona);
    }
}
