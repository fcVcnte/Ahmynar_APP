using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Product.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        private readonly ISupplierRepository _supplierRepo;
        public CreateProductDtoValidator(ISupplierRepository supplierRepo)
        {
            _supplierRepo = supplierRepo;
            Include(new IProductDtoValidator(_supplierRepo));
        }
    }
}
