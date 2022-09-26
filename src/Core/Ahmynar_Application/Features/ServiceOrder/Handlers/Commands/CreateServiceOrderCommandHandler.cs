using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.ServiceOrder.Validators;
using Ahmynar_Application.Features.ServiceOrder.Requests.Commands;
using Ahmynar_Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.ServiceOrder.Handlers.Commands
{
    public class CreateServiceOrderCommandHandler : IRequestHandler<CreateServiceOrderCommand, BaseCommandResponse>
    {
        private readonly IServiceOrderRepository _serviceOrderRepo;
        private readonly IBudgetRepository _budgetRepo;
        private readonly IMapper _mapper;

        public CreateServiceOrderCommandHandler(IServiceOrderRepository serviceOrderRepo, IBudgetRepository budgetRepo, IMapper mapper)
        {
            _serviceOrderRepo = serviceOrderRepo;
            _budgetRepo = budgetRepo;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateServiceOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateServiceOrderDtoValidator(_budgetRepo);
            var validationResult = await validator.ValidateAsync(request.ServiceOrderDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Falha na criação";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var serviceOrder = _mapper.Map<Ahmynar_Domain.ServiceOrder>(request.ServiceOrderDto);

                serviceOrder = await _serviceOrderRepo.AddAsync(serviceOrder);

                response.Success = true;
                response.Message = "Sucesso na criação";
                response.Id = serviceOrder.Id;
            }

            return response;
        }
    }
}
