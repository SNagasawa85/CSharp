class Ninja
{
    private int calorieIntake;
    public List<Food> FoodHistory;

    public Ninja()
    {
        calorieIntake = 0;
        FoodHistory = new List<Food>();
    }

    public void Eat(Food item)
    {
        if (IsFull == false)
        {
            calorieIntake += item.Calories;
            FoodHistory.Add(item);
            Console.WriteLine($"Ninja Ate:{item.Name}");
            if(item.IsSpicy == true)
            {
                Console.WriteLine($"{item.Name} is Spicy!");
            }
            if(item.IsSweet == true)
            {
                Console.WriteLine($"{item.Name} is Sweet!");
            }
        }
        else if (IsFull == true)
        {
            Console.WriteLine("WARNING!! You eat too much at buffet!  Go run to lose weight!");
        }
    }

    bool IsFull
    {
        get
        {
            return calorieIntake > 1200;
        }
    }

}