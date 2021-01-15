using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Repositories.Drivers.Dto
{
    public class DriverDto
    {
        public long Id { get; set; }

        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
