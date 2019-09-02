using System;

namespace BlackJack
{
    public struct Deck
    {
        public static int UsedCards;

        public static Card[] CreateDeck()
        {
            Card[] deck = new Card[36];

            for (int cardName= 2, index = 0; cardName <= 11; cardName++)
            {
                if (cardName == 5)
                {
                    continue;
                }

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

            UsedCards = 0;

            return deck;
        }
    }
}
