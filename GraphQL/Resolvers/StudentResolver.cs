
using HotChocolate;
using System.Linq;
using StudentServiceGQL.DomainObjects;
using StudentServiceGQL.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StudentServiceGQL.GraphQL.Resolvers
{
        public class StudentResolvers
        {
            public async Task<IQueryable<Address>> GetAddresses([Parent]Student student, [Service] IRepository<Address> addressRepository)
            {
            
                var result = await addressRepository.GetEntitiesAsync();
                return result.Where(x => x.StudentID == student.StudentID);
            }

            public async Task<IQueryable<CollegeProgram>> GetCollegeProgram([Parent]Student student, [Service] IRepository<CollegeProgram>  collegeProgramRepository)
            {
                var result = await collegeProgramRepository.GetEntitiesAsync();
                return result.Where(x => x.CollegeProgramID == student.CollegeProgramID);
            }
        }

}