namespace ChefsDishes.Models;

public class DishWithChefs : Dish
{
    public List<Chef>? cheflist {get; set;}
}