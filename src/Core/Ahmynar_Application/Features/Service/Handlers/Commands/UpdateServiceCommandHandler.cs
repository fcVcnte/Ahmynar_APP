using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Service.Validators;
using Ahmynar_Application.Exceptions;
using Ahmynar_Application.Features.Service.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Service.Handlers.Commands
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Unit>
    {
        private readonly IServiceRepository _serviceRepo;
        private readonly IMapper _mapper;

        public UpdateServiceCommandHandler(IServiceRepository serviceRepo, IMapper mapper)
        {
            _serviceRepo = serviceRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateServiceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ServiceDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var service = await _serviceRepo.GetByIdAsync(request.ServiceDto.Id);

            _mapper.Map(request.ServiceDto, service);
            await _serviceRepo.UpdateAsync(service);

            return Unit.Value;
        }
    }
}
