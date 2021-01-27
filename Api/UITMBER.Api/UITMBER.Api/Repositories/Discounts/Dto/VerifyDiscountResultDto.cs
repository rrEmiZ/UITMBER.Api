using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Repositories.Discounts.Dto
{
    public class VerifyDiscountResultDto
    {
        public bool Success { get; set; }
        public bool CanUse { get; set; }
        public string Error { get; set; }
    }
}
