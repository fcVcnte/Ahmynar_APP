using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Service.Validators
{
    public class IServiceDtoValidator : AbstractValidator<IServiceDto>
    {
        public IServiceDtoValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} não pode exceder 50 caracteres.");

            RuleFor(p => p.SalePrice)
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.Obs)
                .MaximumLength(100).WithMessage("{PropertyName} não pode exceder 100 caracteres.");
        }
    }
}
