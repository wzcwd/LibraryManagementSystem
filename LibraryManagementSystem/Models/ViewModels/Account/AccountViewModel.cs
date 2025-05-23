using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.ViewModels.Account;

public class AccountViewModel
{
    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string Email { get; set; }
}