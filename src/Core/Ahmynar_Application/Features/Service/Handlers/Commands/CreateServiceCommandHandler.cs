using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Service.Validators;
using Ahmynar_Application.Features.Service.Requests.Commands;
using Ahmynar_Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Service.Handlers.Commands
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, BaseCommandResponse>
    {
        private readonly IServiceRepository _serviceRepo;
        private readonly IMapper _mapper;

        public CreateServiceCommandHandler(IServiceRepository serviceRepo, IMapper mapper)
        {
            _serviceRepo = serviceRepo;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateServiceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ServiceDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Falha na criação";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var service = _mapper.Map<Ahmynar_Domain.Service>(request.ServiceDto);

                service = await _serviceRepo.AddAsync(service);

                response.Success = true;
                response.Message = "Sucesso na criação";
                response.Id = service.Id;
            }

            return response;
        }
    }
}
