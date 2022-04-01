using HotChocolate.Types;
using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using StudentServiceGQL.DomainObjects;
using StudentServiceGQL.DataService;

namespace StudentServiceGQL.GraphQL.Types{

    public class AddressType: ObjectType<Address>
    {
        protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
        {
            descriptor.Description("Address  Model ");
            descriptor.Field(x => x.AddressID);
            descriptor.Field(x => x.City);
            descriptor.Field(x => x.Student).Description("Student data linked to address")
                        .ResolveWith<Resolvers>(x => x.GetStudent(default!, default!))
                        .UseDbContext<StudentServiceContext>();
            descriptor.Field(x => x.State)
                        .ResolveWith<Resolvers>(x => x.GetStudent(default!, default!))
                        .UseDbContext<StudentServiceContext>();
        }

        private class Resolvers{

            public IQueryable<Student> GetStudent(Address address, [ScopedService] StudentServiceContext dbContext){
            
                return dbContext.Students.Where(x => x.StudentID == address.StudentID);
            }

            public IQueryable<State> GetState(Address address, [ScopedService] StudentServiceContext dbContext){
            
                return dbContext.States.Where(x => x.StateID == address.StateID);
            }
        }
    }
}