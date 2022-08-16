using Ahmynar_Application.DTOs.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Customer.Requests.Commands
{
    public class UpdateLegalEntityCustomerCommand : IRequest<Unit>
    {
        public UpdateLegalEntityCustomerDto LegalEntityDto { get; set; }
    }
}
