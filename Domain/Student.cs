using System.ComponentModel.DataAnnotations;

namespace Domain 
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }

}