using System.ComponentModel.DataAnnotations;

namespace LoginRegistration.Models;

public class User 
{
    [Key]
    public int UserId {get; set;}
    [Required(ErrorMessage = "is Required.")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
    [Display(Name = "First Name")]
    public string FirstName {get; set;}

    [Required(ErrorMessage = "is Required.")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
    [Display(Name = "Last Name")]
    
    public string LastName {get; set;}

    [Required(ErrorMessage = "is Required.")]
    [EmailAddress(ErrorMessage = "must be a valid email.")]
    [Display(Name = "Email")]
    public string Email {get; set;}

    [Required(ErrorMessage = "is Required.")]
    [DataType(DataType.Password, ErrorMessage = "must be a valid password")]
    [Display(Name = "Password")]
    public string Password {get; set;}

    [Required(ErrorMessage = "is Required.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "must match password.")]
    [Display(Name = "Password confirmation")]
    public string ConfirmPassword {get; set;}
    public DateTime Created_at {get; set;} = DateTime.Now;
    public DateTime Updated_at {get; set;} = DateTime.Now;
}