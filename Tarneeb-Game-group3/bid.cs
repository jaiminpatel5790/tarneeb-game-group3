using System;
using System.Collections.Generic;
using System.Text;

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
    }

}
