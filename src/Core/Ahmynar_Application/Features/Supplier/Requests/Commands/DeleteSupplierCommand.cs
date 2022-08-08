using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahmynar_Application.Features.Supplier.Requests.Commands
{
    public class DeleteSupplierCommand : IRequest
    {
        public int Id { get; set; }
    }
}
