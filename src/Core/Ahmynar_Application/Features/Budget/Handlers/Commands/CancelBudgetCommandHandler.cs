using Ahmynar_Application.Contracts.Persistence;
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
    public class CancelBudgetCommandHandler : IRequestHandler<CancelBudgetCommand>
    {
        private readonly IBudgetRepository _budgetRepo;
        private readonly IMapper _mapper;

        public CancelBudgetCommandHandler(IBudgetRepository budgetRepo, IMapper mapper)
        {
            _budgetRepo = budgetRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CancelBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget = await _budgetRepo.GetByIdAsync(request.Id);

            if (budget == null)
                throw new NotFoundException(nameof(Ahmynar_Domain.Budget), request.Id);
            await _budgetRepo.CancelBudgetAsync(budget);

            return Unit.Value;
        }
    }
}
