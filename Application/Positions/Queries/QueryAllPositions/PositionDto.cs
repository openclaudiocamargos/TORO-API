using Application.Commom.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Positions.Queries.QueryAllPositions
{
    public class PositionDto : IMapFrom<Position>
    {
        public string Symbol { get; set; } = "";
        public decimal CurrentPrice { get; set; }
    }
}
