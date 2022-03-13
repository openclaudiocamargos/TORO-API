namespace Domain.Entities
{
    public class UserPositionAggregate
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int PositionId { get; set; }
        public Position Position { get; set; } = null!;
        public int Ammount { get; set; }
        public byte[]? RowVersion { get; set; }
    }
}