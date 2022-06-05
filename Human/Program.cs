// See https://aka.ms/new-console-template for more information
class Human
{
    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    public int Health;

    public string SetName(string NameVal)
    {
        Name = NameVal;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        Health = 100;
        return $"{NameVal} has been created!";
    }

    public void CreateCustom(string NameVal, int Str, int Intel, int Dex, int Health)
    {
        Name = NameVal;
        Strength = Str;
        Intelligence = Intel;
        Dexterity = Dex;
        Health = Health;
    }

    public int Attack(Human target)
    {
        int damage = Human.Strength * 5;
        target.Health -= damage;
        return target.Health;
    }

}


