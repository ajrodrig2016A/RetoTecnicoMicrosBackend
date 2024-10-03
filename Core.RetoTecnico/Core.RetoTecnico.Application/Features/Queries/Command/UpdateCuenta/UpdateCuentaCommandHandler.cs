using Core.RetoTecnico.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.UpdateCuenta
{
    public class UpdateCuentaCommandHandler : IRequestHandler<UpdateCuentaCommand, int>
    {
        IBancoUnitOfWork _unitOfWork;
        public UpdateCuentaCommandHandler(IBancoUnitOfWork bancoUnitOfWork)
        {
            _unitOfWork = bancoUnitOfWork;
        }
        public async Task<int> Handle(UpdateCuentaCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.CuentasRepository.UpdateCuenta(request);
            return result;
        }
    }
}
