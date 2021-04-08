using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Windows.Media.Imaging;
using CardDisplayTake3;

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
            Spade = 4
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

        public Guid ID { get; set; }
        public Boolean isFlipped { get; set; }
        public BitmapImage cardImage { get; set; }

        public void setTrump(Enums.Suit TrumpSuit)
        {
            this.Trump = TrumpSuit;
        }

        public Card(Enums.Suit suit, Enums.CardNumber card, Boolean isFlipped)
        {
            //Lets create some sort of ID to uniquely identify the cards.
            this.ID = Guid.NewGuid();
            //set card suit
            this.Suit = suit;
            //set card rank
            this.CardNumber = card;
            //set is flipped or not
            this.isFlipped = isFlipped;
            this.cardImage = GetCardImagePath(suit, card, isFlipped);

        }

        public Card()
        {

        }

        public const string PLAYING_CARDS_PATH = @"/images/cards";
        public BitmapImage GetCardImagePath(Enums.Suit suit, Enums.CardNumber card, Boolean isFlipped)
        {
            if (isFlipped == true)
            {

                return Helper.GetImage(PLAYING_CARDS_PATH + "/back.bmp");
            }
            else
            {

                return Helper.GetImage(PLAYING_CARDS_PATH + "/" + suit.ToString() + (int)card + ".png");
            }


        }

        //Overloading operator.
        public static bool operator > (Card card1, Card card2)
        {
            Card card = new Card();
            Boolean decision = false;
            if (card1.Suit == card.Trump)
            {
                return decision = true;
            }
            if (card2.Suit == card.Trump)
            {
                return decision = true;
            }
            if (card1.Suit == card2.Suit)
            {
                if (card1.CardNumber > card2.CardNumber)
                {
                    decision = true;
                }
                else
                {
                    decision = false;
                }
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

    //public class Deck
    //{
    //    public Deck()
    //    {
    //        Reset();
    //    }

    //    public List<Card> Cards { get; set; }

    //    public void Reset()
    //    {
    //        Cards = Enumerable.Range(1, 4).SelectMany(s => Enumerable.Range(1, 13).Select(c => new Card()
    //                {
    //                    Suit = (Enums.Suit) s,
    //                    CardNumber = (Enums.CardNumber) c
    //                }
    //            )
    //        ).ToList();
    //    }

    //    public void Shuffle()
    //    {
    //        Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
    //    }

    //    public Card TakeCard()
    //    {
    //        var card = Cards.FirstOrDefault();
    //        Cards.Remove(card);

    //        return card;
    //    }

    //    public List<Card> TakeCards(int numberOfCards)
    //    {
    //        var cards = Cards.Take(numberOfCards);

    //        var takeCards = cards as List<Card> ?? cards.ToList();
    //        Cards.RemoveAll(takeCards.Contains);
    //        return takeCards;
    //    }

    //    public List<Card> Sort(List<Card> listOfCards)
    //    {
    //        List<Card> sorted = listOfCards.GroupBy(s => s.Suit).
    //            OrderByDescending(c => c.Count()).SelectMany(g => g.OrderByDescending(c => c.CardNumber)).ToList();

    //        return sorted;

    //    }   

        
    //}
}
