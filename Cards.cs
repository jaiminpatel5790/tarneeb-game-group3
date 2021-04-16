using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Windows.Media.Imaging;
using CardDisplayTake3;

namespace Cards

{
    /// <summary>
    /// This is class name enums which will hold 2 enum for Suit and cardnumber
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// Enum for suit
        /// </summary>
        public enum Suit
        {
            None = 0,
            Club = 1,
            Diamond = 2,
            Heart = 3,
            Spade = 4
        }

        /// <summary>
        /// Enum for Card Number
        /// 
        /// </summary>
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

    /// <summary>
    /// Starting of the card class which will be making card objects 
    /// </summary>
    public class Card
    {
        public Enums.Suit Suit { get; set; } // Suit of the card from enum Suit of Enums class

        public Enums.CardNumber
            CardNumber { get; set; } // Card number of the card from the enum cardnumber of enums class

        public Enums.Suit
            Trump
        {
            get;
            set;
        } //Trump is the tarneeb suit which will be selected for the card when highest bidder selects the trump

        public Guid ID { get; set; } // This is the ID which will be used for getting image path
        public Boolean isFlipped { get; set; } // Checking if the card is flipped or not
        public BitmapImage cardImage { get; set; } // Getting card image.

        /// <summary>
        /// Setting up trump suit 
        /// </summary>
        /// <param name="TrumpSuit"> trumpsuit is the suit which will be defined</param>
        public void setTrump(Enums.Suit TrumpSuit)
        {
            this.Trump = TrumpSuit;
        }

        /// <summary>
        /// Constructor for card class
        /// </summary>
        /// <param name="suit"> suit of the card </param>
        /// <param name="card"> CardNumber of the card</param>
        /// <param name="isFlipped"> Checking if the card isFlipped or not</param>
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

        /// <summary>
        /// Default constructor for card class
        /// </summary>
        public Card()
        {

        }

        // String path shoowing to get the card images from
        public const string PLAYING_CARDS_PATH = @"/images/cards";

        /// <summary>
        /// Getting card image path for particular card object
        /// </summary>
        /// <param name="suit"> suit of the card from object</param>
        /// <param name="card"> card number of the card from object</param>
        /// <param name="isFlipped"> checking if the card was flipped or not</param>
        /// <returns> Bitmap image for that source path</returns>
        public BitmapImage GetCardImagePath(Enums.Suit suit, Enums.CardNumber card, Boolean isFlipped)
        {
            if (isFlipped == true)
            {

                return Helper.GetImage(PLAYING_CARDS_PATH + "/back.bmp");
            }
            else
            {

                return Helper.GetImage(PLAYING_CARDS_PATH + "/" + suit.ToString() + (int) card + ".png");
            }


        }

        //Overloading operator.
        /// <summary>
        /// Checking which card greater from card1 and card2
        /// </summary>
        /// <param name="card1"> card object 1</param>
        /// <param name="card2"> card object 2</param>
        /// <returns> Boolean if the condition if true or false.</returns>
        public static bool operator >(Card card1, Card card2)
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


        /// <summary>
        /// Checking which card greater from card1 and card2
        /// </summary>
        /// <param name="card1"> card object 1</param>
        /// <param name="card2"> card object 2</param>
        /// <returns> Boolean if the condition if true or false.</returns>
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

        /// <summary>
        /// Override string for card object
        /// </summary>
        /// <returns> the string displaying card objects value</returns>
        public override String ToString()
        {
            return "The suit is " + this.Suit + " The card number is " + this.CardNumber;
        }

    }

}
