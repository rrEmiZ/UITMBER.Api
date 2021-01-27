using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Enums;
using UITMBER.Api.Repositories.Orders.Dto;

namespace UITMBER.Api.Repositories.Orders
{
   public interface IOrderRepository
    {

        Task<List<OrdersDto>> GetMyOrders(long userId);
        Task<List<OrdersDto>> GetCarTypes(long userId);
        Task<List<OrdersDto>> GetClientOrderDetails(long userId);
        public Task<NewOrderResultDto> NewOrderAsync(long userid, double startlat, double startlong, double endlat,
            double endlong, double distance, CarType type, double cost, OrderStatus status, PaymentType paymenttype, LuggageType luggagetype);
        public Task<NewOrderPaymentResultDto> NewOrderPayment(long orderId);
        public Task<ClientOrderResultDto> ClientRate(long idOrder, double driverRate, string info, int userid);
    }
}
