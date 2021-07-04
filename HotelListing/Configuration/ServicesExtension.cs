using HotelListing.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Configuration
{
    public static class ServicesExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApiUser>(
                options => options.User.RequireUniqueEmail=true
                );

            builder = new IdentityBuilder(
                builder.UserType, typeof(IdentityRole), services
                );

            builder
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
