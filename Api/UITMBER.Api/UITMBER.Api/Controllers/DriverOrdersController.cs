using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Configuration;
using UITMBER.Api.Enums;
using UITMBER.Api.Repositories.DriverOrders;

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

        public async Task<IActionResult> DriverRate(long IdOrder, string Info, double ClientRate)
        {
            try
            {
                var Result = await _ordersRepository.DriverRate(IdOrder, Info, ClientRate);

                if (!Result.Succes)
                {
                    return BadRequest(Result.Error = "Blad!");
                }
                return Ok(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public async Task<IActionResult> GetDriverOrderDetails(long IdOrder)
        {
            try
            {
                var Result = await _ordersRepository.GetDriverOrderDetails(IdOrder);

                if (!Result.Success)
                {
                    return BadRequest(Result.Error = "Blad!");
                }
                return Ok(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public async Task<IActionResult> ChangeOrderStatus(long idOrder, OrderStatus status)
        {
            try
            {
                var Result = await _ordersRepository.ChangeOrderStatus(idOrder, status);

                if (!Result.Success)
                {
                    return BadRequest(Result.Error = "Blad!");
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
