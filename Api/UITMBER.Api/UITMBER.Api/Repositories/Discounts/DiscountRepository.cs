using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.Repositories.Discounts.Dto;

namespace UITMBER.Api.Repositories.Discounts
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly UDbContext _context;

        public DiscountRepository(UDbContext context)
        {
            _context = context;
        }

        public async Task<VerifyDiscountResultDto> Verify(string code)
        {
            var discount = await (from x in _context.Discounts
                                  where x.Code == code && x.Limit > 0
                                  select x).FirstOrDefaultAsync();

            if (discount == null)
            {
                return new VerifyDiscountResultDto()
                {
                    Success = false,
                    CanUse = false
                };
            }
            else
            {
                return new VerifyDiscountResultDto()
                {
                    Success = true,
                    CanUse = true
                };
            }
        }


        public async Task<AddDiscountToOrderDto> AddToOrder(string code, long idorder, int userId)
        {
            var VerifyResult = await Verify(code);

            if (VerifyResult.CanUse)
            {
                var order = await (from x in _context.Orders
                                   where x.Id == idorder && x.DiscountId == null && x.UserId == userId
                                   select x).FirstOrDefaultAsync();

                var discount = await (from x in _context.Discounts
                                      where x.Code == code
                                      select x).FirstOrDefaultAsync();

                if (order == null)
                {
                    return new AddDiscountToOrderDto()
                    {
                        Success = false
                    };
                }
                else
                {
                    discount.Limit -= 1;
                    _context.Discounts.Update(discount);


                    if (discount.MoneyDisc == 0 && discount.PercentDisc != 0)
                    {
                        order.Cost = order.Cost * (discount.PercentDisc / 100);
                    }
                    else if (discount.MoneyDisc != 0 && discount.PercentDisc == 0)
                    {
                        order.Cost = order.Cost - discount.MoneyDisc;
                    }
                    order.DiscountId = discount.Id;
                    order.Discount = discount;
                    _context.Orders.Update(order);
                    await _context.SaveChangesAsync();

                    return new AddDiscountToOrderDto()
                    {
                        Success = true
                    };
                }
            }
            else
            {
                return new AddDiscountToOrderDto()
                {
                    Success = false
                };
            }
        }
    }
}
