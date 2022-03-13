namespace Application.UserPositions.Queries.QueryPatrimony
{
    public class UserPatrimonyDto
    {
        public decimal CheckingAccountAmount { get; set; }
        public List<UserPatrimonPositionsDto> Positions { get; set; } = new List<UserPatrimonPositionsDto>();
        public decimal Consolidated { get; set; }
    }
}
