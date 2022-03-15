using Application.Commom.Interfaces;
using Application.Commom.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Positions.Queries.QueryAllPositions
{
    public class GetAllPositionsQuery : IRequest<List<PositionDto>>
    { }

    public class GetAllPositionsQueryHandler : IRequestHandler<GetAllPositionsQuery, List<PositionDto>>
    {
        private readonly IToroDbContext _context;
        private readonly IMapper _mapper;

        public GetAllPositionsQueryHandler(IToroDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PositionDto>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Positions.OrderBy(i => i.Symbol).ProjectToListAsync<PositionDto>(_mapper.ConfigurationProvider);
        }
    }
}
