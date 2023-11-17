using System.ComponentModel.DataAnnotations;

namespace TamposModelActivity.Models;

public enum Rank
{
    Instructor, AssistantProfessor, AssociateProfessor, Professor
}

public class Instructor
{
    [Required]
    public int Id { get; set; }
    
    [Display(Name = "First name")]
    public string? FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required")]
    [Display(Name = "Last name")]
    public string LastName { get; set; }
    
    [Display(Name = "Is tenured?")]
    public bool IsTenured { get; set; }
    
    [Required]
    [Display(Name = "Academic Rank")]
    public Rank Rank { get; set; }
    
    [RegularExpression("[0-9]{3}-[0-9]{3}-[0-9]{4}", ErrorMessage = "Format must be: 000-000-0000")]
    [Display(Name = "Office phone number")]
    public string? PhoneNumber { get; set; }
    
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string? EmailAddress { get; set; }
    
    [Url]
    [Display(Name = "Personal Webpage")]
    public string? PersonalURL { get; set; }
    
    [Required]
    [StringLength(10, MinimumLength = 5)]
    [Display(Name = "Password (Unused)")]
    [DataType(DataType.Password)]
    public string? UnusedPassword { get; set; }
    
    [Display(Name = "Hiring Date")]
    [DataType(DataType.Date)]
    public DateTime HiringDate { get; set; }
}