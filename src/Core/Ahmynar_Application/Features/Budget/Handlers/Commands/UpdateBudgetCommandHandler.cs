using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Budget.Validators;
using Ahmynar_Application.Exceptions;
using Ahmynar_Application.Features.Budget.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Budget.Handlers.Commands
{
    public class UpdateBudgetCommandHandler : IRequestHandler<UpdateBudgetCommand, Unit>
    {
        private readonly IBudgetRepository _budgetRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IProductRepository _productRepo;
        private readonly IServiceRepository _serviceRepo;
        private readonly IMapper _mapper;

        public UpdateBudgetCommandHandler(IBudgetRepository budgetRepo, ICustomerRepository customerRepo, IProductRepository productRepo, IServiceRepository serviceRepo, IMapper mapper)
        {
            _budgetRepo = budgetRepo;
            _customerRepo = customerRepo;
            _productRepo = productRepo;
            _serviceRepo = serviceRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBudgetCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBudgetDtoValidator(_customerRepo);
            var validationResult = await validator.ValidateAsync(request.BudgetDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

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

            var budget = await _budgetRepo.GetByIdAsync(request.BudgetDto.Id);

            _mapper.Map(request.BudgetDto, budget);
            budget.Products = products;
            budget.Services = services;

            await _budgetRepo.UpdateAsync(budget);

            return Unit.Value;
        }
    }
}
