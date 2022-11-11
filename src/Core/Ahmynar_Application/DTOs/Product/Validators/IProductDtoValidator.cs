using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;

namespace Ahmynar_Application.DTOs.Product.Validators
{
    public class IProductDtoValidator : AbstractValidator<IProductDto>
    {
        private readonly ISupplierRepository _supplierRepo;
        public IProductDtoValidator(ISupplierRepository supplierRepo)
        {
            _supplierRepo = supplierRepo;

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} não pode exceder 50 caracteres.");

            RuleFor(p => p.GroupProduct)
                .NotNull()
                .IsInEnum();

            RuleFor(p => p.PurchasePrice)
                .NotNull()
                .LessThanOrEqualTo(p => p.SalePrice);

            RuleFor(p => p.Quantity)
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.Unit)
                .MaximumLength(15).WithMessage("{PropertyName} não pode exceder 15 caracteres.");

            RuleFor(p => p.SalePrice)
                .NotNull()
                .GreaterThanOrEqualTo(p => p.PurchasePrice);

            RuleFor(p => p.Obs)
                .MaximumLength(100).WithMessage("{PropertyName} não pode exceder 100 caracteres.");

            //RuleFor(p => p.SupplierId)
            //    .GreaterThan(0)
            //    .MustAsync(async (id, token) =>
            //    {
            //        var supplierExists = await _supplierRepo.Exists((int)id);
            //        return supplierExists;
            //    })
            //    .WithMessage("{PropertyName} não existe.");
        }
    }
}
