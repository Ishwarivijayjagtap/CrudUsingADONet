using System.ComponentModel.DataAnnotations;

namespace CrudUsingADONet.Models
{
    public class Student
    {
        [Key]
        public int RollNo { get; set; }
        [Required]
        [Display(Name = "Student Name")]
        public string? Name { get; set; }
        [Required]
     
        [Display(Name = "Student percentage")]
        public int Percentage { get; set; }
        [Display(Name = "Student Branch")]
        [Required]
        public string? Branch { get; set; }
    }

    
}

