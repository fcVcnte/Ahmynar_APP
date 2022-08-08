using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Product.Validators;
using Ahmynar_Application.Exceptions;
using Ahmynar_Application.Features.Product.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Product.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepo;
        private readonly ISupplierRepository _supplierRepo;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepo, ISupplierRepository supplierRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _supplierRepo = supplierRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductDtoValidator(_supplierRepo);
            var validationResult = await validator.ValidateAsync(request.ProductDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var product = await _productRepo.GetByIdAsync(request.ProductDto.Id);

            _mapper.Map(request.ProductDto, product);
            await _productRepo.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
