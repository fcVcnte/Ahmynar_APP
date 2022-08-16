using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Customer.Validators;
using Ahmynar_Application.Exceptions;
using Ahmynar_Application.Features.Customer.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Customer.Handlers.Commands
{
    public class UpdateNaturalPersonCustomerCommandHandler : IRequestHandler<UpdateNaturalPersonCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public UpdateNaturalPersonCustomerCommandHandler(ICustomerRepository customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNaturalPersonCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateNaturalPersonCustomerDtoValidator();
            var validationResult = await validator.ValidateAsync(request.NaturalPersonDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var customer = await _customerRepo.GetByIdAsync(request.NaturalPersonDto.Id);

            _mapper.Map(request.NaturalPersonDto, customer);
            await _customerRepo.UpdateAsync(customer);

            return Unit.Value;
        }
    }
}
