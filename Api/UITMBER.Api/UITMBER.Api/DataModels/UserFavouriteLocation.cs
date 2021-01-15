using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.DataModels
{
    public class UserFavouriteLocation
    {
        public long Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public long UserId { get; set; }

        public double Lat { get; set; }
        public double Long { get; set; }
        public string Name { get; set; }

    }
}
