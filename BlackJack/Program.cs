using System;

namespace BlackJack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Card[] deck = Deck.CreateDeck();
            Player player = new Player();
            Computer computer = new Computer();

            do
            {
                Deck.ShuffleDeck(deck);
                Deck.UsedCards = 0;
                player.TotalPoints = 0;
                computer.TotalPoints = 0;
                player.Hand = "";
                computer.Hand = "";
                Console.WriteLine("Who plays first? (Player/Computer)");
                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "player":
                        Deck.UsedCards = player.GetTwoCards(deck, Deck.UsedCards);

                        if (PointsProcessor.CheckAfterFirstTurn(ref player))
                        {
                            break;
                        }

                        Deck.UsedCards = computer.GetTwoCards(deck, Deck.UsedCards);
                        Deck.UsedCards = player.GetCard(deck, Deck.UsedCards, computer, true);
                        Deck.UsedCards = computer.GetCard(deck, Deck.UsedCards, player);
                        PointsProcessor.ChooseWinner(ref player,ref computer);
                        break;
                    case "computer":
                        Deck.UsedCards = computer.GetTwoCards(deck, Deck.UsedCards);

                        if (PointsProcessor.CheckAfterFirstTurn(ref computer))
                        {
                            break;
                        }

                        Deck.UsedCards = player.GetTwoCards(deck, Deck.UsedCards);
                        Deck.UsedCards = computer.GetCard(deck, Deck.UsedCards, player);
                        Deck.UsedCards = player.GetCard(deck, Deck.UsedCards, computer, false);
                        PointsProcessor.ChooseWinner(ref player,ref computer);
                        break;
                    default:
                        Console.WriteLine("Incorrect data");
                        break;
                }
                
            }
            while (ContinueGame(player, computer));
            Console.ReadLine();
        }

        public static bool ContinueGame(Player player, Computer computer)
        {
            Console.WriteLine("Start a new game? (Yes/No)");

            do
            {
                string command = Console.ReadLine();

                if (command.ToLower() == "yes")
                {
                    Console.Clear();
                    return true;
                }
                else if (command.ToLower() == "no")
                {

                    Console.WriteLine($"Total player wins: {player.Victory}");
                    Console.WriteLine($"Total computer wins: {computer.Victory}");
                    return false;
                }
                else
                {
                    Console.WriteLine("Incorrect data");
                }
            } while (true);
        }
    }
}

