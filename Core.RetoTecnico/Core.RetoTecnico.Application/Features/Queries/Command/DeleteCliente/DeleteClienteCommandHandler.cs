using Core.RetoTecnico.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.DeleteCliente
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, int>
    {
        IBancoUnitOfWork _unitOfWork;
        public DeleteClienteCommandHandler(IBancoUnitOfWork bancoUnitOfWork)
        {
            _unitOfWork = bancoUnitOfWork;
        }
        public async Task<int> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ClientesRepository.DeleteCliente(request);
            return result;
        }
    }
}
