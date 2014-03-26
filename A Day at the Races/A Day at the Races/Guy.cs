using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MyRadioButton.Text = this.Name + " has " + this.Cash + " bucks";
            MyLabel.Text = this.Name + " hasn't placed a bet!";
        }

        public void ClearBet()
        {
            MyBet = null;
        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            if (this.Cash >= 5)
            {
                MyBet = new Bet() { Amount = BetAmount, Dog = DogToWin, Bettor = this };
                return true;
            }
            else
            {
                MessageBox.Show(this.Name + " has not enough money to bet!");
                return false;
            }
        }

        public void Collect(int Winner)
        {
            this.Cash += MyBet.PayOut(Winner);
            this.ClearBet();
            this.UpdateLabels();
        }
    }
}
