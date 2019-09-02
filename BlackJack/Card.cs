namespace BlackJack
{
    public struct Card
    {
        public int Points;
        public CardName Name;
        public Suit Suit;

        public Card(CardName cardName, Suit suit)
        {
            Suit = suit;
            Name = cardName;
            Points = (int)cardName;
        }
    }
}
