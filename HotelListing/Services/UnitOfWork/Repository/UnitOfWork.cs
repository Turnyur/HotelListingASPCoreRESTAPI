using HotelListing.Data;
using HotelListing.Services.UnitOfWork.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Services.UnitOfWork.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed;
        private readonly AppDbContext _context;
        private ICountryRepository _countryRepository;
        private IHotelRepository _hotelRepository;

        public IHotelRepository hotelRepository => 
            (_hotelRepository)??=(IHotelRepository)new HotelRepository(_context);

        public ICountryRepository countryRepository =>
            (_countryRepository)??= (ICountryRepository)new CountryRepository(_context);

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                    disposed = true;
                }
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
