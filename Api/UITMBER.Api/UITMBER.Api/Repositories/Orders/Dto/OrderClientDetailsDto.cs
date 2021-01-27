using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Repositories.Orders.Dto
{
    public class OrderClientDetailsDto
    {
        public double StartLat { get; set; }
        public double StartLong { get; set; }

        public double EndLat { get; set; }
        public double EndLong { get; set; }

        public long? DriverId { get; set; }
        public long OrderId { get; set; }

    }
}
