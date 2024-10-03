using Core.RetoTecnico.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.UpdateCliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, int>
    {
        IBancoUnitOfWork _unitOfWork;
        public UpdateClienteCommandHandler(IBancoUnitOfWork bancoUnitOfWork)
        {
            _unitOfWork = bancoUnitOfWork;
        }
        public async Task<int> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ClientesRepository.UpdateCliente(request);
            return result;
        }
    }
}
