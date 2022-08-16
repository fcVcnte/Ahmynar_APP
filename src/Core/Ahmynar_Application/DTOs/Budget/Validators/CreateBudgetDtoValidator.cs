using Ahmynar_Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.DTOs.Budget.Validators
{
    public class CreateBudgetDtoValidator : AbstractValidator<CreateBudgetDto>
    {
        private readonly ICustomerRepository _customerRepo;
        public CreateBudgetDtoValidator(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
            Include(new IBudgetDtoValidator(_customerRepo));
        }
    }
}
