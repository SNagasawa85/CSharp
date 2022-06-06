class Buffet
{
    public List<Food> Menu;

    public Buffet()
    {
        Menu = new List<Food>()
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
            new Food("Drunken Noodles", 750, true, false)
        };
    }

    public Food Serve()
    {
        Random rand = new Random();
        Food entree = Menu[rand.Next(Menu.Count())];
        return entree;
    }

}
