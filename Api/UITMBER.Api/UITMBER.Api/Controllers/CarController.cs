using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;
using UITMBER.Api.Models.Car;
using UITMBER.Api.Repositories.Cars;
using UITMBER.Api.Repositories.Cars.Dto;

namespace UITMBER.Api.Controllers
{
    /// <summary>
    /// Author : MelchenkoIvan
    /// Changes : jjonca
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;


        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        [HttpGet]
        public async Task<List<CarDto>> GetMyCars()
        {
            //Added user verify
            var userId = Convert.ToInt64(User.FindFirst("UserId")?.Value);
            var GetMyCarsResult = await _carRepository.GetMyCarsAsync(userId);
            return GetMyCarsResult;

        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CarModel car)
        {
            try
            {
                var addResult = await _carRepository.AddAsync(car);
                if (addResult)
                {
                    return Ok("Car is criated");
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + "" + ex.InnerException);
            }

        }



        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCarModel car)
        {
            try
            {
                //Added user verify
                var userId = Convert.ToInt64(User.FindFirst("UserId")?.Value);
                var updateResult = await _carRepository.UpdateCarAsync(car, userId);

                if (updateResult)
                {
                    return Ok("Car is updated");
                }
                else
                {
                    return BadRequest();
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + "" + ex.InnerException);
            }

        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                //Added user verify
                var userId = Convert.ToInt64(User.FindFirst("UserId")?.Value);
                var deleteResult = await _carRepository.DeleteAsync(id, userId);

                if (deleteResult)
                {
                    return Accepted();
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + "" + ex.InnerException);
            }
        }
    }
}
