using Application.Commom.Enumerated;
using Application.Commom.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Positions.Queries.QueryTopPositions
{
    public class GetTop7DaysPositionsQuery : IRequest<List<TopPositionDto>>
    {
        public int LimitPositions { get; set; }
        public eOperationType OperationType { get; set; }
    }

    public class GetTop7DaysPositionsQueryHandler : IRequestHandler<GetTop7DaysPositionsQuery, List<TopPositionDto>>
    {
        private readonly IToroDbContext _context;
        private readonly IMapper _mapper;

        public GetTop7DaysPositionsQueryHandler(IToroDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TopPositionDto>> Handle(GetTop7DaysPositionsQuery request, CancellationToken cancellationToken)
        {
            var referenceDate = DateTime.UtcNow.Date.AddDays(-7);
            var query = from up in _context.UserPositions.Include(i => i.Position)
                        .Where(i => (i.CreatedAt >= referenceDate) && (i.Amount * (int)request.OperationType > 0))
                        group up by new { up.Position.Symbol, up.Position.CurrentPrice }
                        into p
                        select new TopPositionDto() 
                        { 
                            Symbol = p.Key.Symbol, 
                            TotalAmount = p.Sum(i => Math.Abs(i.Amount)), 
                            TotalValue = p.Sum(i => Math.Abs(i.Amount) * Math.Abs(i.Price)),
                            CurrentPrice = p.Key.CurrentPrice
                        };

            return await query.OrderByDescending(i => i.TotalAmount).Take(request.LimitPositions).ToListAsync(cancellationToken);
        }
    }
}
