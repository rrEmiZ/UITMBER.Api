using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Repositories.DriverOrders.Dto
{
    public class DriverOrdersResultDto
    {
        public bool Succes { get; set; }
        public string Error { get; set; }
        public double? ClientRate { get; set; }
        public string Info { get; set; }
        public DateTime? Date { get; set; }
    }
}
