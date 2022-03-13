using Domain.Commom;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal AccountAmount { get; set; }
        public List<UserPosition> Positions { get; set; } = new List<UserPosition>();
        public List<UserPositionAggregate> PositionsAggregate { get; set; } = new List<UserPositionAggregate>();
        public byte[]? RowVersion { get; set; }
    }
}
