
using StudentServiceGQL.DataService;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using StudentServiceGQL.DomainObjects;
using System;

namespace StudentServiceGQL.Repository{

    public class AddressRepository: IRepository<Address>, IAsyncDisposable
    {
        private readonly StudentServiceContext _dbContext;

        public AddressRepository(IDbContextFactory<StudentServiceContext> dbContext){
            this._dbContext = dbContext.CreateDbContext();
        }

        public async Task<Address> CreateEntityAsync(Address entity)
        {
            await _dbContext.Addresses.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteEntityAsync(int id)
        {
            var address = await _dbContext.Addresses.FindAsync(id);
             _dbContext.Addresses.Remove(address);
             await _dbContext.SaveChangesAsync();
        }

        public  ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public async Task<IQueryable<Address>> GetEntitiesAsync()
        {
            var address = await _dbContext.Addresses.ToListAsync();
            return address.AsQueryable();
        }

        public async Task<Address> GetEntityAsync(int id)
        {
           return await _dbContext.Addresses.FindAsync(id);
        }

        public async Task UpdateEntityAsync(Address entity)
        {
                var currentAddress = await _dbContext.Addresses.FindAsync(entity.AddressID);
                currentAddress.StreetOne = entity.StreetOne;
                currentAddress.StreetTwo = entity.StreetTwo;
                currentAddress.City = entity.City;
                currentAddress.StateID = entity.StateID;
                currentAddress.ZipCode = entity.ZipCode;

                _dbContext.Entry(currentAddress).State = EntityState.Modified;
                try
                {
                    _dbContext.Addresses.Update(currentAddress);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine("e" + e.Message);
                }
        }
    }
}