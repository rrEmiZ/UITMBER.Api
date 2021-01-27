using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UITMBER.Api.Configuration;
using UITMBER.Api.DataModels;
using UITMBER.Api.Extensions;
using UITMBER.Api.Models.Order;
using UITMBER.Api.Repositories.Orders;
using UITMBER.Api.Repositories.Orders.Dto;

namespace UITMBER.Api.Controllers
{

    /// <summary>
    /// Author : Kamilgolda, Karol Jarosz 60104
    /// Changes : jjonca
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly AppSettings _appSettings;

        public OrdersController(IOrderRepository orderRepository, AppSettings appSettings)
        {
            _orderRepository = orderRepository;
            _appSettings = appSettings;
        }


        [HttpGet]
        public Task<List<OrdersDto>> GetMyOrders()
        {
            return _orderRepository.GetMyOrders(this.UserId());
        }

        [HttpGet]
        public Task<List<OrdersDto>> GetCarTypes()
        {
            return _orderRepository.GetCarTypes(this.UserId());
        }

        [HttpGet]
        public Task<List<OrdersDto>> GetClientOrderDetails()
        {
            return _orderRepository.GetClientOrderDetails(this.UserId());
        }


        [HttpGet]
        public double GetCost(DateTime date, double distance)
        {
            var cost = (date.DayOfWeek >= DayOfWeek.Monday && date.DayOfWeek <= DayOfWeek.Friday) ? distance * _appSettings.CostMultiply : distance * (_appSettings.CostMultiply + 0.3);
            return cost;
        }

        [HttpPost]
        public async Task<IActionResult> OrderPayment(long orderid)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            try
            {

                var newPaymentResult = await _orderRepository.NewOrderPayment(orderid);

                if (!newPaymentResult.Success)
                {
                    return BadRequest(newPaymentResult.Error);
                }
                return Ok(newPaymentResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpPost]
        public async Task<IActionResult> OrderAccept([FromBody] OrderModel input)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            try
            {
                var newOrderResult = await _orderRepository.NewOrderAsync(userId,input.StartLat,input.StartLong,
                    input.EndLat, input.EndLong, input.Distance, input.Type, input.Cost, input.Status, input.PaymentType, input.LuggageType);

                if (!newOrderResult.Success)
                {
                    return BadRequest(newOrderResult.Error = "Bad request");
                }
                return Ok(newOrderResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> ClientRate(long idOrder, double driverRate, string info)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            try
            {
                var Result = await _orderRepository.ClientRate(idOrder, driverRate, info, userId);

                if (!Result.Success)
                {
                    return BadRequest(Result.Error = "Bad request");
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
