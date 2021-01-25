using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Configuration;
using UITMBER.Api.Repositories.Cash;
using UITMBER.Api.Repositories.Cash.Dto;
using UITMBER.Api.Repositories.Drivers;
using UITMBER.Api.Repositories.Drivers.Dto;

namespace UITMBER.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CashController : ControllerBase
    {
        private readonly ICashRepository _cashRepository;
        private readonly AppSettings _appSettings;

        public CashController(ICashRepository driverRepository, AppSettings appSettings)
        {
            _cashRepository = driverRepository;
            _appSettings = appSettings;
        }

        [HttpGet]
        public async Task<ActionResult<CashDto>> GetUserSaldo(DateTime startDate, DateTime endDate)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            var result = await _cashRepository.GetMySaldo(startDate, endDate, userId);
            if (result.BadRequest == true)
            {
                return BadRequest("The user was not found or has no Orders");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet]
        public async Task<ActionResult<CashDto>> GetTaxistEarnings(DateTime startDate, DateTime endDate)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            var result = await _cashRepository.GetMyEarnings(startDate, endDate, userId);
            if (result.BadRequest == true)
            {
                return BadRequest("The taxist was not found or has no Orders");
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
