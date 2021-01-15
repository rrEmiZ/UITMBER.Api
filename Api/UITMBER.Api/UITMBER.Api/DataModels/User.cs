using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.DataModels
{
    public class User
    {
        public long Id { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDriver { get; set; }

        public double Lat { get; set; }
        public double Long { get; set; }

        public bool IsWorking { get; set; }
    }
}
