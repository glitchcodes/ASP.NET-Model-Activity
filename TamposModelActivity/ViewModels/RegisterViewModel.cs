using System.ComponentModel.DataAnnotations;

namespace TamposModelActivity.ViewModels;

public class RegisterViewModel
{
    [Display(Name = "Username")]
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
    
    [Display(Name = "Confirm password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password confirmation is required")]
    // [Compare("Password")]
    public string ConfirmPassword { get; set; }
    
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }
    
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    
    [Display(Name = "Email Address")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email address is required")]
    public string? Email { get; set; }
    
    [RegularExpression("[0-9]{3}-[0-9]{3}-[0-9]{4}", ErrorMessage = "Format is 000-000-0000")]
    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }
}