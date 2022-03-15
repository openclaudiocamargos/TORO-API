using Application.Commom.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserPositions.Queries.QueryPatrimony
{
    public class GetPatrimonyQuery : IRequest<UserPatrimonyDto>
    {
    }

    public class GetPatrimonyQueryHandler : IRequestHandler<GetPatrimonyQuery, UserPatrimonyDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IToroDbContext _context;
        private readonly IMapper _mapper;

        public GetPatrimonyQueryHandler(IToroDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<UserPatrimonyDto> Handle(GetPatrimonyQuery request, CancellationToken cancellationToken)
        {
            var checkingAccountAmount = _context.Users.Find(_currentUserService.UserId!.Value)!.AccountAmount;

            var positions = await _context.UserPositionsAggragate
                .Include(t => t.Position)
                .Where(i => i.UserId == _currentUserService.UserId!.Value)
                .Select(i => new UserPatrimonPositionsDto()
                {
                    Amount = i.Ammount,
                    CurrentPrice = i.Position.CurrentPrice,
                    Symbol = i.Position.Symbol
                })
                .ToListAsync(cancellationToken);

            var patrimony = new UserPatrimonyDto()
            {
                CheckingAccountAmount = checkingAccountAmount,
                Positions = positions,
                Consolidated = checkingAccountAmount + positions.Sum(i => i.Amount * i.CurrentPrice)
            };

            return patrimony;
        }
    }
}
