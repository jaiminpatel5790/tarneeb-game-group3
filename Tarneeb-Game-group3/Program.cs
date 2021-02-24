using System;
using Cards;
using System.Collections.Generic;

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

            Team FirstTeam = new Team(player1, player2);
            Team SecondTeam = new Team(player3, player4);

            Random number = new Random();
            int BidPlayer = number.Next(1,4);
            Console.WriteLine(BidPlayer);
            int counter = 0;
            for(int i = BidPlayer; i <= 8; i++)
            {
                Console.WriteLine(i);
                if(BidPlayer < 4)
                {
                    //Bid.CreateBid(player[BidPlayer], tricks, suit);
                }

                counter++;
                if(counter == 4)
                {
                    break;
                }
            }



        }
    }
}
