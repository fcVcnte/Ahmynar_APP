using Ahmynar_Application.Contracts.Persistence;
using Ahmynar_Application.Exceptions;
using Ahmynar_Application.Features.Product.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Application.Features.Product.Handlers.Commands
{
    public class CheckInProductCommandHandler : IRequestHandler<CheckInProductCommand>
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public CheckInProductCommandHandler(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CheckInProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetByIdAsync(request.Id);

            if (product == null || request.QuantityIn == 0)
            {
                throw new NotFoundException(nameof(Ahmynar_Domain.Product), request.Id);
            }

            await _productRepo.AddQuantityAsync(product, request.QuantityIn);

            return Unit.Value;
        }
    }
}
