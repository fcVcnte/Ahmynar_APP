using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Service.Validators
{
    public class CreateServiceDtoValidator : AbstractValidator<CreateServiceDto>
    {
        public CreateServiceDtoValidator()
        {
            Include(new IServiceDtoValidator());
        }
    }
}
