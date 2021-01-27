using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Enums;

namespace UITMBER.Api.Repositories.Orders.Dto
{
    public class NewOrderPaymentResultDto
    {
        public bool Success { get; set; }
        public bool IsPaid { get; set; }
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public PaymentType paymentType { get; set; }
        public string Error { get; set; }
    }
}
