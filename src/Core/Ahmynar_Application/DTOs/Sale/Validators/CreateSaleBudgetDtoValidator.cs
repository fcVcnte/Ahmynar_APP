using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Sale.Validators
{
    public class CreateSaleBudgetDtoValidator : AbstractValidator<CreateSaleBudgetDto>
    {
        private readonly IBudgetRepository _budgetRepo;

        public CreateSaleBudgetDtoValidator(IBudgetRepository budgetRepo)
        {
            _budgetRepo = budgetRepo;
            Include(new ISaleBudgetDtoValidator(_budgetRepo));
        }
    }
}
