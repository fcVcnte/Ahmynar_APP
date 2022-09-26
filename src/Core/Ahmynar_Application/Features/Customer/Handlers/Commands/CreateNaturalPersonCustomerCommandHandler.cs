using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Customer.Validators;
using Ahmynar_Application.Features.Customer.Requests.Commands;
using Ahmynar_Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Customer.Handlers.Commands
{
    public class CreateNaturalPersonCustomerCommandHandler : IRequestHandler<CreateNaturalPersonCustomerCommand, BaseCommandResponse>
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public CreateNaturalPersonCustomerCommandHandler(ICustomerRepository customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateNaturalPersonCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateNaturalPersonCustomerDtoValidator();
            var validationResult = await validator.ValidateAsync(request.NaturalPersonDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Falha na criação";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var customer = _mapper.Map<Ahmynar_Domain.Customer>(request.NaturalPersonDto);

                customer = await _customerRepo.AddAsync(customer);

                response.Success = true;
                response.Message = "Sucesso na criação";
                response.Id = customer.Id;
            }

            return response;
        }
    }
}
