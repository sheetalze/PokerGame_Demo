using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetalPokerGame_Demo
{
    public enum Hand
    {
        Nothing,
        HighCard,
        OnePair,
        Straight,
        Flush,
        StraightFlush
    }

    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }

    class PlayerCardsCalculator : Card
    {
        private int hearts;
        private int diamond;
        private int club;
        private int spades;
        private Card[] cards;
        private HandValue handValue;

        public PlayerCardsCalculator(Card[] sortedHand)
        {
            hearts = 0;
            diamond = 0;
            club = 0;
            spades = 0;
            cards = new Card[2];
            Cards = sortedHand;
            handValue = new HandValue();
        }

        public HandValue HandValues
        {
            get { return handValue; }
            set { handValue = value; }
        }

        public Card [] Cards
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
            }
        }

        public Hand EvaluateHand()
        {
            getNumberOfSuit();
            
            if (StraightFlush())
                return Hand.StraightFlush;
            else if (Flush())
                return Hand.Flush;
            else if (Straight())
                return Hand.Straight;
            else if (OnePair())
                return Hand.OnePair;
            else if (HighCard())
                return Hand.HighCard;
            
            //if the hand is nothing, than the player with highest card wins
            handValue.HighCard = (int)cards[1].MyValue;
            return Hand.Nothing;
        }

        private void getNumberOfSuit()
        {
            foreach (var element in Cards)
            {
                if (element.MySuit == Card.SUIT.HEARTS)
                    hearts++;
                else if (element.MySuit == Card.SUIT.DIAMONDS)
                    diamond++;
                else if (element.MySuit == Card.SUIT.CLUBS)
                    club++;
                else if (element.MySuit == Card.SUIT.SPADES)
                    spades++;
            }
        }
        
        private bool StraightFlush()
        {
            if (Flush() && Straight())
            {
                return true;
            }
            return false;
        }

        private bool Flush()
        {
            //checking both card of same suit condition only
            if (hearts == 2 || diamond == 2 || club == 2 || spades == 2)
            {
                //if flush, the player with higher cards win
                //whoever has the last card the highest, has automatically all the cards total higher
                handValue.Total = (int)cards[1].MyValue;
                return true;
            }
            return false;
        }

        private bool Straight()
        {
            //checking for 2 cards of sequesntial rank condition only
            if (cards[0].MyValue + 1 == cards[1].MyValue)
            {
                //player with the highest value of the last card wins
                handValue.Total = (int)cards[1].MyValue;
                return true;
            }
            return false;
        }
        
        private bool OnePair()
        {
            if (cards[0].MyValue == cards[1].MyValue)
            {
                handValue.Total = (int)cards[0].MyValue * 2;
                handValue.HighCard = (int)cards[1].MyValue;
                return true;
            }
            return false;
        }

        private bool HighCard()
        {
            if (cards[0].MyValue != cards[1].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue;
                return true;
            }
            return false;
        }
    }
}
