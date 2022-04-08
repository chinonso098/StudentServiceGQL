
using StudentServiceGQL.DataService;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using StudentServiceGQL.DomainObjects;
using System;
using System.Linq;

namespace StudentServiceGQL.Repository{

    public class CollegeProgramRepository: IRepository<CollegeProgram>, IAsyncDisposable
    {
        private readonly StudentServiceContext _dbContext;

        public CollegeProgramRepository(IDbContextFactory<StudentServiceContext> dbContext){
            this._dbContext = dbContext.CreateDbContext();
        }

        public async Task<CollegeProgram> CreateEntityAsync(CollegeProgram entity)
        {
            await _dbContext.CollegePrograms.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteEntityAsync(int id)
        {
            var collegePrgm = await _dbContext.CollegePrograms.FindAsync(id);
             _dbContext.CollegePrograms.Remove(collegePrgm);
             await _dbContext.SaveChangesAsync();
        }

        public  ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public async Task<IQueryable<CollegeProgram>> GetEntitiesAsync()
        {
            var collegePrograms =  await _dbContext.CollegePrograms.ToListAsync();
            return collegePrograms.AsQueryable();
        }

        public async Task<CollegeProgram> GetEntityAsync(int id)
        {
           return await _dbContext.CollegePrograms.FindAsync(id);
        }

        public async Task UpdateEntityAsync(CollegeProgram entity)
        {
                var currentCollegePrgm = await _dbContext.CollegePrograms.FindAsync(entity.CollegeProgramID);
                currentCollegePrgm.ProgramName = entity.ProgramName;
                currentCollegePrgm.StartDate = entity.StartDate;
                currentCollegePrgm.EndDate = entity.EndDate;

                _dbContext.Entry(currentCollegePrgm).State = EntityState.Modified;

                try
                {
                    _dbContext.CollegePrograms.Update(currentCollegePrgm);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine("e" + e.Message);
                }
        }
    }
}