using Application.Commom.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.QueryUserInformations
{
    public class GetUserInformationsQuery : IRequest<UserInformationsDto>
    {
    }

    public class GetUserInformationsQueryHandler : IRequestHandler<GetUserInformationsQuery, UserInformationsDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IToroDbContext _context;
        private readonly IMapper _mapper;

        public GetUserInformationsQueryHandler(IToroDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<UserInformationsDto> Handle(GetUserInformationsQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(_currentUserService.UserId!.Value);
            return _mapper.Map<UserInformationsDto>(user);
        }
    }
}
