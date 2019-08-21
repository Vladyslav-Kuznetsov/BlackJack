using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public struct Player
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
            if (TotalPoints == 21 || TotalPoints == 22)
            {
                Console.WriteLine("Ты выграл");
            }
            Console.WriteLine($"Your card {Hand} Sum ({TotalPoints})");
            return usedCards;
        }
        public int GetCard(Card[] deck, int usedCards)
        {
            for (int i = usedCards; i < deck.Length; i++)
            {
                Console.WriteLine("Хочешь взять карту? (Yes/No)");
                string command = Console.ReadLine();
                if (command.ToLower() == "yes")
                {
                    TotalPoints += deck[i].Points;
                    usedCards++;
                    Hand += $"{deck[i].Name} {deck[i].Suit} ";
                    Console.WriteLine($"Your card {Hand} Sum ({TotalPoints})");
                    if (TotalPoints == 21)
                    {
                        Console.WriteLine("Ты выиграл");
                        break;
                    }
                    else if (TotalPoints > 21)
                    {
                        Console.WriteLine("Ты проиграл");
                        break;
                    }
                }
                else if (command.ToLower() == "no")
                {
                    Console.WriteLine($"Your card {Hand} Sum ({TotalPoints})");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверніе данніе");
                    break;
                }
            }
            return usedCards;
        }

    }
}
