using Application.Commom.Helpers;
using Application.Commom.Interfaces;
using Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LasttName { get; set; }
        public string? Document { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IToroDbContext _context;
        private readonly ICriptographService _criptographService;

        public CreateUserCommandHandler(IToroDbContext context, ICriptographService criptographService)
        {
            _context = context;
            _criptographService = criptographService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Validate duplicated login
            if (_context.Users.Where(i => i.Login == request.Login).Any())
                throw new ValidationException("Username unavailable.");

            var entity = new User
            {
                Login = request.Login,
                Password = _criptographService.GetHash(request.Password!),
                AccountAmount = 0,
                FirstName = request.FirstName,
                LastName = request.LasttName,
                Document = request.Document!.OnlyNumbers()
            };            

            _context.Users.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
