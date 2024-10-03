using Core.RetoTecnico.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.AddPersona
{
    public class AddPersonaCommandHandler : IRequestHandler<AddPersonaCommand, int>
    {
        IBancoUnitOfWork _unitOfWork;
        public AddPersonaCommandHandler(IBancoUnitOfWork bancoUnitOfWork)
        {
            _unitOfWork = bancoUnitOfWork;
        }
        public async Task<int> Handle(AddPersonaCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.PersonasRepository.AddPersona(request);
            return result;
        }
    }
}
