using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.Exceptions;
using Ahmynar_Application.Features.Equipament.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Equipament.Handlers.Commands
{
    public class DeleteEquipamentCommandHandler : IRequestHandler<DeleteEquipamentCommand>
    {
        private readonly IEquipamentRepository _equipamentRepo;
        private readonly IMapper _mapper;

        public DeleteEquipamentCommandHandler(IEquipamentRepository equipamentRepo, IMapper mapper)
        {
            _equipamentRepo = equipamentRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEquipamentCommand request, CancellationToken cancellationToken)
        {
            var equipament = await _equipamentRepo.GetByIdAsync(request.Id);

            if (equipament == null)
                throw new NotFoundException(nameof(Ahmynar_Domain.Equipament), request.Id);
            await _equipamentRepo.DeleteAsync(equipament);

            return Unit.Value;
        }
    }
}
