using Core.RetoTecnico.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.AddMovimiento
{
    public class AddMovimientoCommand : Movimientos, IRequest<decimal>
    {
    }
}
