using Application.Commom.Models;
using Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AmountTransfer.EventHandlers
{
    public class AmountTransferPIXCreatedEventHandler : INotificationHandler<DomainEventNotification<AmountTransferPIXCreatedEvent>>
    {
        private readonly ILogger<AmountTransferPIXCreatedEventHandler> _logger;

        public AmountTransferPIXCreatedEventHandler(ILogger<AmountTransferPIXCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<AmountTransferPIXCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var pixTransfer = notification.DomainEvent.PixTransfer;

            _logger.LogInformation("Toro register {Amount} to user ({user})",
                pixTransfer.Amount,
                pixTransfer.UserId);

            return Task.CompletedTask;
        }
    }
}
