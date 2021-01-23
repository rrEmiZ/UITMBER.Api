using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Enums;

namespace UITMBER.Api.Repositories.Orders.Dto
{
    public class NewOrderResultDto
    {
        public bool Success { get; set; }
        public OrderStatus Status { get; set; }
        public string Error { get; set; }
    }
}
