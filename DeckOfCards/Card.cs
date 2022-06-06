class Card
{
    public string Name;
    public string Suit;
    public int Val;

    public Card(string suit, int val)
    {
        Suit = suit;
        Val = val;
        switch(val)
        {
            case 11: 
                Name = "Jack";
                break;
            case 12:
                Name = "Queen";
                break;
            case 13:
                Name = "King";
                break;
            case 1:
                Name = "Ace";
                break;
            default: 
                Name = val.ToString();
                break;
        }
    }

    public void PrintCard()
    {
        Console.WriteLine($"{Name} of {Suit} with value of {Val}");
    }

}