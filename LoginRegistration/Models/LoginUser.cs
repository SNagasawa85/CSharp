namespace LoginRegistration.Models;
using System.ComponentModel.DataAnnotations;

public class LoginUser
{
    [Required(ErrorMessage ="is Required.")]
    [EmailAddress(ErrorMessage ="must be valid email address.")]
    public string emailSub {get; set;}
    
    [Required(ErrorMessage ="is Required.")]
    [DataType(DataType.Password, ErrorMessage ="must be valid email address.")]
    public string passwordSub {get; set;}

}