using Application.Commom.Interfaces;
using Application.Commom.Models;
using Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.UserPositions.EventHandlers
{
    public class UserPositionCreatedEventHandler : INotificationHandler<DomainEventNotification<UserPositionCreatedEvent>>
    {
        private readonly ILogger<UserPositionCreatedEventHandler> _logger;

        public UserPositionCreatedEventHandler(ILogger<UserPositionCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<UserPositionCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var userPosition = notification.DomainEvent.UserPosition;
            
            _logger.LogInformation("Toro register {typeposition} of users ({user}) position ({position})", 
                userPosition.Amount > 0 ? "buy" : "sell", 
                userPosition.UserId,
                userPosition.PositionId);

            return Task.CompletedTask;
        }
    }
}
