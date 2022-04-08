
using StudentServiceGQL.DataService;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using StudentServiceGQL.DomainObjects;
using System;
using System.Linq;

namespace StudentServiceGQL.Repository{

    public class StudentRepository: IRepository<Student>, IAsyncDisposable
    {
        private readonly StudentServiceContext _dbContext;

        public StudentRepository(IDbContextFactory<StudentServiceContext> dbContext){
            this._dbContext = dbContext.CreateDbContext();
        }

        public async Task<Student> CreateEntityAsync(Student entity)
        {
            await _dbContext.Students.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteEntityAsync(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
             _dbContext.Students.Remove(student);
             await _dbContext.SaveChangesAsync();
        }

        public  ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public async Task<IQueryable<Student>> GetEntitiesAsync()
        {
            var students =  await _dbContext.Students.ToListAsync();
            return students.AsQueryable();
        }

        public async Task<Student> GetEntityAsync(int id)
        {
           return await _dbContext.Students.FindAsync(id);
        }

        public async Task UpdateEntityAsync(Student entity)
        {
                var currentStudent = await _dbContext.Students.FindAsync(entity.StudentID);
                currentStudent.FirstName = entity.FirstName;
                currentStudent.LastName = entity.LastName;
                currentStudent.StudentNumber = entity.StudentNumber;
                currentStudent.Email = entity.Email;
                currentStudent.DoB = entity.DoB;
                currentStudent.AdmissionDate = entity.AdmissionDate;
                currentStudent.Age = entity.Age;

                _dbContext.Entry(currentStudent).State = EntityState.Modified;

                try
                {
                    _dbContext.Students.Update(currentStudent);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine("e" + e.Message);
                }
        }
    }
}