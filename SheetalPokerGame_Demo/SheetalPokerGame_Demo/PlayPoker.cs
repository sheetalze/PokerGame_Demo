using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SheetalPokerGame_Demo
{
    class PlayPoker : CardsPack
    {
        private Card[] firstplayerHand;
        private Card[] secondplayerHand;
        private Card[] sortedfirstplayerHand;
        private Card[] sortedsecondplayerHand;

        public PlayPoker()
        {
            firstplayerHand = new Card[2];
            sortedfirstplayerHand = new Card[2];
            secondplayerHand = new Card[2];
            sortedsecondplayerHand = new Card[2];
        }

        public void Deal()
        {
            createandShuffleCards(); // method to create deck of card and shuffle them 
            getCardsFromdeck();
            sortCards();
            displayCards();
        }

        public void getCardsFromdeck()
        {
            //2 cards for the player
            for (int i = 0; i < 2; i++)
                firstplayerHand[i] = getDeck[i];

            //2 cards for the computer
            for (int i = 2; i < 4; i++)
                secondplayerHand[i -2] = getDeck[i];
        }

        public void sortCards()
        {
            var sortFirstPlayer = from hand in firstplayerHand
                              orderby hand.MyValue
                              select hand;

            var sortSecondPlayer = from hand in secondplayerHand
                                orderby hand.MyValue
                                select hand;

            var z = 0;
            foreach(var element in sortFirstPlayer.ToList())
            {
                sortedfirstplayerHand[z] = element;
                z++;
            }

            z = 0;
            foreach (var element in sortSecondPlayer.ToList())
            {
                sortedsecondplayerHand[z] = element;
                z++;
            }
        }

        public void displayCards()
        {
            Console.Clear();
            //display player hand
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("First Player's CARDS");
            Console.WriteLine("-----------------------");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(sortedfirstplayerHand[i].MyValue + " " + sortedfirstplayerHand[i].MySuit);   
            }
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Second Player's CARDS");
            Console.WriteLine("-----------------------");
            for (int i = 2; i < 4; i++)
            {
                Console.WriteLine(sortedsecondplayerHand[i - 2].MyValue + " " + sortedsecondplayerHand[i - 2].MySuit);
            }

        }

        public void calculateCardsValue(ref List<int> scoreValue)
        {
            PlayerCardsCalculator firstplayerScore = new PlayerCardsCalculator(sortedfirstplayerHand);
            PlayerCardsCalculator secondplayerScore = new PlayerCardsCalculator(sortedsecondplayerHand);

            //get both players cards output
            Hand firstplayerHand = firstplayerScore.EvaluateHand();
            Hand secondplayerHand = secondplayerScore.EvaluateHand();
            
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("\n\n\n\n\n First  Player's Hand: " + firstplayerHand);
            Console.WriteLine("\n Second Player's Hand: " + secondplayerHand);
            Console.WriteLine("---------------------------------------------------------");

            if (firstplayerHand > secondplayerHand)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("First Player wins in this round");
                scoreValue.Add(1);
            }
            else if (firstplayerHand < secondplayerHand)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("Second Player wins in this round!");
                scoreValue.Add(2);
            }
            else 
            {
                //checking based on each payer cards, who wins
                if (firstplayerScore.HandValues.Total > secondplayerScore.HandValues.Total)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("First Player wins in this round!");
                    scoreValue.Add(1);
                }
                else if (firstplayerScore.HandValues.Total < secondplayerScore.HandValues.Total)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Second Player wins in this round!");
                    scoreValue.Add(2);
                }
                // if both player have same then we will check higher number
                else if (firstplayerScore.HandValues.HighCard > secondplayerScore.HandValues.HighCard)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("First Player wins in this round!");
                    scoreValue.Add(1);
                }
                else if (firstplayerScore.HandValues.HighCard < secondplayerScore.HandValues.HighCard)
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Second Player wins in this round!");
                    scoreValue.Add(2);
                }
                else
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("DRAW, no one wins in this round!");
                    scoreValue.Add(0);
                }
            }
        }
        
    }
}
