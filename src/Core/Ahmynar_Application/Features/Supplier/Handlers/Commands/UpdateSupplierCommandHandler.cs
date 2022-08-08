using Ahmynar_Application.DTOs.Supplier.Validators;
using Ahmynar_Application.Exceptions;
using Ahmynar_Application.Features.Supplier.Requests.Commands;
using Ahmynar_Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Supplier.Handlers.Commands
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Unit>
    {
        private readonly ISupplierRepository _supplierRepo;
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(ISupplierRepository supplierRepo, IMapper mapper)
        {
            _supplierRepo = supplierRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSupplierDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SupplierDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var supplier = await _supplierRepo.GetByIdAsync(request.SupplierDto.Id);

            _mapper.Map(request.SupplierDto, supplier);
            await _supplierRepo.UpdateAsync(supplier);

            return Unit.Value;
        }
    }
}
