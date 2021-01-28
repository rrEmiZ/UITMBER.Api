using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.DriverOrders.Dto;

namespace UITMBER.Api.Repositories.DriverOrders
{
    public interface IDriverOrdersRepository
    {
        public Task<List<Order>> GetAvalilableOrders(double lattitude, double longitude);

        public Task<DriverOrdersResultDto> ProcessOrder(long id, long iddriver);

        public Task<ClientInfoResultDto> GetClientInfo(long id);
    }
}
