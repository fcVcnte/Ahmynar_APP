using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Equipament.Validators;
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
    public class UpdateEquipamentCommandHandler : IRequestHandler<UpdateEquipamentCommand, Unit>
    {
        private readonly IEquipamentRepository _equipamentRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public UpdateEquipamentCommandHandler(IEquipamentRepository equipamentRepo, ICustomerRepository customerRepo, IMapper mapper)
        {
            _equipamentRepo = equipamentRepo;
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEquipamentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEquipamentDtoValidator(_customerRepo);
            var validationResult = await validator.ValidateAsync(request.EquipamentDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var equipament = await _equipamentRepo.GetByIdAsync(request.EquipamentDto.Id);

            _mapper.Map(request.EquipamentDto, equipament);
            await _equipamentRepo.UpdateAsync(equipament);

            return Unit.Value;
        }
    }
}
