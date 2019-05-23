using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blackjack_Mindfire_03_ASP.Models;
using Blackjack_Mindfire_03_ASP.Models.Participants;

using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace Blackjack_Mindfire_03_ASP.Components
{
    public class Players : ViewComponent
    {
        private UserInterface gameInterface;
        public Players(UserInterface userInterface)
        {
            gameInterface = userInterface;
        }
        // Handles asynchronous calls and returns a partial view that cooresponds to the kind of interaction that was enacted
        // 'Hit', 'Hold' or just plain 'display'
        public IViewComponentResult Invoke(String action, String playerName)
        {
            Models.Participants.Player player = gameInterface.players.Where(p => p.PlayerName.Equals(playerName)).First();
            if (action.Equals("display"))
            {
                return View("Display", player);
            }
            else if (action.Equals("hit"))
            {
                player.Hit(gameInterface.dealer);
                if (player.Bust == true)
                {
                    if (AllHoldOrBust(gameInterface.players))
                    {
                        ResolveGame();
                    }
                    return View("BustDisplay", player);
                }
                return View("Display", player);
            }
            else if (action.Equals("hold"))
            {
                player.Hold = true;
                if (AllHoldOrBust(gameInterface.players))
                {
                    ResolveGame();
                }
                return View("HoldDisplay", player);
            }
            return View("Display", player);  // Maybe make this a 404
        }

        public bool AllHoldOrBust(List<Models.Participants.Player> players)
        {
            if (players.All(p => p.Hold == true || p.Bust == true))
                return true;
            else
                return false;
        }
        public void ResolveGame()
        {
            gameInterface.dealer.ResolveDealerRound(gameInterface.players);
            gameInterface.scorer.ResolvePoints();
        }
    }
}
