using Ahmynar_Application.DTOs.Supplier;
using MediatR;
using System.Collections.Generic;

namespace Ahmynar_Application.Features.Supplier.Requests.Queries
{
    public class GetSuppliersListRequest : IRequest<List<SupplierDto>>
    {
    }
}
