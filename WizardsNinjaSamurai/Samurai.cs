public class Samurai : Human
{
    public Samurai(string name) : base(name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        health = 200;        
    }

    public override int Attack(Human target)
    {
        base.Attack(target);
        if(target.health < 50)
        {
            target.health = 0;
            Console.WriteLine($"{Name} has forced {target.Name} to commit sudoku.");
        }
        return target.health;
    }

    public int Meditate()
    {
        health = 200;
        Console.WriteLine($"{Name} has reached a state of Zen and is now magically full health... weird huh?");
        return health;
    }
}