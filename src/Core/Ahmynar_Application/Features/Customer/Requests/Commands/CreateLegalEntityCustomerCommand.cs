using Ahmynar_Application.DTOs.Customer;
using Ahmynar_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Customer.Requests.Commands
{
    public class CreateLegalEntityCustomerCommand : IRequest<BaseCommandResponse>
    {
        public CreateLegalEntityCustomerDto LegalEntityDto { get; set; }
    }
}
