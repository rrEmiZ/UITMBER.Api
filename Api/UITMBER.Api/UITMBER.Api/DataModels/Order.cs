using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Enums;

namespace UITMBER.Api.DataModels
{
    public class Order
    {
        public long Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public long UserId { get; set; }

        public DateTime CreationTime { get; set; }

        public double StartLat { get; set; }
        public double StartLong { get; set; }

        public double EndLat { get; set; }
        public double EndLong { get; set; }

        public double Distance { get; set; }

        public CarType Type { get; set; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        public long? CarId { get; set; }

        [ForeignKey(nameof(DriverId))]
        public User Driver { get; set; }
        public long? DriverId { get; set; }

        public double Cost { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public OrderStatus Status { get; set; }

        public PaymentType PaymentType { get; set; }

        public LuggageType LuggageType { get; set; }

        [Range(1.0, 5.0)]
        public double? DriverRate { get; set; } //Ocena kierowcy przez klienta
        public DateTime? DriverRateDate { get; set; }
        [MaxLength(300)]
        public string DriverRateInfo { get; set; }

        [ForeignKey(nameof(DiscountId))]
        public Discount Discount { get; set; }
        public long? DiscountId { get; set; }
        //
        [Range(1.0, 5.0)]
        public double? ClientRate { get; set; }
        public DateTime? ClientRateDate { get; set; }

        [MaxLength(300)]
        public string ClientRateInfo { get; set; }
    }
}
