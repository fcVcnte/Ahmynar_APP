using Ahmynar_Application.DTOs.Budget;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Budget.Requests.Commands
{
    public class UpdateBudgetCommand : IRequest<Unit>
    {
        public UpdateBudgetDto BudgetDto { get; set; }
    }
}
