using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Cards
{
    internal abstract class DefenseCard : Card
    {
        private int def;
        
        public int Def { get { return def; } set { def = value; } }

        public override int SetDefense(int DefMultiplier, int FragilityMultiplier)
        {
            return (def * DefMultiplier) * FragilityMultiplier;
        }

        public DefenseCard()
        {
            this.Type = "Defense";
        }
    }
}
