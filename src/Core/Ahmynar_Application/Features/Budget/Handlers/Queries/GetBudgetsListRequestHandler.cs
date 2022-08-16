using Ahmynar_Application.DTOs.Budget;
using Ahmynar_Application.Features.Budget.Requests.Queries;
using Ahmynar_Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Budget.Handlers.Queries
{
    public class GetBudgetsListRequestHandler : IRequestHandler<GetBudgetsListRequest, List<BudgetListDto>>
    {
        private readonly IBudgetRepository _budgetRepo;
        private readonly IMapper _mapper;

        public GetBudgetsListRequestHandler(IBudgetRepository budgetRepo, IMapper mapper)
        {
            _budgetRepo = budgetRepo;
            _mapper = mapper;
        }
        public async Task<List<BudgetListDto>> Handle(GetBudgetsListRequest request, CancellationToken cancellationToken)
        {
            var budgets = await _budgetRepo.GetAllAsync();
            return _mapper.Map<List<BudgetListDto>>(budgets);
        }
    }
}
