using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Options
{
    public class ProjectSettings
    {
        public string? JWTSecretKey { get; set; }
        public string? JWTIssuer { get; set; }
        public string? JWTAudience { get; set; }
        public string? CriptKey { get; set; }
    }
}
