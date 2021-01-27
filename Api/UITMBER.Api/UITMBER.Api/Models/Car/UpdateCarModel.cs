using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Models.Car
{
    public class UpdateCarModel
    {
        
            public long Id { get; set; }


            public long UserId { get; set; }
            public string Model { get; set; }
            public string Manufacturer { get; set; }
            public string PlateNo { get; set; }
            public string Photo { get; set; }
            public int Year { get; set; }
            public string Color { get; set; }

            

            public bool IsActive { get; set; }
        
    }
}
