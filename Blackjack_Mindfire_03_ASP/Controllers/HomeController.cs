using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blackjack_Mindfire_03_ASP.Models;
using Blackjack_Mindfire_03_ASP.Models.GameElements;
using Blackjack_Mindfire_03_ASP.Models.Participants;

namespace Blackjack_Mindfire_03_ASP.Controllers
{
    public class HomeController : Controller
    {
        UserInterface gameInterface;
        public HomeController(UserInterface userInterface)
        {
            gameInterface = userInterface;
        }
        [HttpGet]
        public ViewResult Index() => View(new AmountPlayers());
        [HttpPost]
        public ViewResult Index(AmountPlayers amtPlayers)
        {
            int amt = 0;
            if ( !int.TryParse(amtPlayers.Amt, out amt) || string.IsNullOrEmpty(amtPlayers.Amt) || (amt < 1 || amt > 9))
            {
                ModelState.AddModelError(nameof(amtPlayers.Amt),
                    "Please enter an amount of players between 1-9");
            }
            if (ModelState.IsValid)
            {
                gameInterface.InitializeInterface(amt);
                gameInterface.dealer.InitialDeal(gameInterface.players);
                return View("PlayGame", gameInterface);
            }
            else
            {
                return View();
            }
        }
        // Helps handle asynch calls to my 'Players' View Component
        [HttpPost]
        public IActionResult GetHitHold(string action, string playerName)
        {
            return ViewComponent("Players", new { action, playerName });
        }

        public ViewResult Final()
        {
            return View("FinalDisplay", gameInterface);
        }
    }
}
