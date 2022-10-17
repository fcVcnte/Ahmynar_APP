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
    public class CreateSaleBudgetCommandHandler : IRequestHandler<CreateSaleBudgetCommand, BaseCommandResponse>
    {
        private readonly IBudgetRepository _budgetRepo;
        private readonly ISaleRepository _saleRepo;
        private readonly IMapper _mapper;

        public CreateSaleBudgetCommandHandler(IBudgetRepository budgetRepo, ISaleRepository saleRepo, IMapper mapper)
        {
            _budgetRepo = budgetRepo;
            _saleRepo = saleRepo;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSaleBudgetCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSaleBudgetDtoValidator(_budgetRepo);
            var validationResult = await validator.ValidateAsync(request.SaleBudgetDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Falha na criação";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var sale = _mapper.Map<Ahmynar_Domain.Sale>(request.SaleBudgetDto);

                sale = await _saleRepo.AddAsync(sale);

                response.Success = true;
                response.Message = "Sucesso na criação";
                response.Id = sale.Id;
            }

            return response;
        }
    }
}
