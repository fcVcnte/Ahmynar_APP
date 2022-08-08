using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Product.Validators
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        private readonly ISupplierRepository _supplierRepo;
        public UpdateProductDtoValidator(ISupplierRepository supplierRepo)
        {
            _supplierRepo = supplierRepo;
            Include(new IProductDtoValidator(_supplierRepo));

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} é obrigatória.")
                .GreaterThan(0);
        }
    }
}
