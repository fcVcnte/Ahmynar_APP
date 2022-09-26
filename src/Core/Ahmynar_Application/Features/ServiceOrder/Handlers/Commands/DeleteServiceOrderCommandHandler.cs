using Ahmynar_Application.Contracts.Persistence;
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
    public class DeleteServiceOrderCommandHandler : IRequestHandler<DeleteServiceOrderCommand>
    {
        private readonly IServiceOrderRepository _serviceOrderRepo;
        private readonly IMapper _mapper;

        public DeleteServiceOrderCommandHandler(IServiceOrderRepository serviceOrderRepo, IMapper mapper)
        {
            _serviceOrderRepo = serviceOrderRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteServiceOrderCommand request, CancellationToken cancellationToken)
        {
            var serviceOrder = await _serviceOrderRepo.GetByIdAsync(request.Id);

            if (serviceOrder == null)
                throw new NotFoundException(nameof(Ahmynar_Domain.ServiceOrder), request.Id);
            await _serviceOrderRepo.DeleteAsync(serviceOrder);

            return Unit.Value;
        }
    }
}
