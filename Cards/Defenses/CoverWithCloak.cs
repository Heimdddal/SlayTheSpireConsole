using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Cards.Defenses
{
    internal class CoverWithCloak : DefenseCard
    {
        public CoverWithCloak()
        {
            Name = " Укрыться плащом";
            EnergyCost = 1;
            Def = 4;
        }
    }
}
