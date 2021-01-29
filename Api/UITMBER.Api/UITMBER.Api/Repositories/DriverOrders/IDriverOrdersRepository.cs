using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Enums;
using UITMBER.Api.Repositories.DriverOrders.Dto;

namespace UITMBER.Api.Repositories.DriverOrders
{
    public interface IDriverOrdersRepository
    {
        public Task<DriverOrdersResultDto> DriverRate(long IdOrder, string Info, double ClientRate);
        public Task<GetDriverOrderDetailsResultDto> GetDriverOrderDetails(long IdOrder);
        public Task<ChangeOrderStatusResultDto> ChangeOrderStatus(long idOrder, OrderStatus status);
    }
}
