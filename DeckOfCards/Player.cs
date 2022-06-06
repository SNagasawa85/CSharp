class Player 
{
    public string Name;
    public List<Card> Hand = new List<Card>();

    public Player(string name)
    {
        Name = name;
    }

    public Card Draw(Deck draw)
    {
        Card drawCard = draw.Deal();
        Hand.Add(drawCard);
        Console.WriteLine(Hand.Count);
        return drawCard;
    }

    public Card Discard(int idx)
    {
        if(idx > Hand.Count){
            return null;
        }        
        Card DisCarded = Hand[idx];
        Hand.RemoveAt(idx);
        return DisCarded;        
    }

    public List<Card> ShowHand()
    {
        foreach(Card card in Hand){
            Console.Write(card.Name + " of " + card.Suit + ", ");
        }
        return Hand;
    }
}