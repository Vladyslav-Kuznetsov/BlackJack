using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                for (int cardSuit = 0; cardSuit <= 3; cardSuit++)
                {

                    deck[index] = new Card { Name = ((CardName)cardName), Suit = ((Suit)cardSuit) };
                    switch (deck[index].Name)
                    {
                        case CardName.Six:
                            deck[index].Points = 6;
                            break;
                        case CardName.Seven:
                            deck[index].Points = 7;
                            break;
                        case CardName.Eight:
                            deck[index].Points = 8;
                            break;
                        case CardName.Nine:
                            deck[index].Points = 9;
                            break;
                        case CardName.Ten:
                            deck[index].Points = 10;
                            break;
                        case CardName.Jack:
                            deck[index].Points = 2;
                            break;
                        case CardName.Queen:
                            deck[index].Points = 3;
                            break;
                        case CardName.King:
                            deck[index].Points = 4;
                            break;
                        case CardName.Ace:
                            deck[index].Points = 11;
                            break;
                    }
                    index++;
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
