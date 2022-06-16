namespace WeddingPlanner.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User 
{
    [Key]
    public int UserID {get; set;}
    [Required(ErrorMessage ="is required.")]
    [Display(Name = "First Name")]
    public string FirstName {get; set;}
    [Required(ErrorMessage ="is required.")]
    [Display(Name = "Last Name")]
    public string LastName {get; set;}
    [Required(ErrorMessage ="is required.")]
    [EmailAddress]
    public string Email {get; set;}
    [Required(ErrorMessage ="is required.")]
    [MinLength(8, ErrorMessage = "ust be at least 8 characters")]
    [DataType(DataType.Password)]
    public string Password {get; set;}
    [Required]
    [NotMapped]
    [Compare("Password", ErrorMessage = "must match Password.")]
    [DataType(DataType.Password)]
    [Display(Name ="Re enter Password")]
    public string ConfirmPassword {get; set;}
    public List<Association> Weddings {get; set;} = new List<Association>();

}