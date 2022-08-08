using Ahmynar_Application.Exceptions;
using Ahmynar_Application.Features.Supplier.Requests.Commands;
using Ahmynar_Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Supplier.Handlers.Commands
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand>
    {
        private readonly ISupplierRepository _supplierRepo;
        private readonly IMapper _mapper;

        public DeleteSupplierCommandHandler(ISupplierRepository supplierRepo, IMapper mapper)
        {
            _supplierRepo = supplierRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepo.GetByIdAsync(request.Id);

            if (supplier == null)
                throw new NotFoundException(nameof(Ahmynar_Domain.Supplier), request.Id);
            await _supplierRepo.DeleteAsync(supplier);

            return Unit.Value;
        }
    }
}
