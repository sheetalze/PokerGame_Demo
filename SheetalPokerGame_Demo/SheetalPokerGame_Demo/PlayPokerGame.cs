using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetalPokerGame_Demo
{
    class PlayPokerGame
    {
        static void Main(string[] args)
        {
            int totalRounds;
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("This Poker game is for two players");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("How many rounds you want to play?  Maximum 2-5 rounds are allowed");
            totalRounds = Convert.ToInt32(Console.ReadLine().ToUpper());

            //Console.WriteLine(totalRounds);
            int numberofrounds = 0;
            List<int> roundScore = new List<int>();
            PlayPoker dc = new PlayPoker();

            bool quit = false;

            if (totalRounds < 2 || totalRounds > 5)
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("Please enter correct number of rounds, maximum 2-5 rounds are allowed");
                Console.WriteLine("----------------------------------------------------------------------");
                quit = true;
            }
            if (!quit)
            {
                for (int r = 0; r < totalRounds; r++)
                {
                    Console.WriteLine("Poker Round:- ");
                    Console.WriteLine("-----------------");
                    dc.Deal();
                    dc.calculateCardsValue(ref roundScore);
                    Console.WriteLine("Continue to next round , pres any key");
                    Console.ReadKey();

                }

            }

            //we are checking which player will be the winner of final game
            if (roundScore != null && roundScore.Count > 0)
            {
                //roundScore.ForEach(i => Console.WriteLine("{0}\t", i));
                int player1Score = WinningOccurence(roundScore, 1);
                int player2Score = WinningOccurence(roundScore, 2);
                Console.WriteLine("---------------------------------------------------------");

                if (player1Score > player2Score)
                {
                    Console.WriteLine("Player 1 is winner of this game");
                }
                else if (player1Score < player2Score)
                {
                    Console.WriteLine("Player 2 is winner of this game");
                }
                else if (player1Score == player2Score)
                {
                    Console.WriteLine("It's a Tie !!");
                }

            }
            Console.ReadKey();
        }

        //this method will check which player is having more success rounds and who wins between 2 players
        static int WinningOccurence(List<int> scores, int player)
        {
            return ((from temp in scores where temp.Equals(player) select temp).Count());

        }
    }
}
