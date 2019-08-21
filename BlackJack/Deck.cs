using System;


namespace BlackJack
{
    public struct Deck
    {
        public static int UsedCards;
        public static Card[] CreateDeck()
        {
            Card[] deck = new Card[36];

            for (int cardName = 0, index = 0; cardName <= 8; cardName++)
            {
                for (int cardSuit = 0; cardSuit <= 3; cardSuit++, index++)
                {
                    deck[index] = new Card((CardName)cardName, (Suit)cardSuit);
                }
            }
            return deck;
        }
        public static Card[] ShuffleDeck(Card[] deck)
        {
            Random random = new Random();

            for (int i = deck.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                Card temp = deck[j];
                deck[j] = deck[i];
                deck[i] = temp;
            }

            return deck;
        }
        public static void ShowDeck(Card[] deck)
        {
            foreach (Card c in deck)
            {
                Console.WriteLine($"{c.Name} {c.Suit} {c.Points}");
            }
        }
    }
}
