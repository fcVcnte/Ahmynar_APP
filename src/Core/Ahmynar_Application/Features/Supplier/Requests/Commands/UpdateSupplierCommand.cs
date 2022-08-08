using Ahmynar_Application.DTOs.Supplier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahmynar_Application.Features.Supplier.Requests.Commands
{
    public class UpdateSupplierCommand : IRequest<Unit>
    {
        public UpdateSupplierDto SupplierDto { get; set; }
    }
}
