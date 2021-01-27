using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Repositories.Drivers.Dto
{
    public class DriverDto
    {
        public long Id { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
