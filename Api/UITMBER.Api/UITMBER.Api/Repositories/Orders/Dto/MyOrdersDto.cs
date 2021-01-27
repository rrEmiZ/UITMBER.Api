using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Repositories.Orders.Dto
{
    public class MyOrdersDto
    {
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public long? DriverId { get; set; }

        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public string DriverEmail { get; set; }
        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }
    }
}
