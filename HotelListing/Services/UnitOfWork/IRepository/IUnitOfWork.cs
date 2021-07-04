using HotelListing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Services.UnitOfWork.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        /* IHotelRepository hotelRepository { get; }
           ICountryRepository countryRepository { get; }
         IGenericRepository<Country> genericRepository { get;  }
        */

        IGenericRepository<Country> countryRepository { get; }
        IGenericRepository<Hotel> hotelRepository { get; }

        Task Save();
    }
}
