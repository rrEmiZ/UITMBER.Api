using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Repositories.Cash.Dto
{
    public class CashDto
    {
        public bool BadRequest { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double TotalCost { get; set; }
    }
}
