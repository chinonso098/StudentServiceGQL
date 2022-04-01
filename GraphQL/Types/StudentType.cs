using HotChocolate.Types;
using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using StudentServiceGQL.DomainObjects;
using StudentServiceGQL.DataService;

namespace StudentServiceGQL.GraphQL.Types{

    public class StudentType: ObjectType<Student>
    {
        protected override void Configure(IObjectTypeDescriptor<Student> descriptor)
        {
            descriptor.Description("Student model ");
            descriptor.Field(x => x.StudentID).Description("This represents the id from the database");
            descriptor.Field(x => x.FirstName).Description("Student's firstname");
            descriptor.Field(x => x.Addresses).Description("Student Address")
                        .ResolveWith<Resolvers>(x => x.GetAddresses(default!, default!))
                        .UseDbContext<StudentServiceContext>();
            descriptor.Field(x => x.CollegeProgram).Description("Currently enrolled program")
                        .ResolveWith<Resolvers>(x => x.GetCollegeProgram(default!, default!))
                        .UseDbContext<StudentServiceContext>();
        }


        private class Resolvers{

            public IQueryable<Address> GetAddresses([Parent]Student student, [ScopedService] StudentServiceContext dbContext){
            
                return dbContext.Addresses.Where(x => x.StudentID == student.StudentID);
            }

            public IQueryable<CollegeProgram> GetCollegeProgram([Parent]Student student, [ScopedService] StudentServiceContext dbContext){
            
                return dbContext.CollegePrograms.Where(x => x.CollegeProgramID == student.CollegeProgramID);
            }
        }
    }
}