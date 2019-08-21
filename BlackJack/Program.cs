using System;

namespace BlackJack
{
    enum Suits
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }
    enum Cards
    {
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
    struct Card
    {
        public int Points;
        public string Name;
        public string Suit;
    }
    struct Computer
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
                Console.WriteLine("comp выграл");
            }
            Console.WriteLine($"Comp card {Hand} Sum ({TotalPoints})");
            return usedCards;
        }
        public int GetCard(Card[] deck, int usedCards)
        {
            for (int i = usedCards; i < deck.Length; i++)
            {
                
                if (TotalPoints < 20)
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
        struct Player
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
        struct Deck
        {
            public static int UsedCards;
            public static Card[] CreateDeck()
            {
                Card[] deck = new Card[36];

                for (int cardName = 0, index = 0; cardName <= 8; cardName++)
                {
                    for (int cardSuit = 0; cardSuit <= 3; cardSuit++)
                    {

                        deck[index] = new Card { Name = ((Cards)cardName).ToString(), Suit = ((Suits)cardSuit).ToString() };
                        switch (deck[index].Name)
                        {
                            case "Six":
                                deck[index].Points = 6;
                                break;
                            case "Seven":
                                deck[index].Points = 7;
                                break;
                            case "Eight":
                                deck[index].Points = 8;
                                break;
                            case "Nine":
                                deck[index].Points = 9;
                                break;
                            case "Ten":
                                deck[index].Points = 10;
                                break;
                            case "Jack":
                                deck[index].Points = 2;
                                break;
                            case "Queen":
                                deck[index].Points = 3;
                                break;
                            case "King":
                                deck[index].Points = 4;
                                break;
                            case "Ace":
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
        class Program
        {
            static void Main(string[] args)
            {
                Card[] deck = Deck.CreateDeck();

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
}
