namespace BlackJack
{
    public struct Card
    {
        public int Points;
        public CardName Name;
        public Suit Suit;

        public Card(int points, Suit suit)
        {
            Points = points;
            Suit = suit;
            Name = (CardName)Points;
        }
    }
}
