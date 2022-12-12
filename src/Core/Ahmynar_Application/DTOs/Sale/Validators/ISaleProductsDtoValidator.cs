using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Sale.Validators
{
    public class ISaleProductsDtoValidator : AbstractValidator<ISaleProductsDto>
    {
        private readonly IProductRepository _productRepo;

        public ISaleProductsDtoValidator(IProductRepository productRepo)
        {
            _productRepo = productRepo;

            RuleFor(s => s.PaymentSale)
                .NotNull()
                .IsInEnum();

            RuleFor(p => p.TotalDiscounts)
                .LessThan(p => p.TotalSale);

            RuleFor(s => s.TotalSale)
                .NotNull();
        }
    }
}
