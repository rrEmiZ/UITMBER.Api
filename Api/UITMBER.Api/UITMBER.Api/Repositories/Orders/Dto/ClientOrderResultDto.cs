using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Repositories.Orders.Dto
{
    public class ClientOrderResultDto
    {
        public long? IdDriver { get; set; }
        public bool Success { get; set; }
        public double? Rate { get; set; }
        public string Info { get; set; }
        public DateTime? Date { get; set; }
        public string Error { get; set; }
    }
}
