using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;

namespace UITMBER.Api.Data
{
    public class UDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }
        public DbSet<UserFavouriteLocation> UserFavouriteLocations { get; set; }
        public DbSet<Car> Cars { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        public UDbContext(DbContextOptions<UDbContext> dbContextOptions) :base(dbContextOptions)
        {

        }
    }
}
    