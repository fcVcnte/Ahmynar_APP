using Ahmynar_Application.DTOs.Budget;
using Ahmynar_Application.Features.Budget.Requests.Queries;
using Ahmynar_Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Budget.Handlers.Queries
{
    public class GetBudgetDetailRequestHandler : IRequestHandler<GetBudgetDetailRequest, BudgetDto>
    {
        private readonly IBudgetRepository _budgetRepo;
        private readonly IMapper _mapper;

        public GetBudgetDetailRequestHandler(IBudgetRepository budgetRepo, IMapper mapper)
        {
            _budgetRepo = budgetRepo;
            _mapper = mapper;
        }

        public async Task<BudgetDto> Handle(GetBudgetDetailRequest request, CancellationToken cancellationToken)
        {
            var budget = await _budgetRepo.GetByIdAsync(request.Id);
            return _mapper.Map<BudgetDto>(budget);
        }
    }
}
