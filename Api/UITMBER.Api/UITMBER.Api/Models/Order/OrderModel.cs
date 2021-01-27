using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Enums;

namespace UITMBER.Api.Models.Order
{
    public class OrderModel
    {
        public double StartLat { get; set; }
        public double StartLong { get; set; }
        public double EndLat { get; set; }
        public double EndLong { get; set; }
        public double Distance { get; set; }
        public CarType Type { get; set; }
        public double Cost { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentType PaymentType { get; set; }
        public LuggageType LuggageType { get; set; }
    }
}
