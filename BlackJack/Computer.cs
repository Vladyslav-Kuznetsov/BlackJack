using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public struct Computer
    {
        public int TotalPoints;
        public string Hand;
        public int Victory;
        public int GetTwoCards(Card[] deck, int usedCards)
        {
            int a = usedCards + 2;                       //Переименовать а
            for (int i = usedCards; i < a; i++)
            {
                TotalPoints += deck[i].Points;
                usedCards++;
                Hand += $"{deck[i].Name} {deck[i].Suit} ";
            }
           
            Console.WriteLine($"Comp card {Hand} Sum ({TotalPoints})");
            return usedCards;
        }
        public int GetCard(Card[] deck, int usedCards)
        {
            for (int i = usedCards; i < deck.Length; i++)
            {

                if (TotalPoints < 16)
                {
                    TotalPoints += deck[i].Points;
                    usedCards++;
                    Hand += $"{deck[i].Name} {deck[i].Suit} ";
                    Console.WriteLine($"Comp card {Hand} Sum ({TotalPoints})");
                    if (TotalPoints == 21)
                    {
                        Console.WriteLine("comp выиграл");
                        break;
                    }
                    else if (TotalPoints > 21)
                    {
                        Console.WriteLine("Комп перебрал");
                        break;
                    }
                }

            }
            return usedCards;
        }
    }
}
