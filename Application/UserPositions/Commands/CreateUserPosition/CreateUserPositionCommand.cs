using Application.Commom.Exceptions;
using Application.Commom.Interfaces;
using Domain.Entities;
using Domain.Event;
using MediatR;

namespace Application.UserPositions.Commands.CreateUserPosition
{
    public class CreateUserPositionCommand : IRequest<int>
    {
        public string? Symbol { get; set; }
        public int Amount { get; set; }
    }

    public class CreateUserPositionCommandHandler : IRequestHandler<CreateUserPositionCommand, int>
    {
        private readonly IToroDbContext _context;
        private readonly IDomainEventService _domainEventService;
        private readonly ICurrentUserService _currentUserService;

        public CreateUserPositionCommandHandler(IToroDbContext context, IDomainEventService domainEventService, ICurrentUserService currentUserService)
        {
            _context = context;
            _domainEventService = domainEventService;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreateUserPositionCommand request, CancellationToken cancellationToken)
        {
            var position = _context.Positions.Where(i => i.Symbol == request.Symbol).FirstOrDefault();
            if (position == null)
                throw new NotFoundException("position", request.Symbol!);

            var user = _context.Users.Find(_currentUserService.UserId);
            if (user == null)
                throw new NotFoundException("user", _currentUserService.UserId!.Value);

            var positionAggregate = _context.UserPositionsAggragate.Where(i => i.PositionId == position.Id && i.UserId == _currentUserService.UserId!.Value).FirstOrDefault();

            // Update and validate user 
            user.AccountAmount -= request.Amount * position.CurrentPrice;
            if (user.AccountAmount < 0)
                throw new ForbiddenAccessException("Insuficiente funds");
            _context.Users.Update(user);

            // Add the nem position
            var entity = new UserPosition
            {                
                Amount = request.Amount,
                Price = position.CurrentPrice,
                UserId = _currentUserService.UserId!.Value,
                PositionId = position.Id,
                CreatedAt = DateTime.UtcNow
            };
            _context.UserPositions.Add(entity);

            // Update and validade user position
            if (positionAggregate != null)
            {
                positionAggregate.Ammount += request.Amount;
                if (positionAggregate.Ammount < 0)
                    throw new ForbiddenAccessException("Insuficiente position amount");
                _context.UserPositionsAggragate.Update(positionAggregate);
            }
            else
            {
                if (request.Amount < 0)
                    throw new ForbiddenAccessException("Insuficiente position amount");
                _context.UserPositionsAggragate.Add(new UserPositionAggregate()
                {
                    Ammount = request.Amount,
                    PositionId = position.Id,
                    UserId = _currentUserService.UserId!.Value
                });
            }

            await _context.SaveChangesAsync(cancellationToken);
            await _domainEventService.Publish(new UserPositionCreatedEvent(entity));

            return entity.Id;
        }
    }
}
