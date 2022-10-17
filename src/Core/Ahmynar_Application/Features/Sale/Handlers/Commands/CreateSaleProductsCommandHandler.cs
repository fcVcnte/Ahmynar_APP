using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Sale.Validators;
using Ahmynar_Application.Features.Sale.Requests.Commands;
using Ahmynar_Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Sale.Handlers.Commands
{
    public class CreateSaleProductsCommandHandler : IRequestHandler<CreateSaleProductsCommand, BaseCommandResponse>
    {
        private readonly IProductRepository _productRepo;
        private readonly ISaleRepository _saleRepo;
        private readonly IMapper _mapper;

        public CreateSaleProductsCommandHandler(IProductRepository productRepo, ISaleRepository saleRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _saleRepo = saleRepo;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSaleProductsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSaleProductsDtoValidator(_productRepo);
            var validationResult = await validator.ValidateAsync(request.SaleProductsDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Falha na criação";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                ICollection<Ahmynar_Domain.Product> products = new List<Ahmynar_Domain.Product>();

                if (request.SaleProductsDto.ProductIds.Count != 0 && request.SaleProductsDto.ProductIds.ElementAt(0) != 0)
                {
                    foreach (int id in request.SaleProductsDto.ProductIds)
                    {
                        products.Add(await _productRepo.GetByIdAsync(id));
                    }
                }

                var sale = _mapper.Map<Ahmynar_Domain.Sale>(request.SaleProductsDto);
                sale.Products = products;

                sale = await _saleRepo.AddAsync(sale);

                response.Success = true;
                response.Message = "Sucesso na criação";
                response.Id = sale.Id;
            }

            return response;
        }
    }
}
