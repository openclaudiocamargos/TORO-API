using Application.Commom.Exceptions;
using Application.Users.Queries.QueryUserInformations;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Application.Test.Users.Queries
{
    using static Testing;

    public class QueryUserInformationsTests
    {
        [Test]
        public async Task ShouldReturnUserInformations()
        {
            var result = await SendAsync(new GetUserInformationsQuery());
            Assert.IsNotEmpty(result.FirstName);
        }
    }
}
