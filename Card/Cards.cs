using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace Cards

{
    public static class Enums
    {
        public enum Suit
        {
            None = 0,
            Club = 1,
            Diamond = 2,
            Heart = 3,
            Spades = 4
        }

        public enum CardNumber
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4,
            Six = 5,
            Seven = 6,
            Eight = 7,
            Nine = 8,
            Ten = 9,
            Jack = 10,
            Queen = 11,
            King = 12,
            Ace = 13
        }


    }
    public class Card
    {
        public Enums.Suit Suit { get; set; }

        public Enums.CardNumber CardNumber { get; set; }

        public Enums.Suit Trump { get; set; }

        
        public Enums.Suit setTrump(Enums.Suit TrumpSuit)
        {
            return this.Trump = TrumpSuit; 
        }
        //Overloading operator.
        public static bool operator >(Card card1, Card card2)
        {
            Card card = new Card();
            Boolean decision = false;
            if (card1.Suit == card.Trump)
            {
                return decision = true;
            }
            else if (card2.Suit == card.Trump)
            {
                return decision = false;
            }
            else if(card1.CardNumber > card2.CardNumber)
            {
                return decision = false;
            }
            return decision;
        }


        public static bool operator <(Card card1, Card card2)
        {
            if (card1.CardNumber < card2.CardNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override String ToString()
        {
            return "The suit is " + this.Suit + " The card number is " + this.CardNumber;
        }

    }

    public class Deck
    {
        public Deck()
        {
            Reset();
        }

        public List<Card> Cards { get; set; }

        public void Reset()
        {
            Cards = Enumerable.Range(1, 4).SelectMany(s => Enumerable.Range(1, 13).Select(c => new Card()
                    {
                        Suit = (Enums.Suit) s,
                        CardNumber = (Enums.CardNumber) c
                    }
                )
            ).ToList();
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
        }

        public Card TakeCard()
        {
            var card = Cards.FirstOrDefault();
            Cards.Remove(card);

            return card;
        }

        public List<Card> TakeCards(int numberOfCards)
        {
            var cards = Cards.Take(numberOfCards);

            var takeCards = cards as List<Card> ?? cards.ToList();
            Cards.RemoveAll(takeCards.Contains);
            return takeCards;
        }

        public List<Card> Sort(List<Card> listOfCards)
        {
            List<Card> sorted = listOfCards.GroupBy(s => s.Suit).
                OrderByDescending(c => c.Count()).SelectMany(g => g.OrderByDescending(c => c.CardNumber)).ToList();

            return sorted;

        }   

        
    }
}
