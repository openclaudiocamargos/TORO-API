using Application.AmountTransfer.Command.CreateAmountTransferPIX;
using Application.Positions.Queries.QueryAllPositions;
using Application.UserPositions.Commands.CreateUserPosition;
using Application.UserPositions.Queries.QueryPatrimony;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Test.UserPositions.Commands
{
    using static Testing;

    public class CreateUserPositionTests
    {
        [Test]
        public async Task ShouldCreateUserPositionBuy()
        {
            var positions = await SendAsync(new GetAllPositionsQuery());
            var oldPatrimony = await SendAsync(new GetPatrimonyQuery());

            var positionToBy = positions.FirstOrDefault();
            // Transfer money if necessary
            if (oldPatrimony.CheckingAccountAmount < positionToBy!.CurrentPrice)
            {
                await SendAsync(new CreateAmountPIXTransferCommand()
                {
                     Amount = positionToBy!.CurrentPrice,
                     Event = "TARGET",
                     Origin = new OriginPersonInformation()
                     {
                         Account = "0001",
                         Bank = "0001",
                         Branch = "0001",
                         CPF = "000000000191"
                     },
                     Target = new PersonInformation()
                     {
                         Account = "1",
                         Bank = "352",
                         Branch = "0001"
                     }
                });
            }

            // Buy position
            var commandUserPosition = new CreateUserPositionCommand()
            {
                Amount = 1,
                Symbol = positionToBy.Symbol
            };
            var createPositionResponse = await SendAsync(commandUserPosition);

            // Check patrimony changes
            var newPatrimony = await SendAsync(new GetPatrimonyQuery());

            Assert.IsTrue(oldPatrimony.CheckingAccountAmount == newPatrimony.CheckingAccountAmount + createPositionResponse.Price);
        }

        [Test]
        public async Task ShouldCreateUserPositionSell()
        {
            var positions = await SendAsync(new GetAllPositionsQuery());
            var oldPatrimony = await SendAsync(new GetPatrimonyQuery());

            var positionToSell = oldPatrimony.Positions.FirstOrDefault();

            // Sell position
            var commandUserPosition = new CreateUserPositionCommand()
            {
                Amount = -1,
                Symbol = positionToSell!.Symbol!
            };
            var createPositionResponse = await SendAsync(commandUserPosition);

            // Check patrimony changes
            var newPatrimony = await SendAsync(new GetPatrimonyQuery());

            Assert.IsTrue(oldPatrimony.CheckingAccountAmount == newPatrimony.CheckingAccountAmount - createPositionResponse.Price);
        }
    }
}
