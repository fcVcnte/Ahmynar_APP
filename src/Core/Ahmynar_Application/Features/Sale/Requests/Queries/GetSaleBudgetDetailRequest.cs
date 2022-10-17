using Ahmynar_Application.DTOs.Sale;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Sale.Requests.Queries
{
    public class GetSaleBudgetDetailRequest : IRequest<SaleBudgetDto>
    {
        public int Id { get; set; }
    }
}
