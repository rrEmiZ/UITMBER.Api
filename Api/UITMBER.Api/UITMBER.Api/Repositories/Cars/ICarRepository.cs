using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;
using UITMBER.Api.Enums;
using UITMBER.Api.Models.Car;
using UITMBER.Api.Repositories.Cars.Dto;

namespace UITMBER.Api.Repositories.Cars
{
    public interface ICarRepository 
    {
        Task<List<CarDto>> GetMyCarsAsync();
        Task<bool> AddAsync(CarModel car);
        Task<bool> UpdateCarAsync(UpdateCarModel car);
        Task<bool> DeleteAsync(long id);
    }
}
