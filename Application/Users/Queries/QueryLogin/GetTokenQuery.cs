using Application.Commom.Exceptions;
using Application.Commom.Interfaces;
using Application.Commom.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.QueryLogin
{
    public class GetTokenQuery : IRequest<UserDto>
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
    }

    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, UserDto>
    {
        private readonly IUserAuthenticationService _userAuthenticationService;
        private readonly IToroDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICriptographService _criptographService;

        public GetTokenQueryHandler(IToroDbContext context, 
            IMapper mapper, 
            IUserAuthenticationService userAuthenticationService,
            ICriptographService criptographService)
        {
            _context = context;
            _mapper = mapper;
            _userAuthenticationService = userAuthenticationService;
            _criptographService = criptographService;
        }

        public async Task<UserDto> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            var hashPassword = _criptographService.GetHash(request.Password!);

            var user = await _context.Users
                .Where(x => x.Login == request.Login && hashPassword == x.Password!)
                .AsNoTracking()
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
                throw new NotFoundException("User not found");

            user.Token = _userAuthenticationService.GenerateJWT(user.Id.ToString());

            return user;
        }
    }
}
