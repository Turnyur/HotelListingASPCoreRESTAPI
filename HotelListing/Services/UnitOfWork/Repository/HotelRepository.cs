using HotelListing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Services.UnitOfWork.Repository
{
    public class HotelRepository : GenericRepository<Hotel>
    {
        public HotelRepository(AppDbContext context) : base(context)
        {
        }
    }
}
