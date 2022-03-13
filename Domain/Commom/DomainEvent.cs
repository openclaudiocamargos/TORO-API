﻿namespace Domain.Commom
{
    public abstract class DomainEvent
    {
        public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
