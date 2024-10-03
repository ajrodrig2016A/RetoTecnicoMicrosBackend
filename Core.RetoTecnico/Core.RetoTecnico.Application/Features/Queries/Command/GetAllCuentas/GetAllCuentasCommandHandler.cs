using Core.RetoTecnico.Application.Contracts.Persistence;
using Core.RetoTecnico.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.GetAllCuentas
{
    public class GetAllCuentasCommandHandler : IRequestHandler<GetAllCuentasCommand, IEnumerable<Cuentas>>
    {
        IBancoUnitOfWork _unitOfWork;

        public GetAllCuentasCommandHandler(IBancoUnitOfWork bancoUnitOfWork)
        {
            _unitOfWork = bancoUnitOfWork;
        }

        public async Task<IEnumerable<Cuentas>> Handle(GetAllCuentasCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.CuentasRepository.GetAllCuentas();
            return result;
        }
    }
}
