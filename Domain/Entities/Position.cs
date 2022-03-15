namespace Domain.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = "";
        public decimal CurrentPrice { get; set; }
    }
}
