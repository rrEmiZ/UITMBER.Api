using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Repositories.Cars.Dto;

namespace UITMBER.Api.Repositories.Locations
{
    public interface ILocationRepository
    {
        bool SaveLocation(long id, double lat, double longitude);
    }
}
