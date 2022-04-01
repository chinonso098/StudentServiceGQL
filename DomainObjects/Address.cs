using System.ComponentModel.DataAnnotations;

namespace StudentServiceGQL.DomainObjects
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        [Required]
        public string StreetOne { get; set; }

        public string StreetTwo { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int StateID { get; set; }

        public State State { get; set; }

        public virtual int StudentID { get; set; }

        public virtual Student Student { get; set;}

        public string ZipCode { get; set; }

        public bool IsPrimary {get; set;}

    }
}