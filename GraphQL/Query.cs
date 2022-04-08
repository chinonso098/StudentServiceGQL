

using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using StudentServiceGQL.DomainObjects;
using StudentServiceGQL.Repository;

namespace StudentServiceGQL.GraphQL
{
   public class Query
   {
        public async Task<IEnumerable<Student>> GetStudents([Service] IRepository<Student> studentRepository)
        {
            var res = await studentRepository.GetEntitiesAsync();
            return res;
        }

    }
}