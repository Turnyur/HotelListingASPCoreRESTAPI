﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class ApiUser:IdentityUser
    {
        public int FirstName { get; set; }
        public int LastName { get; set; }
    }
}