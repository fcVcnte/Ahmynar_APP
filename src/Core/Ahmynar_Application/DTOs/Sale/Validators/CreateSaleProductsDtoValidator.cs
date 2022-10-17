using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Sale.Validators
{
    public class CreateSaleProductsDtoValidator : AbstractValidator<CreateSaleProductsDto>
    {
        private readonly IProductRepository _productRepo;

        public CreateSaleProductsDtoValidator(IProductRepository productRepo)
        {
            _productRepo = productRepo;
            Include(new ISaleProductsDtoValidator(_productRepo));
        }
    }
}
