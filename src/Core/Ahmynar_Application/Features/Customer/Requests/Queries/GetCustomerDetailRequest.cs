using Ahmynar_Application.DTOs.Customer;
using MediatR;

namespace Ahmynar_Application.Features.Customer.Requests.Queries
{
    public class GetCustomerDetailRequest : IRequest<CustomerDto>
    {
        public int Id { get; set; }
    }
}
