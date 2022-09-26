using Ahmynar_Application.Contracts.Persistence;
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
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
    {
        private readonly IServiceRepository _serviceRepo;
        private readonly IMapper _mapper;

        public DeleteServiceCommandHandler(IServiceRepository serviceRepo, IMapper mapper)
        {
            _serviceRepo = serviceRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepo.GetByIdAsync(request.Id);

            if (service == null)
                throw new NotFoundException(nameof(Ahmynar_Domain.Service), request.Id);
            await _serviceRepo.DeleteAsync(service);

            return Unit.Value;
        }
    }
}
