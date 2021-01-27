using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.DataModels
{
    public class Payment
    {
        public long Id { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        public long OrderId { get; set; }

        public bool IsPaid { get; set; }

    }
}
