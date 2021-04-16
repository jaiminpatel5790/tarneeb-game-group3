using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using CardDisplayTake3;
using Cards;

namespace Tarneeb_Game_group3
{
    /// <summary>
    /// Bid class will have all the attributes that will be needed when the player bids depending on their card. 
    /// </summary>
    class Bid
    {
        public bool IsPass { get; set; } // If the player bidded or not, if not then it will be true else it will false.
        public int Tricks { get; set; } // Number of tricks the bids 
        public char Suit { get; set; } // Suit the player chooses when they win.
        public Player Player { get; set; } // Player who bids

        /// <summary>
        /// This method will make the bid of the player who is being passed as in the parameter. It will check if the player wants to bid or not. 
        /// </summary>
        /// <param name="randomPlayer"> Is the player for which the bidding will be done</param>
        /// <returns> Bid object for that particular player</returns>
        public static Bid CreateBid(Player randomPlayer)
        {
            Bid bid1 = new Bid();

           
            //Computer Bid. This is only for the computer bid, human bid is not made here. 
            bid1 = randomPlayer.playersCards[0].Suit != randomPlayer.playersCards[1].Suit ? CreatePassBid(randomPlayer) : GameLogic.ComputerBid(randomPlayer);

            return bid1;
            
        }

        /// <summary>
        /// This method will pass the bid instead of placing one. 
        /// </summary>
        /// <param name="player"> Is the player for which we will pass the bid</param>
        /// <returns> The bid object for that player</returns>
        public static Bid CreatePassBid(Player player)
        {
            Bid bid = new Bid() // Bid object
            {
                IsPass = true,
                Player = player,
            };
            return bid;
        }

        /// <summary>
        /// This method will check whose bid is the highest among the 3 computer players, and we will also get a suit for that bid when we place it
        /// </summary>
        /// <param name="listOfBids"> Is the list containing all the bid objects for 3 computer players</param>
        /// <returns> The bid which was selected to be the highest</returns>
        public Bid HigherBid(List<Bid> listOfBids)
        {
            Bid highest = null;
            int sum1 = 0;
            int sum2 = 0;

            //Going through each bid and checking their tricks with next bid's trick. 
            for (int i = 0; i < listOfBids.Count -1; i++)
            {
                //Highest trick will be selected
                highest = listOfBids[i].Tricks > listOfBids[i + 1].Tricks ? listOfBids[i] : listOfBids[i + 1];

                // If both of their bids are same then we would sum the value of cards for how much they bid.
                if (listOfBids[i].Tricks == listOfBids[i + 1].Tricks) 
                { 
                    // Going through each card until the tricks they played and summing it
                    for (int j = 1; j < listOfBids[i].Tricks; j++)
                    {

                        sum1 += (int)(listOfBids[i].Player.playersCards[j].CardNumber + (int)listOfBids[i].Player.playersCards[j + 1].CardNumber);
                    }

                    // Going through each card until the tricks they played and summing it
                    for (int k = 1; k < listOfBids[i + 1].Tricks; k++)
                    {

                        sum2 += (int)(listOfBids[i + 1].Player.playersCards[k].CardNumber + (int)listOfBids[i + 1].Player.playersCards[k + 1].CardNumber);
                    }


                    highest = sum1 > sum2 ? listOfBids[i] : listOfBids[i + 1];
                }
            }
            return highest;
        }

        /// <summary>
        /// This method will start the process of bidding for computer players. It will selest random number from 1, 2, and 3 and then whoever comes first
        /// CreateBid method will be called on them. CreateBid method calls the computerBid method which is in the GameLogic class. 
        /// </summary>
        /// <param name="listOfPlayer"> List containing all the players object</param>
        /// <returns> The list of bids object of each player</returns>
        public  List<Bid> GoNext(List<Player> listOfPlayer)
        {
            //Random number selection
            Random number = new Random();
            int SelectedIndex = number.Next(0, 3);
            
            //Based on the random number random pplayer will be selected from the list using index
            Player randomPlayer = listOfPlayer[SelectedIndex];
          
            //Initializing list of bids which will be returned after each method call. Player 1 is always human player and that bid will be done in main class
            List<Bid> bidders = new List<Bid>();
         
            Bid player2Bid = new Bid();
            Bid player3Bid = new Bid();
            Bid player4Bid = new Bid();


            //If the 2nd player is selected i.e 1st in the list then the order of playing would be 2, 3 and 4
            if (SelectedIndex == 0)
            {
                
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

            //If the 3rd player is selected i.e 2nd in the list then the order of playing would be 3, 4 and 2
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

            //If the 4th player is selected i.e 3rd in the list then the order of playing would be 4, 2 and 3
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

            //Adding to the list of bids we made
            bidders.Add(player2Bid);
            bidders.Add(player3Bid);
            bidders.Add(player4Bid);

            return bidders;
            
        }

        /// <summary>
        /// To string will return the proper string displaying attributes for the bid object
        /// </summary>
        /// <returns> A string </returns>
        public override String ToString()
        {
            return "The Player is " + Player + " Tricks: " + Tricks  + " and suit is " + Suit.ToString();
        }
    }

}
