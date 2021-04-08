using System;
using Cards;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
//using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using CardDisplayTake3;

namespace Tarneeb_Game_group3
{
    //class Program 
    //{
    //        static void Main(string[] args)
    //        {
    //            var deck = new Deck();

    //            deck.Shuffle();
    //            List<Card> pass1 = deck.Sort(deck.TakeCards(13));
    //            deck.Shuffle();
    //            List<Card> pass2 = deck.Sort(deck.TakeCards(13));
    //            deck.Shuffle();
    //            List<Card> pass3 = deck.Sort(deck.TakeCards(13));
    //            deck.Shuffle();
    //            List<Card> pass4 = deck.Sort(deck.TakeCards(13));




    //            Console.WriteLine("Player 1 Cards:");
    //            Player player1 = new Player("Alaadin Addas", pass1);
    //            player1.playersCards.ForEach(Console.WriteLine);
    //            Console.WriteLine("_____________________________________");
    //            Console.WriteLine("Player 2 Cards:");
    //            Player player2 = new Player("John Doe", pass2);
    //            player2.playersCards.ForEach(Console.WriteLine);
    //            Console.WriteLine("_____________________________________");
    //            Console.WriteLine("Player 3 Cards:");
    //            Player player3 = new Player("Jane Doe", pass3);
    //            player3.playersCards.ForEach(Console.WriteLine);
    //            Console.WriteLine("_____________________________________");
    //            Console.WriteLine("Player 4 Cards:");
    //            Player player4 = new Player("Some Doe", pass4);
    //            player4.playersCards.ForEach(Console.WriteLine);

    //            Team FirstTeam = new Team(player1, player3);
    //            Team SecondTeam = new Team(player2, player4);

    //            List<Player> playerList = new List<Player>{player1, player2, player3, player4};


    //            List<Bid> newBid = new List<Bid>();
    //            Bid bid = new Bid();
    //            Bid Highestbidder;

    //            newBid = bid.GoNext(playerList);

    //            Highestbidder = bid.HigherBid(newBid);
    //            Console.WriteLine(Highestbidder.ToString());
    //            Console.WriteLine("Trump suit: " + Highestbidder.Suit);
    //            Console.WriteLine(Highestbidder.Player); 

    //            Card newCard = new Card();

    //           newCard.setTrump((Enums.Suit) Highestbidder.Suit);

    //           Console.WriteLine(newCard.Trump);


    //           List<Card> listOfCards = new List<Card>();

    //           Enums.Suit currentSuit = Enums.Suit.None;
    //           Enums.CardNumber currentCardNumber = 0;
    //           Player currentPlayer = null;

    //            //Player startingPlayer = Highestbidder.Player;

    //            Card player1Card = putCard(player1, newCard.Trump, currentSuit, currentCardNumber);
    //           Console.WriteLine("Player 1 puts: " + player1Card);

    //         currentSuit=  player1Card.Suit;
    //         currentCardNumber = player1Card.CardNumber;
    //         currentPlayer = player1;

    //         Console.WriteLine("Suit: " + currentSuit + " Card number: " + currentCardNumber + " player: " + currentPlayer);


    //            Card player2Card = putCard(player2, newCard.Trump, currentSuit, currentCardNumber);
    //            Console.WriteLine("PLayer 2 puts: " + player2Card);

    //            currentSuit = player2Card.Suit;
    //            currentCardNumber = player2Card.CardNumber;
    //            currentPlayer = player2;

    //            Console.WriteLine("Suit: " + currentSuit + " Card number: " + currentCardNumber + " player: " + currentPlayer);

    //            Card player3Card = putCard(player3, newCard.Trump, currentSuit, currentCardNumber);
    //            Console.WriteLine("PLayer 3 puts: " + player3Card);
    //            currentSuit = player3Card.Suit;
    //            currentCardNumber = player3Card.CardNumber;
    //            currentPlayer = player3;

    //            Console.WriteLine("Suit: " + currentSuit + " Card number: " + currentCardNumber + " player: " + currentPlayer);

    //            Card player4Card = putCard(player4, newCard.Trump, currentSuit, currentCardNumber);
    //            Console.WriteLine("PLayer 4 puts: " + player4Card);

    //            currentSuit = player4Card.Suit;
    //            currentCardNumber = player4Card.CardNumber;
    //            currentPlayer = player4;

    //            Console.WriteLine("Suit: " + currentSuit + " Card number: " + currentCardNumber + " player: " + currentPlayer);


    //            //listOfCards.Add(player1Card);
    //            //listOfCards.Add(player2Card);
    //            //listOfCards.Add(player3Card);
    //            //listOfCards.Add(player4Card);




    //            // Player startingPlayer = Highestbidder.Player;



    //        }



    //        public static Card putCard(Player player, Enums.Suit tarneebTrump, Enums.Suit suit, Enums.CardNumber cardNumber )
    //        {
    //            Card gamingCard = new Card();
    //            gamingCard = null;

    //            List<int> lowerCards = new List<int>();


    //            if ((cardNumber == 0) && (suit == Enums.Suit.None))
    //            {
    //                //if (gamingCard == null)
    //                //{
    //                    gamingCard = player.playersCards[0];
    //                    player.playersCards.Remove(player.playersCards[0]);
    //                //}

    //            }
    //            else
    //            {
    //                foreach (var card in player.playersCards)
    //                {
    //                    if (card.Suit == suit)
    //                    {

    //                        if (cardNumber < card.CardNumber)
    //                        {

    //                            gamingCard = card;
    //                            player.playersCards.Remove(card);
    //                            break;

    //                        }
    //                        else
    //                        {
    //                            int card_num = (int)card.CardNumber;
    //                            lowerCards.Add(card_num);
    //                           // player.playersCards.Remove(card);
    //                        }

    //                    }
    //                    else
    //                    {
    //                        Card lastCard = player.playersCards.Last();
    //                        gamingCard = lastCard;

    //                    }

    //                }
    //                if(lowerCards.Count > 1)
    //                {
    //                    int lowestCard = lowerCards.Min();
    //                    foreach (var card in player.playersCards)
    //                    {
    //                        if (card.Suit == suit && card.CardNumber == (Enums.CardNumber)lowestCard)
    //                        {
    //                            gamingCard = card;
    //                            player.playersCards.Remove(card);

    //                        }
    //                    }
    //                }


    //            }




    //            return gamingCard;
    //        }
    //        //public static Card GameLogic(List<Card> listOfCards)
    //        //{
    //        //    for (int i = 0; i <= listOfCards.Count; i++)
    //        //    {
    //        //        if (listOfCards[i].CardNumber == Enums.CardNumber.Ace)
    //        //        {
    //        //            listOfCards.Remove(listOfCards[i]);

    //        //            break;
    //        //        }
    //        //        return listOfCards[i];
    //        //    }

    //        //}
    //    }
}
