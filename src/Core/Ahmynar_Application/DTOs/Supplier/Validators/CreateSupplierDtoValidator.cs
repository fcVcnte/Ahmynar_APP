using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahmynar_Application.DTOs.Supplier.Validators
{
    public class CreateSupplierDtoValidator : AbstractValidator<CreateSupplierDto>
    {
        public CreateSupplierDtoValidator()
        {
            Include(new ISupplierDtoValidator());
        }
    }
}
