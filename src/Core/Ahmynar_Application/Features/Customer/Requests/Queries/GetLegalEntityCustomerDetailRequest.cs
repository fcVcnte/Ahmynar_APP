﻿using Ahmynar_Application.DTOs.Customer;
using MediatR;

namespace Ahmynar_Application.Features.Customer.Requests.Queries
{
    public class GetLegalEntityCustomerDetailRequest : IRequest<LegalEntityCustomerDto>
    {
        public int Id { get; set; }
    }
}
