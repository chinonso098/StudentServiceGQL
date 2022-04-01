using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentServiceGQL.DomainObjects
{
    public class Student
    {
        [Key]
        public int StudentID {get; set;}

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        public string StudentNumber { get; set; }

        public string Email {get; set;}

        [Required]
        public DateTime DoB { get; set; }

        [Required]
        public DateTime AdmissionDate { get; set; }

        [Required]
        public int CollegeProgramID {get; set;}
        
        public CollegeProgram CollegeProgram { get; set; } 

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}