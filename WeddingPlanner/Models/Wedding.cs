namespace WeddingPlanner.Models;
using System.ComponentModel.DataAnnotations;

public class Wedding
{
    [Key]
    public int WeddingID {get; set;}
    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Wedder One")]
    public string WedderOne {get; set;}
    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Wedder Two")]
    public string WedderTwo {get; set;}
    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Wedding Date")]
    [NoPastDate]
    public DateTime WeddingDate {get; set;}
    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Wedding Address")]
    public string Address {get; set;}
    public int UserID {get; set;}
    public User? Creator {get; set;}
    public List<Association> Users {get; set;} = new List<Association>();

}

public class NoPastDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        DateTime subDate = (DateTime)value;
        if(subDate.Date < DateTime.Now.Date)
        {
            return new ValidationResult("You cannot choose a date that has past.");
        }
        return ValidationResult.Success;
    }
}