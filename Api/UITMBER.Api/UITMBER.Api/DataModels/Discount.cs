using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.DataModels
{
    public class Discount
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public double MoneyDisc { get; set; }

        public double PercentDisc { get; set; }

        public int Limit { get; set; }
    }
}
