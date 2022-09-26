using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.ServiceOrder.Validators;
using Ahmynar_Application.Exceptions;
using Ahmynar_Application.Features.ServiceOrder.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.ServiceOrder.Handlers.Commands
{
    public class UpdateServiceOrderCommandHandler : IRequestHandler<UpdateServiceOrderCommand, Unit>
    {
        private readonly IServiceOrderRepository _serviceOrderRepo;
        private readonly IBudgetRepository _budgetRepo;
        private readonly IMapper _mapper;

        public UpdateServiceOrderCommandHandler(IServiceOrderRepository serviceOrderRepo, IBudgetRepository budgetRepo, IMapper mapper)
        {
            _serviceOrderRepo = serviceOrderRepo;
            _budgetRepo = budgetRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateServiceOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateServiceOrderDtoValidator(_budgetRepo);
            var validationResult = await validator.ValidateAsync(request.ServiceOrderDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var serviceOrder = await _serviceOrderRepo.GetByIdAsync(request.ServiceOrderDto.Id);

            _mapper.Map(request.ServiceOrderDto, serviceOrder);
            await _serviceOrderRepo.UpdateAsync(serviceOrder);

            return Unit.Value;
        }
    }
}
