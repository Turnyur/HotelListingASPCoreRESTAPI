using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Configuration
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(m=>m.Id);
            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd();
            builder.Property(m => m.CreatedAt)
                .HasComputedColumnSql("GetDate()");

            Hotel[] hotels = new Hotel[]
           {
                new Hotel {Id=100, Name="Eko Hotel", Address="Victoria Island", Rating=5, CountryId=1 },
                new Hotel {Id=101, Name="Atlantic Hotel", Address="Lekki Phase 1", Rating=3, CountryId=1 },
                new Hotel {Id=102, Name="Kwame Nkrumah Hotel", Address="Kwame Nkra", Rating=4, CountryId=3 }
           };

            builder.HasData(hotels);
           
        }
    }
}
