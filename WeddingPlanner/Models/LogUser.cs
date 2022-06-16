namespace WeddingPlanner.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class LogUser
{
    [Required(ErrorMessage ="is required.")]
    [EmailAddress(ErrorMessage ="must be a valid email.")]
    public string LogEmail {get; set;}
    [Required(ErrorMessage ="is required.")]
    [DataType(DataType.Password)]
    public string LogPassword {get; set;}
}