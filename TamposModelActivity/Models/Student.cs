using System.ComponentModel.DataAnnotations;

namespace TamposModelActivity.Models;

public enum Course
{
    BSIT, BSCS, OTHER
}

public class Student
{
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "First name is required")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    
    [Required]
    [Display(Name = "GPA")]
    public double GPA { get; set; }
    
    [Required]
    [Display(Name = "Course")]
    public Course Course { get; set; }
    
    [Required]
    [Display(Name = "Admission Date")]
    public DateTime AdmissionDate { get; set; }
    
    [Required]
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
}