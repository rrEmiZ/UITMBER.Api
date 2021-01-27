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

        public DriverOrdersRepository(UDbContext contex)
        {
            _context = contex;
        }

        public async Task<DriverOrdersResultDto> DriverRate(long idOrder, string info, double clientRate)
        {
            Order result = await (from o in _context.Orders
                            where o.Id == idOrder
                            select o).SingleOrDefaultAsync();

            result.ClientRate = clientRate;
            result.ClientRateDate = DateTime.Now;
            result.ClientRateInfo = info;

            _context.Orders.Update(result);
            _context.SaveChanges();

            return new DriverOrdersResultDto()
            {
                Success = true,
                Date =result.ClientRateDate,
                Info=result.ClientRateInfo,
                Rate= result.ClientRate,
                IdClient=result.UserId
            };
        }
        public async Task<DriverOrdersResultDto> ChangeOrderStatus(long idOrder, OrderStatus status)
        {
            Order result = await (from o in _context.Orders
                                  where o.Id == idOrder
                                  select o).SingleOrDefaultAsync();

            result.Status = status;
            result.EndTime = DateTime.Now;

            _context.Orders.Update(result);
            _context.SaveChanges();

            return new DriverOrdersResultDto()
            {
                Success = true,
                IdOrder = result.Id,
                Status =result.Status,
                EndTime = result.EndTime    
            };
        }


        public async Task<GetDriverOrderDetailsDto> GetDriverOrderDetails(long idOrder)
        {
            Order resultOrder = await (from o in _context.Orders
                                  where o.Id == idOrder
                                  select o).SingleOrDefaultAsync();

            User resultUser = _context.Users.Where(x => x.Id == resultOrder.UserId).SingleOrDefault();

            //zamowienia z ID klienta
            List<Order> ClientOrdersRateResult = _context.Orders.Where(x => x.UserId == resultUser.Id).Select(x => new Order()
            {
                 ClientRate= x.ClientRate
            }).ToList();

            //Srednia ocena

            double? Sum = 0;
            foreach (var item in ClientOrdersRateResult)
            {
                Sum += item.ClientRate;
            }
            double clientRate= (double)(Sum / ClientOrdersRateResult.Count());

            return new GetDriverOrderDetailsDto()
            {
                Success=true,

                CreationTime= resultOrder.CreationTime,
                StartLat = resultOrder.StartLat,
                StartLong =resultOrder.StartLong,
                EndLat = resultOrder.EndLat,
                EndLong= resultOrder.EndLong,
                Type = resultOrder.Type,
                LuggageType =resultOrder.LuggageType,
                Earnings = resultOrder.Cost,
                Status =resultOrder.Status,


                FirstName =resultUser.FirstName,
                LastName = resultUser.LastName,
                PhoneNumber=resultUser.PhoneNumber,
                Photo = resultUser.Photo,
                ClientRate = clientRate

            };
        }



    }
}
