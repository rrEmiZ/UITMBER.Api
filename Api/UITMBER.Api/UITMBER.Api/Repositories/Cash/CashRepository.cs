using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.Repositories.Cash.Dto;

namespace UITMBER.Api.Repositories.Cash
{
    public class CashRepository : ICashRepository
    {
        private readonly UDbContext _context;

        public CashRepository(UDbContext context)
        {
            _context = context;
        }

        public async Task<CashDto> GetMyEarnings(DateTime startDate, DateTime endDate, long currentUserId)
        {
            double totalEarnings = 0;
            var user = await _context.Users.Where(u => u.IsWorking == true
                                                  && u.IsDriver == true
                                                  && u.Id == currentUserId)
                                                  .FirstOrDefaultAsync();
            if (user != null)
            {
                var resultOrders =
                await _context.Orders.Where(o => o.StartTime != null
                                            && o.EndTime != null
                                            && o.DriverId != null
                                            && o.DriverId == currentUserId
                                            && (o.StartTime >= startDate && o.EndTime <= endDate)).ToListAsync();

                foreach (var order in resultOrders)
                {
                    totalEarnings += order.Cost;
                }

                return new CashDto
                {
                    BadRequest = false,
                    From = startDate,
                    To = endDate,
                    TotalCost = totalEarnings
                };
            }
            else
            {
                return new CashDto
                {
                    BadRequest = true,
                    From = DateTime.Now,
                    To = DateTime.Now,
                    TotalCost = 0
                };
            }
        }

        public async Task<CashDto> GetMySaldo(DateTime startDate, DateTime endDate, long currentUserId)
        {
            double totalSaldo = 0;
            var user = await _context.Users.Where(u => u.IsWorking == false
                                                  && u.IsDriver == false
                                                  && u.Id == currentUserId)
                                                  .FirstOrDefaultAsync();
            if (user != null)
            {
                var resultOrders =
                await _context.Orders.Where(o => o.StartTime != null
                                            && o.EndTime != null
                                            && o.DriverId != null
                                            && o.UserId == currentUserId
                                            && (o.StartTime >= startDate && o.EndTime <= endDate)).ToListAsync();

                foreach (var order in resultOrders)
                {
                    totalSaldo += order.Cost;
                }

                return new CashDto
                {
                    BadRequest = false,
                    From = startDate,
                    To = endDate,
                    TotalCost = totalSaldo
                };
            }
            else
            {
                return new CashDto
                {
                    BadRequest = true,
                    From = DateTime.Now,
                    To = DateTime.Now,
                    TotalCost = 0
                };
            }
        }
    }
}
