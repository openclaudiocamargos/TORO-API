using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserPositions.Commands.CreateUserPosition
{
    public class CreateUserPositionDto
    {
        public string Symbol { get; set; } = "";
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
