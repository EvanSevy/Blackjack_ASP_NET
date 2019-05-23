using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blackjack_Mindfire_03_ASP.Models.Participants;
using Blackjack_Mindfire_03_ASP.Models.GameElements;

namespace Blackjack_Mindfire_03_ASP.Models
{
    public class UserInterface
    {
        protected const int AMT_DECKS = 1;
        public Dealer dealer;
        public List<Player> players;
        public Scorer scorer;
        public UserInterface()
        {
            InitializeInterface(3);
        }
        public void InitializeInterface(int amtPlayers)
        {
            players = new List<Player>();
            dealer = new Dealer(AMT_DECKS);
            for (int i = 0; i < amtPlayers; i++)
            {
                //players.Add(new Player(($"'{i + 1}'").ToString()));
                players.Add(new Player(($"{i + 1}").ToString()));
            }
            scorer = new Scorer(players, dealer);
        }
        public virtual void StartGame() { }
    }
}
