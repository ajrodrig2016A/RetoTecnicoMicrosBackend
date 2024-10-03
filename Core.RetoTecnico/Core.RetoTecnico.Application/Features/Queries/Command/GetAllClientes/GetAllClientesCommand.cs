using Core.RetoTecnico.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.GetAllClientes
{
    public class GetAllClientesCommand : Clientes, IRequest<IEnumerable<Clientes>>
    {
    }
}
