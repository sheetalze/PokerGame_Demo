using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetalPokerGame_Demo
{
    class CardsPack : Card
    {
        private Card[] deck; 

        public CardsPack()
        {
            deck = new Card[52];
        }

        public Card[] getDeck { get { return deck; } } 
        
        public void createandShuffleCards()
        {
            int i = 0;
            foreach(SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach(VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    deck[i] = new Card { MySuit = s, MyValue = v };
                    i++;
                }
            }

            ShuffleCards();
        }

        //shuffle the deck
        public void ShuffleCards()
        {
            Random rand = new Random();
            Card temp;

            //run the shuffle 1000 times
            for (int shuffleTimes = 0; shuffleTimes < 1000; shuffleTimes++)
            {
                for (int i = 0; i < 52; i++)
                {
                    //swap the cards
                    int secondCardIndex = rand.Next(13);
                    temp = deck[i];
                    deck[i] = deck[secondCardIndex];
                    deck[secondCardIndex] = temp;
                }
            }
        }
    }
}
