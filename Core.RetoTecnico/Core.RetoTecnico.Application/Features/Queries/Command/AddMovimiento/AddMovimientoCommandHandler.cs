using Core.RetoTecnico.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.AddMovimiento
{
    internal class AddMovimientoCommandHandler : IRequestHandler<AddMovimientoCommand, decimal>
    {
        IBancoUnitOfWork _unitOfWork;

        public AddMovimientoCommandHandler(IBancoUnitOfWork bancoUnitOfWork)
        {
            _unitOfWork = bancoUnitOfWork;
        }
        public async Task<decimal> Handle(AddMovimientoCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.MovimientosRepository.AddMovimiento(request);
            return result;
        }
    }
}
