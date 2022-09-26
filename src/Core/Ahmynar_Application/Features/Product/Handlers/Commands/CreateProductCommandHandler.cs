using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Product.Validators;
using Ahmynar_Application.Features.Product.Requests.Commands;
using Ahmynar_Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Product.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse>
    {
        private readonly IProductRepository _productRepo;
        private readonly ISupplierRepository _supplierRepo;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepo, ISupplierRepository supplierRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _supplierRepo = supplierRepo;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateProductDtoValidator(_supplierRepo);
            var validationResult = await validator.ValidateAsync(request.ProductDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Falha na criação";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var product = _mapper.Map<Ahmynar_Domain.Product>(request.ProductDto);

                product = await _productRepo.AddAsync(product);

                response.Success = true;
                response.Message = "Sucesso na criação";
                response.Id = product.Id;
            }

            return response;
        }
    }
}
