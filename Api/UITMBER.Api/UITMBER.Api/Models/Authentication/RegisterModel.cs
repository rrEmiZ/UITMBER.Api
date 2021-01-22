using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Models.Authentication
{
    public class RegisterModel
    {
        [MaxLength(128)]
        public string Email { get; set; }
        [MaxLength(16)]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
    }
}
