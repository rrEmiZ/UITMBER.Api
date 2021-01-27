using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Enums;

namespace UITMBER.Api.Repositories.DriverOrders.Dto
{
    public class DriverOrdersResultDto
    {

        public bool Success { get; set; }
        public double? IdClient { get; set; }
        public double? IdOrder { get; set; }
        public double? Rate { get; set; }
        public string Info { get; set; }
        public string Error { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? EndTime { get; set; }
        public OrderStatus Status { get; set; }
    }
}
