using System;

namespace BlackJack
{
        class Program
        {
            static void Main(string[] args)
            {
                Card[] deck = Deck.CreateDeck();
            Deck.ShuffleDeck(deck);
            Deck.ShowDeck(deck);
                Player player = new Player();
                Computer computer = new Computer();
                bool gameOver = false;
                do
                {
                    Deck.ShuffleDeck(deck);
                    Deck.UsedCards = 0;
                    player.TotalPoints = 0;
                    computer.TotalPoints = 0;
                    player.Hand = "";
                    computer.Hand = "";
                    Console.WriteLine("Кто играет первый? (Player/Comp)");
                    string command = Console.ReadLine();
                    switch (command.ToLower())
                    {
                        case "player":
                            Deck.UsedCards = player.GetTwoCards(deck, Deck.UsedCards);
                            Deck.UsedCards = computer.GetTwoCards(deck, Deck.UsedCards);
                            Deck.UsedCards = player.GetCard(deck, Deck.UsedCards);
                            Deck.UsedCards = computer.GetCard(deck, Deck.UsedCards);
                            break;
                        case "comp":
                            Console.WriteLine(2);
                            break;
                    }

                }
                while (!gameOver);



                Deck.UsedCards = player.GetTwoCards(deck, Deck.UsedCards);

                Deck.UsedCards = player.GetCard(deck, Deck.UsedCards);


                Console.ReadLine();


            }

        }

    }

