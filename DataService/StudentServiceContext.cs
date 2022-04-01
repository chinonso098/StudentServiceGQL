using Microsoft.EntityFrameworkCore;
using StudentServiceGQL.DomainObjects;
using System;



namespace StudentServiceGQL.DataService
{
    public class StudentServiceContext: DbContext
    {

        public DbSet<Student> Students { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<CollegeProgram> CollegePrograms { get; set; }

        public StudentServiceContext(DbContextOptions<StudentServiceContext> options) : base(options)
        {
            //...
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollegeProgram>().HasData(
                new CollegeProgram{ CollegeProgramID = 1, ProgramName = "Mathematics", StartDate = new DateTime(2020, 10, 03), EndDate = new DateTime(2084, 10, 03)},
                new CollegeProgram{ CollegeProgramID = 2, ProgramName = "Physics", StartDate = new DateTime(2020, 10, 03), EndDate = new DateTime(2084, 10, 03)},
                new CollegeProgram{ CollegeProgramID = 3, ProgramName = "Bio-Chemistry", StartDate = new DateTime(2020, 10, 03), EndDate = new DateTime(2084, 10, 03)},
                new CollegeProgram{ CollegeProgramID = 4, ProgramName = "Geology", StartDate = new DateTime(2020, 10, 03), EndDate = new DateTime(2084, 10, 03)});

           modelBuilder.Entity<Student>().HasData(
               new Student { StudentID = 1, FirstName = "Nicholas", LastName = "Gunn", Age = 38, StudentNumber = "9580389442", AdmissionDate = new DateTime(2020, 10, 03), DoB = new DateTime(1984, 10, 03), CollegeProgramID = 3 },
               new Student { StudentID = 2, FirstName = "Charles", LastName = "Freiderick", Age = 42, StudentNumber = "9580389442", AdmissionDate = new DateTime(2021, 11, 03), DoB = new DateTime(1979, 10, 03), CollegeProgramID = 2});

           modelBuilder.Entity<State>().HasData(
               new State { StateID = 1, Name = "New York", ShortName="NY" },
               new State { StateID = 2, Name = "California", ShortName ="CA" },
               new State { StateID = 3, Name = "Georgia", ShortName ="GA" },
               new State { StateID = 4, Name = "North Dakota", ShortName ="ND" },
               new State { StateID = 5, Name = "South Dakota", ShortName ="SD" },
               new State { StateID = 6, Name = "North Carolina", ShortName ="NC" },
               new State { StateID = 7, Name = "South Carolina", ShortName ="SC" },
               new State { StateID = 8, Name = "Indiana", ShortName ="IN" },
               new State { StateID = 9, Name = "Texas", ShortName ="TX" },
               new State { StateID = 10, Name = "Illinois", ShortName ="IL" });

           modelBuilder.Entity<Address>().HasData(
               new Address { AddressID = 1, StudentID = 1, StreetOne = "8564 Fresco Street", StreetTwo = String.Empty, City = "Polmero", StateID = 1, ZipCode = "96542", IsPrimary = true},
               new Address { AddressID = 3, StudentID = 1, StreetOne = "2346 Venture Rd", StreetTwo = String.Empty, City = "Fishers", StateID = 1, ZipCode = "96983", IsPrimary = false},
               new Address { AddressID = 2, StudentID = 2, StreetOne = "9621 Pinta Lane", StreetTwo = String.Empty, City = "Nina", StateID = 2, ZipCode = "52145", IsPrimary = true});
        }

    }
}