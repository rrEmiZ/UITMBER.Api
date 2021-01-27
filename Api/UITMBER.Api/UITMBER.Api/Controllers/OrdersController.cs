using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Configuration;
using UITMBER.Api.DataModels;
using UITMBER.Api.Enums;
using UITMBER.Api.Models.Order;
using UITMBER.Api.Repositories.Orders;
using UITMBER.Api.Repositories.Orders.Dto;

namespace UITMBER.Api.Controllers
{
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

        [HttpGet("{userId}")]
        public async Task<List<MyOrdersDto>> GetMyOrders(long userId)
        {
            try
            {
                var result = await _orderRepository.GetMyOrders(userId);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Cannot find data!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet]
        public List<string> GetCarTypes()
        {
            return Enum.GetNames(typeof(CarType)).ToList();

        }

        [HttpGet]
        public List<string> GetLuggageTypes()
        {
            return Enum.GetNames(typeof(LuggageType)).ToList();
        }

        [HttpGet("{OrderId}")]
        public async Task<OrderClientDetailsDto> GetClientOrderDetails(long OrderId)
        {
            try
            {
                var result = await _orderRepository.GetMyOrdersGetClientOrderDetails(OrderId);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Cannot find data!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
