using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(m=>m.Id);
            builder.Property(m => m.CreatedAt)
                .HasComputedColumnSql("GetDate()");

            builder.Property(m => m.Name)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(m => m.ShortName)
                .IsUnicode(false)
                .HasMaxLength(3);

              builder.HasMany(m => m.Hotels)
               .WithOne(m => m.Country)
               .HasForeignKey(m=>m.CountryId);
            Country[] countries = new Country[]
            {
                new Country {Id=1, Name="Nigeria", ShortName="NG" },
                new Country {Id=2, Name="Ghana", ShortName="GH" },
                new Country {Id=3, Name="Germany", ShortName="DE" }
            };

            builder.HasData(countries);
            
        }
    }
}
