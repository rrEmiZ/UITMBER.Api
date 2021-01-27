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

        public DriverOrdersController(IDriverOrdersRepository  driverOrdersRepository, AppSettings appSettings)
        {
            _ordersRepository = driverOrdersRepository;
            _appSettings = appSettings;
        }



        [HttpPut]
        public async Task<IActionResult> DriverRate(long idOrder, string info, double clientRate)
        {
            try
            {
                var Result = await _ordersRepository.DriverRate(idOrder, info, clientRate);

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

        [HttpGet]
        public async Task<IActionResult> GetDriverOrderDetails(long idOrder)
        {
            try
            {
                var Result = await _ordersRepository.GetDriverOrderDetails(idOrder);

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
        public async Task<IActionResult> ChangeOrderStatus(long idOrder, OrderStatus status)
        {
            try
            {
                var Result = await _ordersRepository.ChangeOrderStatus(idOrder,status);

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

