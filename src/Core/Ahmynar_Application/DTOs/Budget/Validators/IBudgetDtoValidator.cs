using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Budget.Validators
{
    public class IBudgetDtoValidator : AbstractValidator<IBudgetDto>
    {
        private readonly ICustomerRepository _customerRepo;

        public IBudgetDtoValidator(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;

            RuleFor(p => p.Number)
                .NotNull();

            RuleFor(p => p.TotalDiscounts)
                .LessThan(p => p.Total);

            RuleFor(p => p.Total)
                .NotNull();

            RuleFor(p => p.Obs)
                .MaximumLength(100).WithMessage("{PropertyName} não pode exceder 100 caracteres.");

            RuleFor(p => p.CustomerId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var customerExists = await _customerRepo.Exists((int)id);
                    return customerExists;
                })
                .WithMessage("{PropertyName} não existe.");
        }
    }
}
