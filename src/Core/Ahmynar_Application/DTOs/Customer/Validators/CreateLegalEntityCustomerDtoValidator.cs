using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Customer.Validators
{
    public class CreateLegalEntityCustomerDtoValidator : AbstractValidator<CreateLegalEntityCustomerDto>
    {
        public CreateLegalEntityCustomerDtoValidator()
        {
            Include(new ILegalEntityCustomerDtoValidator());
        }
    }
}
