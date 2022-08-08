using Ahmynar_Application.DTOs.Supplier;
using Ahmynar_Application.Responses;
using MediatR;

namespace Ahmynar_Application.Features.Supplier.Requests.Commands
{
    public class CreateSupplierCommand : IRequest<BaseCommandResponse>
    {
        public CreateSupplierDto SupplierDto { get; set; }
    }
}
