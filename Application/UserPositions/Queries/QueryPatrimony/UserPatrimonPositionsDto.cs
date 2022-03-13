using Application.Commom.Mappings;
using Domain.Entities;

namespace Application.UserPositions.Queries.QueryPatrimony
{
    public class UserPatrimonPositionsDto
    {
        public string? Symbol { get; set; }
        public int Amount { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
