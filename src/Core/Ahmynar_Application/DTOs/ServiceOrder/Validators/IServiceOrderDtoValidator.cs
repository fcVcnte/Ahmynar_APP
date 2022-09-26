using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.ServiceOrder.Validators
{
    public class IServiceOrderDtoValidator : AbstractValidator<IServiceOrderDto>
    {
        private readonly IBudgetRepository _budgetRepo;

        public IServiceOrderDtoValidator(IBudgetRepository budgetRepo)
        {
            _budgetRepo = budgetRepo;

            RuleFor(p => p.Number)
                .NotNull();

            RuleFor(p => p.Status)
                .NotNull()
                .IsInEnum();

            RuleFor(p => p.TotalDiscounts)
                .LessThan(p => p.Total);

            RuleFor(p => p.Total)
               .NotNull();

            RuleFor(p => p.Obs)
                .MaximumLength(100).WithMessage("{PropertyName} não pode exceder 100 caracteres.");

            RuleFor(p => p.BudgetId)
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
