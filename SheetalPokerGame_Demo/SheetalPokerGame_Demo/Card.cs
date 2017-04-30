using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetalPokerGame_Demo
{
    class Card
    {
        public enum SUIT
        {
            DIAMONDS,
            HEARTS,
            CLUBS,
            SPADES
        }

        public enum VALUE
        {
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN,
            EIGHT,NINE, TEN, JACK, QUEEN, KING, ACE
        }
        
        //properties
        public SUIT MySuit { get; set; }
        public VALUE MyValue { get; set; }
    }
}
