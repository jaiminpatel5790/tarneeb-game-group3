using System;
using System.Collections.Generic;
using System.Text;
using Cards;

namespace Tarneeb_Game_group3
{
    /// <summary>
    /// This is the player class which we will be using to create player objects
    /// </summary>
    class Player
    {
        //A string to hold the name of the player
        public string name { get; set; }

        // A list of cards to hold the player's card
        public List<Card> playersCards = new List<Card>();

        /// <summary>
        /// A contructor to intantiate the player object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="playersCards"></param>
        public Player(string name, List<Card> playersCards)
        {


            this.name = name;
            this.playersCards = playersCards;
        }

         
        /// <summary>
        /// A to string method to display the name of the player
        /// </summary>
        /// <returns> the string of the player name</returns>
        public override string ToString()
        {
            return name;
        }

       
    }

}
