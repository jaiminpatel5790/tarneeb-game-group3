using System;
using Cards;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Tarneeb_Game_group3
{
    class Program 
    {
        static void Main(string[] args)
        {
            var deck = new Deck();

            deck.Shuffle();
            List<Card> pass1 = deck.Sort(deck.TakeCards(13));
            deck.Shuffle();
            List<Card> pass2 = deck.Sort(deck.TakeCards(13));
            deck.Shuffle();
            List<Card> pass3 = deck.Sort(deck.TakeCards(13));
            deck.Shuffle();
            List<Card> pass4 = deck.Sort(deck.TakeCards(13));

            


            Console.WriteLine("Player 1 Cards:");
            Player player1 = new Player("Alaadin Addas", pass1);
            player1.playersCards.ForEach(Console.WriteLine);
            Console.WriteLine("_____________________________________");
            Console.WriteLine("Player 2 Cards:");
            Player player2 = new Player("John Doe", pass2);
            player2.playersCards.ForEach(Console.WriteLine);
            Console.WriteLine("_____________________________________");
            Console.WriteLine("Player 3 Cards:");
            Player player3 = new Player("Jane Doe", pass3);
            player3.playersCards.ForEach(Console.WriteLine);
            Console.WriteLine("_____________________________________");
            Console.WriteLine("Player 4 Cards:");
            Player player4 = new Player("Some Doe", pass4);
            player4.playersCards.ForEach(Console.WriteLine);

            Team FirstTeam = new Team(player1, player3);
            Team SecondTeam = new Team(player2, player4);

            List<Player> playerList = new List<Player>{player1, player2, player3, player4};
            

            List<Bid> newBid = new List<Bid>();
            Bid bid = new Bid();
            Bid Highestbidder;

            newBid = bid.GoNext(playerList);

            Highestbidder = bid.HigherBid(newBid);
            Console.WriteLine(Highestbidder.ToString());
            Console.WriteLine("Trump suit: " + Highestbidder.Suit);
            Console.WriteLine(Highestbidder.Player); 

            Card newCard = new Card();

           newCard.setTrump((Enums.Suit) Highestbidder.Suit);

           Console.WriteLine(newCard.Trump);

           Player startingPlayer = Highestbidder.Player;
           
        




        }

        public static Card GameLogic(List<Card> listOfCards)
        {
            for (int i = 0; i <= listOfCards.Count; i++)
            {
                if (listOfCards[i].CardNumber == Enums.CardNumber.Ace)
                {
                    listOfCards.Remove(listOfCards[i]);
                    
                    break;
                }
                return listOfCards[i];
            }
           
        }
    }
}
