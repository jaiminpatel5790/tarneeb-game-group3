﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using CardDisplayTake3;
using Cards;

namespace Tarneeb_Game_group3
{
    class Bid
    {
        public bool IsPass { get; set; }
        public int Tricks { get; set; }
        public char Suit { get; set; }
        public Player Player { get; set; }

        public static Bid CreateBid(Player randomPlayer)
        {
            Bid bid1 = new Bid();

           
            //Computer Bid
            bid1 = randomPlayer.playersCards[0].Suit != randomPlayer.playersCards[1].Suit ? CreatePassBid(randomPlayer) : GameLogic.ComputerBid(randomPlayer);

            return bid1;
            //Bid bid = new Bid()
            //{
            //    IsPass = false,
            //    Player = player,
            //    Tricks = tricks,
            //    Suit = suit
            //};
            //return bid;
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

       

        //public int CompareTo(Bid other)
        //{
        //    if (this.Tricks != other.Tricks)
        //    {
        //        return this.Tricks.CompareTo(other.Tricks);
        //    }
        //    else
        //    {
        //        int thisSuitOrder = 4 - (int) this.Suit;
        //        int otherSuitOrder = 4 - (int) other.Suit;

        //        return thisSuitOrder.CompareTo(otherSuitOrder);
        //    }
        //}

      

        
        public Bid HigherBid(List<Bid> listOfBids)
        {
            Bid highest = null;
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < listOfBids.Count -1; i++)
            {
                highest = listOfBids[i].Tricks > listOfBids[i + 1].Tricks ? listOfBids[i] : listOfBids[i + 1];
                if (listOfBids[i].Tricks == listOfBids[i + 1].Tricks) 
                { 
                    for (int j = 1; j < listOfBids[i].Tricks; j++)
                    {

                        sum1 += (int)(listOfBids[i].Player.playersCards[j].CardNumber + (int)listOfBids[i].Player.playersCards[j + 1].CardNumber);
                    }

                    for (int k = 1; k < listOfBids[i + 1].Tricks; k++)
                    {

                        sum2 += (int)(listOfBids[i + 1].Player.playersCards[k].CardNumber + (int)listOfBids[i + 1].Player.playersCards[k + 1].CardNumber);
                    }


                    highest = sum1 > sum2 ? listOfBids[i] : listOfBids[i + 1];
                }
            }
            return highest;
        }

       //public Bid FindBid(Player randomPlayer)
       //{
       //    Bid bid1 = new Bid();
           
       //     bid1 = randomPlayer.playersCards[0].Suit != randomPlayer.playersCards[1].Suit ? CreatePassBid(randomPlayer) : CreateBid(randomPlayer);

       //     return bid1;
       //}

       static int OptionalSum(int player1_trick, int player2_trick, List<Card> listOfCards1, List<Card> listOfCards2)
       {
           int sum1 = 0;
           int sum2 = 0;

           for (int i = 0; i < player1_trick; i++)
           {
               sum1 = (int)(listOfCards1[i].CardNumber + (int)listOfCards1[i + 1].CardNumber);
           }

           for (int i = 0; i < player2_trick; i++)
           {
               sum2 = (int)(listOfCards2[i].CardNumber + (int)listOfCards2[i + 1].CardNumber);
           }

           return sum1 > sum2 ? sum1 : sum2;

       }

        public  List<Bid> GoNext(List<Player> listOfPlayer)
        {
            Random number = new Random();
            int SelectedIndex = number.Next(0, 3);
            Console.WriteLine(SelectedIndex);
            Player randomPlayer = listOfPlayer[SelectedIndex];
          
            List<Bid> bidders = new List<Bid>();
         
            Bid player2Bid = new Bid();
            Bid player3Bid = new Bid();
            Bid player4Bid = new Bid();



            if (SelectedIndex == 0)
            {
                //player 1
                
                //player2
                randomPlayer = listOfPlayer[SelectedIndex];
                player2Bid = CreateBid(randomPlayer);
                SelectedIndex = 1;
                //player 3
                randomPlayer = listOfPlayer[SelectedIndex];
                player3Bid = CreateBid(randomPlayer);
                SelectedIndex = 2;
                //player4
                randomPlayer = listOfPlayer[SelectedIndex];
                player4Bid = CreateBid(randomPlayer);
                SelectedIndex = 0;

               
               
            }
            if (SelectedIndex == 1)
            {
                //player3
                randomPlayer = listOfPlayer[SelectedIndex];
                player3Bid = CreateBid(randomPlayer);
                SelectedIndex = 2;
                //player4
                randomPlayer = listOfPlayer[SelectedIndex];
                player4Bid = CreateBid(randomPlayer);
                SelectedIndex = 0;
                //player2
                randomPlayer = listOfPlayer[SelectedIndex];
                player2Bid = CreateBid(randomPlayer);
                SelectedIndex = 0;
               
               
              
            }

            if (SelectedIndex == 2)
            {
                //player4
                randomPlayer = listOfPlayer[SelectedIndex];
                player4Bid = CreateBid(randomPlayer);
                SelectedIndex = 0;
                //player2
                randomPlayer = listOfPlayer[SelectedIndex];
                player2Bid = CreateBid(randomPlayer);
                SelectedIndex = 1;
                //player3
                randomPlayer = listOfPlayer[SelectedIndex];
                player3Bid = CreateBid(randomPlayer);
                SelectedIndex = 3;
               
            }

          

            //bidders.Add(player1Bid);
            bidders.Add(player2Bid);
            bidders.Add(player3Bid);
            bidders.Add(player4Bid);

            return bidders;
            
        }

        public override String ToString()
        {
            return "The Player is " + Player + " Tricks: " + Tricks  + " and suit is " + Suit.ToString();
        }
    }

}
