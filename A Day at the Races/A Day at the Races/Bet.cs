using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Day_at_the_Races
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            string description = "";
            if (this.Amount >= 5)
                description = Bettor.Name + " bets " + Amount + " bucks on Dog #" + Dog;
            else if (this.Amount == 0)
                description = Bettor.Name + "hasn't placed a bet";
            return description;
        }

        public int PayOut(int Winner)
        {
            if (Winner == Dog)
                return Amount += Amount;
            else
                return -1 * Amount;
        }
    }
}
