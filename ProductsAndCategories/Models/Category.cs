#pragma warning disable CS8618
namespace ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public int CategoryID {get; set;}

[Required(ErrorMessage ="is required.")]
    public string Name {get; set;}
    public List<Association> Products {get; set;} = new List<Association>();
    
}
