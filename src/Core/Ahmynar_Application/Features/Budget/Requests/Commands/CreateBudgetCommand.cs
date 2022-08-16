using Ahmynar_Application.DTOs.Budget;
using Ahmynar_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Budget.Requests.Commands
{
    public class CreateBudgetCommand : IRequest<BaseCommandResponse>
    {
        public CreateBudgetDto BudgetDto { get; set; }
    }
}
