using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blackjack_Mindfire_03_ASP.Models
{
    public class AmountPlayers
    {
        public AmountPlayers()
        {
            Amt = "1";
        }
        public AmountPlayers(string amt)
        {
            Amt = amt;
        }
        public string Amt
        {
            get;
            set;
        }
    }
}
