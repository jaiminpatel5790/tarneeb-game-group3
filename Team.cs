using System;
using System.Collections.Generic;
using System.Text;

namespace Tarneeb_Game_group3
{
    /// <summary>
    /// This is the team class to make the team object containing each player
    /// </summary>
    class Team
    {
        //Player object 1
        public Player player1 { get; set; }

        //PLayer object 2
        public Player player2 { get; set; }

        //Score attribute to store the score for that team
        public int score { get; set; }

        // A constructor to make a team consisting of 2 players
        public Team(Player player1,Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.score = 0;
        }

        // Default constructor
        public Team()
        {
            this.player1 = null;
            this.player2 = null;
        }

        
    }
}
