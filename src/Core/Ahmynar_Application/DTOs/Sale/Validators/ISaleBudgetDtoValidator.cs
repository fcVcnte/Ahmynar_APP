using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Sale.Validators
{
    public class ISaleBudgetDtoValidator : AbstractValidator<ISaleBudgetDto>
    {
        private readonly IBudgetRepository _budgetRepo;
        public ISaleBudgetDtoValidator(IBudgetRepository budgetRepo)
        {
            _budgetRepo = budgetRepo;

            RuleFor(s => s.PaymentSale)
                .NotNull()
                .IsInEnum();

            RuleFor(s => s.TotalSale)
                .NotNull();

            RuleFor(s => s.BudgetId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var budgetExists = await _budgetRepo.Exists((int)id);
                    return budgetExists;
                })
                .WithMessage("{PropertyName} não existe.");
        }
    }
}
