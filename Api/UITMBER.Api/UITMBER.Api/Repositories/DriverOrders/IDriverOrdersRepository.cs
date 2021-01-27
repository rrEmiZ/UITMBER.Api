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
        public Task<DriverOrdersResultDto> DriverRate(long idOrder, string info, double clientRate);

        public Task<GetDriverOrderDetailsDto> GetDriverOrderDetails(long idOrder);
        
        public Task<DriverOrdersResultDto> ChangeOrderStatus(long idOrder, OrderStatus status);
    }
}
