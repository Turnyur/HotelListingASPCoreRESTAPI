using AutoMapper;
using HotelListing.Data;
using HotelListing.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Configuration
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            //Country => CountryDTO
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();

            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();

            CreateMap<ApiUser, UserDTO>().ReverseMap();
            CreateMap<ApiUser, CreateUserDTO>().ReverseMap();
        }
    }
}
