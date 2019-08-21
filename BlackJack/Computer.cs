using System;

namespace BlackJack
{
    public struct Computer
    {
        public int TotalPoints;
        public string Hand;
        public int Victory;

        public int GetTwoCards(Card[] deck, int usedCards)
        {
            int cardsToGet = usedCards + 2;   
            
            for (int i = usedCards; i < cardsToGet; i++)
            {
                TotalPoints += deck[i].Points;
                usedCards++;
                Hand += $"{deck[i].Name} {deck[i].Suit}, ";
            }
           
            Console.WriteLine($"Computer card {Hand} Sum ({TotalPoints})");
            return usedCards;
        }

        public int GetCard(Card[] deck, int usedCards, Player player)
        {
            for (int i = usedCards; i < deck.Length; i++)
            {
                if (player.TotalPoints < 21 && TotalPoints < 16)
                {
                    TotalPoints += deck[i].Points;
                    usedCards++;
                    Hand += $"{deck[i].Name} {deck[i].Suit}, ";
                    Console.WriteLine($"Computer card {Hand} Sum ({TotalPoints})");
                }
            }

            return usedCards;
        }

        public void Clear()
        {
            TotalPoints = 0;
            Hand = string.Empty;
        }
    }
}
