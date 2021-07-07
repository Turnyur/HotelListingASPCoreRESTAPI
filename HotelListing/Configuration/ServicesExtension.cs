using HotelListing.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static void ConfigureJwt(this IServiceCollection services, 
            IConfiguration configuration)
        {
           var jwtSettings = configuration.GetSection("JwtSettings");

            //Gets Secret Key from System Environment variable
            //  string jwtKey= Environment.GetEnvironmentVariable("KEY");
            string jwtKey = jwtSettings.GetSection("SecretKey").Value;



            services.AddAuthentication(
                options =>
              {
                  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              }).AddJwtBearer(options =>
                    options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                        IssuerSigningKey = 
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    }); 


        }
    }
}
