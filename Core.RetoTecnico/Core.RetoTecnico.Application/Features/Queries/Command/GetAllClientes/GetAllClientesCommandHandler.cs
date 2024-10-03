using Core.RetoTecnico.Application.Contracts.Persistence;
using Core.RetoTecnico.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.GetAllClientes
{
    public class GetAllClientesCommandHandler : IRequestHandler<GetAllClientesCommand, IEnumerable<Clientes>>
    {
        IBancoUnitOfWork _unitOfWork;

        public GetAllClientesCommandHandler(IBancoUnitOfWork bancoUnitOfWork)
        {
            _unitOfWork = bancoUnitOfWork;
        }

        public async Task<IEnumerable<Clientes>> Handle(GetAllClientesCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ClientesRepository.GetAllClientes();
            return result;
        }
    }
}
