class Buffet 
{
    public List<IConsumable> Menu;

    public Buffet()
    {
        Menu = new List<IConsumable>()
        {
            new Food("Sushi", 200, true, false),
            new Food("Pizza", 400, false, true),
            new Food("Cake", 500, false, true),
            new Food("Noodles", 300, true, false),
            new Food("Rice", 400, false, false),
            new Food("General Tsao's Chicken", 600, true, true),
            new Food("Broccoli Beef", 650, false, true),
            new Food("Chow Mein", 450, false, true),
            new Food("Miso Soup", 180, false, true),
            new Food("Drunken Noodles", 750, true, false),
            new Drink("Mountian Dew", 500, false, true),
            new Drink("Coffee", 50, false, false),
            new Drink("Coke", 180, false, true),
            new Drink("Sprite", 130, false, true),
            new Drink("Ginger Tea", 60, false, true),
            new Drink("Hot Spicy Juice", 70, false, true)
        };
    }

    public IConsumable Serve()
    {
        Random rand = new Random();
        IConsumable entree = Menu[rand.Next(Menu.Count())];
        return entree;
    }

}
