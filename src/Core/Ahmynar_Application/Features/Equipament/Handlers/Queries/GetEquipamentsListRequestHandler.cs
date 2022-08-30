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
    public class GetEquipamentsListRequestHandler : IRequestHandler<GetEquipamentsListRequest, List<EquipamentListDto>>
    {
        private readonly IEquipamentRepository _equipamentRepo;
        private readonly IMapper _mapper;

        public GetEquipamentsListRequestHandler(IEquipamentRepository equipamentRepo, IMapper mapper)
        {
            _equipamentRepo = equipamentRepo;
            _mapper = mapper;
        }
        public async Task<List<EquipamentListDto>> Handle(GetEquipamentsListRequest request, CancellationToken cancellationToken)
        {
            var equipaments = await _equipamentRepo.GetAllAsync();
            return _mapper.Map<List<EquipamentListDto>>(equipaments);
        }
    }
}
