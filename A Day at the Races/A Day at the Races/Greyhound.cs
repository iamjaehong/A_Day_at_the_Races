using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races
{
    public class Greyhound
    {
        public string Name;
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer;

        public bool Run()
        {
            MyPictureBox.Left += Randomizer.Next(1, 4);
            Location = MyPictureBox.Left;
            if (Location >= 535)
                return true;
            else
                return false;
        }

        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = 10;
        }
    }
}
