using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.ViewModels.Account;

public class LoginViewModel
{

    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
    
    public string ReturnUrl { get; set; }
    
}