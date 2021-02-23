using System;
using System.Collections.Generic;
using System.Text;

namespace Tarneeb_Game_group3
{
    class Team
    {
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public int score { get; set; }

        public Team(Player player1,Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.score = 0;
        }

        public Team()
        {
            this.player1 = null;
            this.player2 = null;
        }
    }
}
