using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Repositories.Discounts;

namespace UITMBER.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;


        public DiscountsController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Verify(string code)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            try
            {
                var VerifyResult = await _discountRepository.Verify(code);

                if (!VerifyResult.Success)
                {
                    return BadRequest(VerifyResult.Error = "Bad request");
                }
                return Ok(VerifyResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToOrder(string code, long idorder)
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            try
            {
                var Result = await _discountRepository.AddToOrder(code, idorder, userId);

                if (!Result.Success)
                {
                    return BadRequest(Result.Error = "Discount can't be added");
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
