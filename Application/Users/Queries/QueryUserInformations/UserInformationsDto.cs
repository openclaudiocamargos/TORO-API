using Application.Commom.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.QueryUserInformations
{
    public class UserInformationsDto : IMapFrom<User>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal AccountAmount { get; set; }
        public string? Document { get; set; }
    }
}
