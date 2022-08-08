using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahmynar_Application.DTOs.Supplier.Validators
{
    public class UpdateSupplierDtoValidator : AbstractValidator<UpdateSupplierDto>
    {
        public UpdateSupplierDtoValidator()
        {
            Include(new ISupplierDtoValidator());

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} é obrigatória.")
                .GreaterThan(0);
        }
    }
}
