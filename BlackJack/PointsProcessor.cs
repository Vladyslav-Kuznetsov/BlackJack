using System;

namespace BlackJack
{
    public struct PointsProcessor
    {
        public static bool CheckAfterFirstTurn (ref Player player)
        {
            if (player.TotalPoints == 21 || player.TotalPoints == 22)
            {
                player.Victory++;
                Console.WriteLine("You Win");
                return true;
            }

            return false;
        }

        public static bool CheckAfterFirstTurn(ref Computer computer)
        {
            if (computer.TotalPoints == 21 || computer.TotalPoints == 22)
            {
                computer.Victory++;
                Console.WriteLine("Computer Win");
                return true;
            }

            return false;
        }

        public static void ChooseWinner (ref Player player, ref Computer computer)
        {
            if (player.TotalPoints <= 21 && computer.TotalPoints > 21)
            {
                player.Victory++;
                Console.WriteLine("You Win");
            }

            if (computer.TotalPoints <= 21 && player.TotalPoints > 21)
            {
                computer.Victory++;
                Console.WriteLine("Computer Win");
            }

            if (player.TotalPoints > computer.TotalPoints && player.TotalPoints <= 21)
            {
                player.Victory++;
                Console.WriteLine("You Win");
            }

            if (computer.TotalPoints > player.TotalPoints && computer.TotalPoints <= 21)
            {
                computer.Victory++;
                Console.WriteLine("Computer Win");
            }

            if (player.TotalPoints > 21 && computer.TotalPoints > 21)
            {
                if (player.TotalPoints < computer.TotalPoints)
                {
                    player.Victory++;
                    Console.WriteLine("You Win");
                }
                else if (player.TotalPoints > computer.TotalPoints)
                {
                    computer.Victory++;
                    Console.WriteLine("Computer Win");
                }
            }
        }
    }
}
