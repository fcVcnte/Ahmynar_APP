using Ahmynar_Application.DTOs.Supplier;
using Ahmynar_Application.Features.Supplier.Requests.Queries;
using Ahmynar_Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Supplier.Handlers.Queries
{
    public class GetSupplierDetailRequestHandler : IRequestHandler<GetSupplierDetailRequest, SupplierDto>
    {
        private readonly ISupplierRepository _supplierRepo;
        private readonly IMapper _mapper;

        public GetSupplierDetailRequestHandler(ISupplierRepository supplierRepo, IMapper mapper)
        {
            _supplierRepo = supplierRepo;
            _mapper = mapper;
        }

        public async Task<SupplierDto> Handle(GetSupplierDetailRequest request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepo.GetByIdAsync(request.Id);
            return _mapper.Map<SupplierDto>(supplier);
        }
    }
}
