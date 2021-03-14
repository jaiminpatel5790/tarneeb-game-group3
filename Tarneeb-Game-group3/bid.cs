using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Cards;

namespace Tarneeb_Game_group3
{
    class Bid
    {
        public bool IsPass { get; private set; }
        public int Tricks { get; private set; }
        public char Suit { get; private set; }
        public Player Player { get; private set; }

        public static Bid CreateBid(Player player, int tricks, char suit)
        {
            Bid bid = new Bid()
            {
                IsPass = false,
                Player = player,
                Tricks = tricks,
                Suit = suit 
            };
            return bid;
        }

        public static Bid CreatePassBid(Player player)
        {
            Bid bid = new Bid()
            {
                IsPass = true,
                Player = player,
            };
            return bid;
        }

        public override string ToString()
        {
            if(IsPass)
            {
                return Player.ToString() + " - Pass.";
            }
            else
            {
                string suitString =
                    (Suit == (int) Enums.Suit.None) ? "No Trump" : Suit.ToString();
                return Player.ToString() + " " + Tricks + " " + suitString;
            }
        }

        public int CompareTo(Bid other)
        {
            if (this.Tricks != other.Tricks)
            {
                return this.Tricks.CompareTo(other.Tricks);
            }
            else
            {
                int thisSuitOrder = 4 - (int) this.Suit;
                int otherSuitOrder = 4 - (int) other.Suit;

                return thisSuitOrder.CompareTo(otherSuitOrder);
            }
        }

        //public static int MakeBid(List<Card> listOfCards)
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


        public static void GoNext(List<Player> listOfPlayer)
        {
            Random number = new Random();
            int SelectedIndex = number.Next(0, 4);
            Console.WriteLine(SelectedIndex);
            Player randomPlayer = listOfPlayer[SelectedIndex];
            ////Testing
            //Console.WriteLine("Random player " + randomPlayer);
            
            if(SelectedIndex == 0)
            {
                //player1
                CreateBid(randomPlayer, 5, 'S');
                SelectedIndex = 1;
                //player2
                randomPlayer = listOfPlayer[SelectedIndex];
                CreatePassBid(randomPlayer);
                SelectedIndex = 2;
                //player 3
                randomPlayer = listOfPlayer[SelectedIndex];
                CreateBid(randomPlayer, 2, 'C');
                SelectedIndex = 3;
                //player4
                randomPlayer = listOfPlayer[SelectedIndex];
                CreateBid(randomPlayer, 3, 'H');
                SelectedIndex = 0;
               
            }
            if (SelectedIndex == 1)
            {
                //player2
                randomPlayer = listOfPlayer[SelectedIndex];
                CreatePassBid(randomPlayer);
                SelectedIndex = 2;
                //player3
                randomPlayer = listOfPlayer[SelectedIndex];
                CreateBid(randomPlayer, 2, 'C');
                SelectedIndex = 3;
                //player4
                randomPlayer = listOfPlayer[SelectedIndex];
                CreateBid(randomPlayer, 3, 'H');
                SelectedIndex = 0;
                //player1
                randomPlayer = listOfPlayer[SelectedIndex];
                CreateBid(randomPlayer, 5, 'S');
                SelectedIndex = 1;
            }

            if (SelectedIndex == 2)
            {
                //player3
                randomPlayer = listOfPlayer[SelectedIndex];
                CreateBid(randomPlayer, 2, 'C');
                SelectedIndex = 3;
                //player4
                randomPlayer = listOfPlayer[SelectedIndex];
                CreateBid(randomPlayer, 3, 'H');
                SelectedIndex = 0;
                //player1
                randomPlayer = listOfPlayer[SelectedIndex];
                CreateBid(randomPlayer, 5, 'S');
                SelectedIndex = 1;
                //player2
                randomPlayer = listOfPlayer[SelectedIndex];
                CreatePassBid(randomPlayer);
                SelectedIndex = 2;

            }

            if (SelectedIndex == 3)
            {
                //player4
                randomPlayer = listOfPlayer[SelectedIndex];
                CreateBid(randomPlayer, 3, 'H');
                SelectedIndex = 0;
                //player1
                randomPlayer = listOfPlayer[SelectedIndex];
                CreateBid(randomPlayer, 5, 'S');
                SelectedIndex = 1;
                //player2
                randomPlayer = listOfPlayer[SelectedIndex];
                CreatePassBid(randomPlayer);
                SelectedIndex = 2;
                //player3
                randomPlayer = listOfPlayer[SelectedIndex];
                CreateBid(randomPlayer, 2, 'C');
                SelectedIndex = 3;
            }


        }
    }

}
