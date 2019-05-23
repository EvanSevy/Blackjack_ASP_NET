using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackjack_Mindfire_03_ASP.Models.Participants
{
    public class Player : IParticipant
    {
        public Player(String playerName) : base(playerName)
        {
        }
        public bool Hold
        {
            get;
            set;
        } = false;
    }
}
