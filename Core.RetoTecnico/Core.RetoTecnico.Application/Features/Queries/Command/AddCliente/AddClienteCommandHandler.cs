using Core.RetoTecnico.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.AddCliente
{
    public class AddClienteCommandHandler : IRequestHandler<AddClienteCommand,string>
    {
        IBancoUnitOfWork _unitOfWork;

        public AddClienteCommandHandler(IBancoUnitOfWork bancoUnitOfWork)
        {
            _unitOfWork = bancoUnitOfWork;
        }

        public async Task<string> Handle(AddClienteCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ClientesRepository.AddCliente(request);
            return result;
        }
    }
}
