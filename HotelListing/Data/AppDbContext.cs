using HotelListing.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class AppDbContext:IdentityDbContext<ApiUser>
    {

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        public AppDbContext(DbContextOptions options): base(options)
        {



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());

            
        }
    }
}
