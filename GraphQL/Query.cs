
using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using StudentServiceGQL.DataService;
using StudentServiceGQL.DomainObjects;

namespace StudentServiceGQL.GraphQL
{
   public class Query
   {

        // private readonly StudentServiceContext _dbContext;

        // public Query(StudentServiceContext dbContext){
        //     this._dbContext = dbContext;
        // }
        
        [UseDbContext(typeof(StudentServiceContext))]
        [UseProjection]
        public IQueryable<Student> GetStudents([ScopedService] StudentServiceContext dbContext){
            
            return dbContext.Students;
        }


  
        [UseDbContext(typeof(StudentServiceContext))]
        [UseProjection]
        public IQueryable<State> GetStates([ScopedService] StudentServiceContext dbContext){
            
            return dbContext.States;
        }


        [UseDbContext(typeof(StudentServiceContext))]
        [UseProjection]
        public IQueryable<Address> GetAddress([ScopedService] StudentServiceContext dbContext){
            
            return dbContext.Addresses;
        }

    }
}