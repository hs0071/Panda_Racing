using System;
using System.Windows.Forms;

namespace Panda_Racing
{
    public partial class RacingForm : Form
    {
        Panda[] Pandas = new Panda[4];

        Factory pFactory = new Factory();
        Punter[] punters = new Punter[3];

        public RacingForm()
        {
            InitializeComponent();
            SetupRaceTrack();
        }

        private void SetupRaceTrack()
        {

            Panda.StartingPosition1 = Panda1.Right - racetrack.Left;
            Panda.RacetrackLength1 = racetrack.Size.Width - 70; //fixing length of race - till finish line

            Pandas[0] = new Panda() { PandaPictureBox = Panda1 };
            Pandas[1] = new Panda() { PandaPictureBox = Panda2 };
            Pandas[2] = new Panda() { PandaPictureBox = Panda3 };
            Pandas[3] = new Panda() { PandaPictureBox = Panda4 };

            punters[0] = pFactory.getPunter("Jass", MaximumBet, JassBet); //getting Jass object from factory class
            punters[1] = pFactory.getPunter("Aman", MaximumBet, AmanBet); //getting Aman object from factory class
            punters[2] = pFactory.getPunter("Harjot", MaximumBet, HarjotBet); //getting Harjot object from factory class


            foreach (Punter punter in punters)
            {
                punter.UpdateLabels();
            }
        }

        private void JassButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[0].Cash);
        }

        private void AmanButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[1].Cash);
        }

        private void HarjotButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[2].Cash);
        }

        private void setMaximumBetTextLabel(int Cash)
        {
            MaximumBet.Text = String.Format("Maximum Bet: ${0}", Cash);
        }

        // setting the bet for each Punter and updating labels respectively
        private void Bets_Click(object sender, EventArgs e)
        {
            int PunterNum = 0;

            if (JassButton.Checked)
            {
                PunterNum = 0;
            }
            if (AmanRButton.Checked)
            {
                PunterNum = 1;
            }
            if (HarjotRButton.Checked)
            {
                PunterNum = 2;
            }

            punters[PunterNum].PlaceBet((int)BettingAmount.Value, (int)PandaNumber.Value);
            punters[PunterNum].UpdateLabels();
        }

        private void race_Click(object sender, EventArgs e)
        {
            bool NoWinner = true;
            int winningPanda;
            race.Enabled = false; //disable start race button

            while (NoWinner)
            { // loop until we have a winner
                Application.DoEvents();
                for (int i = 0; i < Pandas.Length; i++)
                {
                    if (Panda.Run(Pandas[i]))
                    {
                        winningPanda = i + 1;
                        NoWinner = false;
                        MessageBox.Show("We have a winner - Panda #" + winningPanda);
                        foreach (Punter punter in punters)
                        {
                            if (punter.bet != null)
                            {
                                punter.Collect(winningPanda); //give double amount to all who've won or deduce betted amount
                                punter.bet = null;
                                punter.UpdateLabels();
                            }
                        }
                        foreach (Panda Panda in Pandas)
                        {
                            Panda.TakeStartingPosition();
                        }
                        break;
                    }
                }
            }
            if (punters[0].busted && punters[1].busted && punters[2].busted)
            {  //stop punters from betting if they run out of cash
                String message = "Do you want to Play Again?";
                String title = "GAME OVER!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    SetupRaceTrack(); //restart game
                }
                else
                {
                    this.Close();
                }

            }
            race.Enabled = true; //enable race button 
        }

    }
}
