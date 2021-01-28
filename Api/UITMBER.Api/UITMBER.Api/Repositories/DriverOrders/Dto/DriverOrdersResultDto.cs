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
        public string Error { get; set; }
        public OrderStatus Status { get; set; }
        public long idOrder { get; set; }
    }
}
