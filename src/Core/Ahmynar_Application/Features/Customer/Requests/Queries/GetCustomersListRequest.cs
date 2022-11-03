using Ahmynar_Application.DTOs.Customer;
using MediatR;

namespace Ahmynar_Application.Features.Customer.Requests.Queries
{
    public class GetCustomersListRequest : IRequest<List<CustomerDto>>
    {
    }
}
