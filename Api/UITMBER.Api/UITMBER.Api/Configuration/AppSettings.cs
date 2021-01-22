using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Configuration
{
    public class AppSettings
    {
        public string JWTSecurityKey { get; set; }
        public string JWTIssuer { get; set; }
        public string JWTAudience { get; set; }
    }
}
