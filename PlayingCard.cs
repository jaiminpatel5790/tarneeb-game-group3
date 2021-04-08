using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CardDisplayTake3
{
    public class PlayingCard
    {


        #region ENUMS

        public enum Suits
        {
            Club = 1,
            Diamond = 2,
            Heart = 3,
            Spade = 4,
        }

        public enum CardNumber
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
        }

        #endregion




        

        public Guid ID { get; set; }
        public Suits cardSuit { get; set; }
        public CardNumber cardNumber { get; set; }
        public Boolean isFlipped { get; set; }
        public BitmapImage cardImage { get; set; }






        public PlayingCard(Suits suit, CardNumber card, Boolean isFlipped)
        {
            //Lets create some sort of ID to uniquely identify the cards.
            this.ID = Guid.NewGuid();
            //set card suit
            this.cardSuit = suit;
            //set card rank
            this.cardNumber = card;
            //set is flipped or not
            this.isFlipped = isFlipped;
            this.cardImage = GetCardImagePath(suit, card, isFlipped);





        }

        public PlayingCard(Suits suit, CardNumber card)
        {
            //Lets create some sort of ID to uniquely identify the cards.
            this.ID = Guid.NewGuid();
            //set card suit
            this.cardSuit = suit;
            //set card rank
            this.cardNumber = card;
            //set is flipped or not
            this.isFlipped = false;
            this.cardImage = GetCardImagePath(suit, card, isFlipped);





        }

        //no parameter constructor.
        public PlayingCard()
        {
        }

        /// <summary>
        /// Gets the image card path using the helper class method getimagepath
        /// </summary>
        //This method utilizes the Helper class method GetImage to get the path of the the image.
        //Uri absoluteUri = new Uri("pack://application:,,,/images/cards", UriKind.Absolute);
        public const string PLAYING_CARDS_PATH = "images\\cards";
        public BitmapImage GetCardImagePath(Suits suit, CardNumber card, Boolean isFlipped)
        {
            if (isFlipped == true)
            {

                return Helper.GetImage(PLAYING_CARDS_PATH + "\\back.bmp");
            }
            else
            {

                return Helper.GetImage(PLAYING_CARDS_PATH + "\\" + suit.ToString() + (int)card + ".png");
            }


        }

        public override string ToString()
        {
            return cardSuit.ToString() + (int)cardNumber + ".png";
        }



    }
}

