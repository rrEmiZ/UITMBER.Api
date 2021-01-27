using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Aplication.Dto;

namespace UITMBER.Api.Repositories.Aplication
{
    public class AplicationRepository : IAplicationRepository
    {
        private readonly UDbContext _dbContext;
        public AplicationRepository(UDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<UserApplication>> GetMyApplications(long userId)
        {

            try
            {
                var aplicationsList = await _dbContext.UserApplications.Select
                (x => new UserApplication()
                {
                    DriverLicencePhoto = x.DriverLicencePhoto,
                    UserId =x.UserId,
                    Date = x.Date,
                    DriverLicenceNo = x.DriverLicenceNo,
                    CarId = x.CarId,

                }).Where(u => u.UserId == userId).ToListAsync();

                return aplicationsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> SendApplication(AplicationDto ApDto)
        {
            UserApplication newAplication = new UserApplication()
            {
                DriverLicencePhoto = ApDto.DriverLicencePhoto,
                UserId = ApDto.UserId,
                Date = ApDto.Date,
                DriverLicenceNo = ApDto.DriverLicenceNo,
                CarId = ApDto.CarId,
                
            };

            await _dbContext.UserApplications.AddAsync(newAplication);
            return await _dbContext.SaveChangesAsync() > 0;

        }
    }
}
