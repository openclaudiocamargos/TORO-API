using Application.Commom.Mappings;
using Domain.Entities;

namespace Application.Users.Queries
{
    public class UserDto : IMapFrom<User>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Token { get; set; }
    }
}
