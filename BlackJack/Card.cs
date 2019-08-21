namespace BlackJack
{
    public struct Card
    {
        public int Points;
        public CardName Name;
        public Suit Suit;

        public Card(CardName cardName, Suit suit)
        {
            Name = cardName;
            Suit = suit;

            switch(Name)
            {
                case CardName.Six:
                    Points = 6;
                    break;
                case CardName.Seven:
                    Points = 7;
                    break;
                case CardName.Eight:
                    Points = 8;
                    break;
                case CardName.Nine:
                    Points = 9;
                    break;
                case CardName.Ten:
                    Points = 10;
                    break;
                case CardName.Jack:
                    Points = 2;
                    break;
                case CardName.Queen:
                    Points = 3;
                    break;
                case CardName.King:
                    Points = 4;
                    break;
                case CardName.Ace:
                    Points = 11;
                    break;
                default:
                    Points = 0;
                    break;
            }
        }
    }
}
