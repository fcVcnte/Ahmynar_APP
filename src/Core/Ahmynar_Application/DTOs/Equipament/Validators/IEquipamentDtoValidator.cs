using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Equipament.Validators
{
    public class IEquipamentDtoValidator : AbstractValidator<IEquipamentDto>
    {
        private readonly ICustomerRepository _customerRepo;

        public IEquipamentDtoValidator(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;

            RuleFor(p => p.TypeEquipament)
                .NotNull()
                .IsInEnum();

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} não pode exceder 100 caracteres.");

            RuleFor(p => p.Specs)
                .MaximumLength(50).WithMessage("{PropertyName} não pode exceder 50 caracteres.");

            RuleFor(p => p.Acessories)
                .MaximumLength(50).WithMessage("{PropertyName} não pode exceder 50 caracteres.");

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
