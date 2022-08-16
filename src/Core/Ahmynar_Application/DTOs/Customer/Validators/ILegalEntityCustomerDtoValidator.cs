using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Customer.Validators
{
    public class ILegalEntityCustomerDtoValidator : AbstractValidator<ILegalEntityCustomerDto>
    {
        public ILegalEntityCustomerDtoValidator()
        {
            RuleFor(p => p.TypeCustomer)
                .NotNull()
                .IsInEnum();

            RuleFor(p => p.CompanyName)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull()
                .MaximumLength(80).WithMessage("{PropertyName} não pode exceder 80 caracteres.");

            RuleFor(p => p.TradeName)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull()
                .MaximumLength(40).WithMessage("{PropertyName} não pode exceder 40 caracteres.");

            RuleFor(p => p.Cnpj)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull()
                .MinimumLength(14).WithMessage("{PropertyName} inválido")
                .MaximumLength(14).WithMessage("{PropertyName} não pode exceder 14 caracteres.");

            RuleFor(p => p.IE)
                .NotEmpty().WithMessage("Inscrição Estadual é obrigatória.")
                .NotNull()
                .MinimumLength(10).WithMessage("Inscrição Estadual inválida")
                .MaximumLength(10).WithMessage("Inscrição Estadual não pode exceder 10 caracteres.");

            RuleFor(p => p.IM)
                .MinimumLength(7).WithMessage("Inscrição Estadual inválida")
                .MaximumLength(8).WithMessage("Inscrição Estadual não pode exceder 10 caracteres.");

            RuleFor(p => p.Phone)
                .MinimumLength(10).WithMessage("{PropertyName} inválido")
                .MaximumLength(40).WithMessage("{PropertyName} não pode exceder 40 caracteres.");

            RuleFor(p => p.Cellphone)
                .MinimumLength(11).WithMessage("{PropertyName} inválido")
                .MaximumLength(40).WithMessage("{PropertyName} não pode exceder 40 caracteres.");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} não pode exceder 100 caracteres.");

            RuleFor(p => p.Number)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull();

            RuleFor(p => p.Address2)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} não pode exceder 50 caracteres.");

            RuleFor(p => p.AddressComplement)
                .MaximumLength(100).WithMessage("{PropertyName} não pode exceder 100 caracteres.");

            RuleFor(p => p.City)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull()
                .MaximumLength(40).WithMessage("{PropertyName} não pode exceder 40 caracteres.");

            RuleFor(p => p.State)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull()
                .MaximumLength(40).WithMessage("{PropertyName} não pode exceder 40 caracteres.");

            RuleFor(p => p.Country)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull()
                .MaximumLength(56).WithMessage("{PropertyName} não pode exceder 56 caracteres.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} é obrigatória.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} não pode exceder 100 caracteres.");

            RuleFor(p => p.Obs)
                .MaximumLength(200).WithMessage("{PropertyName} não pode exceder 200 caracteres.");
        }
    }
}
