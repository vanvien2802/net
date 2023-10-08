using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentMVC.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Id{get; set;}
        [StringLength(100)]
        public string Name {get; set;} = null!;
        public int Age {get; set;}
        [StringLength(256)]
        public string Address {get; set;} = null!;
    }
}
