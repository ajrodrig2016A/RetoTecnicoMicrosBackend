using Core.RetoTecnico.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Application.Features.Queries.Command.UpdatePersona
{
    public class UpdatePersonaCommandHandler : IRequestHandler<UpdatePersonaCommand, int>
    {
        IBancoUnitOfWork _unitOfWork;
        public UpdatePersonaCommandHandler(IBancoUnitOfWork bancoUnitOfWork)
        {
            _unitOfWork = bancoUnitOfWork;
        }
        public async Task<int> Handle(UpdatePersonaCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.PersonasRepository.UpdatePersona(request);
            return result;
        }
    }
}
