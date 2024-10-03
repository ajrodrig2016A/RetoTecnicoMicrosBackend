using Core.RetoTecnico.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.DeletePersona
{
    public class DeletePersonaCommandHandler : IRequestHandler<DeletePersonaCommand, int>
    {
        IBancoUnitOfWork _unitOfWork;
        public DeletePersonaCommandHandler(IBancoUnitOfWork bancoUnitOfWork)
        {
            _unitOfWork = bancoUnitOfWork;
        }
        public async Task<int> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.PersonasRepository.DeletePersona(request);
            return result;
        }
    }
}
