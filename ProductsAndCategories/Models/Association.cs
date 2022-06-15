#pragma warning disable CS8618
namespace ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
public class Association
{
    [Key]
    public int AssociationID {get; set;}

    public int CategoryID {get; set;}
    public int ProductID {get; set;}
    public Product Product {get; set;}
    public Category Category {get; set;}
}