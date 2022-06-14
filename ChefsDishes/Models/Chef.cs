#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace ChefsDishes.Models;


public class Chef
{
    [Key]
    public int ChefId {get; set;}
    [Required(ErrorMessage = "is required.")]
    public string FirstName {get; set;}
    [Required(ErrorMessage = "is required.")]
    public string LastName {get; set;}
    [Required(ErrorMessage = "is required.")]
    [NoFuture]
    [Display(Name = "Date of birth")]
    public DateTime BirthDate {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
    public List<Dish> CreatedDishes {get; set;} = new List<Dish>();

}

public class Dish
{
    [Key]
    public int DishId {get; set;}

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Name of Dish:")]
    public string Name {get; set;}

    [Required(ErrorMessage = "is required.")]
    [Range(0, 9999, ErrorMessage = "must be between 1 and 10000.")]
    [Display(Name = "# of Calories:")]
    public int Calories {get; set;}

    [Required(ErrorMessage = "is required.")]
    public string Description {get; set;}
    public int Tastiness {get; set;}

    [Display(Name="Chef")]
    public int ChefId {get; set;} 
    public Chef? Creator { get; set;}
    [NotMapped]
    public List<Chef> AllChefs {get; set;} = new List<Chef>();
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
}


public class NoFutureAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        DateTime subDate = (DateTime)value;
        int compYear = DateTime.Now.Year - 18;
        DateTime compDate = new DateTime(compYear, DateTime.Now.Month, DateTime.Now.Day);
        if(subDate > compDate)
        {
            return new ValidationResult("Chef Must be at least 18 Years Old!");
        }
        return ValidationResult.Success;
    }
}