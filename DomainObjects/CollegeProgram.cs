using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentServiceGQL.DomainObjects
{
    public class CollegeProgram{
        [Key]
        public int CollegeProgramID {get; set;}
        [Required]
        public string ProgramName {get; set;}
        [Required]
        public DateTime StartDate {get; set;}
        [Required]
        public DateTime EndDate {get; set;}

    }
}