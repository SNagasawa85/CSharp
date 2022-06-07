class SpiceHound : Ninja
{
    public string Name;
    public SpiceHound(string name)
    {
        Name = name;
    }
    // provide override for IsFull (Full at 1200 Calories)

    public override bool IsFull
    {
        get
        {
            return calorieIntake > 1200;
        }
    }
    
    public override void Consume(IConsumable item)
    {
        if(IsFull == false)
        {
            calorieIntake += item.Calories;
            if(item.IsSpicy == true)
            {
                calorieIntake -= 5;
            }
            ConsumptionHistory.Add(item);
            Console.WriteLine(item.GetInfo());
        }
        if(IsFull == true)
        {
            Console.WriteLine($"{Name} is full!!! Stop Eating!!");
        }
    }
}