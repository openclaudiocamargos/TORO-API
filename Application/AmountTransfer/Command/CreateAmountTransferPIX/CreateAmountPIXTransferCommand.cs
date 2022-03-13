using Application.Commom.Exceptions;
using Application.Commom.Helpers;
using Application.Commom.Interfaces;
using Domain.Entities;
using Domain.Event;
using MediatR;

namespace Application.AmountTransfer.Command.CreateAmountTransferPIX
{
    public class PersonInformation
    {
        public string? Bank { get; set; }
        public string? Branch { get; set; }
        public string? Account { get; set; }
    }

    public class OriginPersonInformation : PersonInformation
    {
        public string? CPF { get; set; }
    }

    public class CreateAmountPIXTransferCommand : IRequest<int>
    {
        public string? Event { get; set; }
        public PersonInformation Target { get; set; } = null!;
        public OriginPersonInformation Origin { get; set; } = null!;
        public decimal Amount { get; set; }
    }

    public class CreateAmountTransferPIXCommandHandler : IRequestHandler<CreateAmountPIXTransferCommand, int>
    {
        private readonly IToroDbContext _context;
        private readonly IDomainEventService _domainEventService;

        public CreateAmountTransferPIXCommandHandler(IToroDbContext context, IDomainEventService domainEventService)
        {
            _context = context;
            _domainEventService = domainEventService;
        }

        public async Task<int> Handle(CreateAmountPIXTransferCommand request, CancellationToken cancellationToken)
        {
            // Get user informations
            var user = _context.Users.Where(i => i.Document == request.Origin.CPF!.OnlyNumbers()).FirstOrDefault();
            if (user == null)
                throw new NotFoundException("user", "Document " + request.Origin.CPF);

            // Validate account
            if (user.Id.ToString() != request.Target.Account)
                throw new ForbiddenAccessException("PIX transfer account information is not the registred user account.");

            // Update ammount user
            user.AccountAmount += request.Amount;
            _context.Users.Update(user);

            // Register transfer
            var entity = new PixTransfer()
            {
                Amount = request.Amount,
                UserId = user.Id,
                AccountOrigin = string.Format("{0}-{1}-{2}", request.Origin.Bank, request.Origin.Branch, request.Origin.Account)
            };
            _context.PixTransfers.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            await _domainEventService.Publish(new AmountTransferPIXCreatedEvent(entity));

            return entity.Id;
        }
    }
}
