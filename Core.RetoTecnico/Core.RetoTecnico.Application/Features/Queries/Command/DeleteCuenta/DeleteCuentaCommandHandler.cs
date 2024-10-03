using Core.RetoTecnico.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.DeleteCuenta
{
    public class DeleteCuentaCommandHandler : IRequestHandler<DeleteCuentaCommand, int>
    {
        IBancoUnitOfWork _unitOfWork;
        public DeleteCuentaCommandHandler(IBancoUnitOfWork bancoUnitOfWork)
        {
            _unitOfWork = bancoUnitOfWork;
        }

        public async Task<int> Handle(DeleteCuentaCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.CuentasRepository.DeleteCuenta(request);
            return result;
        }
    }
}
