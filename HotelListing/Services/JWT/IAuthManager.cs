using HotelListing.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Services.JWT
{
   public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO userDetails);

        Task<string> CreateToken();
    }
}
