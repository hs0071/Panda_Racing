using System;

namespace Panda_Racing
{
    public class Bet
    {
        public int Amount;
        public int PandaNum;
        public Punter Bettor;

        public Bet(int Amount, int PandaNum, Punter Bettor)
        {
            this.Amount = Amount;
            this.PandaNum = PandaNum;
            this.Bettor = Bettor;
        }

        public string GetDescription()
        {
            string description = "";

            if (Amount > 0)
            {
                description = String.Format("{0} bets {1} on Panda #{2}",
                    Bettor.Name, Amount, PandaNum);
            }
            else
            {
                description = String.Format("{0} hasn't placed any bets",
                    Bettor.Name);
            }
            return description;
        }

        public int Pay(int Winner)
        {
            if (PandaNum == Winner)
            {
                return Amount;
            }
            return -Amount;
        }
    }
}
