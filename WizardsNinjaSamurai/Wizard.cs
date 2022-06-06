public class Wizard : Human
{
    public Wizard(string name) : base(name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 25;
        Dexterity = 3;
        health = 50;
    }

        // Build Attack method
    public override int Attack(Human target)
    {
        int dmg = Intelligence * 5;
        target.health -= dmg;
        health += dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage! {Name} healed {dmg} health points.");
        return target.health;
    }

    public int Heal(Human target)
    {
        int heal = Intelligence * 10;
        target.health += heal;
        Console.WriteLine($"{Name} healed {target.Name} for {heal} points.");
        return target.health;
    }
    
}
