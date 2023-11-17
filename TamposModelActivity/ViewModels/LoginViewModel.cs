using System.ComponentModel.DataAnnotations;

namespace TamposModelActivity.ViewModels;

public class LoginViewModel
{
    [Display(Name = "Username")]
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
    
    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}