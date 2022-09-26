using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.ServiceOrder.Validators
{
    public class UpdateServiceOrderDtoValidator : AbstractValidator<UpdateServiceOrderDto>
    {
        private readonly IBudgetRepository _budgetRepo;

        public UpdateServiceOrderDtoValidator(IBudgetRepository budgetRepo)
        {
            _budgetRepo = budgetRepo;
            Include(new IServiceOrderDtoValidator(_budgetRepo));

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} é obrigatória.")
                .GreaterThan(0);
        }
    }
}
