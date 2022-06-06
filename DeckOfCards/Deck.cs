class Deck
{
    public List<Card> cards = new List<Card>();

    public Deck()
    {
        ResetDeck();
        Console.WriteLine(cards.Count);
    }

    public List<Card> ResetDeck()
    {
        cards.Clear();
        for(int i = 1; i<14; i++)
        {
            for(int j = 1; j<5; j++){
                if(j == 1){
                    cards.Add(new Card("Spades", i));
                }
                else if(j == 2){
                    cards.Add(new Card("Hearts", i));
                }
                else if(j == 3){
                    cards.Add(new Card("Diamonds", i));
                }
                else {
                    cards.Add(new Card("Clubs", i));
                }
            
            }
        }
        return cards;
    }

    public Card Deal()
    {
        Card dealt = cards[0];
        cards.RemoveAt(0);
        Console.WriteLine(cards.Count);
        return dealt;
    }

    public void Shuffle()
    {
        Random rand = new Random();
        List<Card> NewCards = new List<Card>();
        while (cards.Count > 0)
        {
            int idx = rand.Next(0,cards.Count);
            NewCards.Add(cards[idx]);
            cards.RemoveAt(idx);
        }
        cards = NewCards;
        foreach (Card card in cards)
        {
            Console.Write(card.Name + " of " + card.Suit + ", ");
        }
    }

}