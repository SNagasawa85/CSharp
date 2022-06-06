public class Ninja : Human
{
    public Ninja(string name) : base(name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 175;
        health = 100;        
    }

    public override int Attack(Human target)
    {
        int dmg = Dexterity * 5;
        Random rand = new Random();
        int extra = rand.Next(1,6);
        if(extra == 5){
            dmg += 10;
            Console.WriteLine($"{Name} Scored CRITICAL HIT for an extra 10 dmg!!");
        }
        target.health -= dmg;        
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.health;
    }

    public int Steal(Human target)
    {
        target.health -= 5;
        health += 5;
        Console.WriteLine($"{Name} stole 5 health points from {target.Name}!");
        return target.health;
    }

}