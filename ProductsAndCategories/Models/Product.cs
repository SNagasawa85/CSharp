#pragma warning disable CS8618
namespace ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int ProductID {get; set;}
    
    [Required(ErrorMessage = "is required.")]
    public string Name {get; set;}

    [Required(ErrorMessage = "is required.")]
    public string Description {get;set;}
    [Required(ErrorMessage ="is required.")]
    public int Price {get; set;}
    public List<Association> Categories {get; set;} = new List<Association>();

}
