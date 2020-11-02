using System;
using System.Drawing;
using System.Windows.Forms;

namespace Panda_Racing
{
    public class Panda
    {
        private static int StartingPosition;
        private static int RacetrackLength;
        public PictureBox PandaPictureBox = null;
        public int Location = 0;
        public static Random MyRandom = new Random(); //declared random object as static to avoid same random number

        public static int StartingPosition1 { get => StartingPosition; set => StartingPosition = value; }
        public static int RacetrackLength1 { get => RacetrackLength; set => RacetrackLength = value; }

        // generation across all Panda objects

        public static bool Run(Panda obj)
        {
            int distance = MyRandom.Next(2, 6);
            if (obj.PandaPictureBox != null)
                obj.MovePandaPictureBox(distance);

            obj.Location += distance;
            if (obj.Location >= (RacetrackLength1 - StartingPosition1))
            {
                return true;
            }
            return false;
        }

        public void TakeStartingPosition()
        {
            MovePandaPictureBox(-Location); //reset location to -ve distance ie. to starting point
            Location = 0;

        }

        public void MovePandaPictureBox(int distance)
        {
            Point p = PandaPictureBox.Location;
            p.X += distance;
            PandaPictureBox.Location = p; //move Panda in x-axis
        }
    }
}
