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

        public async Task<List<Order>> GetAvalilableOrders(double lattitude, double longitude)
        {

            var Orders = await(from x in _context.Orders
                               where x.StartLat == lattitude && x.StartLong == longitude && x.Status == (OrderStatus)1
                               select x).ToListAsync();
            return Orders;
        }

        public async Task<ClientInfoResultDto> GetClientInfo(long id)
        {
            var Client = await(from x in _context.Users
                              where x.Id == id
                              select x).SingleOrDefaultAsync();
            return new ClientInfoResultDto()
            {
                Success = true,
                Id = Client.Id,
                Email = Client.Email,
                FirstName = Client.FirstName,
                LastName = Client.LastName,
                Photo = Client.Photo,
                PhoneNumber = Client.PhoneNumber,
                Lat = Client.Lat,
                Long = Client.Long

            };
        }

        public async Task<DriverOrdersResultDto> ProcessOrder(long id, long iddriver)
        {
            var Order = await(from x in _context.Orders
                         where x.Id == id
                         select x).SingleOrDefaultAsync();
            Order.DriverId = iddriver;
            Order.Status = (OrderStatus)2;
            _context.Orders.Update(Order);
            _context.SaveChanges();
            return new DriverOrdersResultDto() { 
                 Success = true,
                  Status = Order.Status,
                   idOrder = Order.Id
            };
        }
    }
}
