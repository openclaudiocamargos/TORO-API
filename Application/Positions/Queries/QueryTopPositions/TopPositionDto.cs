using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Positions.Queries.QueryTopPositions
{
    public class TopPositionDto
    {
        public string? Symbol { get; set; }
        public int TotalAmount { get; set; }
        public decimal TotalValue { get; set; }
    }
}
