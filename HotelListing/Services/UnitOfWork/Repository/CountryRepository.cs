using HotelListing.Data;
using HotelListing.Services.UnitOfWork.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Services.UnitOfWork.Repository
{
    public class CountryRepository : GenericRepository<Country>, IGenericRepository<Country>
    {
        public CountryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
