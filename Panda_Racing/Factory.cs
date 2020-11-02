using System;
using System.Windows.Forms;

namespace Panda_Racing
{
    public class Factory
    {
        public Punter getPunter(String Name, Label MaximumBet, Label bet)
        {
            Punter p;
            switch (Name.ToLower())
            {
                case "jass":
                    p = new Jass(null, MaximumBet, 50, bet);
                    break;

                case "aman":
                    p = new Aman(null, MaximumBet, 50, bet);
                    break;

                case "Harjot":
                    p = new Harjot(null, MaximumBet, 50, bet);
                    break;

                default:
                    p = null;
                    break;
            }
            p.setPunterName();
            return p;
        }
    }
}
