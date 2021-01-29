using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Enums;

namespace UITMBER.Api.Repositories.DriverOrders.Dto
{
    public class GetDriverOrderDetailsResultDto
    {
        public bool Success { get; set; }
        public string Error { get; set; }

        public DateTime CreationTime { get; set; }
        public double StartLat { get; set; }
        public double StartLong { get; set; }

        public double EndLat { get; set; }
        public double EndLong { get; set; }
        public CarType Type { get; set; }
        public double Earnings { get; set; }
        public OrderStatus Status { get; set; }
        public LuggageType LuggageType { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
    }
}
