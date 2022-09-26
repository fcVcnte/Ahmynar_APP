using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Equipament.Validators;
using Ahmynar_Application.Features.Equipament.Requests.Commands;
using Ahmynar_Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Equipament.Handlers.Commands
{
    public class CreateEquipamentCommandHandler : IRequestHandler<CreateEquipamentCommand, BaseCommandResponse>
    {
        private readonly IEquipamentRepository _equipamentRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public CreateEquipamentCommandHandler(IEquipamentRepository equipamentRepo, ICustomerRepository customerRepo, IMapper mapper)
        {
            _equipamentRepo = equipamentRepo;
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateEquipamentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEquipamentDtoValidator(_customerRepo);
            var validationResult = await validator.ValidateAsync(request.EquipamentDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Falha na criação";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var equipament = _mapper.Map<Ahmynar_Domain.Equipament>(request.EquipamentDto);

                equipament = await _equipamentRepo.AddAsync(equipament);

                response.Success = true;
                response.Message = "Sucesso na criação";
                response.Id = equipament.Id;
            }

            return response;
        }
    }
}
