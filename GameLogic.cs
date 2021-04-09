using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;
using Tarneeb_Game_group3;

namespace CardDisplayTake3
{
    class GameLogic
    {
        public static Card putCard(Player player, Enums.Suit tarneebTrump, Enums.Suit suit, Enums.CardNumber cardNumber)
        {
            Card gamingCard = new Card();
            gamingCard = null;

            List<int> lowerCards = new List<int>();


            if ((cardNumber == 0) && (suit == Enums.Suit.None))
            {
                //if (gamingCard == null)
                //{
                gamingCard = player.playersCards[0];
                player.playersCards.Remove(player.playersCards[0]);
                //}

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
                            // player.playersCards.Remove(card);
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
                        // ignored
                    }
                }


            }
            return gamingCard;
        }

        public static Card HighestCard(List<Card> listofCards, Enums.Suit tarneebSuit)
        {
            List<Card> sortedCards = new List<Card>();
            Card returningCard = new Card();

            foreach (var card in listofCards)
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


            return returningCard;
        }

       
    }
}
