using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Repositories.DriverOrders.Dto
{
    public class ClientInfoResultDto
    {
        public bool Success { get; set; }
        public string Error { get; set; }
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
