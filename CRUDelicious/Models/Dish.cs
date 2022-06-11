using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;

public class Dish
{
    [Key]
    public int DishId {get; set;}
    [Required(ErrorMessage ="A Name is required.")]
    public string Name {get; set;}
    [Required(ErrorMessage ="A Chef is required.")]
    public string Chef {get; set;}
    [Required(ErrorMessage ="A Tastiness is required.")]
    public int Tastiness {get; set;}
    [Required(ErrorMessage ="Calories must be above 0.")]
    [Range(0,9999)]
    public int Calories {get; set;}
    [Required(ErrorMessage ="A Description is required.")]
    public string Description {get; set;}
    public DateTime created_at {get; set;} = DateTime.Now;
    public DateTime updated_at {get; set;} = DateTime.Now;
}