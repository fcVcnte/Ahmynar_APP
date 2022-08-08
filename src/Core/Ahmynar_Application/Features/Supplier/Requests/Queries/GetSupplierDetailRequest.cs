using Ahmynar_Application.DTOs.Supplier;
using MediatR;

namespace Ahmynar_Application.Features.Supplier.Requests.Queries
{
    public class GetSupplierDetailRequest : IRequest<SupplierDto>
    {
        public int Id { get; set; }
    }
}
