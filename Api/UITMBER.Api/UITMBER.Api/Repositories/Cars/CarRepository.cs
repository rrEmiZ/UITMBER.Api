using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.DataModels;
using UITMBER.Api.Enums;
using UITMBER.Api.Models.Car;
using UITMBER.Api.Repositories.Cars.Dto;

namespace UITMBER.Api.Repositories.Cars
{
    public class CarRepository : ICarRepository
    {
        private readonly UDbContext _context;

        public CarRepository(UDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(CarModel car)
        {
            var Caar = new Car
            {
                Id = car.Id,
                User = car.User,
                UserId = car.UserId,
                Model = car.Model,
                Manufacturer = car.Manufacturer,
                PlateNo = car.PlateNo,
                Photo = car.Photo,
                Year = car.Year,
                Color = car.Color,
                Type = car.Type,
                IsActive = car.IsActive

            };
            await _context.Cars.AddAsync(Caar);
            return await _context.SaveChangesAsync() > 0;
           
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var car = await _context.Cars.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Cars.Remove(car);
            return await _context.SaveChangesAsync() > 0;
            

        }

        public  Task<List<CarDto>> GetMyCarsAsync()
        {
            
            return  _context.Cars.Select(x => new CarDto()
            {
                Id = x.Id,
                User = x.User,
                UserId = x.UserId,
                Model = x.Model,
                Manufacturer = x.Manufacturer,
                PlateNo = x.PlateNo,
                Photo = x.Photo,
                Year = x.Year,
                Color = x.Color,
                Type = x.Type,
                IsActive = x.IsActive

            }).ToListAsync();
            
        }

        public async Task<bool> UpdateCarAsync(UpdateCarModel car)
        {
            
            var Caar = new Car
            {
                Id = car.Id,
                UserId = car.UserId,
                Model = car.Model,
                Manufacturer = car.Manufacturer,
                PlateNo = car.PlateNo,
                Photo = car.Photo,
                Year = car.Year,
                Color = car.Color,
                IsActive = car.IsActive

            };
            _context.Cars.Update(Caar) ;
            return await _context.SaveChangesAsync() > 0;

        }

    }
}
