using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.DataModels;
using UITMBER.Api.Enums;
using UITMBER.Api.Repositories.Drivers.Dto;
using UITMBER.Api.Repositories.Orders.Dto;

namespace UITMBER.Api.Repositories.Orders
{
    public class OrderRepository :IOrderRepository
    {
        private readonly UDbContext _context;

        public OrderRepository(UDbContext context)
        {
            _context = context;
        }

        public async Task<NewOrderPaymentResultDto> NewOrderPayment(long orderId)
        {
            var payment = await (from x in _context.Payments
                             where x.OrderId == orderId && x.IsPaid == true
                             select x).FirstOrDefaultAsync();
            
            if (payment==null)
            {
                 payment = new Payment()
                {
                    OrderId = orderId,
                    Order = await (from x in _context.Orders
                                   where x.Id == orderId
                                   select x).FirstOrDefaultAsync(),
                    IsPaid = true
                };


                await _context.Payments.AddAsync(payment);
                await _context.SaveChangesAsync();

                return new NewOrderPaymentResultDto()
                {
                    Success = true,
                    IsPaid = payment.IsPaid,
                    OrderId = payment.OrderId,
                    UserId = payment.Order.UserId,
                    paymentType = payment.Order.PaymentType
                };
            }
            else
            {
                return new NewOrderPaymentResultDto()
                {
                    Success = false,
                    Error = "Zapłacone"
                };
            }

            
        }
        


        public async Task<NewOrderResultDto> NewOrderAsync(long userid, double startlat, double startlong, double endlat,
            double endlong, double distance, CarType type, double cost, OrderStatus status, PaymentType paymenttype, LuggageType luggagetype )
        {
            
            var order = new Order()
            {
                UserId = userid,
                CreationTime = DateTime.Now,
                StartLat = startlat,
                StartLong = startlong,
                EndLat = endlat,
                EndLong = endlong,
                Distance = distance,
                Type = type,
                Cost = cost,
                Status = status,
                PaymentType = paymenttype,
                LuggageType = luggagetype,
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return new NewOrderResultDto()
            {
                Success = true,
                Status = order.Status
            };
        }

        public async Task<ClientOrderResultDto> ClientRate(long idOrder, double driverRate, string info, int userid)
        {
            Order result = await (from p in _context.Orders
                             where p.Id==idOrder && p.UserId==userid
                             select p).FirstOrDefaultAsync();
            if (result != null) { 
            result.DriverRateDate = DateTime.Now;
            result.DriverRateInfo = info;
            result.DriverRate = driverRate;

            _context.Orders.Update(result);
            await _context.SaveChangesAsync();

                return new ClientOrderResultDto()
                {
                    Success = true,
                    IdDriver = result.DriverId,
                    Rate = result.DriverRate,
                    Info = result.DriverRateInfo,
                    Date = result.DriverRateDate
                };
            }
            else
            {
                return new ClientOrderResultDto()
                {
                    Success = false
                };
            }
            
        }

        public async Task<List<OrdersDto>> GetMyOrders(long userId)
        {
            return await _context.Orders.Where(x => x.UserId == userId)
            .Select(x => new OrdersDto()
            {
                UserId = x.UserId,
                ClientRating = x.ClientRate,
                DriverRating = x.DriverRate,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                Photo = x.User.Photo,
                PhoneNumber = x.User.PhoneNumber

            }).ToListAsync();
        }

        public async Task<List<OrdersDto>> GetCarTypes(long userId)
        {
            return await _context.Cars.Where(x => x.UserId == userId)
                .Select(x => new OrdersDto()
                {
                    UserId = x.UserId,
                    Type = x.Type

                }).ToListAsync();
        }

        public async Task<List<OrdersDto>> GetClientOrderDetails(long userId)
        {
            return await _context.Orders.Where(x => x.UserId == userId)
                .Select(x => new OrdersDto()
                {
                    UserId = x.UserId,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Photo = x.User.Photo,
                    PhoneNumber = x.User.PhoneNumber,
                    StartLat = x.StartLat,
                    EndLat = x.EndLat,
                    StartLong = x.StartLong,
                    EndLong = x.EndLong,
                    Cost = x.Cost,
                    DriverRating = x.DriverRate


                }).ToListAsync();
        }
    }
}
