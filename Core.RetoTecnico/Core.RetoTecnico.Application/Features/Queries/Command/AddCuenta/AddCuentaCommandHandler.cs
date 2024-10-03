using Core.RetoTecnico.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.AddCuenta
{
    public class AddCuentaCommandHandler : IRequestHandler<AddCuentaCommand, string>
    {
        IBancoUnitOfWork _unitOfWork;

        public AddCuentaCommandHandler(IBancoUnitOfWork bancoUnitOfWork)
        {
            _unitOfWork = bancoUnitOfWork;
        }
        public async Task<string> Handle(AddCuentaCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.CuentasRepository.AddCuenta(request);
            return result;
        }
    }
}
