using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Configuration;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.DriverOrders;
using UITMBER.Api.Repositories.DriverOrders.Dto;

namespace UITMBER.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DriverOrdersController : ControllerBase
    {
        private readonly IDriverOrdersRepository _ordersRepository;
        private readonly AppSettings _appSettings;

        public DriverOrdersController(IDriverOrdersRepository driverOrdersRepository, AppSettings appSettings)
        {
            _ordersRepository = driverOrdersRepository;
            _appSettings = appSettings;
        }


        [HttpGet]
        public async Task<List<Order>> GetAvalilableOrders(double lattitude, double longitude) {
               return await _ordersRepository.GetAvalilableOrders(lattitude,longitude);
        }
        [HttpGet]
        public async Task<IActionResult> GetClientInfo(long id)
        {
            try
            {
                var Result = await _ordersRepository.GetClientInfo(id);

                if (!Result.Success)
                {
                    return BadRequest(Result.Error);
                }
                return Ok(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPut]
        public async Task<IActionResult> ProcessOrder(long id, long iddriver)
        {
            try
            {
                var Result = await _ordersRepository.ProcessOrder(id,iddriver);

                if (!Result.Success)
                {
                    return BadRequest(Result.Error);
                }
                return Ok(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
