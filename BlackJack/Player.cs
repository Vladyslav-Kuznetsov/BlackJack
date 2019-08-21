using System;

namespace BlackJack
{
    public struct Player
    {
        public int TotalPoints;
        public string Hand;
        public int Victory;
        public int GetTwoCards(Card[] deck, int usedCards)
        {
            int a = usedCards + 2;   

            for (int i = usedCards; i < a; i++)
            {
                TotalPoints += deck[i].Points;
                usedCards++;
                Hand += $"{deck[i].Name} {deck[i].Suit}, ";
            }

            Console.WriteLine($"Your card {Hand} Sum ({TotalPoints})");
            return usedCards;
        }

        public int GetCard(Card[] deck, int usedCards, Computer computer, bool firstTurn)
        {
            if (!firstTurn && (computer.TotalPoints >= 21 || TotalPoints > computer.TotalPoints))
            {
                return usedCards;
            }

            for (int i = usedCards; i < deck.Length; i++)
            {
                if (TotalPoints >= 21 || (computer.TotalPoints < TotalPoints && computer.TotalPoints >= 21))
                {
                    return usedCards;
                }

                Console.WriteLine("One more card? (Yes/No)");
                string command = Console.ReadLine();

                if (command.ToLower() == "yes")
                {
                    TotalPoints += deck[i].Points;
                    usedCards++;
                    Hand += $"{deck[i].Name} {deck[i].Suit}, ";
                    Console.WriteLine($"Your card {Hand} Sum ({TotalPoints})");
                }
                else if (command.ToLower() == "no")
                {
                    Console.WriteLine($"Your card {Hand} Sum ({TotalPoints})");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect data");
                    break;
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
