using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentServiceGQL.DomainObjects
{
    public class State
    {
        [Key]
        public int StateID { get; set; }
        [Required]
        public string Name { get; set; }

        public string ShortName {get; set;}

    }
}