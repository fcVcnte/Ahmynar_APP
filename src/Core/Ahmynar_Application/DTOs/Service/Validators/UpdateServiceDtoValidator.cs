using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Service.Validators
{
    public class UpdateServiceDtoValidator : AbstractValidator<UpdateServiceDto>
    {
        public UpdateServiceDtoValidator()
        {
            Include(new IServiceDtoValidator());

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} é obrigatória.")
                .GreaterThan(0);
        }
    }
}
