using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Equipament.Validators
{
    public class CreateEquipamentDtoValidator : AbstractValidator<CreateEquipamentDto>
    {
        private readonly ICustomerRepository _customerRepo;

        public CreateEquipamentDtoValidator(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
            Include(new IEquipamentDtoValidator(_customerRepo));
        }
    }
}
