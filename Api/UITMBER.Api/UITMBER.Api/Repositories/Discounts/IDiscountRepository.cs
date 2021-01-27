using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Repositories.Discounts.Dto;

namespace UITMBER.Api.Repositories.Discounts
{
    public interface IDiscountRepository
    {
        public Task<VerifyDiscountResultDto> Verify(string code);
        public Task<AddDiscountToOrderDto> AddToOrder(string code, long idorder, int userId);
    }
}
