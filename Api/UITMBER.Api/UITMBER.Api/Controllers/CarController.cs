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
    [ApiController]
    [Route("[controller]/[action]")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _CarRepository;

       
        public CarController(ICarRepository CarRepository)
        {
            _CarRepository = CarRepository;
        }


        [HttpGet]
        public  async Task<List<CarDto>> GetMyCars()
        {
   
                var GetMyCarsResult =  await _CarRepository.GetMyCarsAsync();
                return GetMyCarsResult;
            
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CarModel car)
        {
            try
            {
                var addResult = await _CarRepository.AddAsync(car);
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

                var UpdateResult = await _CarRepository.UpdateCarAsync(car);
                
                if (UpdateResult)
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

                var DeleteResult = await _CarRepository.DeleteAsync(id);

                if (DeleteResult)
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
