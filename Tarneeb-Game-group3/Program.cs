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
            List<Card> pass2 = deck.Sort(deck.TakeCards(13));
            List<Card> pass3 = deck.Sort(deck.TakeCards(13));
            List<Card> pass4 = deck.Sort(deck.TakeCards(13));

            // Console.WriteLine(deck.MostCards(pass1));

            //static int MakeBid(List<Card> listOfCards)
            //{
            //    if (listOfCards[3].Suit == listOfCards[4].Suit)
            //    {
            //        if (listOfCards[4].Suit == listOfCards[5].Suit)
            //        {
            //            return 6;
            //        }
            //        else
            //        {
            //            return 5;
            //        }

            //    }
            //    else
            //    {
            //        return 4;
            //    }
            //}
           

            //if (trick2 == trick3)
            //{
            //    int higherBid = OptionalSum(trick1, trick2, pass1, pass2);
            //}


            


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
            //playerList.Add(player1);
            //playerList.Add(player2);
            //playerList.Add(player3);
            //playerList.Add(player4);

            //List<string> names = new List<string> { "One", "Two", "Three", "Four", "Five" }; 
            //for (int i = 0; i < names.Count; i++) 
            //{ Console.WriteLine("Names " + names[i]); }


            List<Bid> newBid = new List<Bid>();
            Bid bid = new Bid();
            Bid Highestbidder;

            newBid = bid.GoNext(playerList);

            Highestbidder = bid.HigherBid(newBid);
            Console.WriteLine(Highestbidder.ToString());
            Console.WriteLine("Trump suit: " + Highestbidder.Suit);

            //Console.WriteLine("Highest " + newBid.HigherBid(, trick2, trick3, trick4));

            // List<int> listOfTricks = new List<int>(trick1, trick2, trick3, trick4);
            //int higherBid = 0;

            //if (trick1 == trick2)
            //{
            //    higherBid = OptionalSum(trick1, trick2, pass1, pass2);
            //}

            //Console.WriteLine(higherBid);


            //Random number = new Random();
           
            //int BidPlayer = number.Next(1,4);
            //Console.WriteLine(BidPlayer);
            //Player randomPlayer = playerList[BidPlayer];
            ////Testing
            //Console.WriteLine("Random player " + randomPlayer);



           

            //Console.WriteLine(BidPlayer);
            //int counter = 0;

            //for(int i = BidPlayer; i <= 8; i++)
            //{
            //    int secondBid = number.Next(1, 5);
            //    //Player randomPlayer = playerList[BidPlayer];
            //    Console.WriteLine("Player " + playerList[secondBid]);

            //    Console.WriteLine(i);
            //    //if (i == 1)
            //    //{
            //    //    int num = 1;
            //    //    Object obj = num;
            //    //}
            //    if(BidPlayer < 4)
            //    {
            //        //Bid.CreateBid(player[BidPlayer], tricks, suit);
            //    }

            //    counter++;
            //    Console.WriteLine("Counter " + counter);

            //    if(counter == 4)
            //    {
            //        break;
            //    }
            //}




        }
    }
}
