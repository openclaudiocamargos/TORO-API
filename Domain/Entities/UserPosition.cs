using Domain.Commom;

namespace Domain.Entities
{
    public class UserPosition
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int PositionId { get; set; }
        public Position Position { get; set; } = null!;
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}