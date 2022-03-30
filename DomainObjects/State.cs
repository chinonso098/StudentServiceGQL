using System.ComponentModel.DataAnnotations;

namespace StudentServiceGQL.DomainObjects
{
    public class State
    {
        [Key]
        public int StateID { get; set; }

        public string Name { get; set; }
    }
}