using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Budget.Validators;
using Ahmynar_Application.DTOs.Product;
using Ahmynar_Application.Features.Budget.Requests.Commands;
using Ahmynar_Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Budget.Handlers.Commands
{
    public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, BaseCommandResponse>
    {
        private readonly IBudgetRepository _budgetRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IProductRepository _productRepo;
        private readonly IServiceRepository _serviceRepo;
        private readonly IMapper _mapper;

        public CreateBudgetCommandHandler(IBudgetRepository budgetRepo, ICustomerRepository customerRepo, IProductRepository productRepo, IServiceRepository serviceRepo, IMapper mapper)
        {
            _budgetRepo = budgetRepo;
            _customerRepo = customerRepo;
            _productRepo = productRepo;
            _serviceRepo = serviceRepo;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBudgetDtoValidator(_customerRepo);
            var validationResult = await validator.ValidateAsync(request.BudgetDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Falha na criação";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                ICollection<Ahmynar_Domain.Product> products = new List<Ahmynar_Domain.Product>();
                ICollection<Ahmynar_Domain.Service> services = new List<Ahmynar_Domain.Service>();

                foreach (int id in request.BudgetDto.ServiceIds)
                {
                    services.Add(await _serviceRepo.GetByIdAsync(id));
                }

                if (request.BudgetDto.ProductIds.Count != 0 && request.BudgetDto.ProductIds.ElementAt(0) != 0)
                {
                    foreach (int id in request.BudgetDto.ProductIds)
                    {
                        products.Add(await _productRepo.GetByIdAsync(id));
                    }
                }

                var budget = _mapper.Map<Ahmynar_Domain.Budget>(request.BudgetDto);
                budget.Products = products;
                budget.Services = services;

                budget = await _budgetRepo.AddAsync(budget);

                response.Success = true;
                response.Message = "Sucesso na criação";
                response.Id = budget.Id;
            }

            return response;
        }
    }
}
