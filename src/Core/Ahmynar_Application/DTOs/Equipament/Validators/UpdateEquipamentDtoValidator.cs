using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Equipament.Validators
{
    public class UpdateEquipamentDtoValidator : AbstractValidator<UpdateEquipamentDto>
    {
        private readonly ICustomerRepository _customerRepo;

        public UpdateEquipamentDtoValidator(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
            Include(new IEquipamentDtoValidator(_customerRepo));

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} é obrigatória.")
                .GreaterThan(0);
        }
    }
}
