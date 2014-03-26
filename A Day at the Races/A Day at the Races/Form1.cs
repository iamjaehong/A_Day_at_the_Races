using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    public partial class Form1 : Form
    {
        Random MyRandomizer = new Random();
        Greyhound[] greyhound = new Greyhound[4];
        Guy[] guy = new Guy[3];

        public Form1()
        {
            InitializeComponent();
            guy[0] = new Guy() { Cash = 50, Name = "Joe", MyRadioButton = rBtnJoe, MyLabel = lblJoeBet, MyBet = null };
            guy[1] = new Guy() { Cash = 75, Name = "Bob", MyRadioButton = rBtnBob, MyLabel = lblBobBet, MyBet = null };
            guy[2] = new Guy() { Cash = 45, Name = "Al", MyRadioButton = rBtnAl, MyLabel = lblAlBet, MyBet = null };

            for (int i = 0; i < guy.Length; i++)
            {
                guy[i].UpdateLabels();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int winningDog;
            for (int i = 0; i < greyhound.Length; i++)
            {
                greyhound[i].Run();
                if (greyhound[i].Run())
                {
                    winningDog = i + 1;
                    timer1.Stop();
                    MessageBox.Show("The " + greyhound[i].Name + " has won the race!");
                    for (int k = 0; k < guy.Length; k++)
                    {
                        if (guy[k].MyBet != null)
                        {
                            guy[k].Collect(winningDog);
                            guy[k].ClearBet();
                            guy[k].UpdateLabels();
                        }
                    }
                    for (int j = 0; j < greyhound.Length; j++)
                    {
                        greyhound[j].TakeStartingPosition();
                    }
                    groupBox1.Enabled = true;
                    this.UseWaitCursor = false;
                    break;
                }
            }
        }
        private void btnRace_Click(object sender, EventArgs e)
        {
            greyhound[0] = new Greyhound()
            {
                MyPictureBox = pictureDog1,
                StartingPosition = pictureDog1.Left,
                RacetrackLength = pictureRaceTrack.Width,
                Randomizer = MyRandomizer,
                Location = pictureRaceTrack.Width - pictureDog1.Left,
                Name = "Dog1"
            };
            greyhound[1] = new Greyhound()
            {
                MyPictureBox = pictureDog2,
                StartingPosition = pictureDog2.Left,
                RacetrackLength = pictureRaceTrack.Width - pictureDog2.Width,
                Randomizer = MyRandomizer,
                Location = pictureRaceTrack.Width - pictureDog2.Left,
                Name = "Dog2"
            };
            greyhound[2] = new Greyhound()
            {
                MyPictureBox = pictureDog3,
                StartingPosition = pictureDog3.Left,
                RacetrackLength = pictureRaceTrack.Width - pictureDog3.Width,
                Randomizer = MyRandomizer,
                Location = pictureRaceTrack.Width - pictureDog3.Left,
                Name = "Dog3"
            };
            greyhound[3] = new Greyhound()
            {
                MyPictureBox = pictureDog4,
                StartingPosition = pictureDog4.Left,
                RacetrackLength = pictureRaceTrack.Width - pictureDog4.Width,
                Randomizer = MyRandomizer,
                Location = pictureRaceTrack.Width - pictureDog4.Left,
                Name = "Dog4"
            };
            timer1.Start();
            groupBox1.Enabled = false;
            this.UseWaitCursor = true;
        }
        private void btnBets_Click(object sender, EventArgs e)
        {
            if (rBtnJoe.Checked)
            {
                if (guy[0].PlaceBet((int)nudBets.Value, (int)nudDogNumber.Value))
                    lblJoeBet.Text = guy[0].MyBet.GetDescription();
            }
            if (rBtnBob.Checked)
            {
                if (guy[1].PlaceBet((int)nudBets.Value, (int)nudDogNumber.Value))
                    lblBobBet.Text = guy[1].MyBet.GetDescription();
            }
            if (rBtnAl.Checked)
            {
                if (guy[2].PlaceBet((int)nudBets.Value, (int)nudDogNumber.Value))
                    lblAlBet.Text = guy[2].MyBet.GetDescription();
            }
        }
    }
}
