using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Favourites.Dto;

namespace UITMBER.Api.Repositories.Favourites
{
    public interface IFavouritesRepository
    {
        Task<List<UserFavouriteLocation>> GetMyLocationsAsync(long userId);
        Task<bool> AddLocationAsync(LocationDto location);
        Task<bool> DeleteLocationAsync(long id);
    }
}
