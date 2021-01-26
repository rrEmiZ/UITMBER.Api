using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Repositories.Aplication.Dto
{
    public class AplicationDto
    {

        public long UserId { get; set; }

        public DateTime Date { get; set; }
        
        public string DriverLicenceNo { get; set; }
        public string DriverLicencePhoto { get; set; }

        public long CarId { get; set; }
    }
}
