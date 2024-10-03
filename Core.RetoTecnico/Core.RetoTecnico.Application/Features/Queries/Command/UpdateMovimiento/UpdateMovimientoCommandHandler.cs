using Core.RetoTecnico.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.UpdateMovimiento
{
    public class UpdateMovimientoCommandHandler : IRequestHandler<UpdateMovimientoCommand, int>
    {
        IBancoUnitOfWork _unitOfWork;
        public UpdateMovimientoCommandHandler(IBancoUnitOfWork bancoUnitOfWork)
        {
            _unitOfWork = bancoUnitOfWork;
        }
        public async Task<int> Handle(UpdateMovimientoCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.MovimientosRepository.UpdateMovimiento(request);
            return result;
        }
    }
}
