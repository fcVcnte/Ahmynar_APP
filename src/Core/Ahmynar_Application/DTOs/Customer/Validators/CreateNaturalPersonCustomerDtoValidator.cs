using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Customer.Validators
{
    public class CreateNaturalPersonCustomerDtoValidator : AbstractValidator<CreateNaturalPersonCustomerDto>
    {
        public CreateNaturalPersonCustomerDtoValidator()
        {
            Include(new INaturalPersonCustomerDtoValidator());
        }
    }
}
