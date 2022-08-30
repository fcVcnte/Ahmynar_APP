using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.DTOs.Equipament;
using Ahmynar_Application.Features.Equipament.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Equipament.Handlers.Queries
{
    public class GetEquipamentDetailRequestHandler : IRequestHandler<GetEquipamentDetailRequest, EquipamentDto>
    {
        private readonly IEquipamentRepository _equipamentRepo;
        private readonly IMapper _mapper;

        public GetEquipamentDetailRequestHandler(IEquipamentRepository equipamentRepo, IMapper mapper)
        {
            _equipamentRepo = equipamentRepo;
            _mapper = mapper;
        }

        public async Task<EquipamentDto> Handle(GetEquipamentDetailRequest request, CancellationToken cancellationToken)
        {
            var equipament = await _equipamentRepo.GetByIdAsync(request.Id);
            return _mapper.Map<EquipamentDto>(equipament);
        }
    }
}
