using Ahmynar_Application.DTOs.Supplier.Validators;
using Ahmynar_Application.Features.Supplier.Requests.Commands;
using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.Responses;
using AutoMapper;
using MediatR;

namespace Ahmynar_Application.Features.Supplier.Handlers.Commands
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, BaseCommandResponse>
    {
        private readonly ISupplierRepository _supplierRepo;
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(ISupplierRepository supplierRepo, IMapper mapper)
        {
            _supplierRepo = supplierRepo;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSupplierDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SupplierDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Falha na criação";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var supplier = _mapper.Map<Ahmynar_Domain.Supplier> (request.SupplierDto);

            supplier = await _supplierRepo.AddAsync (supplier);

            response.Success = true;
            response.Message = "Sucesso na criação";
            response.Id = supplier.Id;
            return response;
        }
    }
}
