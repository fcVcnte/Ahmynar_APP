using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.ServiceOrder.Validators
{
    public class CreateServiceOrderDtoValidator : AbstractValidator<CreateServiceOrderDto>
    {
        private readonly IBudgetRepository _budgetRepo;

        public CreateServiceOrderDtoValidator(IBudgetRepository budgetRepo)
        {
            _budgetRepo = budgetRepo;
            Include(new IServiceOrderDtoValidator(_budgetRepo));
        }
    }
}
