using Ahmynar_Application.DTOs.Supplier;
using Ahmynar_Application.Features.Supplier.Requests.Queries;
using Ahmynar_Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Supplier.Handlers.Queries
{
    public class GetSuppliersListRequestHandler : IRequestHandler<GetSuppliersListRequest, List<SupplierDto>>
    {
        private readonly ISupplierRepository _supplierRepo;
        private readonly IMapper _mapper;

        public GetSuppliersListRequestHandler(ISupplierRepository supplierRepo, IMapper mapper)
        {
            _supplierRepo = supplierRepo;
            _mapper = mapper;
        }

        public async Task<List<SupplierDto>> Handle(GetSuppliersListRequest request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepo.GetAllAsync();
            return _mapper.Map<List<SupplierDto>>(suppliers);
        }
    }
}
