using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Customer.Validators
{
    public class UpdateLegalEntityCustomerDtoValidator : AbstractValidator<UpdateLegalEntityCustomerDto>
    {
        public UpdateLegalEntityCustomerDtoValidator()
        {
            Include(new ILegalEntityCustomerDtoValidator());

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} é obrigatória.")
                .GreaterThan(0);
        }
    }
}
