using Domain.Commom;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Event
{
    public class AmountTransferPIXCreatedEvent : DomainEvent
    {
        public AmountTransferPIXCreatedEvent(PixTransfer pixTransfer)
        {
            PixTransfer = pixTransfer;
        }

        public PixTransfer PixTransfer { get; }
    }
}
