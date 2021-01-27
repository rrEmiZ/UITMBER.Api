using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Favourites.Dto;

namespace UITMBER.Api.Repositories.Favourites
{
    public class FavouritesRepository : IFavouritesRepository
    {
        private readonly UDbContext _context;

        public FavouritesRepository(UDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> AddLocationAsync(LocationDto location)
        {
            UserFavouriteLocation newLocation = new UserFavouriteLocation
            {
                UserId = location.UserId,

                Name = location.Name,
                Long = location.Long,
                Lat = location.Lat
            };

            await _context.UserFavouriteLocations.AddAsync(newLocation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteLocationAsync(long id)
        {
            var location = await _context.UserFavouriteLocations.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.UserFavouriteLocations.Remove(location);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<UserFavouriteLocation>> GetMyLocationsAsync(long userId)
        {
            try
            {
                var locationList = await _context.UserFavouriteLocations.Select
                (x => new UserFavouriteLocation()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Name = x.Name,
                    Lat = x.Lat,
                    Long = x.Long

                }).Where(u => u.UserId == userId).ToListAsync();

                return locationList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
