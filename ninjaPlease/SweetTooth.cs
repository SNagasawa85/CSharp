class SweetTooth : Ninja
{
    public string Name;
    public SweetTooth(string name) : base()
    {
        Name = name;
    }
    // provide override for IsFull (Full at 1500 Calories)
    public override bool IsFull
    {
        get
        {
            return calorieIntake > 1500;
        }
    }
    public override void Consume(IConsumable item)
    {
        if(IsFull == false)
        {
        calorieIntake += item.Calories;
            if(item.IsSweet == true){
                calorieIntake += 10;
            }
        ConsumptionHistory.Add(item);
        Console.WriteLine(item.GetInfo());
        }
        if(IsFull == true)
        {
            Console.WriteLine($"{Name} is Full!! Too Much Consumption");
        }
    }
}