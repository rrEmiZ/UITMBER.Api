using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.DataModels;
using UITMBER.Api.Enums;
using UITMBER.Api.Repositories.DriverOrders.Dto;

namespace UITMBER.Api.Repositories.DriverOrders
{
    public class DriverOrdersRepository : IDriverOrdersRepository
    {

        private readonly UDbContext _context;

        public DriverOrdersRepository(UDbContext context)
        {
            _context = context;
        }

        public async Task<DriverOrdersResultDto> DriverRate(long IdOrder, string Info, double ClientRate)
        {
            Order result =
                await (from o in _context.Orders where o.Id == IdOrder select o).SingleOrDefaultAsync();
            result.ClientRate = ClientRate;
            result.ClientRateDate = DateTime.Now;
            result.ClientRateInfo = Info;
            _context.Orders.Update(result);
            _context.SaveChanges();

            return new DriverOrdersResultDto()
            {
                Succes = true,
                ClientRate = result.ClientRate,
                Date = result.ClientRateDate,
                Info = result.ClientRateInfo
            };
        }

        public async Task<GetDriverOrderDetailsResultDto> GetDriverOrderDetails(long IdOrder)
        {
            Order result =
                await (from o in _context.Orders where o.Id == IdOrder select o).SingleOrDefaultAsync();
            User resultUser = _context.Users.Where(x => x.Id == result.UserId).SingleOrDefault();

            return new GetDriverOrderDetailsResultDto()
            {
                Success = true,
                CreationTime = result.CreationTime,
                StartLat = result.StartLat,
                StartLong = result.StartLong,
                EndLat = result.EndLat,
                EndLong = result.EndLong,
                Type = result.Type,
                LuggageType = result.LuggageType,
                Earnings = result.Cost,
                Status = result.Status,


                FirstName = resultUser.FirstName,
                LastName = resultUser.LastName,
                PhoneNumber = resultUser.PhoneNumber,
                Photo = resultUser.Photo
            };
        }

        public async Task<ChangeOrderStatusResultDto> ChangeOrderStatus(long idOrder, OrderStatus status)
        {
            Order result =
                await (from o in _context.Orders where o.Id == idOrder select o).SingleOrDefaultAsync();
            result.Status = status;
            _context.Orders.Update(result);
            _context.SaveChanges();

            return new ChangeOrderStatusResultDto()
            {
                Success = true,
                IdOrder = result.Id,
                Status = result.Status
            };
        }

    }
}
