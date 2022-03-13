using Domain.Commom;
using Domain.Entities;

namespace Domain.Event
{
    public class UserPositionCreatedEvent : DomainEvent
    {
        public UserPositionCreatedEvent(UserPosition userPosition)
        {
            UserPosition = userPosition;
        }

        public UserPosition UserPosition { get; }
    }
}