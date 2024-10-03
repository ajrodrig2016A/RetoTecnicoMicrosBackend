using Core.RetoTecnico.Application.Contracts.Persistence;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.DeleteMovimiento
{
    public class DeleteMovimientoCommandHandler : IRequestHandler<DeleteMovimientoCommand, int>
    {
        IBancoUnitOfWork _unitOfWork;
        public DeleteMovimientoCommandHandler(IBancoUnitOfWork bancoUnitOfWork)
        {
            _unitOfWork = bancoUnitOfWork;
        }
        public async Task<int> Handle(DeleteMovimientoCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.MovimientosRepository.DeleteMovimiento(request);
            return result;
        }

    }
}
