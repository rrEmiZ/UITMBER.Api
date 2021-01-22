using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Models.Authentication
{
    public class AuthenticationnModel
    {
        [MaxLength(128)]
        public string Login { get; set; }
        [MaxLength(16)]
        public string Password { get; set; }
    }
}
