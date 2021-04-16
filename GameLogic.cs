using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;
using Tarneeb_Game_group3;

namespace CardDisplayTake3
{
    /// <summary>
    /// This class is for computer logic
    /// </summary>
    class GameLogic
    {
       
        /// <summary>
        /// A function to put the card 
        /// </summary>
        /// <param name="player"> the player who will be putting the card</param>
        /// <param name="tarneebTrump"> is the tareeb suit for that game</param>
        /// <param name="suit"> is the suit that was put by previous player</param>
        /// <param name="cardNumber"> is the card number put by that player</param>
        /// <returns></returns>
        public static Card putCard(Player player, Enums.Suit tarneebTrump, Enums.Suit suit, Enums.CardNumber cardNumber)
        {
            Card gamingCard = new Card();
            gamingCard = null;

            List<int> lowerCards = new List<int>();
            

            if ((cardNumber == 0) && (suit == Enums.Suit.None))
            {
                
                gamingCard = player.playersCards[0];
                player.playersCards.Remove(player.playersCards[0]);
               

            }
            else
            {
                foreach (var card in player.playersCards)
                {
                    if (card.Suit == suit)
                    {

                        if (cardNumber < card.CardNumber)
                        {

                            gamingCard = card;
                            player.playersCards.Remove(card);
                            break;

                        }
                        else
                        { 
                            int card_num = (int)card.CardNumber;
                            lowerCards.Add(card_num);
                            
                        }

                    }
                    else
                    {
                        Card lastCard = player.playersCards.Last();
                        gamingCard = lastCard;

                    }

                }
                if (lowerCards.Count > 1)
                {
                    try
                    {

                        int lowestCard = lowerCards.Min();
                        foreach (var card in player.playersCards)
                        {
                            if (card.Suit == suit && card.CardNumber == (Enums.CardNumber) lowestCard)
                            {
                                gamingCard = card;
                                player.playersCards.Remove(card);

                            }
                        }
                    }
                    catch (Exception e)
                    {
                       Console.WriteLine(e);
                    }
                }


            }
            return gamingCard;
        }

        /// <summary>
        /// Checking highest card from the list of cards that are put by thr player
        /// </summary>
        /// <param name="listOfCards">Is the list which will be containing all the cads object</param>
        /// <param name="tarneebSuit">is the tarneeb suit</param>
        /// <returns></returns>
        public static Card HighestCard(List<Card> listOfCards, Enums.Suit tarneebSuit)
        {
            List<Card> sortedCards = new List<Card>();
            Card returningCard = new Card();

            foreach (var card in listOfCards)
            {
                if(card.Suit == tarneebSuit)
                {
                    sortedCards.Add(card);
                }
                
            }
            if(sortedCards.Count == 1)
            {
                returningCard = sortedCards[0];
            }
            else
            {
                for (int i = 0; i < sortedCards.Count - 1; i++)
                {
                    if (sortedCards[i].CardNumber > sortedCards[i + 1].CardNumber)
                    {
                        returningCard = sortedCards[i];
                    }
                    else
                    {
                        returningCard = sortedCards[i + 1];
                    }
                }

            }

            if (sortedCards.Count == 0)
            {
                for (int i = 0; i < listOfCards.Count - 1; i++)
                {
                    if (listOfCards[i].CardNumber > listOfCards[i + 1].CardNumber)
                    {
                        returningCard = listOfCards[i];
                    }
                    else
                    {
                        returningCard = listOfCards[i + 1];
                    }
                }
            }


            return returningCard;
        }

        /// <summary>
        /// This method will be called when the computer has to bid 
        /// </summary>
        /// <param name="player"> is the computer player</param>
        /// <returns></returns>
        public static Bid ComputerBid(Player player)
        {
            int tricks = 0;
            char suit = (char)player.playersCards[0].Suit;
            // Checking if suit of 4 th card matches with 5, if does then we will check furhter or else the bid will be 4
            if (player.playersCards[3].Suit == player.playersCards[4].Suit)
            {
                if (player.playersCards[4].Suit == player.playersCards[5].Suit)
                {
                    if (player.playersCards[5].Suit == player.playersCards[6].Suit)
                    {
                        tricks = player.playersCards[6].Suit == player.playersCards[8].Suit ? 8 : 7;
                    }
                    else
                    {
                        tricks = 6;
                    }


                }
                else
                {
                    tricks = 5;
                }

            }
            else
            {
                tricks = 4;
            }
            Bid bid = new Bid()
            {
                IsPass = false,
                Player = player,
                Tricks = tricks,
                Suit = suit
            };
            return bid;
        }

        
    }
}
