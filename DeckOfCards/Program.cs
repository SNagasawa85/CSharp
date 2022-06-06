
Deck NewCards = new Deck();
Player hank = new Player("Hank");

NewCards.Shuffle();

hank.Draw(NewCards);
hank.Draw(NewCards);
hank.Draw(NewCards);
hank.Draw(NewCards);

hank.Discard(3);
hank.Discard(5);
hank.ShowHand();
